using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class ConstVariable : BaseSymbole
    {
        public ConstVariable(String nom, String str) : base(nom, str)
        {
        }
    }
}
