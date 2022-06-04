using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum IDias
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
            medicos = new List<Medico>();
            AgregarMedicos();
            turnos = new List<Turno>();
            AgregarTurnos();
            pacientes = new List<Paciente>();
            AgregarPacientes();
        }

        public static List<string> Horarios
        {
            get { return horarios; }
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
            usuarios.Add(new Usuario(64081, "Pepe", "123"));
            usuarios.Add(new Usuario(64060, "Alberto", "123"));
            usuarios.Add(new Usuario(64029, "Wally", "123"));
            usuarios.Add(new Usuario(64055, "Silvina", "123"));
            usuarios.Add(new Usuario(64080, "Ilda", "123"));
        }

        /// <summary>
        /// recorre la lista de usuarios y verifica que los parametros ingresados correspondan a un usuario valido.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns>devuelve un bool informando si se logro o no</returns>
        public static bool LoggearUsuario(string usuario, string pass)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Nombre == usuario && u.ValidarPass(pass))
                {
                    return true;
                }
            }
            return false;
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

        //Buscar la forma de devolver una lista con los horarios que NO estan contenidos dentro de un turno
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
            foreach (string ocupado in HorariosOcupados(dia, medico))
            {
                if (horario == ocupado)
                {
                    return true;
                }
            }
            return false;
        }
        
        public static List<string> HorariosDisponibles(DateTime dia, int medico)
        {
            List<string> horariosDisponibles = new List<string>();
            foreach (string horario in horarios)
            {
                if (!EstaOcupado(horario, dia, medico))
                {
                    horariosDisponibles.Add(horario);
                }
            }

            return horariosDisponibles;
        }



        private static void AgregarMedicos()
        {
            medicos.Add(new Medico("Tangalanga", 11283848, new List<IDias>() { IDias.Lunes, IDias.Martes }));
            medicos.Add(new Medico("Bilardo", 10303456, new List<IDias>() { IDias.Jueves, IDias.Viernes, IDias.Sabado }));
            medicos.Add(new Medico("Lotocki", 18373466, new List<IDias>() { IDias.Lunes, IDias.Martes, IDias.Miercoles, IDias.Jueves, IDias.Viernes }));
            medicos.Add(new Medico("Houssay", 06041991, new List<IDias>() { IDias.Miercoles, IDias.Sabado }));
        }

        public static Medico BuscarMedicoPorMatricula(int matricula)
        {
            foreach (Medico dr in medicos)
            {
                if (dr.Matricula == matricula)
                {
                    return dr;
                }
            }
            return null;
        }

        public static List<Medico> ListarMedicosPorDia(int dia)
        {
            List<Medico> medicosDisponibles = new List<Medico>();
            foreach (Medico dr in medicos)
            {
                if (dr.EstaDisponible(dia))
                {
                    medicosDisponibles.Add(dr);
                }
            }

            return medicosDisponibles;
        }

        public static void AgregarTurnos()
        {
            turnos.Add(new Turno(11283848, 000012345, new DateTime(2022, 6, 6), "9:30"));
            turnos.Add(new Turno(11283848, 000012312, new DateTime(2022, 6, 7), "10:30"));
            turnos.Add(new Turno(10303456, 000012445, new DateTime(2022, 6, 9), "10:30"));
            turnos.Add(new Turno(10303456, 000012312, new DateTime(2022, 6, 10), "11:00"));
            turnos.Add(new Turno(18373466, 000012445, new DateTime(2022, 6, 8), "10:30"));
            turnos.Add(new Turno(06041991, 000012444, new DateTime(2022, 6, 8), "12:30"));
            turnos.Add(new Turno(06041991, 000012444, new DateTime(2022, 6, 11), "10:00"));
        }

        public static List<Turno> ListarTurnosPorFecha(DateTime dia)
        {
            List<Turno> turnosDelDia = new List<Turno>();

            foreach (Turno item in turnos)
            {
                if (item.Fecha == dia)
                {
                    turnosDelDia.Add(item);
                }
            }

            return turnosDelDia;
        }

        //falta hacer validaciones!
        public static bool CrearTurno(int medico, int paciente, DateTime fecha, string horario)
        {
            turnos.Add(new Turno(medico, paciente, fecha, horario));
            return true;
        }


        private static void AgregarPacientes()
        {
            pacientes.Add(new Paciente("Ilda", "Zolezzi", 000012345));
            pacientes.Add(new Paciente("Pepe", "Rico", 000012312));
            pacientes.Add(new Paciente("Nirvana", "Olivera", 000012444));
            pacientes.Add(new Paciente("Gusti", "Gallardo", 000012445));
        }

        public static Paciente BuscarPacientePorOS(int obraSocial)
        {
            foreach (Paciente p in pacientes)
            {
                if (p.NroObraSocial == obraSocial)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
