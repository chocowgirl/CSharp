using ExosOOPMonopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    public class CasePropriete
    {
        public string Nom {  get; }// autoproperty

        //complete version below (only if verif of entering and leaving data)
        //private string _nom;
        //public string Nom
        //{
        //    get { return _nom; }
        //    set { _nom = value; }
        //}

        public Couleurs Couleur { get; }

        public int Prix { get; }

        public bool EstHypoteqee { get; }

        public Joueur Proprietaire { get; private set; }

        public CasePropriete(string name, Couleurs colour, int price)
        {
            Nom = name;
            Couleur = colour;
            Prix = price;
            //EstHypoteqee = false; // false is the default value for this so it's not needed
            //Proprietaire = null; //null is the default value for this so it's not needed
        }


        public void Acheter(Joueur acheteur)
        {
            if (acheteur is null) return;  // goal is to leave as soon as possible, so manage the situations where it DOESN'T work first.
            if (Proprietaire == acheteur) return;  //later these returns s/b handled with exceptions
            if (acheteur.Solde < Prix) return;  //later handle exception
            if (acheteur.Solde >= Prix)
            acheteur.Payer(Prix);
            Proprietaire = acheteur;
            acheteur.AjouterPropriete(this);
        }


    }
}
