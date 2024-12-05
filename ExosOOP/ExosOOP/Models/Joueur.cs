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
        //public string nom;
        //public Pions pion;
        public string nom { get; set; }
        public Pions pion { get; set; }

        public int position;



        public int Position
        {
            get { return position; }
        }

        public int Solde
        {
            get;
        }



        public bool Avancer()
        {
            int[]chiffres = De.Lancer(2);
            foreach (int chiffre in chiffres)
            {
                position += chiffre;
            }
            if (chiffres[0] == chiffres[1]){
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
