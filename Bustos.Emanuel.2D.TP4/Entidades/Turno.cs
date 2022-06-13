using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int idTurno;
        private int medico;
        private int paciente;
        private DateTime fecha;
        private string horario;

        public Turno(int id, int medico, int paciente, DateTime fecha, string horario)
        {
            this.idTurno = id;
            this.medico = medico;
            this.paciente = paciente;
            this.fecha = fecha;
            this.horario = horario;

        }

        public int IdTurno
        {
            get { return this.idTurno; }
        }

        public int Medico 
        { 
            get { return this.medico; } 
        }

        public int Paciente
        {
            get { return this.paciente; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
        }

        public string Horario
        {
            get { return this.horario; }
        }

    }
}
