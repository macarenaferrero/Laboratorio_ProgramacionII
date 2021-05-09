using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {

        /// <summary>
        /// Constructor SUV que recibe 3 parametros
        /// </summary>
        /// <param name="chasis">String chasis a asignar</param>
        /// <param name="marca">Enumerado marca a asignar</param>
        /// <param name="color">ConsoleColor color a asignar</param>
        public Suv(string chasis, EMarca marca, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// ReadOnly: Retornara el tamaño mediano que es SUV
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }

        /// <summary>
        /// Metodo Mostrar que devuelve un string con los atributos del SUV
        /// </summary>
        /// <returns>String con los atributos a mostrar</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Tamaño : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
