using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public class Fonction //utile ?? pcq scope est une fonction
    {
        public Fonction()
        {

        }

        public Fonction(String nom, Type type)
        {
            Nom = nom;
            Type = type;
            //tester le type pour savoir de quel type il s'agit puis mettre ce type dans Type
        }

        String Nom { get; set; }

        Type Type { get; set; }

    }
}
