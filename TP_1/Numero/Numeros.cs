using System;

namespace Numeros
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Construccion con parametros
        /// </summary>
        /// <param name="numero">Valor recibido de tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="numero">Valor recibido de tipo string</param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        /// <summary>
        /// Valida que el parametro recibido sea un numero
        /// </summary>
        /// <param name="strNumero">Parametro recibido en string</param>
        /// <returns>Retorna el valor recibido en formato double si es correcto o 0 error</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;

            if(!(double.TryParse(strNumero, out retorno)))
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// Valida el dato recibido y se lo asigna a numero
        /// </summary>
        public string SetNumero { set => numero = ValidarNumero(value); }
        

        /// <summary>
        /// Valida que el dato string recibido sea Binario
        /// </summary>
        /// <param name="binario">Parametro recibido en string</param>
        /// <returns>Retorna true si es binario, sino false</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] arrayAux = binario.ToCharArray();

            for(int i=0; i< arrayAux.Length; i++)
            {
                if(arrayAux[i] != '0' && arrayAux[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// validará que se trate de un binario y luego convertirá ese número binario a decimal
        /// </summary>
        /// <param name="binario">Parametro del tipo string a validar y convertir</param>
        /// <returns>Retorna el valor recibido en decimal o "Valor invalido" en caso de error</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double acumulador = 0;
            char[] arrayAux = binario.ToCharArray();
            Array.Reverse(arrayAux);

            if(EsBinario(binario))
            {
                for(int i=0; i< arrayAux.Length; i++)
                {
                    if(arrayAux[i] == '1')
                    {
                        acumulador += Math.Pow(2,i);
                    }
                }
                retorno = acumulador.ToString();
            }
            return retorno;
        }


        /// <summary>
        /// Convierte numero decimal a binario
        /// </summary>
        /// <param name="numero">Valor del tipo double a convertir</param>
        /// <returns>Retorna numero binario si es posible o "Valor invalido" en caso de error</returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            int auxNum = (int)numero;

            if(auxNum > 0)
            {
                do
                {
                    if(auxNum % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }

                    auxNum = auxNum / 2;

                } while (auxNum > 0);
            }
            else
            {
                if(auxNum == 0)
                {
                    retorno = "0";
                }
                else
                {
                    retorno = "Valor invalido";
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte numero decimal a binario
        /// </summary>
        /// <param name="numero">Parametro recibido tipo string a convertir</param>
        /// <returns>Retorna valor convertido en string o "Valor incorrecto" en caso de error</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double numAux;
            if(double.TryParse(numero, out numAux))
            {
                retorno = DecimalBinario(numAux);
            }
            return retorno;
        }

        /// <summary>
        /// Resta dos valores de tipo Numero
        /// </summary>
        /// <param name="n1">Parametro recibido tipo Numero</param>
        /// <param name="n2">Parametro recibido tipo Numero</param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {            
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Suma dos valores de tipo Numero
        /// </summary>
        /// <param name="n1">Parametro recibido tipo Numero</param>
        /// <param name="n2">Parametro recibido tipo Numero</param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// Multiplica dos valores de tipo Numero
        /// </summary>
        /// <param name="n1">Parametro recibido tipo Numero</param>
        /// <param name="n2">Parametro recibido tipo Numero</param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Divide dos valores de tipo Numero
        /// </summary>
        /// <param name="n1">Parametro recibido tipo Numero</param>
        /// <param name="n2">Parametro recibido tipo Numero</param>
        /// <returns>Retorna el resultado de la division o el valor minimo ingresado si se dividió por 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
    }
}
