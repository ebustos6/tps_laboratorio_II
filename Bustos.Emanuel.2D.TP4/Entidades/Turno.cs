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

        /// <summary>
        /// Getter Id del turno.
        /// </summary>
        public int IdTurno
        {
            get { return this.idTurno; }
        }

        /// <summary>
        /// Getter de Matricula del medico asociado al turno.
        /// </summary>
        public int Medico 
        { 
            get { return this.medico; } 
        }

        /// <summary>
        /// Getter de Obra Social del paciente asociado al turno.
        /// </summary>
        public int Paciente
        {
            get { return this.paciente; }
        }

        /// <summary>
        /// Getter de Fecha del turno.
        /// </summary>
        public DateTime Fecha
        {
            get { return this.fecha; }
        }

        /// <summary>
        /// Getter horario del turno.
        /// </summary>
        public string Horario
        {
            get { return this.horario; }
        }

    }
}
