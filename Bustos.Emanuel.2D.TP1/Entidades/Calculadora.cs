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
        /// realiza operaciones aritmeticas.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, string operador)
        {
            char op;
            if (operador == string.Empty)
            {
                op = ' ';
            }
            else
            {
                op = operador[0];
            }

            switch (ValidarOperador(op))
            {
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// valida los operadores recibidos para la operacion aritmetica.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '-':
                    return "-";
                case '*':
                    return "*";
                case '/':
                    return "/";
                default:
                    return "+";
            }
        }
    }
}
