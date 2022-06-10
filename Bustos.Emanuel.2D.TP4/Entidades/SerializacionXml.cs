using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class SerializacionXml<T>
    {
        private static string ruta;

        static SerializacionXml()
        {
            ruta = AppDomain.CurrentDomain.BaseDirectory;
            ruta += @"/Objetos";
        }

        public static void Serializar(T dato, string archivo)
        {
            string nombreArchivo = ruta + @"/Lista_" + archivo + ".xml";

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, dato);
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error en el archivo {nombreArchivo}, metodo Escribir()");
            }


        }

        public static T Deserializar(string nombre)
        {
            string archivo = string.Empty;
            T dato = default;

            try
            {
                if (Directory.Exists(ruta))
                {
                    string[] archivos = Directory.GetFiles(ruta);

                    foreach (string item in archivos)
                    {
                        if (item.Contains(nombre))
                        {
                            archivo = item;
                            break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(archivo))
                    {
                        using (StreamReader reader = new StreamReader(archivo))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            dato = (T)serializer.Deserialize(reader);
                        }
                    }
                }



                return dato; 
            }
            catch (Exception)
            {

                throw new Exception($"Error en el archivo {archivo}, metodo Escribir()");
            }
        }

    }
}
