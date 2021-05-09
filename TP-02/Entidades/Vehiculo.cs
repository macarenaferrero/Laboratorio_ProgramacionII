using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    public abstract class Vehiculo
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda,
            HarleyDavidson
        }
        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }

        /// <summary>
        /// Constructor de Vehiculo que recibe 3 parametros
        /// </summary>
        /// <param name="chasis">String chasis a asignar</param>
        /// <param name="marca">Enumerado marca a asignar</param>
        /// <param name="color">ConsoleColor color a asignar</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño del vehiculo
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retorno un string con lo datos del vehiculo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }


        /// <summary>
        /// String que retorna los datos del vehiculo
        /// </summary>
        /// <param name="p">Instancia del tipo de Vehiculo</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            if (p != null)
            {
                sb.AppendLine($"Chasis: {p.chasis}");
                sb.AppendLine($"Color: {p.color}");
                sb.AppendLine($"Marca: {p.marca}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer instancia de Vehiculo a comparar</param>
        /// <param name="v2">Segundo instancia de Vehiculo a comparar</param>
        /// <returns>Devuelvo True si los chasis son iguales, False si son distintos</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (!(v1 is null) && !(v2 is null))
            {
                return (v1.chasis == v2.chasis);
            }
            return false;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer instancia de Vehiculo a comparar</param>
        /// <param name="v2">Segundo instancia de Vehiculo a comparar</param>
        /// <returns>Devuelvo False si los chasis son iguales, True si son distintos</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
