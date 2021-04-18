using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Calcula los valores segun el operador seleccionado
        /// </summary>
        /// <param name="num1">Objeto Numero</param>
        /// <param name="num2">Objeto Numero</param>
        /// <param name="operador">String que indica la operacion</param>
        /// <returns>Retorna el valor de la operacion realizada en formato double</returns>
        public static double Operar(Numeros num1, Numeros num2, string operador)
        {
            double respuesta = 0;
            char.TryParse(operador, out char auxValidar);
            //char auxValidar =  Convert.ToChar(operador);

            string auxOperador = ValidarOperador(auxValidar);


            if (num1 != null && num2 != null)
            {
                switch (auxOperador)
                {
                    case "+":
                        respuesta = num1 + num2;
                        break;
                    case "-":
                        respuesta = num1 - num2;
                        break;
                    case "*":
                        respuesta = num1 * num2;
                        break;
                    case "/":
                        respuesta = num1 / num2;
                        break;
                }
            }
            return respuesta;
        }


        /// <summary>
        /// Valida que el valor ingresado sea un signo matematico, de lo contrario devuelve +
        /// </summary>
        /// <param name="operador">Char que indica que operacion a realizar</param>
        /// <returns>Retorna el caracter validado en forma de string</returns>
        private static string ValidarOperador(char operador)
        {
            string aux = "+";
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                //operador.ToString();
                return Convert.ToString(operador);
            }
            return aux;
        }
    }
}
