using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    public static class De
    {

        private static int _valeurMin = 1;
        private static int _valeurMax = 6;
        private static Random _rng = new Random(); //new is used for types, but not for variables (int is a primitive type)
        //could also initialise the _rng in the Property below, starting with if _rng is null, new Random() ***VERIFY THIS

        public static int ValeurMin //guardian/filter of _valeurMin
        {
            get
            {
                return _valeurMin;
            }
            set
            {
                if (value <= 0) return; // mieux de gerer l'exception but we haven't learned this yet
                _valeurMin = value;
                if (value >= _valeurMax)
                {
                    _valeurMax = value + 1;
                }
            }
        }



        public static int ValeurMax //guardian/filter of _valeurMax
        {
            get
            {
                return _valeurMax;
            }
            set
            {
                if (value <= 1) return;
                _valeurMax = value;
                if (value <= _valeurMin)
                {
                    _valeurMin = value - 1;
                }
            }
        }



        public static int[] Lancer(int nbDes)
        {
            //if(rng is null){
            //    rng = new Random();
            //}  We would put this if we didn't instantiate random in the creation of attributes
            // or this could be written as rng ??= new Random();

            int[]chiffres = new int[nbDes];
            
            for (int i=0; i<nbDes; i++) {
                chiffres[i] = _rng.Next(ValeurMin,ValeurMax+1);
            }
            return chiffres;
        }
    }
}
