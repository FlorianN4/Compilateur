using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class BaseSymbole
    {
        public BaseSymbole() {}
        public BaseSymbole(String nom) //type = string, word, byte --> word et byte ? On trouve le type puis on le caste dans i, c ou string
        {  
            Nom = nom; 
        } //on doit tester le type pour le trouver

        public Type Symbole { get ;  set; }
        public String Nom { get; set; }
       
        public int i { get; set; }
        public char c { get; set; }
    }
}
