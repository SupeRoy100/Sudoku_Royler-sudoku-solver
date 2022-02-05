using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Handler_RoyGershon
{
    static class GenericSolverHelper
    {
        
        public static T Some<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e != null) return e;
            }
            return default(T);
        }

        /// <summary>
        /// Centerlize the string (used in the print function in the solver)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string Center(this string s, int width)
        {
            var n = width - s.Length;
            if (n <= 0) return s;
            var half = n / 2;

            if (n % 2 > 0 && width % 2 > 0) half++;

            return new string(' ', half) + s + new String(' ', n - half);
        }

        /// <summary>
        /// check if a string is inside on of the arrays of the string
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Contains(string[] arr, string str)
        {
            foreach(string s in arr)
            {
                if (s == str)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Change the char from sign to a digits for example "@" --> "12"
        /// </summary>
        /// <param name="gridChar"></param>
        /// <returns></returns>
        public static string[] GetRealCharOfCell(char gridChar)
        {
            string[] ret = new string[1];
            int num = gridChar-'0';
            ret[0] = num.ToString();
            return ret;
        }
        
        /// <summary>
        /// change digits string to signs for example "12" --> "@"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetAsciiFromNumberString(string[] str)
        {
            string ret = "";
            for(int i=0; i<str.Length; i++)
            {
                if(str[i] == ".")
                {
                    ret += "0";
                }
                int num = int.Parse(str[i]);
                ret += (char)(num + '0');
            }
            return ret;
        }

        /// <summary>
        /// Get a string of the solved grid
        /// </summary>
        /// <param name="values"></param>
        /// <param name="squares"></param>
        /// <returns>the string represent the grid</returns>
        public static string GetSolvedGridToFile(Dictionary<string, string[]> values, string[] squares)
        {
            string ret = "";
            for(int i=0; i<values.Count; i++)
            {
                
                ret+=GetAsciiFromNumberString(values[squares[i]]);
            }
            return ret;
        }
    }
}
