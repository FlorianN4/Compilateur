﻿using Compilateur.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Compilateur.Table
{
    public class SymboleTable
    {

        Scope MainScope { get; set; } //le main scope est un scope

        Scope CurrentScope { get; set; }

        Dictionary<String, Scope> Symbol { get; set; } //nom, type, scope

        public SymboleTable()
        {
            MainScope = new Scope();
            CurrentScope = MainScope;
        }
        public void SymbolAdd()
        {
            Symbol.Add(CurrentScope.Nom, CurrentScope);
        }

        public void OpenScope(Scope nouveau) //verifier que les fct n'ont pas le meme nom et ajouter le scope a la table des symboles (appel de symboladd)
        {
            if(Symbol.ContainsKey(CurrentScope.Nom)) //fct exist dans dictionnaire
            {
                if (CurrentScope.Nom.Equals(nouveau.Nom))
                    throw new SymbolAlreadyDefinedException();
            }

            CurrentScope = nouveau;
            SymbolAdd();
        }

        public void CloseScope()
        {
            CurrentScope = MainScope;
        }

        public Scope getSymbol(String nom)
        {//fonction dans dictionnaire qui permet d'avoir la valeur (scope) en utilisant la key (nom du scope)
            Scope i = new Scope();
            if(Symbol.ContainsKey(nom))
            {
                Symbol.Add(nom, i);
                return i;
            }
            throw new NotFoundSymbolException();
        }

        public void addVariable(BaseSymbole nom, Type type)
        {
            CurrentScope.SymbolAdd(nom, type);
        }
    }
}