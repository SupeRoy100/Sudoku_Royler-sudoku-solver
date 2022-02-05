using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Handler_RoyGershon
{
    public static class SudokuBoardHelper
    {

        /// <summary>
        /// combine the 2 string to 1. each cell will be the sum of chars indexed in A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
       public static string[] cross(string A, string B)
       {
            return (from a in A from b in B select "" + a + b).ToArray();
       }


        /// <summary>
        /// create a sequace using ascii
        /// </summary>
        /// <param name="rowLength"></param>
        /// <param name="sequenceStater"></param>
        /// <returns>the string represent the sequance</returns>
       public static string CreateSequance(int rowLength, char sequenceStater)
        {
            
            string rows = "";
            
            for(int i=0; i<rowLength; i++)
            {
                rows += (char)(sequenceStater+i);
            }
            
            return rows;
        }

        /// <summary>
        /// create an array of digits that are sequanced by the amount of rowLength
        /// </summary>
        /// <param name="rowLength"></param>
        /// <returns>the array represent the sequance</returns>
        public static string[] CreateDigitSequence(int rowLength)
        {
            
            string[] digits = new string[rowLength];
            for (int i = 0; i < rowLength; i++)
            {
                digits[i] = (i+1).ToString();
            }
            return digits;
        }

        /// <summary>
        /// create the unit list which is represented in SukokuBoard
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="rows"></param>
        /// <param name="blockLength"></param>
        /// <returns>The unitList</returns>
        public static List<string[]> CreateUnitList(string cols, string rows, int blockLength)
        {
            string[] colArr = CreateArrayOfStringByIndex(blockLength, cols);
            string[] rowArr = CreateArrayOfStringByIndex(blockLength, rows);
            List<string[]> unitlist = ((from c in cols select SudokuBoardHelper.cross(rows, c.ToString()))
           .Concat(from r in rows select SudokuBoardHelper.cross(r.ToString(), cols))
           .Concat(from rs in (rowArr) from cs in (colArr) select SudokuBoardHelper.cross(rs, cs))).ToList();
            
        
            return unitlist;
        }

        /// <summary>
        /// create an array of string which in every cell will be the str with the amount of index spaces for example  index=3, str = "ABCDEFGHI" will return => "ABC", "DEF", "GHI" in string array
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <returns>the array</returns>
        public static string[] CreateArrayOfStringByIndex(int index, string str)
        {
            string[] ret = new string[index];
            int counter = 0;
            for (int i=0; i<str.Length; i++)
            {
                ret[(i % index == 0 && i!=0) ? ++counter : counter] += str[i];  
            }
            return ret;

        }

        /// <summary>
        /// get the last boxed indeices without the first and the last. (used in the printing method in solver)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetAllFirstCharInIndexedArr(int index, string str)
        {
            string[] arr = CreateArrayOfStringByIndex(index, str);
            string ret = "";
            for(int i=0; i<arr.Length-1; i++)
            {
                ret += arr[i][index - 1];
            }
            
            return ret;
        }

        /// <summary>
        /// indication to check if the grid contains illegal characters
        /// </summary>
        /// <param name="digits"></param>
        /// <param name="grid"></param>
        /// <returns>bool that it's value is if the grid contains illegal characters </returns>
        public static bool HasIllegalChar(string[] digits, string grid)
        {
            for (int i = 0; i < grid.Length; i++) {
                if (grid[i] != '.')
                {
                    int num = (int)(grid[i] - '0');
                    string temp = num.ToString();
                    if (temp != "0" && !digits.Contains(temp))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
