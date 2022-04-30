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
        public BaseSymbole(String nom) {  Nom = nom; }
        public Type Symbole { get ;  set; }
        public String Nom { get; set; }
       
        public int i { get; set; }
        public char c { get; set; }
    }
}
