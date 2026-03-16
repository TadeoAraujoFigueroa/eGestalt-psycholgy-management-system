using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using BE;
using Xceed.Pdf.Layout.Shape;

namespace TRABAJO_FINAL
{
    public partial class FormDashboard : Form
    {
        //Traemos todas las BLL's que nos propician los datos
        BLLPsicologo bllPsico;
        BLLPaciente bllPaciente;
        BLLSalario bllSalario;
        BLLTurno bllTurno;
        BLLSesion bllSesion;

        DateTime inicioSemestreAnterior;
        DateTime finSemestreAnterior;
        public FormDashboard()
        {
            try
            {
                InitializeComponent();

                //Instanciamos las BLL
                bllPsico = new BLLPsicologo();
                bllPaciente = new BLLPaciente();
                bllTurno = new BLLTurno();
                bllSesion = new BLLSesion();
                bllSalario = new BLLSalario();


                //Calculamos las fechas de inicio y fin del semestre anterior para utilizarlas después
                //Esto significa que el semestre actual es el segundo (entre Julio y Diciembre)
                if (DateTime.Now.Month > 6 && DateTime.Now.Month <= 12)
                {
                    inicioSemestreAnterior = new DateTime((DateTime.Now.Year), 01, 01);
                    finSemestreAnterior = new DateTime((DateTime.Now.Year), 06, 30);
                }
                //Esto significa que el semestre actual es el primero (entre Enero y Junio)
                else
                {
                    inicioSemestreAnterior = new DateTime((DateTime.Now.Year - 1), 07, 01);
                    finSemestreAnterior = new DateTime((DateTime.Now.Year - 1), 12, 31);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Falla al inicializar componentes\n{ex.Message}");
            }
            
            
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargamos los charts con los datos del último mes por defecto, al cargar el form
                //Por eso colocamos -30 días
                DefinirChartPacientesA(DateTime.Now.AddDays(-30), DateTime.Now);
                DefinirChartPsicologos(DateTime.Now.AddDays(-30), DateTime.Now);
                DefinirChartSesiones(DateTime.Now.AddDays(-30), DateTime.Now);
                DefinirChartTurnos(DateTime.Now.AddDays(-30), DateTime.Now);
                DefinirChartFinanzas(DateTime.Now.AddDays(-30), DateTime.Now);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Falla al cargar DashBoard\n{ex.ToString()}");
            }
            

        }


        private void DefinirChartPacientesA(DateTime i, DateTime f) 
        {
            try
            {
                //Seteamos el inicio y el final del período de datos a mostrar
                DateTime inicio = i;
                DateTime final = f;

                chart_cant_usuarios.ChartAreas.Clear();
                chart_cant_usuarios.Series.Clear();
                chart_cant_usuarios.Titles.Clear();
                chart_cant_usuarios.Legends.Clear();

                ChartArea area = new ChartArea();
                area.AxisY.Title = "Cantidad";

                // Mejoramos la legibilidad
                area.AxisX.LabelStyle.Angle = -45; // Etiquetas inclinadas
                area.AxisX.Interval = 1; // Muestra todas las etiquetas
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                area.AxisX.MajorGrid.Enabled = false; // Quitamos líneas innecesarias
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                chart_cant_usuarios.ChartAreas.Add(area);

                // Creamos la serie
                Series serie = new Series("Pacientes Activos");
                serie.ChartType = SeriesChartType.Column;
                serie.Color = Color.MediumSeaGreen;
                serie.BorderWidth = 2;
                serie.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie.LabelForeColor = Color.DarkSlateGray;
                serie.IsXValueIndexed = true;

                //Traigo los pacientes que coincidan con la fecha seleccionada
                var listX = bllPaciente.ListarTodo().Where(u => u.FechaIngreso >= inicio && u.FechaIngreso <= final);
                //Si la fecha de baja es mayor a la fecha final, significa que en ese momento el usuario estaba activo;
                int activos = listX.Count(p => p.Estado == "Activo" || p.FechaDeBaja > final);
                //Si la fecha de baja es menor que el final, se cuenta como discontinuado
                int inactivos = listX.Count(p => p.Estado == "Discontinuado" && p.FechaDeBaja < final);


                serie.Points.AddXY("Pacientes", activos);

                serie["BarLabelStyle"] = "Top";
                serie.SmartLabelStyle.Enabled = false;

                // Creamos la serie
                Series serie_dos = new Series("Pacientes Discontinuados");
                serie_dos.ChartType = SeriesChartType.Column;
                serie_dos.Color = Color.IndianRed;
                serie_dos.BorderWidth = 2;
                serie_dos.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie_dos.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie_dos.LabelForeColor = Color.DarkSlateGray;
                serie_dos.IsXValueIndexed = true;

                serie_dos.Points.AddXY("Pacientes", inactivos);
                serie_dos["BarLabelStyle"] = "Top";
                serie_dos.SmartLabelStyle.Enabled = false;



                chart_cant_usuarios.Series.Add(serie);
                chart_cant_usuarios.Series.Add(serie_dos);
     
          
                // Creamos el título
                Title titulo = new Title
                {
                    Text = $"Pacientes desde el {inicio.ToShortDateString()} hasta {final.ToShortDateString()}",
                    ForeColor = Color.Teal,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                chart_cant_usuarios.Titles.Add(titulo);

                // Agregamos una leyenda
                Legend leyenda = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DimGray
                };
                chart_cant_usuarios.Legends.Add(leyenda);

                // Aplicamos una paleta de colores agradable
                chart_cant_usuarios.Palette = ChartColorPalette.SeaGreen;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }
        private void DefinirChartPsicologos(DateTime i, DateTime f) 
        {

            try
            {
                DateTime inicio = i;
                DateTime final = f;
                chart_cant_psico.ChartAreas.Clear();
                chart_cant_psico.Series.Clear();
                chart_cant_psico.Titles.Clear();
                chart_cant_psico.Legends.Clear();

                ChartArea area = new ChartArea();
                area.AxisY.Title = "Cantidad";

                // Mejoramos la legibilidad
                area.AxisX.LabelStyle.Angle = -45; // Etiquetas inclinadas
                area.AxisX.Interval = 1; // Muestra todas las etiquetas
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                area.AxisX.MajorGrid.Enabled = false; // Quitamos líneas innecesarias
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                chart_cant_psico.ChartAreas.Add(area);

                // Creamos la serie
                Series serie = new Series("Psicologos Activos");
                serie.ChartType = SeriesChartType.Column;
                serie.Color = Color.MediumSeaGreen;
                serie.BorderWidth = 2;
                serie.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie.LabelForeColor = Color.DarkSlateGray;
                serie.IsXValueIndexed = true;

              

                //Seleccionamos usuarios que hayan ingresado a partir de 30 días atrás
                var listX = bllPsico.ListarTodo().Where(u => u.FechaIngreso >= inicio && u.FechaIngreso <= final);

                //Contamos cuantos son activos y cuantos inactivos para armar las series
                int activos = listX.Count(u => u.Estado == true);
                int inactivos = listX.Count(u => u.Estado == false);

                // Enlazamos los datos
                serie.Points.AddXY("Psicologos", activos);


                serie["BarLabelStyle"] = "Top";
                serie.SmartLabelStyle.Enabled = false;

                chart_cant_psico.Series.Add(serie);

                // Creamos la serie
                Series serie_dos = new Series("Psicologos Inactivos");
                serie_dos.ChartType = SeriesChartType.Column;
                serie_dos.Color = Color.IndianRed;
                serie_dos.BorderWidth = 2;
                serie_dos.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie_dos.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie_dos.LabelForeColor = Color.DarkSlateGray;
                serie_dos.IsXValueIndexed = true;

                //Creamos los datos

                serie_dos.Points.AddXY("Psicologos", inactivos);


                serie_dos["BarLabelStyle"] = "Top";
                serie_dos.SmartLabelStyle.Enabled = false;

                chart_cant_psico.Series.Add(serie_dos);
                // Creamos el título
                Title titulo = new Title
                {
                    Text = $"Psicólogos desde el {inicio.ToShortDateString()} hasta el {final.ToShortDateString()}",
                    ForeColor = Color.Teal,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                chart_cant_psico.Titles.Add(titulo);

                // Agregamos una leyenda
                Legend leyenda = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DimGray
                };
                chart_cant_psico.Legends.Add(leyenda);

                // Aplicamos una paleta de colores agradable
                chart_cant_psico.Palette = ChartColorPalette.SeaGreen;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void DefinirChartSesiones(DateTime i, DateTime f) 
        {
            try
            {
                DateTime inicio = i;
                DateTime final = f;

                chart_sesiones.ChartAreas.Clear();
                chart_sesiones.Series.Clear();
                chart_sesiones.Titles.Clear();
                chart_sesiones.Legends.Clear();

                ChartArea area = new ChartArea();
                area.AxisX.Title = "Sesiones";
                area.AxisY.Title = "Cantidad";

                // Mejoramos la legibilidad
                area.AxisX.LabelStyle.Angle = -45; // Etiquetas inclinadas
                area.AxisX.Interval = 1; // Muestra todas las etiquetas
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                area.AxisX.MajorGrid.Enabled = false; // Quitamos líneas innecesarias
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                chart_sesiones.ChartAreas.Add(area);

                // Creamos la serie
                Series serie = new Series();
                serie.ChartType = SeriesChartType.Pie;
                serie.Color = Color.MediumSeaGreen;
                serie.BorderWidth = 2;
                serie.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie.LabelForeColor = Color.DarkSlateGray;
                
                //Creamos los datos

                //Seleccionamos sesiones que hayan ingresado a partir de 30 días atrás
                var listX = bllSesion.ListarTodo().Where(u => u.Fecha >= inicio && u.Fecha <= final).
                    GroupBy(u => u.Estado == "Abonado" ? "Abonadas" : u.Estado == "No Abonado" ? "No abonadas" : "Cupones Emitidos").
                    Select(g => new { Estado = g.Key, Cantidad = g.Count() }).
                    ToList();
                // Enlazamos los datos
                serie.Points.DataBind(listX, "Estado", "Cantidad", null);

                chart_sesiones.Series.Add(serie);
                // Creamos el título
                Title titulo = new Title
                {
                    Text = $"Sesiones desde el {inicio.ToShortDateString()} hasta el {final.ToShortDateString()}",
                    ForeColor = Color.Teal,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                chart_sesiones.Titles.Add(titulo);

                // Agregamos una leyenda
                Legend leyenda = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DimGray
                };
                chart_sesiones.Legends.Add(leyenda);

                // Aplicamos una paleta de colores agradable
                chart_sesiones.Palette = ChartColorPalette.EarthTones;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void DefinirChartTurnos(DateTime i, DateTime f) 
        {
            try
            {
                DateTime inicio = i;
                DateTime final = f; 

                chart_turnos.ChartAreas.Clear();
                chart_turnos.Series.Clear();
                chart_turnos.Titles.Clear();
                chart_turnos.Legends.Clear();

                ChartArea area = new ChartArea();
                area.AxisX.Title = "Psicólogos";
                area.AxisY.Title = "Cantidad";

                // Mejoramos la legibilidad
                area.AxisX.LabelStyle.Angle = -45; // Etiquetas inclinadas
                area.AxisX.Interval = 1; // Muestra todas las etiquetas
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                area.AxisX.MajorGrid.Enabled = false; // Quitamos líneas innecesarias
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                chart_turnos.ChartAreas.Add(area);

                // Creamos la serie
                Series serie = new Series();
                serie.ChartType = SeriesChartType.Doughnut;
                serie.Color = Color.MediumSeaGreen;
                serie.BorderWidth = 2;
                serie.IsValueShownAsLabel = true; // Muestra el valor encima de cada barra
                serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                serie.LabelForeColor = Color.DarkSlateGray;

                //Creamos los datos

                //Seleccionamos sesiones que hayan ingresado a partir de 30 días atrás
                var listX = bllTurno.ListarTodo().Where(u => u.Fecha >= inicio && u.Fecha <= final).
                    GroupBy(u => u.Estado == "Programado" ? "Programados" : u.Estado == "Cancelado" ? "Cancelados" :
                    u.Estado == "Realizado" ? "Realizados" : "Ausentes").
                    Select(g => new { Estado = g.Key, Cantidad = g.Count() }).
                    ToList();
                // Enlazamos los datos
                serie.Points.DataBind(listX, "Estado", "Cantidad", null);

                chart_turnos.Series.Add(serie);
                // Creamos el título
                Title titulo = new Title
                {
                    Text = $"Sesiones desde el {inicio.ToShortDateString()}  hasta el  {final.ToShortDateString()}",
                    ForeColor = Color.Teal,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                chart_turnos.Titles.Add(titulo);

                // Agregamos una leyenda
                Legend leyenda = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DimGray
                };
                chart_turnos.Legends.Add(leyenda);

                // Aplicamos una paleta de colores agradable
                chart_turnos.Palette = ChartColorPalette.EarthTones;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void DefinirChartFinanzas(DateTime i, DateTime f) 
        {
            try
            {
                DateTime inicio = i;
                DateTime fin = f;
                chart_finanzas.ChartAreas.Clear();
                chart_finanzas.Series.Clear();
                chart_finanzas.Titles.Clear();
                chart_finanzas.Legends.Clear();

                ChartArea area = new ChartArea();
                area.AxisX.LabelStyle.Format = "dd/MM"; 
                area.AxisX.Title = "Fecha";
                area.AxisY.Title = "Monto";

                area.AxisX.MajorGrid.LineColor = Color.LightGray;
                area.AxisY.MajorGrid.LineColor = Color.LightGray;
                area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart_finanzas.ChartAreas.Add(area);

                // Creamos las series para
                //Sesiones pagas
                var serie = chart_finanzas.Series.Add("Ingresos");
                serie.ChartType = SeriesChartType.Column; // línea con relleno suave
                serie.XValueType = ChartValueType.Date;
                serie.BorderWidth = 2;
                serie.Color = Color.FromArgb(120, 106, 153, 80);   // mismo verde, con transparencia
                serie.BorderColor = Color.FromArgb(106, 153, 80);  // borde de la línea
                serie.XValueType = ChartValueType.Date;


                //Salarios
                var serie_Dos = chart_finanzas.Series.Add("Egresos");
                serie_Dos.ChartType = SeriesChartType.Column; // solo línea, sin relleno
                serie_Dos.XValueType = ChartValueType.Date;
                serie_Dos.BorderWidth = 2;
                serie_Dos.Color = Color.OrangeRed;
                serie_Dos.XValueType = ChartValueType.Date;




                //Creamos los datos

                //Recuperamos todas las sesiones abonadas en el rango seleccionado
                var sesiones = bllSesion.ListarTodo().Where(u => u.Fecha >= inicio && u.Fecha <= fin && u.Estado == "Abonado").ToList();

                var sesionesAgrupadas = sesiones.GroupBy(u =>u.Fecha.Date).
                    OrderBy(g => g.Key).
                    Select(g => new { Fecha = g.Key, Monto = g.Sum(x => x.Tarifa.Total) }).ToList();

                //Recuperamos todos los salarios pagados en el intervalo
                var salarios = bllSalario.ListarTodo().Where(s => s.Fecha.Date >= inicio && s.Fecha.Date <= fin).ToList();

                var salariosAgrupados = salarios.GroupBy(s => s.Fecha.Date).OrderBy(g => g.Key).
                    Select(g => new { Fecha = g.Key, Monto = g.Sum(x => x.Monto) }).ToList();

                //Generamos el total de dias entre la fecha seleccionada como inicio
                //Y la fecha actual
                var diasTotales = Enumerable.Range(0, (fin - inicio).Days + 1)
                                               .Select(d => inicio.AddDays(d))
                                               .ToList();

                var dictIngresos = sesionesAgrupadas.ToDictionary(x => x.Fecha.Date, x => x.Monto);
                var dictEgresos = salariosAgrupados.ToDictionary(x => x.Fecha.Date, x => x.Monto);

                var ingresosTotales = diasTotales.Select(d => new
                {
                    Fecha = d.Date,
                    Monto = dictIngresos.TryGetValue(d.Date, out var m) ? m : 0m
                }).ToList();

                var egresosTotales = diasTotales.Select(d => new
                {
                    Fecha = d.Date,
                    Monto = dictEgresos.TryGetValue(d.Date, out var m) ? m : 0m
                }).ToList();

                

                //Ahora vamos agregando punto por punto cada objeto en los gráficos
                foreach (var s in ingresosTotales) 
                {
                    serie.Points.AddXY(s.Fecha, s.Monto);
                }

                foreach(var s in egresosTotales) 
                {
                    serie_Dos.Points.AddXY(s.Fecha, s.Monto);
                }
      
                //Mostramos los totales en los siguientes labels
                lb_ingreso.Text = $"${ingresosTotales.Sum(x => x.Monto)}";
                lb_egreso.Text = $"${egresosTotales.Sum(x => x.Monto)}";

                //chart_finanzas.Series.Add(serie);
                //chart_finanzas.Series.Add(serie_Dos);

            
                Title titulo = new Title
                {
                    Text = $"Entradas y salidas desde el {inicio.ToShortDateString()} hasta el {fin.ToShortDateString()}",
                    ForeColor = Color.Teal,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                chart_finanzas.Titles.Add(titulo);
                 

                // Agregamos una leyenda
                Legend leyenda = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DimGray
                };
                chart_finanzas.Legends.Add(leyenda);

                // Aplicamos una paleta de colores agradable
               
                chart_finanzas.Palette = ChartColorPalette.EarthTones;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarCharts(30);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Esta funcion recibe la cantidad de días a partir de los cuáles queremos obtener los gráficos
        //Es decir, a partir de hoy menos 'x' días, que corresponden al argumento que enviamos al invocar la función
        private void CambiarCharts(int dias) 
        {

            DefinirChartPacientesA(DateTime.Now.AddDays(-dias), DateTime.Now); 
            DefinirChartPsicologos(DateTime.Now.AddDays(-dias), DateTime.Now);
            DefinirChartSesiones(DateTime.Now.AddDays(-dias), DateTime.Now);
            DefinirChartTurnos(DateTime.Now.AddDays(-dias), DateTime.Now);
            DefinirChartFinanzas(DateTime.Now.AddDays(-dias), DateTime.Now);
        }

        private void btn_meses_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarCharts(90);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                CambiarCharts(180);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_semestre_Click(object sender, EventArgs e)
        {
            //Cambiamos los gráficos mostrando los datos del último semestre
            DefinirChartPacientesA(inicioSemestreAnterior, finSemestreAnterior);
            DefinirChartFinanzas(inicioSemestreAnterior, finSemestreAnterior);
            DefinirChartSesiones(inicioSemestreAnterior, finSemestreAnterior);
            DefinirChartTurnos(inicioSemestreAnterior, finSemestreAnterior);
            DefinirChartPsicologos(inicioSemestreAnterior, finSemestreAnterior);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefinirChartTurnos(DateTime.Now, DateTime.Now.AddDays(30));
        }

        #region "FUNCIONES NO UTILIZADAS"
        private void lb_egreso_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                if(dateFin.Value < dateInicio.Value)
                {
                    MessageBox.Show("La fecha de fin no puede ser anterior a la de inicio", "Error en selección de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Cambiamos los gráficos mostrando los datos en el período seleccionado por los filtros
                DefinirChartPacientesA(dateInicio.Value, dateFin.Value);
                DefinirChartFinanzas(dateInicio.Value, dateFin.Value);
                DefinirChartSesiones(dateInicio.Value, dateFin.Value);
                DefinirChartTurnos(dateInicio.Value, dateFin.Value);
                DefinirChartPsicologos(dateInicio.Value, dateFin.Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart_cant_usuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
