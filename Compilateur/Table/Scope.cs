using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class Scope
    {
        public Scope()
        {
            Variables = new Dictionary<string, BaseSymbole>();
        }
        
        Dictionary<String, BaseSymbole> Variables { get; set; } //nom, type, scope

        public String Nom { get; set; }

        public void SymbolAdd(BaseSymbole nouveau, Type type)
        {
            nouveau.Symbole = type;
            if(Variables.ContainsKey(nouveau.Nom))
            {
                Variables.Add(nouveau.Nom, nouveau);
            }
        }
        

    }
}
