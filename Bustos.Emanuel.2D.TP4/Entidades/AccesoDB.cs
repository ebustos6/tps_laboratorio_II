﻿using System;
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

                throw;
            }
            finally
            {
                connection.Close();
            }

        }

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

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

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
                        turnos.Add(new Turno(Convert.ToInt32(reader["MATRICULA_MEDICO"]), Convert.ToInt32(reader["OS_PACIENTE"]), (DateTime)reader["FECHA"], reader["HORARIO"].ToString()));
                    }
                }

                return turnos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }

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

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
