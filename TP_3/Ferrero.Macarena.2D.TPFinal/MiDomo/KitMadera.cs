using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public class KitMadera : DomoGeodesico, IAcciones
    {
        protected ETipoConexion tipoDeConexion;

        /// <summary>
        /// Constructor por defecto que no recibe parametros
        /// </summary>
        public KitMadera() :base()
        {

        }

        /// <summary>
        /// Constructor que recibe cuatro parametros
        /// </summary>
        /// <param name="radio">Float a asignar al atributo radio</param>
        /// <param name="frecuencia">EFrecuencia a asignar al atributo frecuencia</param>
        /// <param name="cliente">String a asignar al nombre del cliente</param>
        /// <param name="tipoConexion">ETipoConexion a asignar al tipo de conexion del domo</param>
        public KitMadera(float radio, EFrecuencia frecuencia, string cliente, ETipoConexion tipoConexion) : base(radio, frecuencia, cliente)
        {
            this.TipoDeConexion = tipoConexion;
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura de TIpoConexion 
        /// </summary>
        public ETipoConexion TipoDeConexion
        {
            get
            {
                return this.tipoDeConexion;
            }
            set
            {
                this.tipoDeConexion = value;
            }
        }

        /// <summary>
        /// Propiedad publica de solo lectura que indica
        /// la cantidad de dias de fabricacion del Domo Geodesico
        /// </summary>
        public int CantidadDiasDeFabricacion
        {
            get
            {
                if (this.Frecuencia == EFrecuencia.F1)
                {
                    return 35;
                }
                else
                {
                    return 45;
                }
            }
        }


        /// <summary>
        /// Metodo que calcula la cantidad de m2 necesarios
        /// para fabricar el domo
        /// </summary>
        /// <returns>Retorna un float con los m2 a utilizar</returns>
        protected override float CalcularM2()
        {
            float m2Domo;
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
            sb.AppendLine("----- DOMO DE MADERA -----");
            sb.AppendLine($"\n{base.InformeFabricacion()}");
            sb.AppendLine($"Tipo de conexion {this.TipoDeConexion}");
            sb.AppendLine($"La cantidad de m2 es de {Decimal.Round((decimal)CalcularM2(), 2)}");
            sb.AppendLine($"Demora en fabricacion: {this.CantidadDiasDeFabricacion}");
            sb.AppendLine("--------------------------");



            return sb.ToString();


        }
    }
}
