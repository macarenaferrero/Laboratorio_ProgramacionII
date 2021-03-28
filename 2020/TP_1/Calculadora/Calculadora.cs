using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numeros;

namespace Calcular
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char recibido sea "+, -, *, /"
        /// </summary>
        /// <param name="operador">Operador recibido en char</param>
        /// <returns>Retorna operador en string o "+" si es erroneo</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno;
            retorno = "+";

            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                retorno = Convert.ToString(operador);
            }

            return retorno;
        }

        /// <summary>
        /// validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1">Valor a operar de tipo Numero</param>
        /// <param name="num2">Valor a operar de tipo Numero</param>
        /// <param name="operador">Operador en formato string</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char auxValidar;
            string auxOperador;

            auxValidar = Convert.ToChar(operador);
            auxOperador = ValidarOperador(auxValidar);

            switch(auxOperador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
