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

        public static int ValeurMin //guardian/filter of _valeurMin
        {
            get
            {
                return _valeurMin;
            }
            set
            {
                if (value <= 0) return;
                if (value >= _valeurMax)
                {
                    _valeurMax = value + 1;
                }
                _valeurMin = value;
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
                if (value < 1) return;
                if (value <= _valeurMin)
                {
                    _valeurMin = value - 1;
                }
            }
        }


        public static Random rng = new Random(); //new is used for types, but not for variables (int is a primitive type


        public static int[] Lancer(int nbDes)
        {
            //if(rng is null){
            //    rng = new Random();
            //}  We would put this if we didn't instantiate random in the creation of attributes
            // or this could be written as rng ??= new Random();

            int[]chiffres = new int[nbDes];
            
            for (int i=0; i<nbDes; i++) {
                chiffres[i] = rng.Next(ValeurMin,ValeurMax+1);
            }
            return chiffres;
        }
    }
}
