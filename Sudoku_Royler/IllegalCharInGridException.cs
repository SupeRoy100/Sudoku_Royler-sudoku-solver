using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Royler
{
    public class IllegalCharInGridException: Exception
    {
        public IllegalCharInGridException() { }

        public IllegalCharInGridException(string message) : base(message) { }

        public IllegalCharInGridException(string message, Exception e) : base(message, e) { }
    }
}
