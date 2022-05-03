using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using Compilateur.Table;

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
            this.SymbolTable.addVariable(new BaseSymbole(context.ID().GetText()), context.ID().GetType()); //+ stocké la valeur de la variable
            base.EnterVardecl(context);
        }

        public override void EnterFctdecl([NotNull] KIWIParser.FctdeclContext context)
        {
            this.SymbolTable.OpenScope(new Scope(context.ID().GetText(), context.ID().GetType()));
            base.EnterFctdecl(context);
        }
    }
}
