using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Servicios;
using System.IO;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Forms;

namespace BLL
{
    public class HistoriaClinicaService
    {
        //Directorio Principal
        private readonly string _carpetaHistorias;

        //String de estado
        private string _estado;

        public HistoriaClinicaService()
        {
            // Ruta del proyecto (3 niveles hacia atrás desde /bin/Debug)
            string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            _carpetaHistorias = Path.Combine(basePath, "HistoriasClinicas");

            if (!Directory.Exists(_carpetaHistorias))
                Directory.CreateDirectory(_carpetaHistorias);
        }

        public bool CambiarEstado(string nombre, string apellido, string estado) 
        {
            try
            {
                string ruta = ObtenerRutaHistoria(nombre, apellido);
                if (!File.Exists(ruta)) return false;

                var lineas = File.ReadAllLines(ruta);

                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].Contains("Estado:"))
                    {
                        if (estado == "Cerrada") 
                        {
                            lineas[i] = lineas[i].Replace("Abierta", estado);
                        }
                        else 
                        {
                            lineas[i] = lineas[i].Replace("Cerrada", estado);
                        }
                        
                    }
                }

                File.WriteAllLines(ruta, lineas);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public string ObtenerRutaHistoria(string nombre, string apellido)
        {
            string nombreArchivo = $"{apellido}_{nombre}_historia.txt";
            return Path.Combine(_carpetaHistorias, nombreArchivo);
        }
        public string LeerHistoria(string nombre, string apellido, out string _estado)
        {
            try
            {
                string ruta = ObtenerRutaHistoria(nombre, apellido);
                _estado = "Abierta";
           

                if (!File.Exists(ruta)) 
                {
                    string rtf = $@"{{\rtf1\ansi
                    \b # Estado: \b0 Abierta\par
                    \b # Paciente: \b0 {apellido}, {nombre}\par
                    \par
                     }}";

                    File.WriteAllText(ruta, rtf);
                    return ruta;
                
                }
                else 
                {
                    var lineas = File.ReadAllLines(ruta);
                    var estadoLinea = lineas.FirstOrDefault(l => l.Contains("Estado:"));
                    if (estadoLinea != null)
                        _estado = estadoLinea.Split(':')[1].Substring(5, 7).Trim();
                    return ruta;
                }
                  
            
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public bool GuardarHistoria(string nombre, string apellido, RichTextBox rb)
        {
            try
            {
                string ruta = ObtenerRutaHistoria(nombre, apellido);
                rb.SaveFile(ruta, RichTextBoxStreamType.RichText);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }
    }


}
