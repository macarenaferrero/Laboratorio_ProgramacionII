using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public class DomoException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        /// <summary>
        /// Constructor que recibe 3 parametros
        /// </summary>
        /// <param name="mensaje">String que indica el mensaje del problema</param>
        /// <param name="clase">String a asignar en el atributo nombreClase</param>
        /// <param name="metodo">String a asignar en el atributo nombreMetodo</param>
        public DomoException(string mensaje, string clase, string metodo) : this(mensaje, clase, metodo, null)
        {
        }

        /// <summary>
        /// Constructor que recibe 4 parametros
        /// </summary>
        /// <param name="mensaje">String que indica el mensaje del problema</param>
        /// <param name="clase">String a asignar en el atributo nombreClase</param>
        /// <param name="metodo">String a asignar en el atributo nombreMetodo</param>
        /// <param name="innerException">Tipo Excepcion que indica la raiz del problema</param>
        public DomoException(string mensaje, string clase, string metodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = clase;
            this.nombreMetodo = metodo;
        }

        /// <summary>
        /// Propiedad publica de lectura de NombreClase
        /// </summary>
        public string NombreClase
        {
            get
            {
                return this.nombreClase;
            }
        }

        /// <summary>
        /// Propiedad publica de lectura de NombreMetodo
        /// </summary>
        public string NombreMetodo
        {
            get
            {
                return this.nombreMetodo;
            }
        }

        /// <summary>
        /// Sobrecarga del ToString() que devuelve un string con la informacion del excepcion
        /// </summary>
        /// <returns>Retorna un string con la informacion de la Exception generada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Excepcion en el metodo {this.NombreMetodo} de la clase {this.NombreClase}");
            sb.AppendLine("Error! Revisa el detalle.");
            sb.AppendLine($"Detalle: {this.Message}");

            return sb.ToString();
        }

    }
}
