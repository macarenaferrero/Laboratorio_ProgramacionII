using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public static class Extension
    {
        /// <summary>
        /// Extension de la clase Float que redondea el valor de los m2
        /// </summary>
        /// <param name="m2">Parametro float</param>
        /// <param name="m2Original">Valor que recibe por parametros a redondear</param>
        /// <returns></returns>
        public static float RedondeoM2(this float m2, float m2Original)
        {
            return (float)Math.Round(m2Original, 2);
        }
    }
}
