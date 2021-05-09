using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

        #region "Constructores"

        /// <summary>
        /// Constructor privado que instancia la lista
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor de Taller que recibe un parametro
        /// </summary>
        /// <param name="espacioDisponible">Int con espacio disponible a asignar</param>
        public Taller(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Metodo que muestra en pantalla todos los vehiculos en el taller
        /// </summary>
        /// <returns>Retorna string con los datos a imprimir</returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo que lista todos los vehiculos del tipo que se solicite en la lista
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>String con los datos solicitados</returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorna el talle con el vehiculo si pudo agregarlo</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (!(taller is null) && !(vehiculo is null) && taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Retorna el talle con el vehiculo si pudo eliminarlo</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            if (!(taller is null) && !(vehiculo is null))
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        taller.vehiculos.Remove(vehiculo);
                        return taller;
                    }
                }
            }
            return taller;
        }
        #endregion
    }
}
