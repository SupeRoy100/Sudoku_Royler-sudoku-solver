using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Sudoku_Handler_RoyGershon;

namespace Sudoku_Royler.UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SudokuSolverTests
    {
        [TestMethod]
        public void SudokuSolver_Solve_1on1_ReturnsTrue()
        {
            string grid = "0";
           SudokuBoard board = new SudokuBoard(grid);
            SudokuSolver solver = new SudokuSolver(board);
            string solved =solver.SolveGrid(grid);
            Assert.IsTrue(solved == "1");

        }

        [TestMethod]
        public void SudokuSolver_Solve_4on4_ReturnsTrue()
        {
            string grid = "1000020100000304";
            SudokuBoard board = new SudokuBoard(grid);
            SudokuSolver solver = new SudokuSolver(board);
            string solved = solver.SolveGrid(grid);
            Assert.IsTrue(solved == "1423324141322314");
        }
        [TestMethod]
        public void SudokuSolver_Solve_9on9_ReturnsTrue()
        {
            string grid = "000020017002000300000000008007200860000138000035004000600000000009000400070050006";
            SudokuBoard board = new SudokuBoard(grid);
            SudokuSolver solver = new SudokuSolver(board);
            string solved = solver.SolveGrid(grid);
            Assert.IsTrue(solved == "458923617712846359963571248147295863296138574835764192684319725529687431371452986");
        }

        [TestMethod]
        public void SudokuSolver_Solve_16on16_ReturnsTrue()
        {
            string grid = "040080@0;010060>30090?04:70=00<006002;0080003000?000000=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>00;9000=?04050=040600000020<090<0@0=00010060?0";
            SudokuBoard board = new SudokuBoard(grid);
            SudokuSolver solver = new SudokuSolver(board);
            string solved = solver.SolveGrid(grid);
            Assert.IsTrue(solved == ";42<8795=:13?6@>38=9?@<4>726;51:?6>@21;:84953<7=175:3=6>?;<@82944:68932=7>?15;<@=>?318@765;<94:2<@925;>?384:17=6751;46:<29@=>?382;<5=:89163?@>4781@><?43:27;=9656=7?@>1;4<59:82393:47256@=8><1;?5?36;<789@:42=>1:281>9=@<?67435;@<4=65?1;3>27:89>9;7:43251=86@?<");
        }

        public void SudokuSolver_Solve_25on25_ReturnsTrue()
        {
            string grid = "00<60070B05H0:1004000000020C0=000:00000000B50000010000000F000030200><0@8I000@0002G00=<F000E?C30000>0G0H00000I840@CE0070003<0904020000000:0H<A@00050000009006I0008053000000D00BC?0:;000B<C0000000G00700400000000>0F00B@D06;=0000000F0I001A54700>083E00;00060D=?00000090020I0180050E0010000@:07004D00900>0H0A0I2500000=00000F00000C1800007E00<02A000B6@00?00=0:08:B<@900050000C00A0E0?00F0800?03060E0070B>50100000000C010@;000:FI?000000E000310E004000020=0HI00>00600000000?0<>06AH0000000=0005G@40=H720900?30F000000800ID20C000010000E300<0000@<050;E0G00?0000C900000I:00009DF74030>IB0;0000010?H060F80I>0:;090D1@070G00=>=E100500060F0G:000200B7;";
            SudokuBoard board = new SudokuBoard(grid);
            SudokuSolver solver = new SudokuSolver(board);
            string solved = solver.SolveGrid(grid);
            Assert.IsTrue(solved == "?B86I379:;5FGH12A4D><=@CE294D3EFABC:7=6>?8<5@GHI;17=<@G54D16?C3E29;BHI:8>AFACEFH2@G<>;89DI1:63=475?B1:;>5H?I=84<@ABEC7FG63D29E4@2DC<3AGH6I=;7B?195:F8>FH9716B:>?8@53<=D2A4CIGE;3;:?6@E8HIDA>19<FGC57B24=5<IG879=DF2B:C4>6HE;?@A13=>BAC;12547EF?G83I@:D<9H6<DF3@AC>E=9;H2?BG186I54:7>1GC=I;H?7BD48F59:2<36E@AI25EB4G6F@<>A:3CH;7?=189D9A7H:D8B2<1IE56F@=43;C?>G86?4;9:135G=7@CDIE>ABFH<2@8H<?G3;6AI:B7D42591>E=FCGECIA1D59:@3?F=H7>6824;B<;31B>FI48HAG2<E:?@=C9D765:729F<=C@B>5648;EAGD1?3IH65D=4?>E72C91;H3<FIB@A:G8D?>82BA@I9F1CG7653:EH;<=4B@=57:H<C1E?D>AG49;F8263ICFA:9=674D32;B@I>8<HEG15?HI6;E82FG3=4<95@1C?7A>BD:4G31<>5?;E6H8I:A=DB2F9C7@");
        }


    }
}
