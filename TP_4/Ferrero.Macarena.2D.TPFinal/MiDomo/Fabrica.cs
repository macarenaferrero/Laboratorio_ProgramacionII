using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{

    public static class Fabrica
    {
        static double stockM2Madera;
        static double stockM2PVC;

        /// <summary>
        /// Constructor estatico que inicializa 
        /// el stock de los materiales diarios
        /// </summary>
        static Fabrica()
        {
            StockM2Madera = 100;
            StockM2PVC = 70;
        }

        /// <summary>
        /// Propiedad publica de StockMadera de lectura y escritura,
        /// que devuelve el stock del material
        /// </summary>
        public static double StockM2Madera
        {
            get
            {
                return stockM2Madera;
            }
            set
            {
                stockM2Madera = value;
            }
        }

        /// <summary>
        /// Propiedad publica de StockPVC de lectura y escritura,
        /// que devuelve el stock del material
        /// </summary>
        public static double StockM2PVC
        {
            get
            {
                return stockM2PVC;
            }
            set
            {
                stockM2PVC = value;
            }
        }
    }
}
