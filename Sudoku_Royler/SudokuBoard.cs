using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Sudoku_Royler;



namespace Sudoku_Handler_RoyGershon
{
    public class SudokuBoard
    {
        public int lengthOfRow { get; set; }
        public string rowSigns { get; set; }
        public string colSigns { get; set; }
        public string[] digits { get; set; }
        public string[] squares { get; set; }

        public SudokuBoard(string grid)
        {
            int length = grid.Length;

            if (length == 0)
                throw new NullGridException("Can not solve a null grid");
            double rowLength = Math.Sqrt(length);
            if (rowLength - Math.Floor(rowLength) != 0)
            {
                throw new IllegalLengthException("The length is not valid");
            }

            lengthOfRow= (int)rowLength;

            rowSigns = SudokuBoardHelper.CreateSequance(lengthOfRow, 'A');

            colSigns = SudokuBoardHelper.CreateSequance(lengthOfRow, '1');
            
            digits = SudokuBoardHelper.CreateDigitSequence(lengthOfRow);

            if (SudokuBoardHelper.HasIllegalChar(digits, grid))
                throw new IllegalCharInGridException("The Sudoku has illegal digitis");

            squares = SudokuBoardHelper.cross(rowSigns, colSigns);

        }

        


    }
}
