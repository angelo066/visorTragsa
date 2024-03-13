using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.Exceptions
{
    public class InvalidArguments : Exception
    {
        public InvalidArguments(string message) : base(message) {
        }
    }
}
