using ExosOOPMonopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    public class CasePropriete : Case 
    {
        //public string Nom {  get; }// autoproperty  - removed because this class is a child of Case which contains name already

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

        public CasePropriete(string name, Couleurs colour, int price) : base (name)
        {
            //Nom = name; //commented out after making CasePropriete a child of Case
            Couleur = colour;
            Prix = price;
            //EstHypoteqee = false; // false is the default value for this so it's not needed
            //Proprietaire = null; //null is the default value for this so it's not needed
        }


        private void Acheter(Joueur acheteur)
        {
            if (acheteur is null) return;  // goal is to leave as soon as possible, so manage the situations where it DOESN'T work first.
            if (Proprietaire == acheteur) return;  //later these returns s/b handled with exceptions
            if (acheteur.Solde < Prix) return;  //later handle exception
            if (acheteur.Solde >= Prix)
            acheteur.Payer(Prix);
            Proprietaire = acheteur;
            acheteur.AjouterPropriete(this);
        }

        private void Sejourner(Joueur visiteur)
        {
            visiteur.Payer(Prix/4);
        }

        public override void Activer(Joueur visiteur)
        {
            if (Proprietaire is null)
            {
                Acheter(visiteur);
            }
            if (Proprietaire == visiteur) return;
            if (!(Proprietaire == visiteur))
            {
                Sejourner (visiteur);
            }
        }
    }
}
