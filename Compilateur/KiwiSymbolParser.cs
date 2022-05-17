using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using Compilateur.Table;
using Compilateur.Exception;
using System;

namespace Compilateur
{
    public class KiwiSymbolParser : KIWIBaseListener
    {
        public SymboleTable SymbolTable { get; private set; }

        public KiwiSymbolParser(string name)
        {
            this.SymbolTable = new SymboleTable();
        }

        public override void EnterVardecl(KIWIParser.VardeclContext context)
        {
            string value;
            KiwiType t = KiwiType.INVALID;
            if (context.BYTE() != null)
                t = KiwiType.BYTE;
            if (context.WORD() != null)
                t = KiwiType.WORD;
            if (context.STRING() != null)
                t = KiwiType.STRING;
            if (context.EQUAL() == null)
                this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t)); // pas de valeur à stocker la valeur de la variable
            else
            {
                if (context.NUMBER() != null)
                {
                    value = context.NUMBER().GetText();

                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                }
                if (context.BIT8() != null)
                {
                    value = context.BIT8().GetText();
                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                    
                }
                if (context.BIT16() != null)
                {
                    value = context.BIT16().GetText();
                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                }
                if (context.HEXA8() != null)
                {
                    value = context.HEXA8().GetText();
                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                }
                if (context.HEXA16() != null)
                {
                    value = context.HEXA16().GetText();
                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                }
                if (context.STRINGLITTERAL() != null)
                {
                    value = context.STRINGLITTERAL().GetText();
                    this.SymbolTable.addVariable(new Variable(context.ID().GetText(), t, value));
                }
            }
            base.EnterVardecl(context);
        }

        public override void EnterFctdecl([NotNull] KIWIParser.FctdeclContext context)
        {
            this.SymbolTable.OpenScope(new Scope(context.ID().GetText(), context.ID().GetType()));
            base.EnterFctdecl(context); // sert à quoi ?
        }

        public override void ExitFctdecl([NotNull] KIWIParser.FctdeclContext context)
        {
            this.SymbolTable.CloseScope();
        }

        public override void EnterParamdecl([NotNull] KIWIParser.ParamdeclContext context)
        {

            KiwiType t = KiwiType.INVALID;
            if (context.BYTE() != null)
                t = KiwiType.BYTE;
            if (context.WORD() != null)
                t = KiwiType.WORD;
            this.SymbolTable.addVariable(new ParamVariable(context.ID().GetText(), t));
        }
      
        public override void EnterConstdecl([NotNull] KIWIParser.ConstdeclContext context) //les constantes n'ont pas de type
        {
            string value;
            
                //exception pour dire qu'une constante a toujours une valeur
            if (context.NUMBER() != null)
            { 
                value = context.NUMBER().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }
            if (context.BIT8() != null)
            {
                value = context.BIT8().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }
            if (context.BIT16() != null)
            {
                value = context.BIT16().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }
            if (context.HEXA8() != null)
            {
                value = context.HEXA8().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }
            if (context.HEXA16() != null)
            {
                value = context.HEXA16().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }
            if (context.STRINGLITTERAL() != null)
            {
                value = context.STRINGLITTERAL().GetText();
                this.SymbolTable.addVariable(new ConstVariable(context.ID().GetText(), value));
            }

        }
    }
}
