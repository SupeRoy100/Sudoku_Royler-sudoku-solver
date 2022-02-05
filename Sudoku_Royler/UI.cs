using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;


namespace Sudoku_Handler_RoyGershon
{
    public static class UI
    {

        /// <summary>
        /// get the input of choise from the user- to input a string with the console or with a file
        /// </summary>
        /// <returns>int that represent the choise</returns>
        public static int GetChoise()
        {
            Console.WriteLine("Hello there!");
            Console.WriteLine("Thanks for choosing the Sudoku Royler");
            Console.WriteLine("Did you get it? because it's a combination of a Sudoku solver and my name, Roy Gershon");
            Console.WriteLine("now....");
            Console.WriteLine("Please choose how you want to insert the unsolved board:");
            Console.WriteLine("Press:");
            Console.WriteLine("(1) for insert a string in the console");
            Console.WriteLine("(2) for insert a game from a file");

            bool isValidChoise = int.TryParse(Console.ReadLine(), out int choise);

            if (!isValidChoise)
            {
                Console.Clear();
                Console.WriteLine("ERR! you must enter only the specific choise numbers ");
                choise = GetChoise();
            }
            else if(choise != 1 && choise != 2)
            {
                Console.Clear();
                Console.WriteLine("ERR! The choise has to be 1 or 2 ");
                choise = GetChoise();
            }
            Console.Clear();
            return choise;
        }

        /// <summary>
        /// get a string imput from console to represent the grid
        /// </summary>
        /// <returns>string that represent the grid</returns>
        public static string[] GetStringFromConsole()
        {
            string grid="";

            Console.WriteLine("Please enter the grid string value:");
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            grid = Console.ReadLine();
            string[] ret = new string[1];
            ret[0] = grid;
            return ret;
        }

        /// <summary>
        /// The main UI function that run the program
        /// </summary>
        public static void SolveUI()
        {
            try
            {
                int choise = GetChoise();
                string[] grids = GridStringHandler(choise);
                HandleSolver(grids);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Whould you like to call the solver again?");
                Console.WriteLine("Press:");
                Console.WriteLine("(1) Yes");
                Console.WriteLine("(2) NO");
                bool isValidChoise = int.TryParse(Console.ReadLine(), out int choise);

                while (!isValidChoise || choise != 1 && choise !=2)
                {
                    
                    Console.WriteLine("ERR! you must enter only the specific choise numbers!");
                    isValidChoise = int.TryParse(Console.ReadLine(), out choise);
                }
                Console.Clear();
                if (choise == 2)
                {
                    
                    Console.WriteLine("Thanks for choosing Sudoku Royler! Hope to see you soon again!");
                    Thread.Sleep(2000);
                    
                }
                else
                {
                    SolveUI();
                }
            }
            
        }

        /// <summary>
        /// handle the choise to input the grid from file or from console
        /// </summary>
        /// <param name="choise"></param>
        /// <returns>an array of string represent array of grids</returns>
        public static string[] GridStringHandler(int choise)
        {
            if (choise == 1)
                return GetStringFromConsole();

            return GetStringFromFile();
        }

        /// <summary>
        /// read the grid from file
        /// </summary>
        /// <returns>a string array represent the grids from the files</returns>
        public static string[] GetStringFromFile()
        {
            
            string[] paths = FileHandler.GetPathOfGridFiles();
            string[] ret = new string[paths.Length];
            
            for(int i=0; i<paths.Length; i++)
            {
                string[] temp = File.ReadAllLines(paths[i]);
                foreach(string line in temp)
                {
                    ret[i] += line;
                }
            }
            return ret;
        }

        /// <summary>
        /// After finishing solving the grid the function handle saving or not the solved grid to a file
        /// </summary>
        /// <param name="grid"></param>
        public static void AddToFile(string grid)
        {
            Console.WriteLine("Do you want to create a file with the solved sudoku?");
            Console.WriteLine("Press:");
            Console.WriteLine("(1) to save");
            Console.WriteLine("(2) to ignore");
            bool isValidChoise = int.TryParse(Console.ReadLine(), out int choise);

            while (!isValidChoise || choise != 1 && choise != 2)
            {

                Console.WriteLine("ERR! you must enter only the specific choise numbers!");
                isValidChoise = int.TryParse(Console.ReadLine(), out choise);
            }
            Console.Clear();
            if (choise == 1)
                FileHandler.CreateSolvedFile(grid);

        }

        /// <summary>
        /// handle the solving of the grids
        /// </summary>
        /// <param name="grids"></param>
        public static void HandleSolver(string[] grids)
        {
            string solvedGrid = "";
            for(int i=0; i<grids.Length; i++)
            {
                SudokuBoard board = new SudokuBoard(grids[i]);
                SudokuSolver solver = new SudokuSolver(board);
                solvedGrid = solver.SolveGrid(grids[i]);
                AddToFile(solvedGrid);
            }
        }
    }
}
