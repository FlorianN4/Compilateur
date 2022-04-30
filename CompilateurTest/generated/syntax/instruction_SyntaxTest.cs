using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Compilateur.Exception;
namespace Compilateur.Tests
{
    [TestClass()]
    public class instruction_SyntaxTest
    {
    //
    // Serie instruction OK
    //
        [TestMethod()]
        public void testinstruction_and_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\and_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\and_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_arith_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\arith_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\arith_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_binary_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\binary_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\binary_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_dec_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\dec_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\dec_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_div_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\div_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\div_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_inc_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\inc_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\inc_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_mod_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\mod_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\mod_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_mul_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\mul_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\mul_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_or_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\or_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\or_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_print_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\print_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\print_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_shl_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\shl_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\shl_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_shr_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\shr_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\shr_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_sub_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\sub_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\sub_instruction.asm");
        }

        [TestMethod()]
        public void testinstruction_xor_instruction_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ok\xor_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ok\xor_instruction.asm");
        }

    //
    // Serie instruction KO
    //
        [TestMethod()]
        [ExpectedException(typeof(NotFoundSymbolException))]
        public void testinstruction_bad_add_instruction_ko(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\instruction\ko\bad_add_instruction.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\instruction\ko\bad_add_instruction.asm");
        }

    }
}
