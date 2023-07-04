using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignment1
{
    public class InvalidValueException : ApplicationException
    {
        public InvalidValueException(string msg) : base(msg) { }
    }
}
