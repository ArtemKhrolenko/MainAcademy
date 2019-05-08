using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class BirdFlewAwayException : Exception
    {
        public BirdFlewAwayException(string message, string message2, DateTime time) : base(message)
        {
        }
    }
}
