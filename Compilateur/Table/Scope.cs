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

        public Scope(string nom, Type type)
        {
            Variables = new Dictionary<string, BaseSymbole>();
            Nom = nom;
            Type = type;
        }
        
        Dictionary<String, BaseSymbole> Variables { get; set; } //nom, type, scope

        public String Nom { get; set; }
        public Type Type { get; set; }

        public void SymbolAdd(BaseSymbole nouveau, KiwiType type) // + ajouter la valeur
        {
            nouveau.Symbole = type;
            if(Variables.ContainsKey(nouveau.Nom))
            {
                Variables.Add(nouveau.Nom, nouveau);
            }
        }
        public void SymbolAdd(Variable nouveau) // avant c'était BaseSymbole en paramètre
        {
            if (Variables.ContainsKey(nouveau.Nom))
            {
                Variables.Add(nouveau.Nom, nouveau);
            }
        }

        public void SymbolAdd(ParamVariable nouveau)
        {
            if (Variables.ContainsKey(nouveau.Nom))
            {
                Variables.Add(nouveau.Nom, nouveau);
            }
        }

        public void SymbolAdd(ConstVariable nouveau)
        {
            if (Variables.ContainsKey(nouveau.Nom))
            {
                Variables.Add(nouveau.Nom, nouveau);
            }
        }
    }
}
