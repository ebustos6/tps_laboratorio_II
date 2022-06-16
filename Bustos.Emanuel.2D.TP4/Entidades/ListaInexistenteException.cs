using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class ListaInexistenteException : Exception
    {
        public ListaInexistenteException()
        {
        }

        public ListaInexistenteException(string message) : base(message)
        {
        }

        public ListaInexistenteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
