using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Compilateur.Exception;
using Compilateur.Generator;
using Compilateur.Table;

namespace Compilateur
{
    public class Program
    {
        static KIWIParser parser = null;
        static void Main(string[] args)
        {
            if( args.Length >= 2)
            {
                string pathKiwi = args[0];
                string pathKAsm = args[1];
                
                Compile(pathKiwi, pathKAsm);
            }
        }

        public static void Compile(string path, string output)
        {
            var sourceCode = File.ReadAllText(path);
            // Check syntax
            var tree = Parse(sourceCode);
            
            //Et la table des symboles? 
            var table = BuildSymbolTable(tree);

            // Genrate code
            var asmCode = PrintAssemblyCode(tree, table);

            // Create output directory 
            CreateFolderStructur(output);
            // Print code to output file
            File.WriteAllText(output, asmCode);
        }

        private static void CreateFolderStructur(string output)
        {
            FileInfo fi = new FileInfo(output);
            Directory.CreateDirectory(fi.DirectoryName);
        }

        public static KIWIParser.KiwiContext Parse(string sourceCode)
        {
            AntlrInputStream input = new AntlrInputStream(sourceCode);
            CommonTokenStream tokens = new CommonTokenStream(new KIWILexer(input));
            parser = new KIWIParser(tokens);
            parser.RemoveErrorListeners();
            var stringErrorListener = new StringErrorListener();
            parser.AddErrorListener(stringErrorListener);

            KIWIParser.KiwiContext tree;

            try
            {
                tree = parser.kiwi();
            }
            catch (RecognitionException e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (stringErrorListener.ErrorHasBeenReported)
            {
                Console.WriteLine(stringErrorListener.ToString());
                throw new ParsingException(stringErrorListener.ToString());
            }

            return tree;
        }

        public static string PrintAssemblyCode(KIWIParser.KiwiContext tree, SymboleTable symbolTable) 
        {
            var stream = new StringWriter();
            var printer = new AssemblyPrinter(stream);
            KiwiVisitor visitor = new KiwiVisitor(printer, symbolTable);
            tree.Accept(visitor);
            printer.Flush();
            printer.Close();
            return stream.ToString();
        }

        public static SymboleTable BuildSymbolTable(KIWIParser.KiwiContext tree) {
            ParseTreeWalker walker = new ParseTreeWalker();
            KiwiSymbolParser symbolParser = new KiwiSymbolParser("Kiwi");
            walker.Walk(symbolParser, tree);

            return symbolParser.SymbolTable;
        }
    }
}
