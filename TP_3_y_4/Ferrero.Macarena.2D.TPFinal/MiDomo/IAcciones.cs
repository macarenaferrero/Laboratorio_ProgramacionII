using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public interface IAcciones
    {
        /// <summary>
        /// Propiedad de solo lectura, indica cantidad de dias de Fabricacion
        /// </summary>
        int CantidadDiasDeFabricacion { get; }        

    }
}
