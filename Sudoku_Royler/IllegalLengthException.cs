using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Royler
{
    public class IllegalLengthException: Exception
    {
        public IllegalLengthException() { }

        public IllegalLengthException(string message) : base(message) { }

        public IllegalLengthException(string message, Exception e): base(message, e) { }
    }
}
