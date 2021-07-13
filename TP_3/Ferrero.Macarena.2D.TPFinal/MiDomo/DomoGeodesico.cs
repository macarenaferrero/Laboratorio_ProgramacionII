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
        protected int id;
        protected string cliente;
        protected float radio;
        protected EFrecuencia frecuencia;
        protected abstract float CalcularM2();
        protected EEstado estado;
        protected string material;
        protected ETipoConexion tipoDeConexion;


        /// <summary>
        /// Constructor por defecto que no recibe parametros
        /// </summary>
        public DomoGeodesico()
        {
        }

        /// <summary>
        /// Constructor que recibe 6 parametros
        /// </summary>
        /// <param name="radio">Float a asignar al atributo radio</param>
        /// <param name="frecuencia">Enumerado de frecuencia que se asigna al domo</param>
        /// <param name="cliente">String con el nombre del cliente que genera el pedido</param>
        /// <param name="tipoConexion">Enumerado que indica el tipo de conexion del domo</param>
        /// <param name="material">String que indica el material del domo</param>
        /// <param name="estado">Enumerado que indica el estado del domo pedido</param>
        public DomoGeodesico(float radio, EFrecuencia frecuencia, string cliente, ETipoConexion tipoConexion, string material, EEstado estado) : this()
        {
            //this.Id = id;
            this.Radio = radio;
            this.Frecuencia = frecuencia;
            this.Cliente = cliente;
            this.Estado = estado;
            this.TipoDeConexion = tipoConexion;
            this.Material = material;
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
        public DomoGeodesico(int id, float radio, EFrecuencia frecuencia, string cliente, ETipoConexion tipoConexion, string material, EEstado estado) : this(radio, frecuencia, cliente, tipoConexion, material, estado)
        {
            this.Id = id;
        }

        /// <summary>
        /// Propiedad Id de lectura y escritura
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
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
        /// Propiedad publica de solo lectura que devuelve los M2 del domo
        /// </summary>
        public float M2
        {
            get
            {
                float auxM2 = 0;
                return auxM2.RedondeoM2(CalcularM2());
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que devuelve el tipo de material del domo solicitado
        /// </summary>
        public string Material
        {
            get
            {
                return this.material;
            }
            set
            {
                if(!(String.IsNullOrWhiteSpace(value)))
                {
                    this.material = value;
                }
            }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura que devuelve el estado del domo
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }




        /// <summary>
        /// Metodo Virtual que devuelve un string con la informacion del domo solicitado.
        /// </summary>
        /// <returns>Retorna un string ocn la informacion del domo solicitado</returns>
        public virtual string InformeFabricacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Nombre del Cliente: {this.Cliente.ToUpper()}");
            sb.AppendLine($"Material: {this.Material}");
            sb.AppendLine($"Domo de radio: {this.Radio}");
            sb.AppendLine($"Frecuencia: {this.Frecuencia}");
            sb.AppendLine($"Tipo de conexion: {this.TipoDeConexion}");

            return sb.ToString();
        }
    }
}
