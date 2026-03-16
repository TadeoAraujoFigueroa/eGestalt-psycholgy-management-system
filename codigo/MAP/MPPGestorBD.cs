using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP
{
    public class MPPGestorBD
    {
        string rutaDatos = ConfigurationManager.AppSettings["RutaDatos"];
        string rutaDatosBase;

        string rutaBackUp = ConfigurationManager.AppSettings["RutaBackup"];
        string rutaBackUpBase;

        public MPPGestorBD() 
        {
            rutaDatosBase = Environment.ExpandEnvironmentVariables(
            rutaDatos ?? "%LOCALAPPDATA%\\eGestalt\\Datos");

            rutaBackUpBase = Environment.ExpandEnvironmentVariables(
            rutaBackUp ?? "%LOCALAPPDATA%\\eGestalt\\Backups");

            //Crea la carpeta si no existe
            Directory.CreateDirectory(rutaBackUpBase);

            Directory.CreateDirectory(rutaDatosBase);
        }
        
        public bool CrearBackUp()
        {
            try
            {
                //Instancia el nombre del backUp segun la fecha y hora
                string nombreBackup = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}";

                //Obtiene la ruta donde se guardará el backUp
                string rutaBackUpNuevo = Path.Combine(rutaBackUpBase, nombreBackup);

                //Crea la carpeta
                Directory.CreateDirectory(rutaBackUpNuevo);

                //Copia los archivos xml
                foreach(string archivo in Directory.GetFiles(rutaDatosBase, "*.xml")) 
                {
                    //Crea la ruta donde copiar el archivo
                    string destino = Path.Combine(rutaBackUpNuevo, Path.GetFileName(archivo));

                    //Copiamos
                    File.Copy(archivo, destino, true);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool RealizarRestore(DateTime fecha)
        {
            try
            {

                //agarra el backUp seleccionado
                string nombreBackUp = $"Backup_{fecha:yyyyMMdd_HHmmss}";
                string backUpSeleccionado = Path.Combine(rutaBackUpBase, nombreBackUp);

                //Copia los XML en la carpeta de datos

                foreach (string archivo in Directory.GetFiles(backUpSeleccionado, "*.xml")) 
                {
                    if(archivo.Contains("bitacoras"))
                    {
                        //No actualizamos la bitacora al hacer restore
                        continue;
                    }
                    string destino = Path.Combine(rutaDatosBase, Path.GetFileName(archivo));
                    File.Copy (archivo, destino, true); 

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
