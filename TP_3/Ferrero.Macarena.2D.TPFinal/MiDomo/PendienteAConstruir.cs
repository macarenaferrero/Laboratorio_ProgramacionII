using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    [Serializable]
    public class PendienteAConstruir<T>
        where T : DomoGeodesico
    {
        protected List<T> listadoPendientes;

        /// <summary>
        /// Constructor que inicializa la lista generica
        /// </summary>
        public PendienteAConstruir()
        {
            listadoPendientes = new List<T>();
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura,
        /// que devuelve la lista
        /// </summary>
        public List<T> ListaPendientes
        {
            get
            {
                return listadoPendientes;
            }
            set
            {
                listadoPendientes = value;
            }

        }

        /// <summary>
        /// Sobrecarga del operador mas que asigna
        /// domos a la lista de pendientes a construir,
        /// si la lista no tiene stock o el objeto a agregar es nulo
        /// se lanza una Exception
        /// </summary>
        /// <param name="listado">PendienteAConstruir<T> listado generico donde se agregara el objeto</param>
        /// <param name="domo">T Domo generico que se agregara a la lista</param>
        /// <returns>Retorna true si pudo agregarlo o false si no pudo</returns>
        public static bool operator +(PendienteAConstruir<T> listado, T domo)
        {
            try
            {
                if (listado != null && domo != null && Fabrica.StockM2Madera >= ((DomoGeodesico)domo).M2)
                {
                    listado.listadoPendientes.Add(domo);
                    if (domo.GetType() == typeof(KitMadera))
                    {
                        Fabrica.StockM2Madera -= domo.M2;
                    }
                    else
                    {
                        Fabrica.StockM2PVC -= domo.M2;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new DomoException("Uno de los objetos que desea añadir es nulo o No hay stock", "PendienteAConstruir.cs", "Sobrecarga operador +", e);
            }

        }


    }
}
