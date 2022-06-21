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
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\syntax\function\ok\function_sous.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\syntax\function\ok\function_sous.asm");
        }

        [TestMethod()]
        public void testfunction_function_sum_ok(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\syntax\function\ok\function_sum.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\syntax\function\ok\function_sum.asm");
        }

    //
    // Serie function KO
    //
        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testfunction_function_empty_ko(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\syntax\function\ko\function_empty.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\syntax\function\ko\function_empty.asm");
        }

        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testfunction_function_missing_paranthesis_ko(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\syntax\function\ko\function_missing_paranthesis.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\syntax\function\ko\function_missing_paranthesis.asm");
        }

    }
}
