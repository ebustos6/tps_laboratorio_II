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

        /// <summary>
        /// Getter y Setter Legajo.
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        /// <summary>
        /// Getter y Setter Nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Getter y Setter Matricula.
        /// </summary>
        public int Matricula
        {
            get { return this.matricula; }
            set { this.matricula = value; }
        }

        /// <summary>
        /// Getter y Setter Lista de Dias Disponibles.
        /// </summary>
        public List<Dias> DiasDisponibles
        {
            get { return this.diasDisponibles; }
            set { this.diasDisponibles = value; }
        }

        /// <summary>
        /// Recorre la lista de dias disponibles para saber si el dia ingresado por parametros esta disponible.
        /// </summary>
        /// <param name="dia"></param>
        /// <returns>Un booleano indicando si esta disponible o no.</returns>
        public bool EstaDisponible(int dia)
        {
            return this.diasDisponibles.Exists(d => (int)d == dia);
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() para agregar el Dr. antes del nombre.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Dr. " + this.Nombre;
        }

    }
}
