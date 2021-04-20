using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class MoneyException : Exception
    {
        public MoneyException(string msg) : base(msg) { }
    }
}
