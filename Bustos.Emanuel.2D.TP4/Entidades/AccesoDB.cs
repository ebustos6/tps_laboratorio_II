using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class AccesoDB
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static AccesoDB()
        {
            connectionString = @"Data Source=.;Initial Catalog=UTN_DB;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// hace un SELECT en la DB de Pacientes.
        /// </summary>
        /// <returns>Una lista de Pacientes</returns>
        /// <exception cref="Exception"></exception>
        public static List<Paciente> LeerPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM PACIENTES";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pacientes.Add(new Paciente(reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), Convert.ToInt32(reader["OS_PACIENTE"])));
                    }
                }

                return pacientes;
            }
            catch (Exception)
            {
                throw new Exception($"Error en el acceso a base de datos, metodo LeerPacientes()");
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// Hace un Insert en la DB de Pacientes con el Paciente insertado por parametros.
        /// </summary>
        /// <param name="paciente"></param>
        /// <exception cref="Exception"></exception>
        public static void GuardarPaciente(Paciente paciente)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO dbo.PACIENTES ([NOMBRE],[APELLIDO],[OS_PACIENTE]) VALUES (@NOMBRE, @APELLIDO, @OS)";
                command.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                command.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                command.Parameters.AddWithValue("@OS", paciente.NroObraSocial);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw new Exception($"Error en el acceso a base de datos, metodo GuardarPaciente()");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Hace un SELECT en la DB de Turnos.
        /// </summary>
        /// <returns>Una lista de Turnos.</returns>
        /// <exception cref="Exception"></exception>
        public static List<Turno> LeerTurnos()
        {
            List<Turno> turnos = new List<Turno>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM TURNOS";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        turnos.Add(new Turno(Convert.ToInt32(reader["ID_TURNO"]), Convert.ToInt32(reader["MATRICULA_MEDICO"]), Convert.ToInt32(reader["OS_PACIENTE"]), (DateTime)reader["FECHA"], reader["HORARIO"].ToString()));
                    }
                }

                return turnos;
            }
            catch (Exception)
            {
                throw new Exception($"Error en el acceso a base de datos, metodo LeerTurnos()");
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// Hace un Insert en la DB de Turnos con el Turno ingresado por parametros.
        /// </summary>
        /// <param name="turno"></param>
        /// <exception cref="Exception"></exception>
        public static void GuardarTurno(Turno turno)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO dbo.TURNOS ([ID_TURNO],[MATRICULA_MEDICO],[OS_PACIENTE],[FECHA],[HORARIO]) VALUES (@ID, @MEDICO, @OS, @FECHA, @HORARIO)";
                command.Parameters.AddWithValue("@ID", turno.IdTurno);
                command.Parameters.AddWithValue("@MEDICO", turno.Medico);
                command.Parameters.AddWithValue("@OS", turno.Paciente);
                command.Parameters.AddWithValue("@FECHA", turno.Fecha);
                command.Parameters.AddWithValue("@HORARIO", turno.Horario);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw new Exception($"Error en el acceso a base de datos, metodo GuardarTurno()");
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
