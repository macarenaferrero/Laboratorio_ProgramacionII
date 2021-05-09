using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        private ETipo tipo;
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }

        /// <summary>
        /// Constructor Sedan que recibe 3 parametros, por defecto TIPO será CuatroPuertas
        /// </summary>
        /// <param name="chasis">String chasis a asignar</param>
        /// <param name="marca">Enumerado marca a asignar</param>
        /// <param name="color">ConsoleColor color a asignar</param>
        public Sedan(string chasis, EMarca marca, ConsoleColor color)
            : this(chasis, marca, color, ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Constructor Sedan que recibe 4 parametros
        /// </summary>
        /// <param name="chasis">String chasis a asignar</param>
        /// <param name="marca">Enumerado marca a asignar</param>
        /// <param name="color">ConsoleColor color a asignar</param>
        /// <param name="tipo">Enumerado tipo a asignar</param>
        public Sedan(string chasis, EMarca marca, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// ReadOnly: Retornara el tamaño mediano que es SEDAN
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Metodo Mostrar que devuelve un string con los atributos del SEDAN
        /// </summary>
        /// <returns>string con los atributos a mostrar</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Tamaño : {this.Tamanio}");
            sb.AppendLine($"Tipo : {this.tipo}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
