using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Royler
{
    public class NullGridException: Exception
    {
        public NullGridException() { }

        public NullGridException(string message) : base(message) { }

        public NullGridException(string message, Exception e) : base(message, e) { }
    }
}
