using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Numeros
    {
        private double numero;


        #region Constructor
        /// <summary>
        /// Constructor que inicializa el atributo en 0
        /// </summary>
        public Numeros()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que setea el atributo con el valor que llegue por parametros
        /// </summary>
        /// <param name="strNumero">String con el numero con el que queremos que se inicialice nuestro atributo</param>
        public Numeros(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Constructor que recibe un double con el parametro que queremos setear nuestro atributo
        /// </summary>
        /// <param name="numero">Double con el valor que queremos setear</param>
        public Numeros(double numero)
        {
            this.numero = numero;
        }

        #endregion

        /// <summary>
        /// Propiedad que setea en numero el valor validado
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }


        #region Metodos
        /// <summary>
        /// Metodo que valida que lo que reciba sea un numero
        /// </summary>
        /// <param name="strNumero">String con el valor que se debe validar</param>
        /// <returns>Retorna el valor validado en tipo Double o 0 si no lo es</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (!(double.TryParse(strNumero, out retorno)))
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que corrobora que el valor recibido sea un binario
        /// </summary>
        /// <param name="binario">String recibido con el valor que se debe corroborar</param>
        /// <returns>Devuelve true si el valor es binario, false si no lo es</returns>
        public bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] arrayAux = binario.ToCharArray();

            for (int i = 0; i < arrayAux.Length; i++)
            {
                if (arrayAux[i] != '0' && arrayAux[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte el valor Binario recibido en un Decimal
        /// </summary>
        /// <param name="binario">String con el valor binario a convertir</param>
        /// <returns>Retorna el valor convertido en string o "Valor invalido" si lo recibido no es binario</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno;
            double auxSuma = 0;
            char[] arrayAux = binario.ToCharArray();
            Array.Reverse(arrayAux);

            if (EsBinario(binario))
            {
                //for (int i = arrayAux.Length - 1; i > 0; i--)
               for(int i=0; i < arrayAux.Length; i++)
                {
                    if (arrayAux[i] == '1')
                    {
                        auxSuma += Math.Pow(2, i);
                    }
                }
                retorno = auxSuma.ToString();
            }
            else
            {
                retorno = "Valor Invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte el valor recibido en Binario
        /// </summary>
        /// <param name="numero">Double recibido con el numero a convertir</param>
        /// <returns>Retorna la conversion en formato string o "Valor Invalido" si lo recibido no es mayor o igual a 0</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = string.Empty;
            numero = Math.Abs(numero);
            int auxDivision;

            if (numero >= 0)
            {

                if (numero == 0)
                {
                    retorno = "0";
                }
                while (numero > 0)
                {
                    auxDivision = (int)numero % 2;
                    retorno = auxDivision.ToString() + retorno;
                    numero = (int)numero / 2;
                }
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }


        /// <summary>
        /// Convierte el valor recibido en Binario
        /// </summary>
        /// <param name="numero">String con el numero a convertir</param>
        /// <returns>Retorna el valor convertido en string si se pudo convertir, sino "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            double auxDouble;
           // Double.TryParse(numero, out auxDouble);
           if(!(double.TryParse(numero, out auxDouble)))
            {
                return "Valor inválido";
            }

           return DecimalBinario(double.Parse(numero));
        }

        /// <summary>
        /// Genera la resta entre el primer elemento y el segundo
        /// </summary>
        /// <param name="n1">Primer objeto Numero a restar</param>
        /// <param name="n2">Segundo objeto Numero a restar</param>
        /// <returns>Retorna la resta entre ambos valores</returns>
        public static double operator -(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero - n2.numero;
            return retorno;
        }


        /// <summary>
        /// Genera la suma entre el primer elemento y el segundo
        /// </summary>
        /// <param name="n1">Primer objeto Numero a sumar</param>
        /// <param name="n2">Segundo objeto Numero a sumar</param>
        /// <returns>Retorna la suma entre ambos valores</returns>
        public static double operator +(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero + n2.numero;
            return retorno;
        }

        /// <summary>
        /// Genera la multiplicacion entre el primer elemento y el segundo
        /// </summary>
        /// <param name="n1">Primer objeto Numero a multiplicar</param>
        /// <param name="n2">Segundo objeto Numero a multiplicar</param>
        /// <returns>Retorna la multiplicacion entre ambos valores</returns>
        public static double operator *(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero * n2.numero;
            return retorno;
        }

        /// <summary>
        /// Genera la division entre el primer elemento y el segundo, corroborando que el segundo sea diferente de 0, sino devuelve el menor valor double
        /// </summary>
        /// <param name="n1">Primer objeto Numero divisor</param>
        /// <param name="n2">Segundo objeto Numero dividendo</param>
        /// <returns>Retorna la division entre los valores</returns>
        public static double operator /(Numeros n1, Numeros n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

        #endregion
    }

}





