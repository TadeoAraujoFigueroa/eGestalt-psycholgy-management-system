using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioDeNotificaciones
    {
        private string _clave;
        private string _remitente;

        public bool EnviarNotificacion(string remitente, string clave, string asunto, string cuerpo, string destinatario, string[] destinatarios) 
        {
            try
            {
                //Creamos la base del mensaje
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(remitente, "Red Social y Solidaria de Asistencia");
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = false;
                //Configuramos el destinatario

                this._remitente = remitente;
                this._clave = clave;

                if (destinatarios.Count() > 1)
                {
                    foreach (string dest in destinatarios)
                    {
                        mensaje.Bcc.Add(dest);
                    }

                }
                else
                {
                    mensaje.To.Add(destinatario);
                }

                return RealizarEnvio(_remitente, _clave, mensaje);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private bool RealizarEnvio(string remitente, string contrasenia, MailMessage mensaje)
        {
            try
            {
                using (SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587))
                {
                    cliente.Credentials = new NetworkCredential(remitente, contrasenia);
                    cliente.EnableSsl = true;
                    cliente.Send(mensaje);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
