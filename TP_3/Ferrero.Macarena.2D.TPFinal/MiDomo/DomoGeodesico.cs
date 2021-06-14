using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiDomo
{
    [XmlInclude(typeof(KitMadera))]
    [XmlInclude(typeof(KitPVC))]

    public abstract class DomoGeodesico
    {
        protected float radio;
        protected EFrecuencia frecuencia;
        protected string cliente;
        protected abstract float CalcularM2();


        /// <summary>
        /// Constructor por defecto que no recibe parametros
        /// </summary>
        public DomoGeodesico()
        {
        }

        /// <summary>
        /// Constructor que recibe 3 parametros
        /// </summary>
        /// <param name="radio">Float a asignar al atributo radio</param>
        /// <param name="frecuencia">Enumerado de frecuencia que se asigna al domo</param>
        /// <param name="cliente">String con el nombre del cliente que genera el pedido</param>
        public DomoGeodesico(float radio, EFrecuencia frecuencia, string cliente)
        {
            this.Radio = radio;
            this.Frecuencia = frecuencia;
            this.Cliente = cliente;
        }

        /// <summary>
        /// Propiedad publica de solo lectura que devuelve los M2 del domo
        /// </summary>
        public float M2
        {
            get
            {
                return CalcularM2();
            }
        }

        /// <summary>
        /// Propiedad publica de Radio de lectura y escritura,
        /// si al setear el radio, el valor no pertenece al rango establecido,
        /// se lanza una excepcion
        /// </summary>
        public float Radio
        {
            get
            {
                return this.radio;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    this.radio = value;
                }
                else
                {
                    throw new DomoException("Radio fuera del rango", "DomoGeodesico.cs", "Asignar radio");
                }
            }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura
        /// del atributo Frecuencia
        /// </summary>
        public EFrecuencia Frecuencia
        {
            get
            {
                return this.frecuencia;
            }
            set
            {
                if (value.GetType() == typeof(EFrecuencia))
                {
                    this.frecuencia = value;
                }
            }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura de cliente,
        /// si el nombre del cliente a asignar es muy corto se lanza una excepcion
        /// </summary>
        public string Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                if (value.Length > 2)
                {
                    this.cliente = value;
                }
                else
                {
                    throw new DomoException("Nombre cliente muy corto", "DomoGeodesico.cs", "Asignar nombre pedido");
                }
            }
        }

  
        /// <summary>
        /// Metodo Virtual que devuelve un string con la informacion del domo solicitado.
        /// </summary>
        /// <returns>Retorna un string ocn la informacion del domo solicitado</returns>
        public virtual string InformeFabricacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre del Cliente: {this.Cliente.ToUpper()}");
            sb.AppendLine($"Domo de radio: {this.Radio}");
            sb.AppendLine($"Frecuencia {this.Frecuencia}");

            return sb.ToString();
        }
    }
}
