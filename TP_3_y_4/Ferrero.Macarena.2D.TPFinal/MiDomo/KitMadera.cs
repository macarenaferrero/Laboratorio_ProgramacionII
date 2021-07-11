using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDomo
{
    public class KitMadera : DomoGeodesico, IAcciones
    {

        /// <summary>
        /// Constructor por defecto que no recibe parametros
        /// </summary>
        public KitMadera() :base()
        {
            
        }

        /// <summary>
        /// Constructor que recibe 6 parametros
        /// </summary>
        /// <param name="radio">Float a asignar al atributo radio</param>
        /// <param name="frecuencia">EFrecuencia a asignar al atributo frecuencia</param>
        /// <param name="cliente">String a asignar al nombre del cliente</param>
        /// <param name="tipoConexion">ETipoConexion a asignar al tipo de conexion del domo</param>
        /// <param name="material">String que indica el material del domo</param>
        /// <param name="estado">Enumerado que indica el estado del domo pedido</param>
        public KitMadera(float radio, EFrecuencia frecuencia, string cliente, ETipoConexion tipoConexion, string material, EEstado estado) : base(radio, frecuencia, cliente, tipoConexion, material, estado)
        {
        }

        /// <summary>
        /// Constructor que recibe 7 parametros
        /// </summary>
        /// <param name="id">Int que se asigna automaticamente al ingresar a la base de datos</param>
        /// <param name="radio">Float a asignar al atributo radio</param>
        /// <param name="frecuencia">Enumerado de frecuencia que se asigna al domo</param>
        /// <param name="cliente">String con el nombre del cliente que genera el pedido</param>
        /// <param name="tipoConexion">Enumerado que indica el tipo de conexion del domo</param>
        /// <param name="material">String que indica el material del domo</param>
        /// <param name="estado">Enumerado que indica el estado del domo pedido</param>
        public KitMadera(int id, float radio, EFrecuencia frecuencia, string cliente, ETipoConexion tipoConexion, string material, EEstado estado) : base(id, radio, frecuencia, cliente, tipoConexion, material, estado)
        {
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
            float aux = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\n{base.InformeFabricacion()}");
            sb.AppendLine($"La cantidad de m2 es de {aux.RedondeoM2(CalcularM2())}");
            sb.AppendLine($"Demora en fabricacion: {this.CantidadDiasDeFabricacion}");
            sb.AppendLine("--------------------------");

            return sb.ToString();


        }
    }
}
