using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Compilateur.Exception;
using CompilateurTest._Masm;
namespace Compilateur.Tests
{
    [TestClass()]
    public class Basic_semanticTest
    {
                public string RootFolder => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../").ToLower());
    //
    // Serie Basic 
    //
        [TestMethod()]
        public void testBasic_basic_print(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\Basic\basic_print.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\Basic\basic_print.asm");

            var res = AssemblyRunner.Start(RootFolder, "Basic",  @"basic_print.asm", true);
            Assert.AreEqual("", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

    }
}
