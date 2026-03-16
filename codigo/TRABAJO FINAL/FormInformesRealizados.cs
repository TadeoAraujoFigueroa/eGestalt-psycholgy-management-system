using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TRABAJO_FINAL
{
    public partial class FormInformesRealizados : Form
    {
        ServicioDeInformes sInformes = new ServicioDeInformes();

        BEInforme beInforme;

        public FormInformesRealizados()
        {
            try
            {
                InitializeComponent();
                sInformes = new ServicioDeInformes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormInformesRealizados_Load(object sender, EventArgs e)
        {
            try
            {
                dgInformes.DataSource = sInformes.retornarInformesActivos();
                dgvRechazados.DataSource = sInformes.retornarInformesRechazados();
                dgInformes.Columns["ContenidoBytes"].Visible = false;
                dgvRechazados.Columns["ContenidoBytes"].Visible = false;
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al abrir el menu\n{ex.Message}");
            }


        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInformes.SelectedRows.Count > 0) 
                {
                    beInforme = dgInformes.SelectedRows[0].DataBoundItem as BEInforme;
                    beInforme.Estado = "Liberado";
                    beInforme.Observaciones = $"Informe validado y liberado el día {DateTime.Now.ToShortDateString()}";

                    if(sInformes.ModificarInforme(beInforme))
                    {
                        MessageBox.Show("Informe validado y liberado con éxito");
                    }
                }

                FormInformesRealizados_Load(this, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReconstruir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgInformes.SelectedRows.Count > 0)
                {
                    beInforme = dgInformes.SelectedRows[0].DataBoundItem as BEInforme;
                    
                    //La clase memorystream nos permite recorrer un buffer de bytes
                    using (MemoryStream ms =  new MemoryStream(beInforme.ContenidoBytes)) 
                    {
                        //y la clase image nos permite reconstruir una imagen a partir de la lectura de ese buffer
                        Image imagenGrafico = Image.FromStream(ms);

                        pictureBox1.Image = imagenGrafico;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    //Personalizamos el menu de guardado
                    saveFileDialog.Title = "Guardar imagen";
                    saveFileDialog.Filter = "Imagen PNG (*.png)|*.png|Imagen JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
                    saveFileDialog.DefaultExt = "png";
                    saveFileDialog.FileName = "imagen";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Determinamos la extensión elegida
                        string ruta = saveFileDialog.FileName;

                        ImageFormat formato = ImageFormat.Png;

                        // Detectar formato según extensión
                        switch (Path.GetExtension(ruta).ToLower())
                        {
                            case ".jpg":
                            case ".jpeg":
                                formato = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                formato = ImageFormat.Bmp;
                                break;
                        }

                        //Guradamos la imagen
                        pictureBox1.Image.Save(ruta, formato);

                        MessageBox.Show("Imagen guardada correctamente en:\n" + ruta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #region "FUNCIONES NO UTILIZADAS"

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvRechazados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
