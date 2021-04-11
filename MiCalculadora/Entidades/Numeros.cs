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

        public Numeros()
        {
            this.numero = 0;
        }

        public Numeros(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public Numeros(double numero)
        {
            this.numero = numero;
        }

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (!(double.TryParse(strNumero, out retorno)))
            {
                retorno = 0;
            }
            return retorno;
        }

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

        public static double operator -(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero - n2.numero;
            return retorno;
        }

        public static double operator +(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero + n2.numero;
            return retorno;
        }

        public static double operator *(Numeros n1, Numeros n2)
        {
            double retorno = 0;
            retorno = n1.numero * n2.numero;
            return retorno;
        }

        public static double operator /(Numeros n1, Numeros n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }


    }

}





