using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// constructor sin parametros.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// constructor que recibe un double.
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero):this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// constructor que recibe un string y lo envia a su atributo.
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero):this()
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// atributo que recibe un string y lo carga como double.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// valida que un string se pueda convertir a doble.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>aux if true, 0 if false</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double aux))
            {
                return aux;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// valida que un numero sea binario.
        /// </summary>
        /// <param name="Binario"></param>
        /// <returns></returns>
        private bool EsBinario(string Binario)
        {
            for (int i = 0; i < Binario.Length - 1; i++)
            {
                if (Binario.Substring(i, 1) != "1" && Binario.Substring(i, 1) != "0")
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            int pos = binario.Length;
            int acum = 0;

            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length - 1; i++)
                {
                    pos--;
                    if (int.TryParse(binario.Substring(i, 1), out int num))
                    {
                        num *= (int)Math.Pow(2, pos - 1);
                        acum += num;
                    }
                }
                binario = acum.ToString();
            }
            else
            {
                binario = "Valor inválido.";
            }
            return binario;
        }

        /// <summary>
        /// recibe un double y devuelve un string con ese numero convertido a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string bin = " ";

            if (Math.Abs((int)numero) > 0)
            {
                while (Math.Abs((int)numero) > 0)
                {
                    if (Math.Abs((int)numero) % 2 == 0)
                    {
                        bin = "0" + bin;
                    }
                    else
                    {
                        bin = "1" + bin;
                    }
                    numero /= 2;
                }
            }
            else
            {
                if (numero == 0)
                {
                    bin = "0";
                }
            }

            return bin;
        }

        /// <summary>
        /// recibe un string y si se puede pasar a double se lo envia a DecimalBinario(double) para ser convertido.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double result) && result != double.MinValue)
            {
                return DecimalBinario(result);
            }
            else
            {
                return "Valor inválido.";
            }
        }

        /// <summary>
        /// sobrecarga el operador "+" entre 2 objetos de tipo "Operando".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// sobrecarga el operador "-" entre 2 objetos de tipo "Operando".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// sobrecarga el operador "*" entre 2 objetos de tipo "Operando".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// sobrecarga el operador "/" entre 2 objetos de tipo "Operando".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if (num2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return num1.numero / num2.numero;
            }
        }
    }
}
