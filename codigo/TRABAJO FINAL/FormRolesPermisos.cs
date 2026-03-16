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
using Seguridad;

namespace TRABAJO_FINAL
{
   
    public partial class FormRolesPermisos : Form
    {
        int cont = 0;
        //
        BERol beRol;
        
        BEPermisoSimple bePermiso;

        BEUsuarioSistema beUsuario;

        //Traemos los roles y realizamos vinculaciones/desvinculaciones
        BLLRol bllRol;
        //Traemos los permisos y realizamos vinculaciones/desvinculaciones
        BLLPermisoSimple bllPermiso;
        //Traemos los usuarios
        BLLUsuarioSistema bllUsuarioSistema;
        //Listas de datos
        List<BEPermisoSimple> permisosSimples;
        
        List<BERol> roles;
        
        List<BEUsuarioSistema> usuarios;

        private MenuStrip _menuStrip;

        public FormRolesPermisos(MenuStrip menuStrip)
        {
            try
            {
                InitializeComponent();

                //Inicializamos BLL's
                bllUsuarioSistema = new BLLUsuarioSistema();
                bllPermiso = new BLLPermisoSimple();
                bllRol = new BLLRol();

                //Inicializamos datos
                _menuStrip = menuStrip;
                


                permisosSimples = new List<BEPermisoSimple>();
                permisosSimples = bllPermiso.listarTodo();

                roles = new List<BERol>();

                usuarios = new List<BEUsuarioSistema>();
                usuarios = bllUsuarioSistema.ListarTodo().Where(u => u.Estado == true).ToList();

                cb_roles.DataSource = bllRol.ListarTodo();
                cb_usuarios.DataSource = usuarios;


                //Cargamos los datos en memoria
                CargarDatos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void FormRolesPermisos_Load(object sender, EventArgs e)
        {

        }

        #region "SELECCIONES"

        //Recuperar rol seleccionado
        private void treeViewRoles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                try
                {
                    if (e.Node.Tag == null)
                        return; // Evitamos error si el Tag es nulo

                    var tagRol = e.Node.Tag.ToString();

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRol));

                    if (beRol != null)
                    {
                        txt_id_rol.Text = beRol.Codigo.ToString();
                        txt_nombre_rol.Text = beRol.Nombre.ToString();

                        CargarPermisoRol(beRol);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Recuperar permiso seleccionado
        private void treeViewPermisos_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node == null)
                    return; // Evitamos error si el Tag es nulo

                var tagPermiso = e.Node.Tag;

                bePermiso = bllPermiso.listarTodo().FirstOrDefault(p => p.Nombre == e.Node.Text.Replace(" ", ""));

                if(bePermiso != null) 
                {
                    txt_id_permiso.Text = bePermiso.Codigo.ToString();
                    txt_nombre_permiso.Text = bePermiso.Nombre.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Recuperar usuarios seleccionado
        private void treeViewUsuarios_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null) { return; }

                beUsuario = usuarios.FirstOrDefault(u => u.Codigo.ToString() == e.Node.Tag.ToString());

                //reseteamos el cheq
                cheq_clave.Checked = false;

                if (beUsuario != null)
                {
                    RellenarDatosUsuario(beUsuario);

                    var rolesUsuario = bllUsuarioSistema.ListarRolesDelUsuario(beUsuario);

                    var rolesUsuarioCompletos = rolesUsuario
                            .Select(ru => roles.FirstOrDefault(r => r.Codigo == ru.Codigo))
                            .Where(r => r != null)
                            .ToList();

     
                    var permisosUsuario = bllUsuarioSistema.ListarPermisosUsuario(beUsuario).Select(p => p.Nombre).ToList();

                    //Llamamos a la función que carga el tree view
                    CargarTreeViewRolesYPermisos(_menuStrip, rolesUsuarioCompletos, permisosUsuario, treeViewUsuarioRoles, "Roles y Permisos del Usuario");


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_roles.Text != "")
                {
                    var nombreRol = cb_roles.Text;
                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Nombre == nombreRol);

                    if (beRol != null)
                    {
                        txt_id_roles_2.Text = beRol.Codigo.ToString();
                        txt_nombre_roles_2.Text = beRol.Nombre.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_usuarios.Text != "")
                {
                    var nombreUsuario = cb_usuarios.Text;
                    beUsuario = usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario);

                    if (beUsuario != null)
                    {
                        RellenarDatosUsuario(beUsuario);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region "ASIGNACIONES"


        //Asigna el permiso seleccionado al rol seleccionado
        private void btn_a_permiso_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != null && txt_id_permiso != null)
                {
                    //A partir de los nodos seleccionados, creamos la relacíón
                    var tagPermiso = txt_id_permiso.Text;

                    var tagRol = txt_id_rol.Text;

                    bePermiso = bllPermiso.listarTodo().FirstOrDefault(p => p.Codigo == int.Parse(tagPermiso.ToString()));

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRol));

                    if(bllRol.AgregarPermisoRol(bePermiso, beRol)) 
                    {
                        MessageBox.Show($"Rol {beRol.Nombre} asociado correctamente a permiso {bePermiso.Nombre}");

                        CargarRoles();
                    }
                    

                    


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Asigna el rol padre seleccionado al rol hijo seleccionado
        private void btn_rol_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != null && txt_id_roles_2 != null)
                {
                    if(txt_id_rol.Text == txt_id_roles_2.Text) 
                    {
                        MessageBox.Show("Por favor, seleccione roles distintos");
                        return;
                    }
                    //A partir de los nodos seleccionados, creamos la relacíón
                    var tagRolHijo = txt_id_roles_2.Text;

                    var tagRolPadre = txt_id_rol.Text;

                    BERol beRolHijo;

                    beRolHijo = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRolHijo));

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRolPadre));

                    if(bllRol.AgregarRolRol(beRol, beRolHijo)) 
                    {
                        MessageBox.Show($"Rol {beRolHijo.Nombre} asignado correctamente a rol {beRol.Nombre}");
                        CargarRoles();
                    }
                    else 
                    {
                        MessageBox.Show($"No se puede asociar el rol {beRolHijo.Nombre} asignado correctamente a rol {beRol.Nombre}");
                    }

                    


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Asigna el rol seleccionado al usuario seleccionado
        private void tn_a_rol_usuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != null && txt_id_u.Text != null)
                {
                    var tagRol = txt_id_rol.Text;

                    var tagUsuario = txt_id_u.Text;

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRol));
                    beUsuario = usuarios.FirstOrDefault(u => u.Codigo == int.Parse(tagUsuario));

                    if (bllUsuarioSistema.VincularUsuarioRol(beUsuario, beRol))
                    {
                        MessageBox.Show("Rol asignado correctamente al usuario");
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Asigna el permiso seleccionado al usuario seleccionado
        private void btn_a_permiso_us_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_permiso.Text != "" && txt_id_u.Text != "")
                {
                    var tagPermiso = txt_id_permiso.Text;

                    var tagUsuario = txt_id_u.Text;

                    bePermiso = permisosSimples.FirstOrDefault(p => p.Codigo.ToString() == tagPermiso.ToString());
                    beUsuario = usuarios.FirstOrDefault(u => u.Codigo == int.Parse(tagUsuario));

                    if (bllUsuarioSistema.VincularUsuarioPermiso(beUsuario, bePermiso))
                    {
                        MessageBox.Show("Permiso asignado correctamente al usuario");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region "DESASIGNACIONES"

        //Desasigna el rol padre seleccionado del rol hijo seleccionado
        private void btn_quit_rol_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != null && txt_id_roles_2 != null)
                {
                    //A partir de los nodos seleccionados, creamos la relacíón
                    var tagRolHijo = txt_id_roles_2.Text;

                    var tagRolPadre = txt_id_rol.Text;

                    BERol beRolHijo;

                    beRolHijo = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRolHijo));

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRolPadre));

                    if(bllRol.DesvincularRolDeRol(beRol, beRolHijo)) 
                    {
                        MessageBox.Show($"Rol {beRolHijo.Nombre} desasignado correctamente a rol {beRol.Nombre}");
                        CargarDatos();
                    }

                    


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //Desasigna el permiso seleccionado del rol seleccionado
        private void btn_q_permiso_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != null && txt_id_permiso != null)
                {
                    //A partir de los nodos seleccionados, creamos la relacíón
                    var tagPermiso = txt_id_permiso.Text;

                    var tagRol = txt_id_rol.Text;

                    bePermiso = bllPermiso.listarTodo().FirstOrDefault(p => p.Codigo == int.Parse(tagPermiso.ToString()));

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRol));

                    if (bllRol.DesvincularPermisoDeRol(bePermiso, beRol))
                    {
                        MessageBox.Show($"Permiso {bePermiso.Nombre}desasignado del rol {beRol.Nombre} correctamente");

                        CargarDatos();
                    }



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Desasigna el permiso seleccionado del usuario seleccionado
        private void btn_q_permiso_us_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_permiso.Text != "" && txt_id_u.Text != "")
                {
                    var tagPermiso = txt_id_permiso.Text;

                    var tagUsuario = txt_id_u.Text;

                    bePermiso = permisosSimples.FirstOrDefault(p => p.Codigo.ToString() == tagPermiso.ToString());
                    beUsuario = usuarios.FirstOrDefault(u => u.Codigo == int.Parse(tagUsuario));

                    if (bllUsuarioSistema.DesvincularUsuarioPermiso(beUsuario, bePermiso))
                    {
                        MessageBox.Show("Permiso desasignado correctamente al usuario");
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Desasigna el rol seleccionado del usuario seleccionado
        private void btn_q_rol_usuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_u.Text != "" && txt_id_rol.Text != "")
                {
                    var tagRol = txt_id_rol.Text;

                    var tagUsuario = txt_id_u.Text;

                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(tagRol));
                    beUsuario = usuarios.FirstOrDefault(u => u.Codigo == int.Parse(tagUsuario));

                    if (bllUsuarioSistema.DesvincularUsuarioRol(beUsuario, beRol))
                    {
                        MessageBox.Show("Rol desasignado correctamente al usuario");

                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region "CARGA DE DATOS"
        private void CargarDatos()
        {
            try
            {
                RecargarPermisosDelRol();

                CargarUsuarios();

                CargarPermisos();

                RecargarPermisosDelRol();

                CargarRolesSimple();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
          
        }

        private void CargarUsuarios()
        {
            treeViewUsuarios.Nodes.Clear();

            TreeNode raiz = new TreeNode("Usuarios");

            foreach (var u in usuarios)
            {
                TreeNode usuario = new TreeNode(u.Nombre);
                usuario.Tag = u.Codigo.ToString();
                raiz.Nodes.Add(usuario);
            }

            treeViewUsuarios.Nodes.Add(raiz);
            treeViewUsuarios.ExpandAll();
        }

        private void CargarPermisos()
        {
            try
            {
                CargarTreeViewPermisos(_menuStrip, permisosSimples.Select(t => t.Nombre).ToList(), treeViewPermisos, "Permisos");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RecargarPermisosDelRol()
        {
            //Me deberia traer los roles cargados con sus permisos
            roles = bllRol.ListarTodo();

            //Cargamos los roles con sus permisos
            foreach (var rol in roles)
            {
                List<BEPermisoBase> lista_permisos_rol = new List<BEPermisoBase>();

                lista_permisos_rol = bllRol.ListarPermisosRol(rol);

                if (lista_permisos_rol.Count() > 0)
                {
                    foreach (var r in lista_permisos_rol)
                    {
                        if (rol.RetornarPermisos().Contains(r))
                        {
                            break;
                        }
                        rol.AgregarHijo(r);
                    }
                }



            }
        }

        public void CargarRolesSimple()
        {
            treeViewRoles.Nodes.Clear();

            TreeNode raiz = new TreeNode("Roles");

            List<BERol> rolesSimples = new List<BERol>();

            rolesSimples = bllRol.ListarTodo();

            foreach (var rol in rolesSimples)
            {
                TreeNode rolSimple = new TreeNode(rol.Nombre);
                rolSimple.Tag = rol.Codigo;

                raiz.Nodes.Add(rolSimple);
            }

            treeViewRoles.Nodes.Add(raiz);
            treeViewRoles.ExpandAll();

        }

        private void CargarRoles()
        {
            treeViewPermisosPorRol.Nodes.Clear();

            TreeNode raiz = new TreeNode("Roles");

            RecargarPermisosDelRol();

            foreach (var p in roles)
            {
                if (p.RetornarPermisos().Count() > 0)
                {
                    TreeNode rolPadre = new TreeNode(p.Nombre);
                    rolPadre.Tag = p.Codigo;
                    CargarPermisoRol(p.RetornarPermisos(), rolPadre);

                    raiz.Nodes.Add(rolPadre);
                }
                else
                {
                    TreeNode rolPadre = new TreeNode(p.Nombre);
                    rolPadre.Tag = p.Codigo;
                    raiz.Nodes.Add(rolPadre);
                }

            }

            treeViewPermisosPorRol.Nodes.Add(raiz);
            treeViewPermisosPorRol.ExpandAll();
        }

        private void CargarPermisoRol(BERol rol)
        {
            try
            {

                treeViewPermisosPorRol.Nodes.Clear();

                beRol = roles.FirstOrDefault(r => r.Codigo == rol.Codigo);


                TreeNode raiz = new TreeNode("Roles y Permisos del Rol");


                if (beRol.RetornarPermisos().Count() > 0)
                {
                    TreeNode rolPadre = new TreeNode(beRol.Nombre);
                    rolPadre.Tag = beRol.Codigo;
                    CargarPermisoRol(beRol.RetornarPermisos(), rolPadre);

                    raiz.Nodes.Add(rolPadre);
                }
                else
                {
                    TreeNode rolPadre = new TreeNode(beRol.Nombre);
                    rolPadre.Tag = beRol.Codigo;
                    raiz.Nodes.Add(rolPadre);
                }

                treeViewPermisosPorRol.Nodes.Add(raiz);
                treeViewPermisosPorRol.ExpandAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void CargarPermisoRol(BEPermisoBase[] permisos, TreeNode rolPadre)
        {
            foreach (var p in permisos)
            {
                if (p is BERol)
                {
                    if (p.RetornarPermisos().Count() > 0)
                    {

                        TreeNode rolSubPadre = new TreeNode(p.Nombre);
                        rolSubPadre.Tag = p.Codigo;

                        CargarPermisoRol(p.RetornarPermisos(), rolSubPadre);

                        rolPadre.Nodes.Add(rolSubPadre);
                    }
                }
                else
                {
                    TreeNode hijo = new TreeNode(p.Nombre);
                    hijo.Tag = p.Codigo;
                    rolPadre.Nodes.Add(hijo);
                }
            }
        }

        private void RellenarDatosUsuario(BEUsuarioSistema beUser)
        {
            try
            {
                txt_clave_u.Text = beUser.Clave;
                txt_nombre_u.Text = beUser.Nombre;
                txt_id_u.Text = beUser.Codigo.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region "METODOS TREE VIEW"

        private void AgregarRolesYPermisosAlTreeView(BEPermisoBase[] lista, TreeNode nodoPadre)
        {
            if (lista != null)
            {
                foreach (var rolUsuario in lista)
                {
                    // Obtengo el rol con su jerarquía completa
                    TreeNode nodoRol = new TreeNode(rolUsuario.Nombre);
                    nodoPadre.Nodes.Add(nodoRol);

                    // Sublista con los permisos del rol
                    BEPermisoBase[] subLista = rolUsuario.RetornarPermisos();

                    // Llamada recursiva para agregar roles y permisos anidados
                    AgregarRolesYPermisosAlTreeView(subLista, nodoRol);
                }
            }

        }

        private void AgregarPermisoAlTreeView(MenuStrip menuStrip, string permisoNombre, TreeNode nodoPadre)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                // Verifico si el item es un ToolStripMenuItem y no un separador
                if (item is ToolStripMenuItem)
                {
                    foreach (var subItem in item.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem menuItem && menuItem.Text.Replace(" ", "") == permisoNombre.Replace(" ", ""))
                        {
                            // Agrego el item padre si no existe en el TreeView
                            TreeNode nodoItemPadre = MetodoNodos(nodoPadre, item.Text);

                            // Agrego el subitem al nodo padre encontrado o creado
                            TreeNode nodoPermiso = new TreeNode(menuItem.Text);
                            nodoItemPadre.Nodes.Add(nodoPermiso);

                            return;
                        }
                    }
                }
            }
        }

        private TreeNode MetodoNodos(TreeNode nodoPadre, string texto)
        {
            foreach (TreeNode nodo in nodoPadre.Nodes)
            {
                if (nodo.Text.Equals(texto, StringComparison.OrdinalIgnoreCase))
                    return nodo;
            }

            // Si no existe, lo creo y lo agrego al padre
            TreeNode nuevoNodo = new TreeNode(texto);
            nodoPadre.Nodes.Add(nuevoNodo);
            return nuevoNodo;
        }
        private void CargarTreeViewPermisos(MenuStrip menuStrip, List<string> permisosUsuario, TreeView treeVmUsuarioPermisos, string raiz)
        {

            treeVmUsuarioPermisos.Nodes.Clear();

            // Nodo raíz
            TreeNode nodoRaiz = new TreeNode(raiz);
            treeVmUsuarioPermisos.Nodes.Add(nodoRaiz);



            if (permisosUsuario != null)
            {
                foreach (var permisoUsuario in permisosUsuario)
                {
                    AgregarPermisoAlTreeView(menuStrip, permisoUsuario, nodoRaiz);
                }
            }

            treeVmUsuarioPermisos.ExpandAll();

        }
        private void CargarTreeViewRolesYPermisos(MenuStrip menuStrip, List<BERol> rolesUsuario, List<string> permisosUsuario, TreeView treeVmUsuarioPermisosRoles, string raiz)
        {
            if (rolesUsuario != null)
            {
                treeVmUsuarioPermisosRoles.Nodes.Clear();

                // Nodo raíz
                TreeNode nodoRaiz = new TreeNode(raiz);
                treeVmUsuarioPermisosRoles.Nodes.Add(nodoRaiz);

                // Agrego los roles y permisos
                AgregarRolesYPermisosAlTreeView(rolesUsuario.ToArray(), nodoRaiz);

                if (permisosUsuario != null)
                {
                    foreach (var permisoUsuario in permisosUsuario)
                    {
                        AgregarPermisoAlTreeView(menuStrip, permisoUsuario, nodoRaiz);
                    }
                }

                treeVmUsuarioPermisosRoles.ExpandAll();
            }
            else
            {
                treeVmUsuarioPermisosRoles.Nodes.Clear();
            }
        }

        #endregion

        //Métodos del ABM rol
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if(txt_nombre_rol.Text != "") 
                {
                    beRol = new BERol();
                    beRol.Nombre = txt_nombre_rol.Text;
                    beRol.Codigo = -1;

                    //Corroboramos la existencia del rol
                    if (bllRol.ExistenciaRol(beRol))
                    {
                        MessageBox.Show("Ese rol ya existe");
                        return;
                    }

                    if (bllRol.Guardar(beRol)) 
                    {
                        MessageBox.Show("Rol creado con éxito");

                        CargarDatos();
                    }
                    

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btn_mod_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != "")
                {
                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(txt_id_rol.Text));

                    if (beRol != null)
                    {
                        beRol.Nombre = txt_nombre_rol.Text;
                    
                        if (bllRol.Modificar(beRol))
                        {
                            MessageBox.Show("Rol modificado con éxito");
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btn_elim_rol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_rol.Text != "")
                {
                    beRol = bllRol.ListarTodo().FirstOrDefault(r => r.Codigo == int.Parse(txt_id_rol.Text));

                    if (beRol != null)
                    {
                        if (bllRol.Baja(beRol))
                        {
                            MessageBox.Show("Rol eliminarcon éxito");
                            CargarDatos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Limpiar Text Box
        private void bnt_limiar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_clave_u.Text = "";
                txt_nombre_u.Text = "";
                txt_id_permiso.Text = "";
                txt_id_rol.Text = "";
                txt_id_roles_2.Text = "";
                txt_id_u.Text = "";
                txt_nombre_permiso.Text = "";
                txt_nombre_rol.Text = "";
                txt_nombre_roles_2.Text = "";
                txt_nombre_u.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cheq_clave_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                if (cheq_clave.Checked)
                {
                    txt_clave_u.Text = Encriptacion.Desencriptar(txt_clave_u.Text);
                }
                else
                {
                    txt_clave_u.Text = Encriptacion.Encriptar(txt_clave_u.Text);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_limpiar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
