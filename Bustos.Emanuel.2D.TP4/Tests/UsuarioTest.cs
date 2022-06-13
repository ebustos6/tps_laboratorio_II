using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Tests
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void ValidarPass_PassIncorrecta_DeberiaRetornarFalse()
        {
            //Arrange
            Usuario u = new Usuario(123, "Pepe", "123");

            //Act
            bool resultado = u.ValidarPass("125");

            //Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarPass_PassCorrecta_DeberiaRetornarTrue()
        {
            //Arrange
            Usuario u = new Usuario(123, "Pepe", "123");

            //Act
            bool resultado = u.ValidarPass("123");

            //Assert
            Assert.IsTrue(resultado);
        }
    }
}
