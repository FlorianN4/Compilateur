using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilateur.Table
{
    public enum KiwiType
    {
        INVALID,
        BYTE,
        WORD,
        STRING
    }


    public class BaseSymbole
    {
        public BaseSymbole() { }
        public BaseSymbole(String nom) //type = string, word, byte --> word et byte ? 
        {
            Nom = nom;
        }

        public BaseSymbole(String nom, KiwiType type, String str)
        {
            Nom = nom;
            Symbole = type;
            Valeur = str;
        }

        public BaseSymbole(String nom, KiwiType type)
        {
            Nom = nom;
            Symbole = type;
        }

        public BaseSymbole(String nom, String str) //les constante n'ont pas de type
        {
            Nom = nom;
            Valeur = str;
        }

        public void TrouverType(String str) //fct pour les constantes 
        {

            if (Int32.TryParse(str, out int numValue))
            { //tester si c'est des bit, hexa ou string
                if (str.StartsWith("0x"))
                {
                    //c'est hexa
                    if (numValue < ushort.MaxValue) ;
                }
                if (str.StartsWith("0b"))
                {
                    //c'est binaire
                    if (numValue < byte.MaxValue) ;
                }
            }
            //c'est string
        }

        public KiwiType Symbole { get; set; }
        public String Nom { get; set; }

        public String Valeur { get; set; }
    }
}
