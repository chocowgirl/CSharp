using System.Drawing;

namespace Demo2Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Voiture v1 = new Voiture();
            v1.color = Enums.EnumColor.Rouge; // if we put using Demo2Static.Enums then
            v1.nbSeats = 4;

            //Voiture v2 = new Voiture();
            //v2.color = Enums.EnumColor.Rouge;
            //v2.nbSeats = 4;

            Voiture v2 = new Voiture() {
                color = Enums.EnumColor.Bleu,
                nbSeats = 5
            };

            Voiture.nbWheels = 4; //normally static attributes are defined in the class not in the program

            Console.WriteLine($"Ma voiture de Dorothée est de couleur {v1.color} et a {v1.nbSeats} sieges.  Toutes les voitures ont {Voiture.nbWheels} roues.");
            Console.WriteLine($"La voiture de Dorothée est de couleur {v2.color} et a {v2.nbSeats} sieges.  Toutes les voitures ont {Voiture.nbWheels} roues.");

            Console.WriteLine($"Je roule trop vite, je crash, je perds une roue...");
            Voiture.nbWheels -= 1; // here ALL the cars lose a wheel, which is why it's important to think about what you make static

            Console.WriteLine(Mathematics.Addition(3.14, 2.5, 7.2));


        }
    }
}
