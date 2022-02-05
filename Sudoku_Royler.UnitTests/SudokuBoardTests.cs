using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sudoku_Royler;
using Sudoku_Handler_RoyGershon;

namespace Sudoku_Royler.UnitTests
{
    [TestClass]
    public class Sudoku
    {
        [TestMethod]
        public void SudokuBoard_EmptyBoard_ReturnsFalse()
        {
            string gridString = "";
            SudokuBoard board;
            Assert.ThrowsException<NullGridException>(() => board = new SudokuBoard(gridString));
        }

        [TestMethod]
        public void SudokuBoard_IllegalLength_ReturnsFalse()
        {
            string gridString = "100";
            SudokuBoard board;
            Assert.ThrowsException<IllegalLengthException>(() => board = new SudokuBoard(gridString));
        }

        [TestMethod]
        public void SudokuBoard_IllegalChar_ReturnFalse()
        {
            string grid = "1000020100000354";
            SudokuBoard board;
            Assert.ThrowsException<IllegalCharInGridException>(() => board = new SudokuBoard(grid));
        }




    }
}
