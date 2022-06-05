using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private static int id;
        private int legajo;
        private string nombre;
        private int matricula;
        private List<IDias> diasDisponibles;

        static Medico()
        {
            id = 10000;
        }

        public Medico()
        {

        }

        public Medico(string nombre, int matricula, List<IDias> diasDisponibles)
        {
            this.legajo = id++;
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

        public List<IDias> DiasDisponibles
        {
            get { return this.diasDisponibles; }
            set { this.diasDisponibles = value; }
        }

        public bool EstaDisponible(int dia)
        {
            foreach (IDias item in this.diasDisponibles)
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
