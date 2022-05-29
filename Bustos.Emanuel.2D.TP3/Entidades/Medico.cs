using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        static int id;
        private int legajo;
        private string nombre;
        private int matricula;
        private List<IDias> diasDisponibles;

        static Medico()
        {
            id = 10000;
        }

        public Medico(string nombre, int matricula, List<IDias> diasDisponibles)
        {
            this.legajo = id++;
            this.nombre = nombre;
            this.matricula = matricula;
            this.diasDisponibles = diasDisponibles;
        }
    }
}
