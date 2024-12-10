using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExosOOPMonopoly.Enums;

namespace ExosOOPMonopoly.Models
{
    public class Joueur
    {
        private int _position;
        private List<CasePropriete> _proprietes; // list b/c as we play we can add properties as we buy them... BUT we don't want this to be accessible directly, so we make this readable by creating the autoproperty

        //public string nom; // these two are left behind by the creation of autoproperties below
        //public Pions pion;
        public string Nom { get; set; }
        public Pions Pion { get; set; }

        public int Solde { get; private set; }


        public Joueur(string name, Pions pion)
        {
            Nom = name;
            Pion = pion;
            Solde = 1500;
            _position = 0;//pas besoin d'initialiser ici car le defaut value of the int is 0
            _proprietes = new List<CasePropriete>();
        }


        public CasePropriete[] Proprietes //searches in the list to show us
        {
            get
            {
                return _proprietes.ToArray();
            }
        }


        public int Position { 
            get
            {
                return _position;
            } 
            private set
            {
                _position = value;
            }
        }


        public bool Avancer()
        {
            int[]chiffres = De.Lancer(2);
            foreach (int chiffre in chiffres)
            {
                Position += chiffre;
            }
            if (chiffres[0] == chiffres[1]){
                return true;
            }
            else
            {
                return false;
            }
        }


        public void EtrePaye(int montant)
        {
            if (montant >= 0) return; //handle with an exception
            Solde += montant;
        }

        public void Payer(int montant)
        {
            if (montant <= 0) return;
            if (Solde < montant) return;
            Solde -= montant;
        }

        public void AjouterPropriete(CasePropriete bien)
        {
            if (bien == null) return;
            if (Proprietes.Contains(bien)) return; //To avoid the possibility of buying the same property twice.
            if (bien.Proprietaire == this) _proprietes.Add(bien);
        }


        public static Joueur operator +(Joueur left, int right)
        {
            //left.Solde += right;
            //return left;
            left.EtrePaye(right); //this way includes the verification that is made in EtrePaye()
            return left;
        }


        //public static CasePropriete[] operator +(Joueur left, CasePropriete right)
        //{
        //    right.Acheter(left);
        //    return left.Proprietes;
        //}  
        // This overloaded operator becomes obsolete/impossible because we protected Acheter() as a private method

    }
}
