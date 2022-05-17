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


        public override string VisitKiwi(KIWIParser.KiwiContext context)
        {
            this.Printer.PrintBegin();

            foreach (var instructionContext in context.instruction())
            {
                var left = this.Visit(instructionContext);
            }

            this.Printer.PrintMainEnd();

            this.Printer.PrintEnd();

            return string.Empty;
        }
        public override string VisitRightExprPLUSMIN([NotNull] KIWIParser.RightExprPLUSMINContext context)
        {
            this.Printer.PrintComment(context.GetText());

            if (context.op.Type == KIWILexer.PLUS)
            {
                this.Printer.PrintAdd(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.MINUS)
            {
                this.Printer.PrintSous(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            return string.Empty;
        }

        public override string VisitInstIncDec([NotNull] KIWIParser.InstIncDecContext context)
        {
            this.Printer.PrintComment(context.GetText());

            if (context.op.Type == KIWILexer.PLUSPLUS)
            {
                this.Printer.PrintInc(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.MINUSMINUS)
            {
                this.Printer.PrintDec(AssemblyRegister.AX, AssemblyRegister.BX);
            }

            return string.Empty;
        }

        public override string VisitRightEpxrBetweenPAR([NotNull] KIWIParser.RightEpxrBetweenPARContext context)
        {
            return base.VisitRightEpxrBetweenPAR(context);
        }
        public override string VisitRightExprENTIER([NotNull] KIWIParser.RightExprENTIERContext context)
        {
            //var = entier
          /*  var right = this.Visit(context.exprd());
            if (!string.IsNullOrWhiteSpace(right))
                this.Printer.PrintMov(AssemblyRegister.AX, right);
            this.Printer.PrintCallPrintAX();
          */
            return base.VisitRightExprENTIER(context);
        }
        public override string VisitInstRightExpr([NotNull] KIWIParser.InstRightExprContext context)
        {
            return base.VisitInstRightExpr(context);
        }
        public override string VisitRightExprSTRING([NotNull] KIWIParser.RightExprSTRINGContext context)
        {
            //mettre le string dans une variable
            //this.Printer.PrintMov(AssemblyRegister.AX, right);
            /*var right = this.Visit(context.exprd());
            if (!string.IsNullOrWhiteSpace(right))
                this.Printer.PrintMov(AssemblyRegister.AX, right);
            this.Printer.PrintCallPrintAX();*/
            //faux
            return base.VisitRightExprSTRING(context);
        }
        public override string VisitRightExprID([NotNull] KIWIParser.RightExprIDContext context)
        {
            Printer.PrintPush(context.GetText());
            return base.VisitRightExprID(context);
        }
        public override string VisitRightExprNOT([NotNull] KIWIParser.RightExprNOTContext context)
        {
            return base.VisitRightExprNOT(context);
        }
        public override string VisitInstLeftEqualRight([NotNull] KIWIParser.InstLeftEqualRightContext context)
        {
            var right = this.Visit(context.exprd());
            if (!string.IsNullOrWhiteSpace(right))
                this.Printer.PrintMov(AssemblyRegister.AX, right);
            this.Printer.PrintCallPrintAX();

            return base.VisitInstLeftEqualRight(context);
        }
        public override string VisitRightExprORANDXORRightExpr([NotNull] KIWIParser.RightExprORANDXORRightExprContext context)
        {
            this.Printer.PrintComment(context.GetText());

            if (context.op.Type == KIWILexer.AND)
            {
                this.Printer.PrintAnd(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.XOR)
            {
                this.Printer.PrintXor(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.OR)
            {
                this.Printer.PrintOr(AssemblyRegister.AX, AssemblyRegister.BX);
            }

            return string.Empty;
        }
        public override string VisitRightExprPARAM([NotNull] KIWIParser.RightExprPARAMContext context)
        {
            this.Printer.PrintComment(context.GetText());

            return base.VisitRightExprPARAM(context);
        }
        public override string VisitRightExprSHIFTDGRightExpr([NotNull] KIWIParser.RightExprSHIFTDGRightExprContext context)
        {        
            this.Printer.PrintComment(context.GetText());
            if (context.op.Type == KIWILexer.SHIFTD)
            {
                this.Printer.PrintShiftd(AssemblyRegister.AX);
            }
            if (context.op.Type == KIWILexer.SHIFTG)
            {
                this.Printer.PrintShiftg(AssemblyRegister.AX);
            }
            return base.VisitRightExprSHIFTDGRightExpr(context);
        }
        public override string VisitRightExprDIVMULMOD([NotNull] KIWIParser.RightExprDIVMULMODContext context)
        {
            this.Printer.PrintComment(context.GetText());
            //type mod div ou mod ?
            if (context.op.Type == KIWILexer.DIV)
            {
                this.Printer.PrintDiv(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.MUL)
            {
                this.Printer.PrintMul(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            if (context.op.Type == KIWILexer.MODULO)
            {
                this.Printer.PrintMod(AssemblyRegister.AX, AssemblyRegister.BX);
            }
            return string.Empty;
        }

        public override string VisitInstNOP(KIWIParser.InstNOPContext context)
        {
            this.Printer.PrintComment(context.GetText());
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
