using ExosOOPMonopoly.Enums;
using ExosOOPMonopoly.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    public class CasePropriete : Case, IProprietaire
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

        public bool EstHypotequee { get; private set; }

        public Joueur Proprietaire { get; private set; }

        public CasePropriete(string name, Couleurs colour, int price) : base(name)
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
            //bc an exception can be thrown by the method Jouer.Payer(int montant) it is no longer necessary to check the solde
            //if (acheteur.Solde < Prix)

            if (acheteur.Solde >= Prix)
                try
                {
                    acheteur.Payer(Prix);
                }
                catch (NotEnoughMoneyException ex)
                {
                    throw new NotEnoughMoneyException(ex.Payeur, ex.Montant, this);
                }
            Proprietaire = acheteur;
            acheteur.AjouterPropriete(this);
        }

        private void Sejourner(Joueur visiteur)
        {
            if(visiteur is null) return; //Handle with an exception
            if(Proprietaire is null) return; //Handle with an exception
            if(Proprietaire == visiteur) return; //Handle with an exception
            int rent = Prix / 4;
            visiteur.Payer(rent);
            Proprietaire.EtrePaye(rent);
        }

        public override void Activer(Joueur visiteur)
        {
            if (visiteur is null) return; //Handle with exception
            if (Proprietaire is null)
            {
                try { 
                    Acheter(visiteur); 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            else if (!(Proprietaire == visiteur))
            {
                Sejourner(visiteur);
            }
            //if (Proprietaire == visiteur) return;
        }

        public void Hypothequer()
        {
            if(EstHypotequee)return; //Handle with exception
            Proprietaire.EtrePaye(Prix / 2);
            EstHypotequee = true;
        }

        public void Deshypothequer()
        {
            if(!EstHypotequee)return; //Handle w exception
            int currentSolde = Proprietaire.Solde;
            Proprietaire.Payer((int)(Prix * 0.6));
            if(currentSolde != Proprietaire.Solde) //making sure the player is able to pay to reput the property on the market
            {
                EstHypotequee = false;
            }

        }

    }
}
