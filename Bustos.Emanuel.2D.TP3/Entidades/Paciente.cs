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
        private Turno turno;

        public Paciente(string nombre, string apellido, int nroObraSocial)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroObraSocial = nroObraSocial;
            this.turno = null;
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

        public bool AsignarTurno(Turno turno)
        {
            if (this.turno is null && turno is not null)
            {
                this.turno = turno;
                return true;
            }
            return false;
        }
    }
}
