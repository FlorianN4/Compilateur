using System.Collections.Generic;
using Antlr4.Runtime.Misc;
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

        public override string VisitRightExprPLUSMIN([NotNull] KIWIParser.RightExprPLUSMINContext context)
        {
            return base.VisitRightExprPLUSMIN(context);
        }
        public override string VisitRightEpxrBetweenPAR([NotNull] KIWIParser.RightEpxrBetweenPARContext context)
        {
            return base.VisitRightEpxrBetweenPAR(context);
        }
        public override string VisitRightExprENTIER([NotNull] KIWIParser.RightExprENTIERContext context)
        {
            return base.VisitRightExprENTIER(context);
        }
        public override string VisitInstRightExpr([NotNull] KIWIParser.InstRightExprContext context)
        {
            return base.VisitInstRightExpr(context);
        }
        public override string VisitRightExprSTRING([NotNull] KIWIParser.RightExprSTRINGContext context)
        {
            return base.VisitRightExprSTRING(context);
        }
        public override string VisitRightExprID([NotNull] KIWIParser.RightExprIDContext context)
        {
            return base.VisitRightExprID(context);
        }
        public override string VisitRightExprNOT([NotNull] KIWIParser.RightExprNOTContext context)
        {
            return base.VisitRightExprNOT(context);
        }
        public override string VisitInstLeftEqualRight([NotNull] KIWIParser.InstLeftEqualRightContext context)
        {
            return base.VisitInstLeftEqualRight(context);
        }
        public override string VisitRightExprORANDXORRightExpr([NotNull] KIWIParser.RightExprORANDXORRightExprContext context)
        {
            return base.VisitRightExprORANDXORRightExpr(context);
        }
        public override string VisitRightExprPARAM([NotNull] KIWIParser.RightExprPARAMContext context)
        {
            return base.VisitRightExprPARAM(context);
        }
        public override string VisitRightExprPLUSPLUSMINMIN([NotNull] KIWIParser.RightExprPLUSPLUSMINMINContext context)
        {
            return base.VisitRightExprPLUSPLUSMINMIN(context);
        }
        public override string VisitRightExprSHIFTDGRightExpr([NotNull] KIWIParser.RightExprSHIFTDGRightExprContext context)
        {
            return base.VisitRightExprSHIFTDGRightExpr(context);
        }
        public override string VisitRightExprDIVMULMOD([NotNull] KIWIParser.RightExprDIVMULMODContext context)
        {
            this.Printer.PrintComment(context.GetText());
            if (context.op.Type == KIWILexer.DIV)
            {
                //this.Printer.PrintDiv();
            }
            //la même pour mul et mod
            return string.Empty;
        }

        public override string VisitInstNOP(KIWIParser.InstNOPContext context)
        {
            this.Printer.PrintNop();
            return string.Empty;
        }

        public override string VisitInstPrint(KIWIParser.InstPrintContext context)
        {
            this.Printer.PrintComment(context.GetText());

            var right = this.Visit(context.exprd());
            if (!string.IsNullOrWhiteSpace(right))
                this.Printer.PrintMov(AssemblyRegister.AX, right);

            this.Printer.PrintCallPrintAX();
            return string.Empty;
        }

    }
}
