using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormRestore : Form
    {
        BEBitacora beBitacora;
        BLLBitacora bllBitacora;

        BLLGestorBD gestorBD;

        BEUsuarioSistema beUsuario;
        private string nombreBackUp = "";
        public FormRestore(BEUsuarioSistema usuario)
        {
            try
            {
                InitializeComponent();
                bllBitacora = new BLLBitacora();
                gestorBD = new BLLGestorBD();
                beUsuario = usuario;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormRestore_Load(object sender, EventArgs e)
        {
            try
            {
                TreeNode nodoRaiz = new TreeNode("BackUp");

                foreach (var b in bllBitacora.ListarTodo().Where(b => b.Detalle == "BackUp").ToList()) 
                {
                    nodoRaiz.Nodes.Add(new TreeNode(b.FechaRegistro));
                }

                treeViewBackUp.Nodes.Add(nodoRaiz);
                treeViewBackUp.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treeViewBackUp_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node == null) { return; }
                if (e.Node.Text == "BackUp") { return; }
                nombreBackUp = e.Node.Text;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void treeViewBackUp_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node == null) { return; }

                nombreBackUp = e.Node.Text;

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                    
                if (gestorBD.RealizarRestore(DateTime.Parse(nombreBackUp, new CultureInfo("es-AR"))))
                {
                    beBitacora = new BEBitacora();
                    beBitacora.Codigo = -1;
                    beBitacora.Detalle = "Restore";
                    beBitacora.FechaRegistro = DateTime.Now.ToString();
                    beBitacora.beUsuario = beUsuario;

                    bllBitacora.Guardar(beBitacora);

                    MessageBox.Show("Restore realizado con éxito");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
