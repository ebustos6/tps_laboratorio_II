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

        public string Nombre
        {
            get { return nombre; }
        }

        public string Apellido 
        { 
            get { return apellido; }
        }

        public int NroObraSocial 
        { 
            get { return nroObraSocial; }
        }

    }
}
