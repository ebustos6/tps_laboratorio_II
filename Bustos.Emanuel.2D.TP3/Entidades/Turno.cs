using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private Medico medico;
        private IDias dia;
        private string horario;

        public Turno(Medico medico, IDias dia, string horario)
        {
            this.medico = medico;
            this.dia = dia;
            this.horario = horario;
        }
    }
}
