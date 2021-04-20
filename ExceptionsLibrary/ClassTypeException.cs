using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class ClassTypeException : Exception
    {
        public ClassTypeException(string msg) : base(msg) { }
    }
}
