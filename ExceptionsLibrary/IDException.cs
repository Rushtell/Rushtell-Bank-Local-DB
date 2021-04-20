using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class IDException : Exception
    {
        public IDException(string msg) : base(msg) { }
    }
}
