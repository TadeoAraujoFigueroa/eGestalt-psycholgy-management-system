using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using MaterialSkin;
using MaterialSkin.Controls;
using Servicios;

namespace TRABAJO_FINAL
{
    public partial class FormMenu : Form
    {
        Form _form_activo;

        private MdiClient mdiClient;

        BERol beRol;
        BLLRol bllRol;
        BLLPago bllPago;
        BEPermisoSimple bePermiso;

        //Traemos los permisos y realizamos vinculaciones/desvinculaciones
        BLLPermisoSimple bllPermiso;

        BEUsuarioSistema beUsuario;

        //Traemos los roles y realizamos vinculaciones/desvinculaciones
        BLLUsuarioSistema bllUsuarioSistema;

        List<BEPermisoSimple> permisosUsuario;

        List<BERol> rolesUsuario;

        BLLDatos bllDatos;
        BLLMetodoDePago bllMetodoDePago;

        public FormMenu(BEUsuarioSistema beUsuarioLogueado)
        {
            try
            {
                InitializeComponent();

                _form_activo = new Form();

                bllUsuarioSistema = new BLLUsuarioSistema();

                bllPermiso = new BLLPermisoSimple();

                bllRol = new BLLRol();

                bllPago = new BLLPago();

                beUsuario = beUsuarioLogueado;

                permisosUsuario = new List<BEPermisoSimple>();

                rolesUsuario = new List<BERol>();

                string rutaLogo = GestorArchivos.ObtenerRutaArchivoImg("LOGO_PROGRAMA.png");

                //string[] imagenLogo = Directory.GetFiles(rutaLogo);
               

                //Creamos los xml

                bllUsuarioSistema.CrearXml();
                bllPago.CrearXml();

                //Traemos los permisos del usuario logueado
                permisosUsuario = bllUsuarioSistema.ListarPermisosUsuario(beUsuario);

                rolesUsuario = bllUsuarioSistema.ListarRolesDelUsuario(beUsuario);

                foreach (var r in rolesUsuario)
                {
                    foreach (var p in bllRol.ListarPermisosRol(r))
                    {
                        if (p is BERol)
                        {
                            CargarRoles(bllRol.ListarPermisosRol(p as BERol), p as BERol);
                        }
                        else
                        {
                            r.AgregarHijo(p);
                            permisosUsuario.Add(p as BEPermisoSimple);
                        }
                    }
                }


                //Agregamos los permisos de salir y cerrar sesión de forma irremovible
                //Todo usuario debe poder salir y cerrar sesión
                permisosUsuario.Add(new BEPermisoSimple
                {
                    Codigo = 23,
                    Nombre = "CerrarSesión"
                });
                permisosUsuario.Add(new BEPermisoSimple
                {
                    Codigo = 24,
                    Nombre = "SalirdelSistema"
                });

                bllMetodoDePago = new BLLMetodoDePago();

                //Creamos los métodos de pago si no existen
                bllMetodoDePago.CrearXml();

                bllDatos = new BLLDatos();

                //Creamos los datos que llenan los combo box si no existen
                bllDatos.CrearXml();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al inicializar componentes\n{ex.Message}");
            }
          
        }

        private void CargarRoles(List<BEPermisoBase> roles, BERol beRol) 
        {
            try
            {
                foreach (var role in roles)
                {
                    if (role is BERol)
                    {
                        CargarRoles(bllRol.ListarPermisosRol(role as BERol), role as BERol);
                    }
                    else
                    {
                        beRol.AgregarHijo(role);
                        permisosUsuario.Add(role as BEPermisoSimple);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is MdiClient client)
                    {
                        mdiClient = client;

                        //Guardamos en el fondo la imagen del logo
                        mdiClient.BackgroundImage = null;
                        //Evitamos que la imagen se duplique
                        mdiClient.BackgroundImageLayout = ImageLayout.None;

                        mdiClient.BackColor = Color.White;

                        //Evento que dibuja el logo
                        mdiClient.Paint += MdiClient_Paint; // nos suscribimos al evento Paint

                        mdiClient.Resize += (s, a) => mdiClient.Invalidate(); //mantiene la relación del logo al realizar un resize             


                    }
                }

                // Cambiar color del resto del form (borde, menú, etc.)
                this.BackColor = Color.FromArgb(242, 232, 207);
                this.ForeColor = Color.FromArgb(56, 102, 65);

                //Ocultamos todo el menu

                OcultarTodosLosItemsDelMenu();

                //Si el usuario tiene permisos, mostramos los items del menu correspondientes
                if (permisosUsuario != null)
                {
                    MostrarItemsSegunPermisos(permisosUsuario);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al cargar menú\n{ex.Message}");
            }
     
        }    
        private void OcultarTodosLosItemsDelMenu() 
        {
            try
            {
                if (this.menuStrip1 != null)
                {
                    //Recorremos los items del menu ToolStripMenu
                    foreach (ToolStripItem item in this.menuStrip1.Items)
                    {
                        if (item is ToolStripMenuItem menuItem)
                        {
                            menuItem.Visible = false;

                            //Si tiene subitems, los recorremos para no mostrarlos
                            if (menuItem.DropDownItems.Count > 0)
                            {
                                OcultarItemsDelSubMenu(menuItem.DropDownItems);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void OcultarItemsDelSubMenu(ToolStripItemCollection subMenus) 
        {
            try
            {
                foreach (ToolStripItem item in subMenus)
                {
                    item.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
         
        private void MostrarItemsSegunPermisos(List<BEPermisoSimple> permisosUsuario) 
        {
            try
            {
                foreach (ToolStripItem item in menuStrip1.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        if (menuItem.DropDownItems.Count > 0)
                        {
                            MostrarSubItemsSegunPermisos(menuItem, permisosUsuario);

                        }

                        if (TienePermiso(menuItem.Text, permisosUsuario))
                        {
                            menuItem.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void MostrarSubItemsSegunPermisos(ToolStripMenuItem menuItem, List<BEPermisoSimple> permisoUsuario) 
        {
            try
            {
                bool flag = false;

                foreach (ToolStripItem item in menuItem.DropDownItems)
                {
                    if (item is ToolStripMenuItem subMenuItem)
                    {
                        if (subMenuItem.DropDownItems.Count > 0)
                        {
                            MostrarSubItemsSegunPermisos(subMenuItem, permisoUsuario);
                        }

                        if (TienePermiso(subMenuItem.Text, permisoUsuario))
                        {
                            subMenuItem.Visible = true;
                            flag = true;
                        }
                    }
                }

                if (flag) { menuItem.Visible = true; }
                ;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private bool TienePermiso(string nombreMenu, List<BEPermisoSimple> permisos) 
        {
            try
            {
                bool flag = false;

                foreach (BEPermisoSimple p in permisos)
                {
                    if (p.Nombre.Replace(" ", "") == nombreMenu.Replace(" ", ""))
                    {
                        flag = true;
                        break;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
         
        }

        //Función que nos permite 'dibujar' la imagen de fondo
        private void MdiClient_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                var cliente = sender as MdiClient;

                //Verificamos que el archivo de imagen exista
                var flag = File.Exists(GestorArchivos.ObtenerRutaArchivoImg("LOGO_PROGRAMA.png"));

                //Si no existe, evitamos cargar la imagen
                if (!flag)
                {
                    return;
                }
                var logo = Image.FromFile(GestorArchivos.ObtenerRutaArchivoImg("LOGO_PROGRAMA.png"));

                if (logo == null) return;

                int x = (cliente.Width - logo.Width) / 2;

                int y = (cliente.Height - logo.Height) / 2;

                //Dibujamos el gráfico a partir de las coordenadas
                e.Graphics.DrawImage(logo, x, y);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

               
            
        }
        
        private void Mostrar_Form(Form formulario) 
        {
            try
            {
                formulario.MdiParent = this;
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.Location = new Point(0, 0);
                formulario.BackColor = Color.FromArgb(242, 232, 207);
                formulario.AutoScroll = true;
                if (_form_activo != null)
                { _form_activo.Close(); }

                _form_activo = formulario;
                _form_activo.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_alta_pacientes = new FornAltaPacientes();
            Mostrar_Form(form_alta_pacientes);
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_pacientes_activos = new FormPacientesActivos();
            Mostrar_Form(form_pacientes_activos);
        }

        private void descontinuadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_pacientes_inactivos = new FormPacientesDiscontinuados();
            Mostrar_Form(form_pacientes_inactivos);
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form_psicologos_alta = new FormABMPsicologos();
            Mostrar_Form(form_psicologos_alta);
        }

        private void activosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form psicologos_activos = new FormListaPacientes();
            Mostrar_Form(psicologos_activos);
        }

        private void aAutorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pacientes_en_espera = new FormPacientesEnEspera();
            Mostrar_Form(pacientes_en_espera);

        }

        private void turneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form turnero_mensual = new FormTurneroMensual();
            Mostrar_Form(turnero_mensual);
        }

        private void aplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Cerrando aplicación..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                MessageBox.Show("Gracias por utilizar la aplicación. ¡Hasta luego!");
                Application.Exit();
            }
            
        }

        private void tablaDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tabla_turnos = new FormTablaDeTurnos();
            Mostrar_Form(tabla_turnos);
        }

        private void tablaDeSesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tabladesesiones = new FormTablaSesiones();
            Mostrar_Form(tabladesesiones);
        }

        private void calcularNuevaTarifaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_actualizar_tarifa = new FormActualizarTarifa();
            Mostrar_Form(form_actualizar_tarifa);
        }

        private void enviarMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_correo = new FormCorreo();
            Mostrar_Form(form_correo);
        }

        private void reporteDeSesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormReporteSesiones();
            Mostrar_Form(form);
        }

        private void informesAValidarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormValidarInformes();
            Mostrar_Form(form);
        }

        private void informesRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormInformesRealizados();
            Mostrar_Form(form);
        }

        private void calculoDeSalariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void calculoDeHonorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_calcular_salario = new FormCalculoHonorarios();
            Mostrar_Form(form_calcular_salario);
        }

        private void tablaDeSalariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_tabla_salarios = new FormTablaDeSalarios();
            Mostrar_Form(form_tabla_salarios);
        }

        private void cuponesSolicitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_cupones_solicitados = new FormCuponesSolicitados();
            Mostrar_Form(form_cupones_solicitados);
        }

        private void historiasClinicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_ingreso_hc = new FormVerificarCodigoDeAcceso();
            Mostrar_Form(form_ingreso_hc);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Quiere cerrar su sesión?", "Cerrando sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes) { this.Close(); }
            
        }

        private void aBMUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_abmusuarios = new FormABMUsuarios();
            Mostrar_Form(form_abmusuarios);
        }

        private void gestorDeRolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_roles_permisos = new FormRolesPermisos(this.menuStrip1);
            Mostrar_Form(form_roles_permisos);
        }

        private void realizarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_backup = new FormBackUp(beUsuario);
            Mostrar_Form(form_backup);
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_bitacora = new FormBitacora();
            Mostrar_Form(form_bitacora);
        }

        private void realizarRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_restore = new FormRestore(beUsuario);  
            Mostrar_Form(form_restore);
        }

        private void verDashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dashboard = new FormDashboard();
            Mostrar_Form(dashboard);
        }
    }
}
