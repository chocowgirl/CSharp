using Demo5Indexeurs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5Indexeurs.Models
{
    public class Carte
    {
        //private variables (b/c we don't want people to be able to change the value of a card)
        private CouleurCarte _couleur;
        private ValeurCarte _valeur;

        //properties so that we can control the value of the card w/out touching it directly
        public CouleurCarte Couleur 
        {
            get { return _couleur; } 
        }

        public ValeurCarte Valeur
        {
            get { return _valeur; }
        }


        //here we create the constructor for the object.
        //we normally show the variables and properties before the constructor

        public Carte(CouleurCarte couleur, ValeurCarte valeur)
        {
            _couleur = couleur;
            _valeur = valeur;
        }


    }
}
