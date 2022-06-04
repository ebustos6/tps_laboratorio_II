using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Certificado
    {
        private static string ruta;

        static Certificado()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ruta += @"/Certificados de Atencion";
        }

        public static void Escribir(Paciente paciente, Medico medico, DateTime fecha, string horario)
        {
            string nombreArchivo = ruta + @"/Certificado_" + paciente.NroObraSocial.ToString() + $"_{fecha.Day}_{fecha.Month}_{fecha.Year}.txt";

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    writer.WriteLine($"El paciente {paciente.Apellido}, {paciente.Nombre} cuyo nro de obra social es: {paciente.NroObraSocial}");
                    writer.WriteLine($"fue atendido en esta institucion por el {medico.Nombre}, el dia {fecha.Day}/{fecha.Month}/{fecha.Year} a las {horario}hs.");
                    writer.WriteLine("\n\n\n\n\nSaluda Atte.\nFirma del profesional.");
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error en el archivo {nombreArchivo}, metodo Escribir()");
            }
            
            
        }



    }
}
