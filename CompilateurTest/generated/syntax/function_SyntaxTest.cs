using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Compilateur.Exception;
namespace Compilateur.Tests
{
    [TestClass()]
    public class function_SyntaxTest
    {
    //
    // Serie function OK
    //
        [TestMethod()]
        public void testfunction_function_sous_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\function\ok\function_sous.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\function\ok\function_sous.asm");
        }

        [TestMethod()]
        public void testfunction_function_sum_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\function\ok\function_sum.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\function\ok\function_sum.asm");
        }

    //
    // Serie function KO
    //
        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testfunction_function_empty_ko(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\function\ko\function_empty.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\function\ko\function_empty.asm");
        }

        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testfunction_function_missing_paranthesis_ko(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\function\ko\function_missing_paranthesis.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\function\ko\function_missing_paranthesis.asm");
        }

    }
}
