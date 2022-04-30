using System.Collections.Generic;
using Compilateur.Generator;
using Compilateur.Table;

namespace Compilateur
{
    public class KiwiVisitor : KIWIBaseVisitor<string>
    {
        public AssemblyPrinter Printer { get; set; }
        public SymboleTable SymbolTable { get; }


        public KiwiVisitor(AssemblyPrinter printer, SymboleTable symbolTable)
        {
            this.Printer = printer;
            this.SymbolTable = symbolTable;
        }

        //public override string VisitKiwi(KIWIParser.KiwiContext context)
        //{
        //    this.Printer.PrintBegin();

        //    foreach (var instructionContext in context.instruction())
        //    {
        //        var left = this.Visit(instructionContext);
        //    }

        //    this.Printer.PrintMainEnd();

        //    this.Printer.PrintEnd();

        //    return string.Empty;
        //}

        //public override string VisitRightExprPlusMinus(KIWIParser.RightExprPlusMinusContext context)
        //{
        //    this.Printer.PrintComment( context.GetText());


        //    if (context.op.Type == KIWILexer.PLUS)
        //        this.Printer.PrintAdd(AssemblyRegister.AX, AssemblyRegister.BX);

        //    return string.Empty;
        //}

        //public override string VisitInstNOP(KIWIParser.InstNOPContext context)
        //{
        //    this.Printer.PrintNop();
        //    return string.Empty;
        //}

        //public override string VisitInstPrint(KIWIParser.InstPrintContext context)
        //{
        //    this.Printer.PrintComment( context.GetText());

        //    var right = this.Visit(context.exprd());
        //    if( !string.IsNullOrWhiteSpace(right) )
        //        this.Printer.PrintMov(AssemblyRegister.AX, right);

        //    this.Printer.PrintCallPrintAX();
        //    return string.Empty;
        //}
        
    }
}
