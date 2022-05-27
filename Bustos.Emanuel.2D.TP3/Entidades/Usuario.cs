using System;

namespace Entidades
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string pass;


        public Usuario(int id, string nombre, string pass)
        {
            this.id = id;
            this.nombre = nombre;
            this.pass = pass;
        }

        public int Id
        {
            get { return this.id; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        /// <summary>
        /// compara si el string ingresado por parametro es igual al atributo pass.
        /// </summary>
        /// <param name="pass"></param>
        /// <returns>un bool indicando si son iguales o no</returns>
        public bool ValidarPass(string pass)
        {
            return (!string.IsNullOrWhiteSpace(pass) && pass.Trim() == this.pass.Trim());
        }
    }
}
