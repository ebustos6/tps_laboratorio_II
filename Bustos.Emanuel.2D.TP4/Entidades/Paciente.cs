using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string nombre;
        private string apellido;
        private int nroObraSocial;


        public Paciente(string nombre, string apellido, int nroObraSocial)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroObraSocial = nroObraSocial;
        }

        /// <summary>
        /// Getter Nombre.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
        }

        /// <summary>
        /// Getter Apellido.
        /// </summary>
        public string Apellido 
        { 
            get { return apellido; }
        }

        /// <summary>
        /// Getter Obra Social.
        /// </summary>
        public int NroObraSocial 
        { 
            get { return nroObraSocial; }
        }

    }
}
