using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class ParamVariable: BaseSymbole
    {
        public ParamVariable(String nom, KiwiType type, String str) : base(nom, type, str)
        {
        }
    }
}
