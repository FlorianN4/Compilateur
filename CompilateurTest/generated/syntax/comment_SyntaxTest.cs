using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Compilateur.Exception;
namespace Compilateur.Tests
{
    [TestClass()]
    public class comment_SyntaxTest
    {
    //
    // Serie comment OK
    //
        [TestMethod()]
        public void testcomment_Comment2_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ok\Comment2.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ok\Comment2.asm");
        }

        [TestMethod()]
        public void testcomment_end_comment_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ok\end_comment.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ok\end_comment.asm");
        }

        [TestMethod()]
        public void testcomment_everywhere_comment_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ok\everywhere_comment.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ok\everywhere_comment.asm");
        }

        [TestMethod()]
        public void testcomment_start_comment_ok(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ok\start_comment.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ok\start_comment.asm");
        }

    //
    // Serie comment KO
    //
        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testcomment_bad_comment_ko(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ko\bad_comment.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ko\bad_comment.asm");
        }

        [TestMethod()]
        [ExpectedException(typeof(ParsingException))]
        public void testcomment_other_bad_comment_ko(){
            Program.Compile(@"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\syntax\comment\ko\other_bad_comment.kiwi", 
                    @"C:\Users\flori\Desktop\Bac3 Q2\Micro Pro & Electro Sys\Micropro\Compilateur\CompilateurTest\generated\output\syntax\comment\ko\other_bad_comment.asm");
        }

    }
}
