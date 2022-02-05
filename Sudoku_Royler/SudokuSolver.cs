using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Sudoku_Royler;


namespace Sudoku_Handler_RoyGershon
{
    public class SudokuSolver : IPrintable
    {
        public SudokuBoard board { get; set; }
        public List<string[]> unitList { get; set; }
        public Dictionary<string, IGrouping<string, string[]>> units { get; set; }
        public Dictionary<string, IEnumerable<string>> peers { get; set; }
        public string[] squares { get; set; }
        public SudokuSolver(SudokuBoard board)
        {
            this.board = board;
             unitList = SudokuBoardHelper.CreateUnitList(board.colSigns, board.rowSigns, (int)Math.Sqrt(board.lengthOfRow));

            squares = board.squares;

            //the same block in board
            units = (from s in squares from u in unitList where u.Contains(s) group u by s into g select g).ToDictionary(g => g.Key);

            //the same row or column
             peers = (from s in squares from u in units[s] from s2 in u where s2 != s group s2 by s into g select g).ToDictionary(g => g.Key, g => g.Distinct());

         
           
        }

        /// <summary>
        /// create an array with combined values from A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static string[][] Zip(string[] A, string[] B)
        {
            var n = Math.Min(A.Length, B.Length);
            string[][] sd = new string[n][];
            for (var i = 0; i < n; i++)
            {
                sd[i] = new string[] { A[i].ToString(), B[i].ToString() };
            }
            return sd;
        }
        
     
        /// <summary>
        /// Given a string of the full amount of digits digits (or . or 0 or -) in the all grid, return a dict of {cell:values}
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Dictionary<string, string[]> Parse_grid(string grid) 
        {

            
                      string[] squares = board.squares;

                    //var grid2 = from c in grid where "0.-123456789...".Contains(c) select c;
                     var values = squares.ToDictionary(s => s, s => board.digits); //To start, every square can be any digit

                     foreach (var sd in Zip(squares, (from s in grid select s.ToString()).ToArray()))
                     {
                         var s = sd[0];
                         var d = sd[1];

                         if (board.digits.Contains(d) && Assign(values, s, d) == null)
                         {
                             return null;
                         }
                     }
            
            return values;
            
            ;
        }


        /// <summary>
        /// Using depth-first Search and propagation, try all possible values.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Dictionary<string, string[]> Search(Dictionary<string, string[]> values)
        {
            if (values == null)
            {
                return null; // Failed earlier
            }
            if (All(from s in squares select values[s].Length == 1 ? "" : null))
            {
                return values; // Solved!
            }

            // Chose the unfilled square s with the fewest possibilities
            var s2 = (from s in squares where values[s].Length > 1 orderby values[s].Length ascending select s).First();

            return GenericSolverHelper.Some(from d in values[s2]
                        select Search(Assign(new Dictionary<string, string[]>(values), s2, d.ToString())));
        }


        /// <summary>
        /// Eliminate all the other values (except d) from values[s] and propagate.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Dictionary<string, string[]> Assign(Dictionary<string, string[]> values, string s, string d)
        {
            if (All(
                    from d2 in values[s]
                    where d2.ToString() != d
                    select Eliminate(values, s, d2.ToString())))
            {
                return values;
            }
            return null;
        }

        // Eliminate d from values[s]; propagate when values or places <= block length-1.
   
        /// <summary>Eliminate d from values[s]; propagate when values or places &lt;= block length-1.</summary>
        public Dictionary<string, string[]> Eliminate(Dictionary<string, string[]> values, string square, string digit)
        {
            //return values ## Already eliminated
            if (!values[square].Contains(digit))
            {
                return values;
            }

            int indexToRemove = Array.IndexOf(values[square], digit);
            values[square] = values[square].Where((source, index) => index != indexToRemove).ToArray();
            //values[s] = values[s].Replace(d, "");

            //return False ## Contradiction: removed last value
            if (values[square].Length == 0)
            {
                return null; //Contradiction: removed last value
            }

            
            else if (values[square].Length == 1)
            {

                //## If there is only one value (d2) left in square, remove it from peers
                if (!All(from s2 in peers[square] select Eliminate(values, s2, values[square][0])))
                {
                    return null;
                }
            }


            //Now check the places where digit appears in the units of square
            foreach (var u in units[square])
            {
                var dplaces = from s2 in u where values[s2].Contains(digit) select s2;

                if (dplaces.Count() == 0)
                {
                    return null;
                }
                else if (dplaces.Count() == 1)
                {
                    // d can only be in one place in unit; assign it there
                    if (Assign(values, dplaces.First(), digit) == null)
                    {
                        return null;
                    }
                }
            }
            return values;
        }


        /// <summary>
        /// the main function of the solver. it will solve the sudoku board, check how much time it will take and print the board and the time
        /// </summary>
        /// <param name="grid">the string containing the unsolved grid</param>
        /// <returns>the solved grid string </returns>
        /// 
        public string SolveGrid(string grid)
        {
            Print_Before_Solve(grid);
            var watch = new Stopwatch();
            watch.Start();
            var solution = Search(Parse_grid(grid));
            var elapsed = watch.ElapsedMilliseconds;
            string solvedGridString = GenericSolverHelper.GetSolvedGridToFile(solution, board.squares);
            Special_Prints.Print_Solved();
            Display(solution);
            Console.WriteLine("solved: {0}, in {1}ms\n", Solved(solution), elapsed);
            return solvedGridString;
        }

        /// <summary>
        /// check if the grid is solved
        /// </summary>
        /// <param name="values"></param>
        /// <returns>bool represent if the grid is solved</returns>
        public bool Solved(Dictionary<string, string[]> values)
        {
            var unitsolved = new Func<IEnumerable<string>, bool>(unit => !new HashSet<string>(unit.Select((s) => values[s][0])).Intersect(new HashSet<string>(board.digits.Select(x => x.ToString()))).Any());
            return values != null && All(unitList.Select((unit) => unitsolved(unit)));
        }

        /// <summary>
        /// print the grid before the solvaiton
        /// </summary>
        /// <param name="grid"></param>
        public void Print_Before_Solve(string grid)
        {
            Special_Prints.Print_Before();
            string[] squares = board.squares;
            int i = 0;
            //var grid2 = from c in grid where "0.-123456789...".Contains(c) select c;
            var values = squares.ToDictionary(s => s, s => (GenericSolverHelper.GetRealCharOfCell(grid[i++]))); 
   
            Display(values);
        }



        /// <summary>
        /// check if the sequence contain a null value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seq"></param>
        /// <returns></returns>
        public bool All<T>(IEnumerable<T> seq)
        {
            foreach (var e in seq)
            {
                if (e == null) return false;
            }
            return true;
        }


        /// <summary>
        /// print the board
        /// </summary>
        /// <param name="values">dicationary which the keys are the square and the value is the array of digits (which will always be with length of 1)</param>
        /// <returns>the same values dictionary</returns>
        public Dictionary<string, string[]> Print_board(Dictionary<string, string[]> values)
        {
            if (values == null) return null;
           
            int index = (int)Math.Sqrt(board.lengthOfRow);
           
            var width = 1 + (from s in squares select values[s].Length).Max();
            
            var firstLine = "╔" + String.Join("╦", Enumerable.Repeat(new String('═', width * index + (index - 1)), index).ToArray()) + "╗";
            var line = "\n"+ "╠" + String.Join("╬", Enumerable.Repeat(new String('═', width*index+(index-1) ), index).ToArray())+ "╣";
            var lastLine = "\n" + "╚" + String.Join("╩", Enumerable.Repeat(new String('═', width * index + (index - 1)), index).ToArray()) + "╝";
            
            string lastColsInBoxes = SudokuBoardHelper.GetAllFirstCharInIndexedArr(index, board.colSigns);
            string lastRowsInBoxes = SudokuBoardHelper.GetAllFirstCharInIndexedArr(index, board.rowSigns);
            Console.WriteLine(firstLine);
            foreach (var r in board.rowSigns)
            {
                Console.WriteLine(String.Join("",
                    (from c in board.colSigns
                     select  (board.colSigns[0]==c  ? "║" : "") + values["" + r + c][0].Center(width) + (lastColsInBoxes.Contains(c)||c == board.colSigns[(int)Math.Pow(index, 2) - 1] ? "║" : "|")).ToArray())
                        + (lastRowsInBoxes.Contains(r) ? line : "") + ((r==board.rowSigns[(int)Math.Pow(index,2) - 1]) ? lastLine : ""));
            }
            

            Console.WriteLine();
            return values;
        }

        /// <summary>
        /// call to the print function
        /// </summary>
        /// <param name="values"></param>
        public void Display(Dictionary<string, string[]> values)
        {
            Print_board(values);
        }
    }
}
