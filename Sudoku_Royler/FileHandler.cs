using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku_Handler_RoyGershon
{
    public static class  FileHandler
    {
        public static string filePath = Path.Combine( System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"Sudoku_Royler\bin\Debug\" , ""), "sudokuFiles");
        public static int filecreated = 1;
        
        /// <summary>
        /// read all the string array of the grids
        /// </summary>
        /// <returns>the array of the grids</returns>
        public static string[] GetPathOfGridFiles()
        {
            OpenFileDialog fileSearcher = new OpenFileDialog();
            fileSearcher.Filter = "Text|*.txt|All|*.*"; ;
            fileSearcher.FilterIndex = 1;
            fileSearcher.Multiselect = true;

            if (fileSearcher.ShowDialog() == DialogResult.OK)
            {
                string[] arrAllFiles = fileSearcher.FileNames; //used when Multiselect = true
                return arrAllFiles;
            }

            return null;
        }
        /// <summary>
        /// output the solved grid to a new file
        /// </summary>
        /// <param name="solvedGrid"></param>
        public static void CreateSolvedFile(string solvedGrid)
        {
            File.WriteAllText(Path.Combine(filePath, $"file{filecreated++}.txt"), solvedGrid);
        }
    }
}
