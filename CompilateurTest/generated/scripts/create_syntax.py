
import os

filePath=os.path.dirname(os.path.realpath(__file__))
syntaxDir=os.path.join(filePath, "../../syntax") 
os.makedirs(os.path.join(filePath, f"../syntax"), exist_ok = True)

for serie in [x for x in os.listdir(syntaxDir) if not x.startswith(".")]:
    test_name = f"{serie}_SyntaxTest"
    test_file = os.path.join(filePath, f"../syntax/{test_name}.cs")

    with open(test_file, "w") as writer:
        okDir=os.path.join(syntaxDir, serie, "ok")
        koDir=os.path.join(syntaxDir, serie, "ko")

        writer.write("using Microsoft.VisualStudio.TestTools.UnitTesting;\n")
        writer.write("using System;\n")
        writer.write("using Compilateur.Exception;\n")
        writer.write("namespace Compilateur.Tests\n")
        writer.write("{\n")
        writer.write("    [TestClass()]\n")
        writer.write(f"    public class {test_name}\n")
        writer.write("    {\n")
        writer.write("    //\n")
        writer.write("    // Serie {} OK\n".format(serie))
        writer.write("    //\n")
        for inputFile in [x for x in os.listdir(okDir) if not x.startswith(".")]:
            in_file = os.path.join(filePath, serie, okDir, f"{inputFile}")
            in_file = os.path.abspath(in_file)

            out_file = os.path.join(filePath, "../output/syntax", serie, "ok")
            out_file = os.path.abspath(out_file)
            os.makedirs(out_file, exist_ok = True)
            out_file = os.path.join(out_file, f"{inputFile.replace('kiwi','asm')}")
            
            writer.write("        [TestMethod()]\n")
            name = inputFile.replace(".kiwi", "")
            writer.write(f"        public void test{serie}_{name}_ok(){{\n")
            writer.write(f"            Program.Compile(@\"{in_file}\", \n")
            writer.write(f"                    @\"{out_file}\");\n")
            writer.write("        }\n\n")


        writer.write("    //\n")
        writer.write("    // Serie {} KO\n".format(serie))
        writer.write("    //\n")
        for inputFile in [x for x in os.listdir(koDir) if not x.startswith(".")]:
            in_file = os.path.join(filePath, serie, koDir, f"{inputFile}")
            in_file = os.path.abspath(in_file)

            out_file = os.path.join(filePath, "../output/syntax", serie, "ko")
            out_file = os.path.abspath(out_file)
            os.makedirs(out_file, exist_ok = True)
            out_file = os.path.join(out_file, f"{inputFile.replace('kiwi','asm')}")

            #Get the expected result
            with open(in_file, "r", encoding="utf-8") as kiwiFile:
                expectedException = [i.strip().lstrip("#") for i in kiwiFile.readlines() if i.startswith("####") ]
                if len(expectedException) > 0:
                    expectedException = expectedException[0]
                else:
                    expectedException = "ParsingException"
                print(expectedException)

            writer.write("        [TestMethod()]\n")
            writer.write(f"        [ExpectedException(typeof({expectedException}))]\n")
            name = inputFile.replace(".kiwi", "")
            writer.write(f"        public void test{serie}_{name}_ko(){{\n")
            writer.write(f"            Program.Compile(@\"{in_file}\", \n")
            writer.write(f"                    @\"{out_file}\");\n")
            writer.write("        }\n\n")
        
        writer.write("    }\n")
        writer.write("}\n")
