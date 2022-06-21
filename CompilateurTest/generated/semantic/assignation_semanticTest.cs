using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Compilateur.Exception;
using CompilateurTest._Masm;
namespace Compilateur.Tests
{
    [TestClass()]
    public class assignation_semanticTest
    {
                public string RootFolder => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../").ToLower());
    //
    // Serie assignation 
    //
        [TestMethod()]
        public void testassignation_assign_instruction(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\assignation\assign_instruction.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\assignation\assign_instruction.asm");

            var res = AssemblyRunner.Start(RootFolder, "assignation",  @"assign_instruction.asm", true);
            Assert.AreEqual("69", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testassignation_complex_assign_instruction(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\assignation\complex_assign_instruction.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\assignation\complex_assign_instruction.asm");

            var res = AssemblyRunner.Start(RootFolder, "assignation",  @"complex_assign_instruction.asm", true);
            Assert.AreEqual("2555", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testassignation_multi_assign_instruction(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\assignation\multi_assign_instruction.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\assignation\multi_assign_instruction.asm");

            var res = AssemblyRunner.Start(RootFolder, "assignation",  @"multi_assign_instruction.asm", true);
            Assert.AreEqual("6925505", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

        [TestMethod()]
        public void testassignation_paranthesis_assign_instruction(){
            Program.Compile(@"C:\compilateur\compilateur4\Compilateur\CompilateurTest\semantic\assignation\paranthesis_assign_instruction.kiwi", 
                    @"C:\compilateur\compilateur4\Compilateur\CompilateurTest\generated\output\semantic\assignation\paranthesis_assign_instruction.asm");

            var res = AssemblyRunner.Start(RootFolder, "assignation",  @"paranthesis_assign_instruction.asm", true);
            Assert.AreEqual("50125", res, "Le résultat de sortie de l'assembleur n'est pas celui attentdu");
        }

    }
}
