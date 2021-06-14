using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public class KitPVC : DomoGeodesico, IAcciones
    {
        /// <summary>
        /// Constructor por defecto que no recibe parametros
        /// </summary>
        public KitPVC() :base()
        {

        }
        /// <summary>
        /// Constructor que recibe tres parametros
        /// </summary>
        /// <param name="radio"></param>
        /// <param name="frecuencia"></param>
        /// <param name="cliente"></param>
        public KitPVC(float radio, EFrecuencia frecuencia, string cliente) : base(radio, frecuencia, cliente)
        {
        }

        /// <summary>
        /// Propiedad publica de solo lectura que indica
        /// la cantidad de dias de fabricacion del domo solicitado
        /// </summary>
        public int CantidadDiasDeFabricacion
        {
            get
            {
                if (this.Frecuencia == EFrecuencia.F1)
                {
                    return 20;
                }
                else
                {
                    return 30;
                }
            }
        }

        /// <summary>
        /// Metodo que calcula la cantidad de m2 del domo
        /// </summary>
        /// <returns>Retorna un float con los m2 a utilizar por el domo</returns>
        protected override float CalcularM2()
        {
            float m2Domo = 0;
            m2Domo = (float)Math.PI * (float)Math.Pow(this.Radio, 2) / 2;

            return m2Domo;
        }


        /// <summary>
        /// Metodo que sobreescribe al metodo declarado en la base
        /// asignando mayor informacion del domo solicitado.
        /// </summary>
        /// <returns>Devuelve un string con los datos del domo</returns>
        public override string InformeFabricacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----- DOMO DE PVC -----");
            sb.AppendLine($"\n{base.InformeFabricacion()}");
            sb.AppendLine($"La cantidad de m2 es de {Decimal.Round((decimal)CalcularM2(), 2)}");
            sb.AppendLine($"Demora en fabricacion: {this.CantidadDiasDeFabricacion}");
            sb.AppendLine("-----------------------");

            return sb.ToString();

        }
    }
}
