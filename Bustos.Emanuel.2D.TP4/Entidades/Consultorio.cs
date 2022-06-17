using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Dias
    {
        Domingo,
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado
    }

    public static class Consultorio
    {
        private static List<Usuario> usuarios;
        private static List<string> horarios;
        private static List<Medico> medicos;
        private static List<Turno> turnos;
        private static List<Paciente> pacientes;

        static Consultorio()
        {
            usuarios = new List<Usuario>();
            AgregarUsuarios();
            horarios = new List<string>();
            AgregarHorarios();
            medicos = SerializacionXml<List<Medico>>.Deserializar("Medicos");
            turnos = AccesoDB.LeerTurnos();
            pacientes = AccesoDB.LeerPacientes();
        }

        public static List<string> Horarios
        {
            get
            {
                if (horarios is null || horarios.Count <= 0)
                {
                    throw new ListaInexistenteException("No existe una lista de horarios, o esta vacia.");
                }
                return horarios; 
            }
        }

        public static List<Medico> Medicos
        {
            get { return medicos; }
        }

        public static List<Paciente> Pacientes
        {
            get { return pacientes; }
        }

        /// <summary>
        /// Crea objetos de tipo Usuario y los agrega a la lista correspondiente.
        /// </summary>
        private static void AgregarUsuarios()
        {
            usuarios.Add(new Usuario(64031, "Ema", "123"));
            usuarios.Add(new Usuario(64060, "Alberto", "123"));
            usuarios.Add(new Usuario(64029, "Wally", "123"));
            usuarios.Add(new Usuario(64055, "Silvina", "123"));
        }

        /// <summary>
        /// recorre la lista de usuarios y verifica que los parametros ingresados correspondan a un usuario valido.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns>devuelve un bool informando si se logro o no</returns>
        public static bool LoggearUsuario(string usuario, string pass)
        {
            if (usuarios is not null && usuarios.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(pass))
                {
                    throw new Exception("Los campos de usuario y contraseña no deben ser nulos o estar vacios.");
                }
                else
                {
                    return usuarios.Exists(u => u.Nombre == usuario && u.ValidarPass(pass));
                }   
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de usuarios, o esta vacia.");
            }
        }

        private static void AgregarHorarios()
        {
            horarios.Add("9:00");
            horarios.Add("9:30");
            horarios.Add("10:00");
            horarios.Add("10:30");
            horarios.Add("11:00");
            horarios.Add("11:30");
            horarios.Add("12:00");
            horarios.Add("12:30");
            horarios.Add("13:00");
            horarios.Add("13:30");
            horarios.Add("14:00");
            horarios.Add("14:30");
            horarios.Add("15:00");
            horarios.Add("15:30");
            horarios.Add("16:00");
            horarios.Add("16:30");
        }

        private static List<string> HorariosOcupados(DateTime dia, int medico)
        {
            List<string> ocupados = new List<string>();
            foreach (Turno item in turnos)
            {
                if (item.Medico == medico && item.Fecha == dia)
                {
                    ocupados.Add(item.Horario);
                }
            }

            return ocupados;
        }
        
        private static bool EstaOcupado(string horario, DateTime dia, int medico)
        {
            return HorariosOcupados(dia, medico).Exists(h => h == horario);
        }
        
        public static List<string> HorariosDisponibles(DateTime dia, int medico)
        {
            if (horarios is not null || horarios.Count > 0)
            {
                return horarios.FindAll(h => !EstaOcupado(h, dia, medico));
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de horarios o esta vacia.");
            }
        }

        public static int GenerarSiguienteIdMedico()
        {
            int id = 10000;
            if (medicos is not null)
            {
                foreach (Medico dr in medicos)
                {
                    if (dr.Legajo > id)
                    {
                        id = dr.Legajo;
                    }
                }
            }
            return id + 1;
        }

        public static Medico BuscarMedicoPorMatricula(int matricula)
        {
            if (medicos is not null)
            {
                return medicos.Find(m => m.Matricula == matricula);
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de Medicos.");
            }
        }

        public static List<Medico> ListarMedicosPorDia(int dia)
        {
            if (medicos is not null)
            {
                return medicos.FindAll(m => m.EstaDisponible(dia));
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de Medicos.");
            }
        }

        public static bool CrearMedico(string nombre, int matricula, List<Dias> diasDisponibles)
        {
            try
            {
                if (nombre is not null && BuscarMedicoPorMatricula(matricula) is null && diasDisponibles is not null)
                {
                    medicos.Add(new Medico(nombre, matricula, diasDisponibles));
                    SerializacionXml<List<Medico>>.Serializar(medicos, "Medicos");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }   
        }

        private static int GenerarSiguienteIdTurno()
        {
            int id = 0;

            if (turnos is not null)
            {
                foreach (Turno item in turnos)
                {
                    if (item.IdTurno > id)
                    {
                        id = item.IdTurno;
                    }
                }
            }

            return id + 1;
        }

        public static List<Turno> ListarTurnosPorFecha(DateTime dia)
        {
            if (turnos is not null)
            {
                return turnos.FindAll(t => t.Fecha == dia);
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de Turnos.");
            }
        }

        public static List<Turno> ListarTurnosPorPaciente(int paciente)
        {
            if (pacientes is not null)
            {
                return turnos.FindAll(t => t.Paciente == paciente);
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de Pacientes.");
            }

        }

        public static bool CrearTurno(int medico, int paciente, DateTime fecha, string horario)
        {
            try
            {
                if (BuscarMedicoPorMatricula(medico) is not null && BuscarPacientePorOS(paciente) is not null && !EstaOcupado(horario, fecha, medico))
                {
                    Turno turno = new Turno(GenerarSiguienteIdTurno(), medico, paciente, fecha, horario);
                    turnos.Add(turno);
                    AccesoDB.GuardarTurno(turno);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
            
        }

        public static Paciente BuscarPacientePorOS(int obraSocial)
        {
            if (pacientes is not null)
            {
                return pacientes.Find(p => p.NroObraSocial == obraSocial);
            }
            else
            {
                throw new ListaInexistenteException("No existe una lista de Pacientes.");
            }
        }

        public static bool CrearPaciente(string nombre, string apellido, int os)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(nombre.Trim()) && !string.IsNullOrWhiteSpace(apellido.Trim()) && BuscarPacientePorOS(os) is null)
                {
                    Paciente paciente = new Paciente(nombre, apellido, os);
                    pacientes.Add(paciente);
                    AccesoDB.GuardarPaciente(paciente);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            
        }
    }
}
