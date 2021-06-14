using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Guarda un objeto del tipo T en un archivo en una ruta declarada
        /// </summary>
        /// <param name="rutaArchivo">String donde se creara el archivo</param>
        /// <param name="info">Objeto T con la informacion a guardar en el archivo</param>
        /// <returns>Retorna true si pudo hacerlo, False sino</returns>
        bool Guardar(string rutaArchivo, T info);

        /// <summary>
        /// Lee un archivo en la ruta declarada
        /// </summary>
        /// <param name="rutaArchivo">String de donde se leera el archivo</param>
        /// <param name="info">Objeto T con la informacion a leer en el archivo</param>
        /// <returns>Retorna true si pudo hacerlo, False sino</returns>
        bool Leer(string rutaArchivo, out T info);

    }
}
