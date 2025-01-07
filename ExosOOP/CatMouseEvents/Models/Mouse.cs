using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMouseEvents.Models
{
    public delegate void DeplacementHandler(int x, int y);
    public class Mouse
    {
        //private Random r = new Random();

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public event DeplacementHandler Deplacement;

        public void Deplacer()
        {
            Random RNG = new Random();
            int xdeplace = RNG.Next(-1, 2); // Random displacement: -1, 0, or 1
            PositionX += xdeplace;
            //can be coded more succinctly as PositionX += RNG.Next(-1, 2);
            PositionY += RNG.Next(-1, 2);
            Deplacement?.Invoke(PositionX, PositionY);
        }

        //constructor not necessary b/c we can also do this in the game
        //public Mouse()
        //{
        //    PositionX = r.Next(1, 11); // Random number between 1 and 10 (inclusive)
        //    PositionY = r.Next(1, 11); // Random number between 1 and 10 (inclusive)
        //}



    }
}
