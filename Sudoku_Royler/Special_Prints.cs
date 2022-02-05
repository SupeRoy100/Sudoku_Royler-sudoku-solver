using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Royler
{
    public static class Special_Prints
    {
    
        public static void Print_Before()
        {
            Console.WriteLine("\n▄▄▄▄  ▄▄▄▄▄ ▄▄▄▄▄ ▄▄▄▄▄ ▄▄▄▄  ▄▄▄▄▄");
            Console.WriteLine("█   █ █     █     █   █ █   █ █");
            Console.WriteLine("█▄▄▄▌ █▄▄▄▄ █▄▄▄▄ █   █ █▄▄▄█ █▄▄▄▄");
            Console.WriteLine("█   █ █     █     █   █ █  █  █");
            Console.WriteLine("█▄▄▄▀ █▄▄▄▄ █     █▄▄▄█ █   █ █▄▄▄▄\n");
        }
        public static void Print_Solved()
        {
            Console.WriteLine("\n▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄ ▄▄▄▄");
            Console.WriteLine("█   █ █       █    █     █   █");
            Console.WriteLine("█▄▄▄█ █▄▄▄    █    █▄▄▄▄ █▄▄▄█");
            Console.WriteLine("█   █ █       █    █     █  █");
            Console.WriteLine("█   █ █       █    █▄▄▄▄ █   █\n");
        }
    }
}
