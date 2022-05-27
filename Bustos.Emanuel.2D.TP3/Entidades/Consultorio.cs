using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Consultorio
    {
        static List<Usuario> usuarios;
        static Usuario usuarioActivo;

        static Consultorio()
        {
            usuarios = new List<Usuario>();
            AgregarUsuarios();
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
                    usuarioActivo = u;
                    return true;
                }
            }
            return false;
        }


    }
}
