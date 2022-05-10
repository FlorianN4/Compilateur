using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class Fonction : Scope
    {
        public Fonction()
        {
        }

        public Fonction(String nom, Type type) : base(nom, type)
        {
        }
    }
}
