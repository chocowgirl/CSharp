using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMouseEvents.Models
{
    public delegate void CaptureHandler();

    public class Cat
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public event CaptureHandler Capture;
        public void SeRapprocher(int sourisX, int sourisY)
        {
            if (PositionX > sourisX) PositionX--;
            else if (PositionX < sourisX) PositionX++;
            if (PositionY > sourisY) PositionY--;
            else if (PositionY < sourisY) PositionY++;
            Console.WriteLine($"le chat se rapproche en {PositionX}, {PositionY}");

            if (PositionX == sourisX && PositionY == sourisY) Capture?.Invoke();
        }



        //can generate cat position in the game.
        //public Cat()
        //{
        //    positionX = r.Next(1, 11); // Random number between 1 and 10 (inclusive)
        //    positionY = r.Next(1, 11); // Random number between 1 and 10 (inclusive)
        //}

        //public void SeRapprocher(Mouse m)
        //{
        //    //boucle for turns?
        //    int xdeplace = 0;
        //    int ydeplace = 0;

        //    //looks at Mouse(m)X, if mouse(m) x is higher than Cat(this)positionX, deplace +1, if lower, -1, if same, no displacement
        //    if (m.positionX > positionX){
        //        xdeplace = -1;
        //    }
        //    else if(m.positionX < positionX){
        //        xdeplace = 1;
        //    }

        //    //looks at Mouse(m)Y, if mouse(m) Y is higher than Cat(c)positionY, deplace +1, if lower, -1, if same, no displacement
        //    if (m.positionY > positionY)
        //    {
        //        ydeplace = -1;
        //    }
        //    else if (m.positionY < positionY)
        //    {
        //        ydeplace = 1;
        //    }
        //    positionX += xdeplace;
        //    positionY += ydeplace;

        //}


    }
}
