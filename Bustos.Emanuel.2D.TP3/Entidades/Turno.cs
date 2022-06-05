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

        public Turno()
        {

        }

        public Turno(int medico, int paciente, DateTime fecha, string horario)
        {
            this.idTurno = Consultorio.GenerarSiguienteIdTurno();
            this.medico = medico;
            this.paciente = paciente;
            this.fecha = fecha;
            this.horario = horario;

        }

        public int IdTurno
        {
            get { return this.idTurno; }
            set { this.idTurno = value; }
        }

        public int Medico 
        { 
            get { return this.medico; } 
            set { this.medico = value; }
        }

        public int Paciente
        {
            get { return this.paciente; }
            set { this.paciente = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public string Horario
        {
            get { return this.horario; }
            set { this.horario = value; }
        }

    }
}
