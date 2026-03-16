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
    public partial class PerfilPsicologo : Form
    {
        private BEPsicologo _psicologo;

        //Nos brinda toda la información para rellenar los combo box
        BLLDatos bLLDatos;

        BLLPsicologo bllPsicologo;
        public PerfilPsicologo(BEPsicologo psicologo)
        {
            try
            {
                InitializeComponent();
                _psicologo = psicologo;
                bLLDatos = new BLLDatos();
                bllPsicologo = new BLLPsicologo();

                cb_dia.DataSource = bLLDatos.retornarDias().Select(d => d.Nombre).ToList();
                cb_jornada.DataSource = bLLDatos.retornarJornada().Select(j => j.Nombre).ToList();
                cb_sala.DataSource = bLLDatos.retornarSalas().Select(s => s.Nombre).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          


        }

        private void PerfilPsicologo_Load(object sender, EventArgs e)
        {
            try 
            {
                txtNombre.Text = _psicologo.Nombre;
                txtApellido.Text = _psicologo.Apellido;
                txtDni.Text = _psicologo.DNI.ToString();
                txtCorreo.Text = _psicologo.Correo;
                txtTel.Text = _psicologo.Telefono.ToString();

                cb_dia.Text = _psicologo.Dia;
                cb_jornada.Text = _psicologo.Jornada;
                cb_sala.Text = _psicologo.Sala;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {  
                //Chequeamos que, en el caso de ocurrir algún cambio en la jornada, día o sala de atención el espacio no este ocupado por otro psicólogo
                BEPsicologo psicoAux = bllPsicologo.ExistePsicologo(cb_jornada.Text, cb_dia.Text, cb_sala.Text);

                if (psicoAux != null) 
                {
                    //Si los psicólogos son diferentes, no permitimos el cambio
                    if(psicoAux.Codigo != _psicologo.Codigo) 
                    {
                        throw new Exception("No puede atender en la sala, jornada y día seleccionados, ese turno ya está ocupado");
                    }
                }


                _psicologo.Nombre = txtNombre.Text;
                _psicologo.Apellido = txtApellido.Text;

                int dni;
                bool flag = int.TryParse(txtDni.Text, out dni);
                if (!flag) 
                {
                    throw new Exception("El dni debe estar compuesto únicamente de números");
                }

                //Reccorremos todos los psicólogos para comprobar si estamos modificando el DNI
                foreach(var p in bllPsicologo.ListarTodo()) 
                {
                    if(p.Codigo == _psicologo.Codigo) 
                    {
                        //Esto significa que estamos realizando una modificación en el DNI
                        //Por lo que corresponde chequear la existencia del mismo
                        if (p.DNI != dni) 
                        {
                            if (bllPsicologo.ExisteDni(dni)) 
                            {
                                throw new Exception("El DNI ingresado ya se encuentra registrado en el sistema");
                            }
                        }
                    }
                }

                //Continuamos 
                _psicologo.DNI = dni;
                _psicologo.Correo = txtCorreo.Text;

                long telefono;
                flag = long.TryParse(txtTel.Text, out telefono);
                if (!flag) 
                {
                    throw new Exception("El teléfono tiene que estar compuesto únicamente de números");
                }
                _psicologo.Telefono = telefono;

                _psicologo.Jornada = cb_jornada.Text;
                _psicologo.Dia = cb_dia.Text;
                _psicologo.Sala = cb_sala.Text;

                if (bllPsicologo.Modificar(_psicologo)) 
                {
                    MessageBox.Show("Psicólogo modificado correctamente");
                }
                else 
                {
                    MessageBox.Show("Falla en la modificación");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
