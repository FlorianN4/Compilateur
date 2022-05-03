using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Compilateur.Exception;
namespace Compilateur.Tests
{
    [TestClass()]
    public class assignation_SyntaxTest
    {
    //
    // Serie assignation OK
    //
        [TestMethod()]
        public void testassignation_assignation_bin_ok(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ok\assignation_bin.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ok\assignation_bin.asm");
        }

        [TestMethod()]
        public void testassignation_assignation_const_ok(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ok\assignation_const.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ok\assignation_const.asm");
        }

        [TestMethod()]
        public void testassignation_assignation_dec_ok(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ok\assignation_dec.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ok\assignation_dec.asm");
        }

        [TestMethod()]
        public void testassignation_assignation_hex_ok(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ok\assignation_hex.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ok\assignation_hex.asm");
        }

    //
    // Serie assignation KO
    //
        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testassignation_bad_assignation_bin_ko(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ko\bad_assignation_bin.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ko\bad_assignation_bin.asm");
        }

        [TestMethod()]
        [ExpectedException(typeof(ValueOverflowException))]
        public void testassignation_bad_assignation_dec_ko(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ko\bad_assignation_dec.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ko\bad_assignation_dec.asm");
        }

        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testassignation_bad_assignation_hex_ko(){
            Program.Compile(@"C:\compilateur\Compilateur\Compilateur\CompilateurTest\syntax\assignation\ko\bad_assignation_hex.kiwi", 
                    @"C:\compilateur\Compilateur\Compilateur\CompilateurTest\generated\output\syntax\assignation\ko\bad_assignation_hex.asm");
        }

    }
}
