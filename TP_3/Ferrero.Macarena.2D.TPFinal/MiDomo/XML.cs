using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MiDomo
{
    public class XML<T> :IArchivo<T>
    {
        /// <summary>
        /// Metodo que lee un archivo
        /// </summary>
        /// <param name="rutaArchivo">String que indica donde se encuentra el archivo a leer</param>
        /// <param name="info">Indica donde se va a guardar lo leido</param>
        /// <returns>Retorna true si pudo leerlo, false si no</returns>
        public bool Leer(string rutaArchivo, out T info)
        {
            if (File.Exists(rutaArchivo))
            {
                using (XmlTextReader lectura = new XmlTextReader(rutaArchivo))
                {
                    XmlSerializer serial = new XmlSerializer(typeof(T));
                    info = (T)serial.Deserialize(lectura);
                }

                return true;
            }
            info = default(T);
            return false;
        }

        /// <summary>
        /// Metodo que guarda un archivo
        /// </summary>
        /// <param name="rutaArchivo">String que indica donde se va a guardar el archivo</param>
        /// <param name="info">Indica donde se va a guardar lo leido</param>
        /// <returns>Retorna true si pudo leerlo, false si no</returns>
        public bool Guardar(string rutaArchivo, T info)
        {
            using (XmlTextWriter escritura = new XmlTextWriter(rutaArchivo, Encoding.UTF8))
            {
                XmlSerializer serial = new XmlSerializer(typeof(T));
                serial.Serialize(escritura, info);
                return true;
            }
        }

    }
}
