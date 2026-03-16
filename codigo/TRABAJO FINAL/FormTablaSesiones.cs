using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormTablaSesiones : Form
    {
        //Definimos las variables a utilizar
        private DateTime fecha;

        private bool _actualizando;
        BLLSesion bllSesion;

        BESesion beSesion;

        List<int> horasExistentes;

        List<BESesion> listaAmostrar;
        private bool _cargando;
        public FormTablaSesiones()
        {
            InitializeComponent();
            bllSesion = new BLLSesion();
            listaAmostrar = new List<BESesion> ();
        }

        private void FormTablaSesiones_Load(object sender, EventArgs e)
        {
            try
            {
                //Guardamos la fecha y hora para filtrar los turnos
                fecha = datePicker.Value;
                //Inicializamos la grilla con los turnos del día actual y la hora seleccionada
                listaAmostrar = bllSesion.ListarTodo();


                if (listaAmostrar.Count() > 0 ) 
                {
                    _cargando = true;

                    cb_estado.DataSource = listaAmostrar.Select(t => t.Estado).Distinct().ToList();

                    _cargando = false;

                    var ini = datePicker.Value.Date;
                    var fin = datePicker2.Value.Date;
                    var estado = cb_estado.Text;

                    var filtradas = listaAmostrar.Where(s =>
                        s.Fecha.Date >= ini &&
                        s.Fecha.Date <= fin &&
                        (s.Estado ?? "").Trim() == estado
                    ).ToList();

                    // evita rebinding raro
                    dgvSesiones.DataSource = null;
                    dgvSesiones.DataSource = filtradas;
                    dgvSesiones.Columns["Codigo"].Visible = false;
                }
                else 
                {
                    MessageBox.Show("No hay sesiones que mostrar");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
 
            

        }

        private void ActualizarGrilla() 

        {
            if (_actualizando) return;
            _actualizando = true;

            try
            {
                var ini = datePicker.Value.Date;
                var fin = datePicker2.Value.Date;
                var estado = cb_estado.Text;

                var filtradas = listaAmostrar.Where(s =>
                       s.Fecha.Date >= ini &&
                       s.Fecha.Date <= fin &&
                       (s.Estado ?? "").Trim() == estado
                   ).ToList();

                // evita rebinding raro
                dgvSesiones.DataSource = null;
                dgvSesiones.DataSource = filtradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _actualizando = false;
            }
        }
           
        

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void datePicker2_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void cb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si es la primera vez, retornamos para evitar errores
            if (_cargando) return;
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSesiones.SelectedRows.Count > 0) 
                {
                    var item = dgvSesiones.CurrentRow != null
                                ? dgvSesiones.CurrentRow.DataBoundItem
                                : null;

                    if (item == null || !(item is BESesion))
                    {
                        MessageBox.Show("Debe seleccionar una sesión válida.");
                        return;
                    }

                    beSesion = (BESesion)item;

                    Form form_modificacion = new FormModificarSesion(beSesion);

                    //Inicializamos la grilla con las sesiones actualizadas
                    listaAmostrar = bllSesion.ListarTodo();

                    form_modificacion.ShowDialog();

                    ActualizarGrilla();
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
