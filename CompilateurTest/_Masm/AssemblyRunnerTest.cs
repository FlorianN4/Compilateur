using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilateurTest._Masm
{
    [TestClass()]
    public class AssemblyRunnerTest
    {
        public string RootFolder => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../").ToLower());

        [TestMethod()]
        public void AssemblyRunnerAA_asm()
        {
            AssemblyRunner.Start(RootFolder, "_runner", "aa.asm", true);
        }

        [TestMethod()]
        public void AssemblyRunnerBB_asmExceptionExpected()
        {
            AssemblyRunner.Start(RootFolder, "_runner", "bb.asm", true);
        }

        [TestMethod]
        public void To8_3Test()
        {
            var p1 = AssemblyRunner.To8_3(@"C:\Users\karl\Downloads\DosBox With MP folder\DOSBox0_74-win32-installer\Screen.bat");
            Assert.IsTrue(p1.EndsWith(".bat"));
            var p2 = AssemblyRunner.To8_3(@"C:\Users\karl\Downloads\DosBox With MP folder\DOSBox0_74-win32-installer\Screenshots & Recordings.bat");
            Assert.IsTrue(p2.EndsWith(".bat"));
        }
    }
}