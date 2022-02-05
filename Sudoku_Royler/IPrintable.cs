using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Royler
{
   public interface IPrintable
    {
         void Display(Dictionary<string, string[]> values);
    }
}
