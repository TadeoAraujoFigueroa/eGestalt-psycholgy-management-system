using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad
{
    public static class Encriptacion
    {
        public static string Encriptar(string clave)
        {
            try
            {
                byte[] encriptado = Encoding.Unicode.GetBytes(clave);
                string resultado = Convert.ToBase64String(encriptado);
                return resultado;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Desencriptar(string claveEncriptada)
        {
            try
            {
                byte[] desencriptar = Convert.FromBase64String(claveEncriptada);
                string resultado = Encoding.Unicode.GetString(desencriptar);
                return resultado;
            }
            catch (CryptographicException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
