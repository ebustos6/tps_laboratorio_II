using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private static int id;
        private int idTurno;
        private int medico;
        private int paciente;
        private int dia;
        private int mes;
        private int anio;
        private string horario;

        static Turno()
        {
            id = 1;
        }
        public Turno(int medico, int paciente, int dia, int mes, int anio, string horario)
        {
            this.idTurno = id++;
            this.medico = medico;
            this.paciente = paciente;
            this.dia = dia;
            this.horario = horario;
            this.mes = mes;
            this.anio = anio;
        }

        public int Medico 
        { 
            get { return this.medico; } 
        }

        public int Paciente
        {
            get { return this.medico; }
        }

        public int Dia 
        { 
            get { return this.dia; } 
        }

        public int Mes
        {
            get { return this.mes; }
        }

        public int Anio
        {
            get { return this.anio; }
        }

        public string Horario
        {
            get { return this.horario; }
        }
    }
}
