using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
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
