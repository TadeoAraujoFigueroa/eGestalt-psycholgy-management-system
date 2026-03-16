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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
namespace TRABAJO_FINAL
{
    public partial class FormReporteSesiones : Form
    {
        BLLPaciente bllPaciente;
        BEPaciente bePaciente;

        BLLPsicologo bllPsicologo;
        BEPsicologo bePsicologo;

        BLLSesion bllSesion;
        BESesion beSesion;

        ServicioDeInformes sInformes;
        BEInforme beInforme;

        List<BEPsicologo> bePsicologoList;
        List<BEPaciente> bePacienteList;

        List<String> nombres_psico;
        List<String> nombres_paciente;
        public FormReporteSesiones()
        {
            try
            {
                InitializeComponent();

                //Inicializamos las BLL's
                bllPaciente = new BLLPaciente();
                bllPsicologo = new BLLPsicologo();
                bllSesion = new BLLSesion();
                sInformes = new ServicioDeInformes();

                nombres_psico = new List<String>();
                nombres_paciente = new List<String>();

                bePsicologoList = new List<BEPsicologo>();
                bePacienteList = new List<BEPaciente>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void FormReporteSesiones_Load(object sender, EventArgs e)
        {
            try 
            {
                //Generamos las listas con la información respectiva
                nombres_psico.Add("Todos");
                nombres_psico.AddRange(bllPsicologo.ListarTodo().Select(x => x.ToString()).ToList());

                nombres_paciente.Add("Todos");
                nombres_paciente.AddRange(bllPaciente.ListarTodo().Select(x => x.ToString()).ToList());

                cb_paciente.DataSource = nombres_paciente;
                cb_psicologo.DataSource = nombres_psico;

                instrucciones.SelectionFont =
                    new Font(instrucciones.Font, FontStyle.Bold | FontStyle.Italic);
                instrucciones.SelectedText = "Instrucciones de uso";

                instrucciones.SelectionFont = new Font(instrucciones.Font, FontStyle.Regular);
                instrucciones.AppendText("\n- Para generar un informe general, de todas las sesiones realizadas por todos los psicólogos, seleccione 'Todos' " +
                    "en el menú desplegable de psicólogos y tilde la opción 'Informe General', seleccionando el tipo de sesiones que quiere obtener (Realizadas, No Abonadas, Cupones Emitidos). \n\n" +
                    "-Para generar un informe general de un único psicólogo, seleccione el nombre del psicólogo y tilde la opción 'Informe General', a demás de seleccionar " +
                    "el tipo de sesión que quiere obtener. \n\n" +
                    "-Para obtener las sesiones realizadas de un psicólogo a un paciente en particular, seleccione el nombre de ambos y tilde el tipo de sesión.");

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
         {
            try
            {
                //Todas las sesiones de un psicólogo con un paciente
                if (cb_paciente.Text != "Todos" && cb_psicologo.Text != "Todos")
                {
                    //Si el informe es personalizado por paciente y psicólogo, no puede ser general
                    check_gral.Checked = false;

                    //Traemos al psicólogo seleccionado
                    bePsicologoList = bllPsicologo.ListarTodo().Where(p => p.ToString() == cb_psicologo.Text).ToList();

                    //Traemos al paciente seleccionado
                    bePacienteList = bllPaciente.ListarTodo().Where(p => p.ToString() == cb_paciente.Text).ToList();

                    foreach (var p in bePsicologoList) 
                    {
                        bePsicologo = p;
                    }

                    foreach (var p in bePacienteList) 
                    {
                        bePaciente = p;
                    }

                    CalcularInformeParticular(bePsicologo, bePaciente);
                   

                }
                //Todas las sesiones realizadas por todos los psicologos (Informe General)
                else if (check_gral.Checked && cb_psicologo.Text == "Todos") 
                {
                    //Si el informe es general, no se filtra por paciente.
                    cb_paciente.SelectedItem = null;

                    bePsicologoList = bllPsicologo.ListarTodo();

                    CalcularInformeGeneral(bePsicologoList);
                }
                //Todas las sesiones de un psicologo con todos sus pacientes
                else if (check_gral.Checked && cb_psicologo.Text != "Todos") 
                {
                    //Si el informe es general, no se filtra por paciente.
                    bePsicologoList = bllPsicologo.ListarTodo().Where(p => p.ToString() == cb_psicologo.Text).ToList();

                    CalcularInformeGeneral(bePsicologoList);
                }
                else 
                {

                    MessageBox.Show("Seleccione correctamente los parámetros");
                }


               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally 
            {
                //Recargamos los datos
                instrucciones.Clear();
                cb_paciente.DataSource = null;
                cb_psicologo.DataSource = null;
                nombres_paciente.Clear();
                nombres_psico.Clear();
                FormReporteSesiones_Load(this, null);
            }
        }

        private void CalcularInformeGeneral(List<BEPsicologo> lista_psicos)
        {
            //Creamos el diccionario que creará los valores del Chart
            Dictionary<string, int> dictSesiones = new Dictionary<string, int>();
            //Contador
            int cantSesiones = 0;
            int total = 0;
            //Acá verificamos el tipo de sesión que se quiere obtener, y contamos la cantidad de sesiones realizadas
            //por cada psicólogo bajo los parámetros establecidos, para luego crear el gráfico con esa información.
            if (rb_cupones.Checked)
            {

                foreach (var p in lista_psicos)
                {

                    //Contamos la cantidad de sesiones que realizó ese psicologo
                    cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == p.DNI && datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha
                    && s.Estado == "Cupón Emitido").Count;

                    if (cantSesiones > 0)
                    {
                        //Creamos el par clave valor en el diccionario
                        dictSesiones.Add(p.ToString(), cantSesiones);

                        //Actualizamos el acumulador
                        total += cantSesiones;

                        //Reiniciamos el contador de sesiones
                        cantSesiones = 0;
                    }

                }

                if (total == 0)
                {
                    MessageBox.Show("No existen sesiones realizadas");
                    return;
                }
                //Llamamos a la función creadora de charts
                CrearChar(dictSesiones, "Cupones Emitidos");
            }
                if (rb_no_abonadas.Checked)
                {
                    foreach (var p in lista_psicos)
                    {

                        //Contamos la cantidad de sesiones que realizó ese psicologo
                        cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == p.DNI && datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha
                        && s.Estado == "No Abonado").Count;

                        if (cantSesiones > 0)
                        {
                            //Creamos el par clave valor en el diccionario
                            dictSesiones.Add(p.ToString(), cantSesiones);

                            //Actualizamos el acumulador
                            total += cantSesiones;

                            //Reiniciamos el contador de sesiones
                            cantSesiones = 0;
                        }

                    }

                    if (total == 0)
                    {
                        MessageBox.Show("No existen sesiones realizadas");
                        return;
                    }
                    //Llamamos a la función creadora de charts
                    CrearChar(dictSesiones, "Sesiones No Abonadas");
                }
                else if (rb_cupones.Checked == false && rb_no_abonadas.Checked == false)
                {
                    foreach (var p in lista_psicos)
                    {

                        //Contamos la cantidad de sesiones que realizó ese psicologo
                        cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == p.DNI && datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha
                        && s.Estado == "Abonado").Count;

                        if (cantSesiones > 0)
                        {
                            //Creamos el par clave valor en el diccionario
                            dictSesiones.Add(p.ToString(), cantSesiones);

                            //Actualizamos el acumulador
                            total += cantSesiones;

                            //Reiniciamos el contador de sesiones
                            cantSesiones = 0;
                        }

                    }

                    if (total == 0)
                    {
                        MessageBox.Show("No existen sesiones realizadas");
                        return;
                    }
                    //Llamamos a la función creadora de charts
                    CrearChar(dictSesiones, "Sesiones Abonadas");
                }
        }
        
        private void CalcularInformeParticular(BEPsicologo bePsicologo, BEPaciente bePaciente) 
        {
            //Creamos el diccionario que creará los valores del Chart
            Dictionary<string, int> dictSesiones = new Dictionary<string, int>();

    

            if (rb_cupones.Checked)
            {

                //Contamos la cantidad de sesiones que realizó ese psicologo
                int cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == bePsicologo.DNI && s.PacienteAsociado.DNI == bePaciente.DNI &&
                datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha && s.Estado == "Cupón Emitido").Count;

                if (cantSesiones == 0)
                {
                    MessageBox.Show("No existen sesiones realizadas bajo los parámetros establecidos");
                    return;
                }
                //Creamos el par clave valor en el diccionario
                dictSesiones.Add(bePaciente.ToString(), cantSesiones);
                //Llamamos a la función creadora de charts
                CrearChar(dictSesiones, $"Cupones Emitidos psicologo {bePsicologo.ToString()} a {bePaciente.ToString()}");
            }
            if (rb_no_abonadas.Checked)
            {

                //Contamos la cantidad de sesiones que realizó ese psicologo
                int cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == bePsicologo.DNI && s.PacienteAsociado.DNI == bePaciente.DNI &&
                datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha && s.Estado == "No Abonado").Count;

                if (cantSesiones == 0)
                {
                    MessageBox.Show("No existen sesiones realizadas bajo los parámetros establecidos");
                    return;
                }
                //Creamos el par clave valor en el diccionario
                dictSesiones.Add(bePaciente.ToString(), cantSesiones);
                //Llamamos a la función creadora de charts
                CrearChar(dictSesiones, $"Sesiones No Abonadas psicologo {bePsicologo.ToString()} a {bePaciente.ToString()}");


            }
            else if (rb_no_abonadas.Checked == false && rb_cupones.Checked == false) 
            {
                if(bePaciente != null) 
                {
                    //Contamos la cantidad de sesiones que realizó ese psicologo
                    int cantSesiones = bllSesion.ListarTodo().FindAll(s => s.PsicologoAsociado.DNI == bePsicologo.DNI && s.PacienteAsociado.DNI == bePaciente.DNI &&
                    datePicker.Value <= s.Fecha && datePicker2.Value >= s.Fecha && s.Estado == "Abonado").Count;

                    if (cantSesiones == 0)
                    {
                        MessageBox.Show("No existen sesiones realizadas bajo los parámetros establecidos");
                        return;
                    }
                    //Creamos el par clave valor en el diccionario
                    dictSesiones.Add(bePaciente.ToString(), cantSesiones);
                    //Llamamos a la función creadora de charts
                    CrearChar(dictSesiones, $"Sesiones Abonadas psicologo {bePsicologo.ToString()} a {bePaciente.ToString()}");
                }
           
            }
        }

        private void CrearChar(Dictionary<string, int> dictSesiones, string titulo_serie)
        {
            // Limpiamos
            chart_uno.ChartAreas.Clear();
            chart_uno.Series.Clear();
            chart_uno.Titles.Clear();
            chart_uno.Legends.Clear();

            // Creamos el área del gráfico
            ChartArea area = new ChartArea();
            area.AxisX.Title = "Psicólogos";
            area.AxisY.Title = "Cantidad de sesiones";

            // Mejoramos la legibilidad
            area.AxisX.LabelStyle.Angle = -45; // Etiquetas inclinadas
            area.AxisX.Interval = 1; // Muestra todas las etiquetas
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisX.MajorGrid.Enabled = false; // Quitamos líneas innecesarias
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            chart_uno.ChartAreas.Add(area);

            // Creamos la serie
            Series serie = new Series(titulo_serie);
            serie.ChartType = SeriesChartType.Column;
            serie.Color = Color.MediumSeaGreen;
            serie.BorderWidth = 2;
            serie.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
            serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            serie.LabelForeColor = Color.DarkSlateGray;

            // Enlazamos los datos
            serie.Points.DataBindXY(dictSesiones.Keys, dictSesiones.Values);

            // Agregamos la serie
            chart_uno.Series.Add(serie);

            // Creamos el título
            Title titulo = new Title
            {
                Text = $"Cantidad de sesiones por psicólogo",
                ForeColor = Color.Teal,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            chart_uno.Titles.Add(titulo);

            // Agregamos una leyenda
            Legend leyenda = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.DimGray
            };
            chart_uno.Legends.Add(leyenda);

            // Aplicamos una paleta de colores agradable
            chart_uno.Palette = ChartColorPalette.SeaGreen;
        }

        private void btn_validacion_Click(object sender, EventArgs e)
        {
            beInforme = new BEInforme();
            beInforme.Codigo = -1;
            beInforme.Estado = "Generado";
            beInforme.FechaGeneracion = DateTime.Now;
            beInforme.Observaciones = $"Informe de sesiones generado el {DateTime.Now.ToShortDateString()} por el usuario actual.";

            //Convertimos el gráfico en un array de bytes para guardarlo en el informe
            using (MemoryStream ms = new MemoryStream())
            {
                chart_uno.SaveImage(ms, ChartImageFormat.Png);
                beInforme.ContenidoBytes = ms.ToArray();
            }

            if (sInformes.GuardarInformeDeSesiones(beInforme)) 
            {
                MessageBox.Show("Informe guardado a la espera de validación.");
            }
            

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFile = new SaveFileDialog()) 
                {
                    saveFile.Title = "Guardar gráfico como imagen";
                    saveFile.Filter = "Imagen PNG (*.png)|*.png|Imagen JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
                    saveFile.DefaultExt = "png";
                    saveFile.FileName = "grafico";

                    if(saveFile.ShowDialog() == DialogResult.OK) 
                    {
                        ChartImageFormat formato = ChartImageFormat.Png;
                        switch (Path.GetExtension(saveFile.FileName).ToLower())
                        {
                            case ".jpg":
                            case "-jpeg":
                                formato = ChartImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                formato = ChartImageFormat.Bmp;
                                break;
                        }
                        chart_uno.SaveImage(saveFile.FileName, formato);
                        MessageBox.Show("Gráfico guardado con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void chart_uno_Click(object sender, EventArgs e)
        {

        }
    }
}
