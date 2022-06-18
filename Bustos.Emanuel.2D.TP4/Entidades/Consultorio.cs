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
            medicos = new List<Medico>();
            turnos = new List<Turno>();
            pacientes = new List<Paciente>();
        }

        /// <summary>
        /// Getter de lista de horarios de atencion del Consultorio.
        /// </summary>
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

        /// <summary>
        /// Getter de lista de medicos del Consultorio.
        /// </summary>
        public static List<Medico> Medicos
        {
            get { return medicos; }
        }

        /// <summary>
        /// Getter de lista de medicos del Consultorio.
        /// </summary>
        public static List<Paciente> Pacientes
        {
            get { return pacientes; }
        }

        /// <summary>
        /// Llama a los metodos para importar de un XML horarios y medicos.
        /// </summary>
        public static void ImportarXML()
        {
            ImportarHorarios();
            ImportarMedicos();
        }

        /// <summary>
        /// Llama a los metodos para importar de una DB pacientes y turnos.
        /// </summary>
        public static void ImportarDB()
        {
            ImportarPacientes();
            ImportarTurnos();
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
        /// Recorre la lista de usuarios y verifica que los parametros ingresados correspondan a un usuario valido.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns>Un bool indicando si se logro o no.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Llama al metodo encargado de deserializar una lista de horarios y lo asigna a la lista creada en esta clase.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void ImportarHorarios()
        {
            try
            {
                horarios = SerializacionXml<List<string>>.Deserializar("Horarios");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Recorre la lista de horarios buscando si los parametros ingresados coinciden.
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="medico"></param>
        /// <returns>Una lista con los horarios que coinciden.</returns>
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

        /// <summary>
        /// Recorre la lista de horarios buscando si los parametros ingresados coinciden.
        /// </summary>
        /// <param name="horario"></param>
        /// <param name="dia"></param>
        /// <param name="medico"></param>
        /// <returns>Un bool indicando si existen o no.</returns>
        private static bool EstaOcupado(string horario, DateTime dia, int medico)
        {
            return HorariosOcupados(dia, medico).Exists(h => h == horario);
        }

        /// <summary>
        /// Recorre la lista de horarios buscando si los parametros ingresados coinciden.
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="medico"></param>
        /// <returns>Una lista con los horarios que no coinciden.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Llama al metodo encargado de deserializar una lista de medicos y lo asigna a la lista creada en esta clase.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void ImportarMedicos()
        {
            try
            {
                medicos = SerializacionXml<List<Medico>>.Deserializar("Medicos");
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Recorre la lista de medicos buscando el numero de legajo mas alto y le suma 1.
        /// </summary>
        /// <returns>Un int con el nuevo legajo.</returns>
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

        /// <summary>
        /// Recorre la lista de medicos buscando si el parametro ingresado coincide.
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>Un objeto de tipo Medico.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Recorre la lista de medicos buscando si el parametro ingresado coincide.
        /// </summary>
        /// <param name="dia"></param>
        /// <returns>Una lista de Medicos.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Valida los datos ingresados por parametros y con ellos crea un Medico en la lista y actualiza su archivoXML correspondiente.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="matricula"></param>
        /// <param name="diasDisponibles"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Llama al metodo encargado de leer la DB de turnos y lo asigna a la lista creada en esta clase.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void ImportarTurnos()
        {
            try
            {
                turnos = AccesoDB.LeerTurnos();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            } 
        }

        /// <summary>
        /// Recorre la lista de turnos buscando el numero de Id mas alto y le suma 1.
        /// </summary>
        /// <returns>Un int con el nuevo Id.</returns>
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

        /// <summary>
        /// Recorre la lista de turnos buscando si el parametro ingresado coincide.
        /// </summary>
        /// <param name="dia"></param>
        /// <returns>Una lista de Turnos.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Recorre la lista de turnos buscando si el parametro ingresado coincide.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>Una lista de Turnos.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Valida los datos ingresados por parametros y con ellos crea un Turno en la lista y en la DB.
        /// </summary>
        /// <param name="medico"></param>
        /// <param name="paciente"></param>
        /// <param name="fecha"></param>
        /// <param name="horario"></param>
        /// <returns>Un bool indicando si se logro o no.</returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Llama al metodo encargado de leer la DB de pacientes y lo asigna a la lista creada en esta clase.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void ImportarPacientes()
        {
            try
            {
                pacientes = AccesoDB.LeerPacientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            
        }

        /// <summary>
        /// Recorre la lista de pacientes buscando si el parametro ingresado coincide.
        /// </summary>
        /// <param name="obraSocial"></param>
        /// <returns>Un objeto de tipo Paciente.</returns>
        /// <exception cref="ListaInexistenteException"></exception>
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

        /// <summary>
        /// Valida los datos ingresados por parametros y con ellos crea un Paciente en la lista y en la DB.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="os"></param>
        /// <returns>Un bool informado si se logro o no.</returns>
        /// <exception cref="Exception"></exception>
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
