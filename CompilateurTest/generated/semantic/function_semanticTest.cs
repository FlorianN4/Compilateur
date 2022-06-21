using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Compilateur.Exception;
using CompilateurTest._Masm;
namespace Compilateur.Tests
{
    [TestClass()]
    public class function_semanticTest
    {
                public string RootFolder => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../").ToLower());
    //
    // Serie function 
    //
        [TestMethod()]
        public void testfunction_assign_param_function(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\function\assign_param_function.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\function\assign_param_function.asm");

            var res = AssemblyRunner.Start(RootFolder, "function",  @"assign_param_function.asm", true);
            Assert.AreEqual("17", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testfunction_param5_function(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\function\param5_function.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\function\param5_function.asm");

            var res = AssemblyRunner.Start(RootFolder, "function",  @"param5_function.asm", true);
            Assert.AreEqual("110", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testfunction_param_function(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\function\param_function.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\function\param_function.asm");

            var res = AssemblyRunner.Start(RootFolder, "function",  @"param_function.asm", true);
            Assert.AreEqual("5", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testfunction_simple_function(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\function\simple_function.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\function\simple_function.asm");

            var res = AssemblyRunner.Start(RootFolder, "function",  @"simple_function.asm", true);
            Assert.AreEqual("10", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

    }
}
