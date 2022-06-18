using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class ConsultorioTest
    {
        [TestMethod]
        public void LoggearUsuario_PassIncorrectaUsuarioCorrecto_DeberiaRetornarFalse()
        {
            bool resultado = Consultorio.LoggearUsuario("Wally", "111");

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void LoggearUsuario_PassCorrectaUsuarioIncorrecto_DeberiaRetornarFalse()
        {
            bool resultado = Consultorio.LoggearUsuario("Pip", "123");

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void LoggearUsuario_PassIncorrectaUsuarioIncorrecto_DeberiaRetornarFalse()
        {
            bool resultado = Consultorio.LoggearUsuario("Pip", "asd");

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void LoggearUsuario_PassCorrectaUsuarioCorrecto_DeberiaRetornarTrue()
        {
            bool resultado = Consultorio.LoggearUsuario("Wally", "123");

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CrearMedico_NombreNuloMatriculaCorrectaListaCorrecta_DeberiaRetornarFalse()
        {
            bool resultado = Consultorio.CrearMedico(null, 444444, new List<Dias> { Dias.Lunes, Dias.Martes });

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ListaInexistenteException))]
        public void HorariosDisponibles_ListaTurnosVacia_DeberiaTirarExcepcion()
        {
            List<string> aux2 = Consultorio.Horarios;
            List<string> aux = Consultorio.HorariosDisponibles(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 6666);

            CollectionAssert.AreEquivalent(aux, aux2);
        }

        [TestMethod]
        public void GenerarSiguienteIdMedico_ListaMedicosVacia_DeberiaRetornar10001()
        {
            Assert.IsTrue(Consultorio.GenerarSiguienteIdMedico() == 10001);
            
        }

        [TestMethod]
        public void BuscarMedicoPorMatricula_ListaMedicosVacia_DeberiaDevolverNull()
        {
            Assert.IsNull(Consultorio.BuscarMedicoPorMatricula(11111));
            
        }

        [TestMethod]
        public void ListarMedicosPorDia_ListaMedicosVacia_DeberiaDevolverListaVacia()
        {
            CollectionAssert.AreEquivalent(Consultorio.ListarMedicosPorDia(1), new List<Medico>());
        }

        [TestMethod]
        public void CrearTurno_ListaMedicosVaciaListaPacienteVacia_DeberiaDevolverFalse()
        {
            Assert.IsFalse(Consultorio.CrearTurno(123, 123, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), "13:00"));
        }

        [TestMethod]
        public void BuscarPacientePorOS_ListaPacientesVacia_DeberiaRetornarNull()
        {
            Assert.IsNull(Consultorio.BuscarPacientePorOS(111));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CrearPaciente_PacienteExistente_DeberiaTirarExcepcion()
        {
            Assert.IsFalse(Consultorio.CrearPaciente("Erick", "Cartman", 666));
        }
    }
}
