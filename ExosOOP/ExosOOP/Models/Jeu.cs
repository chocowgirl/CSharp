﻿using ExosOOPMonopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExosOOPMonopoly.Models
{
    public class Jeu
    {
        private List<Joueur> _joueurs;
        private List<Case> _plateau;

        public Joueur[] Joueurs
        {
            get
            { return _joueurs.ToArray(); }
        }

        public Case[] Plateau
        { 
            get { return _plateau.ToArray(); }
        }


        public Case this[int numero]
        {
            get
            {
                numero = numero % _plateau.Count;
                return _plateau[numero];
            }
        }


        public Joueur this[Pions pion]
        {
            get 
            { 
                foreach (Joueur j in _joueurs)
                {
                    if(j.Pion == pion) return j;
                }
                return null;
            }

        }

        public Jeu(Case[] cases)
        {
            if (cases is null) return; //Handle later with an exception
            if(cases.Length <= 0) return; //Handle later with an exception
            _joueurs = new List<Joueur>();
            _plateau = new List<Case>(cases);
        }


        public void AjouterJoueur(string nom, Pions pion)
        {
            if (nom is null) return; //Handle later with an exception
            if (this[pion] is not null) return; //Handle later with an exception
            Joueur nouveauJoueur = new Joueur(nom, pion);
            _joueurs.Add(nouveauJoueur);
            nouveauJoueur.JoueurAvanceEvent += JoueurAvanceAction;

        }

        public void JoueurAvanceAction(Joueur joueur)
        {
            this[joueur.Position].Activer(joueur);
        }

    }
}
