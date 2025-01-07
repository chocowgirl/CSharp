using CatMouseEvents.Models;

namespace CatMouseEvents
{
    internal class Program
    {
        public static bool FinDeJeu {  get; private set; } = false;
        static void Main(string[] args)
        {
            Mouse s = new Mouse();
            s.PositionX = 5;
            s.PositionY = 5;

            Cat c = new Cat();
            c.PositionX = 0;
            c.PositionY = 0;

            s.Deplacement += delegate (int x, int y)  //delegate is a reaction to the Deplacement.
            {
                Console.WriteLine($"la souris de deplace en {x}, {y}.");
            };

            s.Deplacement += c.SeRapprocher; // this is how we subscribe the cat object to receive the event declaration of displacement from the mouse
            //c.Capture += CaptureAction;


            c.Capture += delegate ()//other method, create an anonymous method
            {
                Console.WriteLine("le chat a capturé le souris!");
                FinDeJeu = true;
            };


            //THE BELOW IS THE CODE FOR THE GAME CONDUCT ITSELF
            do
            {
                s.Deplacer();
            }while(!FinDeJeu);
        }

        //We put other functions other than the MAIN program AFTER the main program
        static void CaptureAction()//this method can be assigned to the method c.Capture (currently commented in the program)
        {
            Console.WriteLine("Le chat a capturé le souris!\nmiam miam.");
            FinDeJeu = true;
        }

    }
}
