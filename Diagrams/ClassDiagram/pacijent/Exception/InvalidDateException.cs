using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar.Exception
{
    class InvalidDateException : System.Exception
    {
        public InvalidDateException()
        {

        }

        public InvalidDateException(string message) : base(message)
        {

        }

        public InvalidDateException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
