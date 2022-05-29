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


        static Consultorio()
        {
            usuarios = new List<Usuario>();
            AgregarUsuarios();
            horarios = new List<string>();
            AgregarHorarios();
            medicos = new List<Medico>();
            AgregarMedicos();
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

        private static void AgregarMedicos()
        {
            medicos.Add(new Medico("Tangalanga", 11283848, new List<IDias>() { IDias.Lunes, IDias.Martes }));
            medicos.Add(new Medico("Bilardo", 10303456, new List<IDias>() { IDias.Jueves, IDias.Viernes, IDias.Sabado }));
            medicos.Add(new Medico("Lotocki", 18373466, new List<IDias>() { IDias.Lunes, IDias.Martes, IDias.Miercoles, IDias.Jueves, IDias.Viernes }));
            medicos.Add(new Medico("Houssay", 06041991, new List<IDias>() { IDias.Miercoles, IDias.Sabado }));
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
    }
}
