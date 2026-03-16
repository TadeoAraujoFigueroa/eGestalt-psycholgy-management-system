using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class GestorArchivos
    {
        public static bool CrearCarpeta() 
        {
            try
            {
                if (!Directory.Exists(ObtenerRutaDatos())) 
                {
                    Directory.CreateDirectory(ObtenerRutaDatos());
                }
                if (!Directory.Exists(ObtenerRutaCupones()))
                {
                    Directory.CreateDirectory(ObtenerRutaCupones());
                }
                if (!Directory.Exists(ObtenerRutaPDF()))
                {
                    Directory.CreateDirectory(ObtenerRutaPDF());
                }
                if (!Directory.Exists(ObtenerRutaRecursos()))
                {
                    Directory.CreateDirectory(ObtenerRutaRecursos());
                }
                if (!Directory.Exists(ObtenerRutaDatos()))
                {
                    Directory.CreateDirectory(ObtenerRutaDatos());
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        
        }

        public static bool CrearRecursos() 
        {
            try
            {
                // Carpeta base del ejecutable (Debug / Release / instalado)
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                // Origen: Recursos dentro del proyecto
                string origenRecursos = Path.Combine(baseDir, "Recursos");

                // Destino: AppData
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string destinoRecursos = Path.Combine(appData, "eGestalt", "Recursos");

                //Creamos la carpeta de destino si no existe
                Directory.CreateDirectory(destinoRecursos);

                // Archivos a copiar
                string[] archivos =
                {
                         "LOGO_PROGRAMA.png",
                         "LOGO_PSICO.png",
                         "i.png",
                         "n.png",
                         "u.png",
                         "fondo_pago.jpg"
                };

                foreach (string archivo in archivos)
                {
                    string origen = Path.Combine(origenRecursos, archivo);
                    string destino = Path.Combine(destinoRecursos, archivo);

                    if (File.Exists(origen) && !File.Exists(destino))
                    {
                        File.Copy(origen, destino);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
                
            
        }
        public static string ObtenerRutaDatos()
        {
            string ruta = ConfigurationManager.AppSettings["RutaDatos"];
            return Environment.ExpandEnvironmentVariables(ruta);
        }

        public static string ObtenerRutaArchivo(string nombreArchivo)
        {
            string rutaDatos = ObtenerRutaDatos();
            return Path.Combine(rutaDatos, nombreArchivo);
        }

        public static string ObtenerRutaPDF() 
        {
            string ruta = ConfigurationManager.AppSettings["PDF"];
            return Environment.ExpandEnvironmentVariables(ruta);
        }

        public static string ObtenerRutaArchivoPDF(string nombreArchivo)
        {
            string rutaDatos = ObtenerRutaPDF();
            return Path.Combine(rutaDatos, nombreArchivo);
        }

        public static string ObtenerRutaRecursos() 
        {
            string ruta = ConfigurationManager.AppSettings["RutaRecursos"];
            return Environment.ExpandEnvironmentVariables(ruta);
        }

        public static string ObtenerRutaArchivoImg(string nombreArchivo)
        {
            string rutaDatos = ObtenerRutaRecursos();
            return Path.Combine(rutaDatos, nombreArchivo);
        }

        public static string ObtenerRutaCupon(string nombreArchivo)
        {
            string rutaDatos = ObtenerRutaCupones();
            return Path.Combine(rutaDatos, nombreArchivo);
        }
        public static string ObtenerRutaCupones()
        {
            string ruta = ConfigurationManager.AppSettings["Cupon"];
            return Environment.ExpandEnvironmentVariables(ruta);
        }
    }
}
