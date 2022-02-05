using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Sudoku_Handler_RoyGershon;


namespace Sudoku_Handler_RoyGershon
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            UI.SolveUI();
        }
    }
}