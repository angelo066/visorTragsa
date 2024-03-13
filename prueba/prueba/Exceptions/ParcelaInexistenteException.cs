using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.Exceptions
{
    public class ParcelaInexistenteException : Exception
    {
        public ParcelaInexistenteException(string message) : base(message) { 

        }
    }
}
