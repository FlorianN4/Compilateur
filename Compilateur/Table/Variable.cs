using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class Variable : BaseSymbole
    {
        public Variable(String nom, KiwiType type, String str) : base(nom, type, str)
        {
        }

        public Variable(String nom, KiwiType type) : base(nom, type)
        {
        }

        public Variable(BaseSymbole a) { }
    }
}
