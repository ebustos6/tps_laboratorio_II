using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private int legajo;
        private string nombre;
        private int matricula;
        private List<Dias> diasDisponibles;

        public Medico()
        {

        }

        public Medico(string nombre, int matricula, List<Dias> diasDisponibles)
        {
            this.legajo = Consultorio.GenerarSiguienteIdMedico();
            this.nombre = nombre;
            this.matricula = matricula;
            this.diasDisponibles = diasDisponibles;
        }

        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Matricula
        {
            get { return this.matricula; }
            set { this.matricula = value; }
        }

        public List<Dias> DiasDisponibles
        {
            get { return this.diasDisponibles; }
            set { this.diasDisponibles = value; }
        }

        public bool EstaDisponible(int dia)
        {
            foreach (Dias item in this.diasDisponibles)
            {
                if ((int)item == dia)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "Dr. " + this.Nombre;
        }

    }
}
