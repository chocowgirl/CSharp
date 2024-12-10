using Demo5Indexeurs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5Indexeurs.Models
{
    public class Paquet
    {
        private List<Carte> _carteList;


        //In the below this[] says my paquet is going to have it's own indexer

        public Carte this[int index]
        {
            get {
                //return _carteList[index];
                Carte c = _carteList[index];
                _carteList.Remove(c);
                return c;
                //The above states that card 4 is this value, remember it in this var, return it but also remove that value(card) from the pile
            }
            //for this demo we don't really need the setter, but he leaves it and sets it to private
            private set {
                _carteList[index] = value;
            }
        }


        public Carte? this[ValeurCarte valeur, CouleurCarte couleur]
        {
            get
            {
                foreach (Carte carte in _carteList)
                {
                    if(carte.Couleur == couleur && carte.Valeur == valeur)
                    {
                        _carteList.Remove(carte);
                        return carte;
                    }
                }
                return null;
            }
        }


        public int Count
        {
            get { return _carteList.Count; }
        }


        public Paquet()
        {
            _carteList = new List<Carte>();
            foreach (CouleurCarte couleur in Enum.GetValues<CouleurCarte>())
            {
                foreach(ValeurCarte valeur in Enum.GetValues<ValeurCarte>())
                {
                    _carteList.Add(new Carte(couleur, valeur));
                }
            }
        }


        //Why use an indexer?  Maybe to be able to take the 4th card in the paquet
        


    }
}
