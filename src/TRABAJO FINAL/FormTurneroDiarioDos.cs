using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormTurneroDiarioDos : Form
    {
        private DateTime fechaSeleccionada;

        BLLTurno bllTurno;

        BLLDatos bllDatos;
   
        public FormTurneroDiarioDos(DateTime fecha)
        {
            try
            {
                InitializeComponent();

                bllTurno = new BLLTurno();

                fechaSeleccionada = fecha;

                bllDatos = new BLLDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void FormTurneroDiarioDos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"Turnos del {fechaSeleccionada:dd/MM/yyyy}";
                CargarTurnosGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        private void CargarTurnosGrilla()
        {
            try
            {
                

                //Definimos los horarios de atención
                List<TimeSpan> horarios = Enumerable.Range(9, 9)
                                                   .Select(h => new TimeSpan(h, 0, 0))
                                                   .ToList();

                string[] salas = bllDatos.retornarSalas().Select(s => s.Nombre).ToArray();

                //Creamos de forma dinámica un data table que le da la estructura al DGV
                DataTable tablaTurnos = new DataTable();

                tablaTurnos.Columns.Add("Horario");

                //Creamos las columnas a partir de las salas
                foreach (string sala in salas)
                {
                    tablaTurnos.Columns.Add(sala);
                }

                //Creamos las filas a partir de los horarios
                foreach (TimeSpan horario in horarios)
                {
                    DataRow fila = tablaTurnos.NewRow();

                    fila["Horario"] = horario.ToString(@"hh\:mm");

                    foreach (string sala in salas)
                    {
                        fila[sala] = "LIBRE";
                    }
                    tablaTurnos.Rows.Add(fila);
                }

                //Traemos los turnos existentes en la fecha seleccionada, siempre y cuando su estado sea el de programado
                var turnos = bllTurno.ListarPorFecha(fechaSeleccionada).Where(x => x.Estado == "Programado" || x.Estado == "Realizado").ToList();
                //Guardamos los turnos en el data table

                if (turnos.Count != 0)
                {
                    foreach (var t in turnos)
                    {
                        string salaColumna = t.Sala;
                        string horarioFila = "";
                        if (t.Hora == 9)
                        {
                            horarioFila = "09:00";
                        }
                        else
                        {
                            horarioFila = $"{t.Hora}:00";
                        }


                        //Buscamos la fila correspondiente al horario
                        DataRow[] filas = tablaTurnos.Select($"Horario = '{horarioFila}'");

                        if (filas.Length > 0)
                        {
                            //Asignamos el turno a la celda correspondiente
                            filas[0][salaColumna] = $"Paciente: {t.PacienteAsociado.Apellido}, {t.PacienteAsociado.Nombre}\nPsicólogo: {t.PsicologoAsociado.Apellido},{t.PsicologoAsociado.Nombre}";
                        }
                    }
                }


                //Asignamos la tabla al DataGridView
                dgvTurnero.DataSource = tablaTurnos;


                //Establecemos el alto de las filas
                foreach (DataGridViewRow fila in dgvTurnero.Rows)
                {

                    fila.Height = 100;
                }

                //Seteamos los colores de las celdas libres y las celdas ocupadas
                foreach (DataGridViewRow row in dgvTurnero.Rows)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        var cellValue = row.Cells[i].Value;

                        if (cellValue != null && cellValue.ToString() != "LIBRE")
                        {
                            row.Cells[i].Style.BackColor = Color.LightSkyBlue; // ocupado
                        }
                        else
                        {

                            row.Cells[i].Style.BackColor = Color.LightGreen; // libre
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }
        private void dgvTurnero_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Guardamos el horario y sala seleccionado
                string sala = dgvTurnero.Columns[e.ColumnIndex].Name;
                int hora = int.Parse(dgvTurnero.Rows[e.RowIndex].Cells["Horario"].Value.ToString().Split(':')[0]);

                if (dgvTurnero.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "LIBRE")
                {
                    //Guardamos el turno existente en un objeto turno
                    BETurno turnoExistente = bllTurno.ListarPorFecha(fechaSeleccionada)
                        .First(t => t.Sala == sala && t.Hora == hora && t.Estado == "Programado" || t.Sala == sala && t.Hora == hora && t.Estado == "Realizado");

                    //Si el turno existe, abrimos el formulario de estado del turno
                    if (turnoExistente != null) 
                    {
                        FormEstadoTurno formEstadoTurno = new FormEstadoTurno(fechaSeleccionada, turnoExistente);
                        formEstadoTurno.ShowDialog();
                        //Luego de cerrar el formulario, recargamos la grilla para reflejar los cambios si existen
                        CargarTurnosGrilla();
                        return;
                    }
                }

                string nombreDia = fechaSeleccionada.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
                nombreDia = char.ToUpper(nombreDia[0]) + nombreDia.Substring(1); // Capitalizamos la primera letra
                                                                                 //Abrimos el formulario para crear el turno
                FormCrearTurno formCrearTurno = new FormCrearTurno(fechaSeleccionada, hora, sala, nombreDia);
                formCrearTurno.ShowDialog();
                CargarTurnosGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }
        private void dgvTurnero_CellMouseMove_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string valor = dgvTurnero.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    dgvTurnero.Cursor = (valor == "LIBRE") ? Cursors.Hand : Cursors.UpArrow;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        #region "FUNCIONES NO UTILIZADAS"
        private void dgvTurnero_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string valor = dgvTurnero.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                dgvTurnero.Cursor = (valor == "LIBRE") ? Cursors.Hand : Cursors.Default;
            }
        }
        private void dgvTurnero_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
         

        }

        private void lbFecha_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTurnero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dgvTurnero_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        
        }



        #endregion

 
    }
}
