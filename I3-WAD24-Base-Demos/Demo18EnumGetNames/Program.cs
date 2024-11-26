using System.Reflection.Metadata;

namespace Demo18EnumGetNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("voici la liste des couleurs de mon enumeration: ");
            
            //foreach (string couleur in Enum.GetNames(typeof(Couleurs)))
            //{
            //    Console.WriteLine(couleur);
            //}
            //The above version (eg slide) is an oldskool way of doing this, the following structure was developed after
            
            //OU...

            foreach (string couleur in Enum.GetNames<Couleurs>())
            {
                Console.WriteLine(couleur);
            }

            foreach (Couleurs couleur in Enum.GetValues<Couleurs>())
            {
                Console.WriteLine(couleur);
            }

            //recuperer une enumeration a partir d'un string
            Console.WriteLine("Quelle couleur aimez-vous?");

            string userColor = Console.ReadLine();

            //Version non-generique:
            //Couleurs couleurFavorite = (Couleurs)Enum.Parse(typeof(Couleurs), userColor);

            //OU
            //version generique:

            //Couleurs couleurFavorite = Enum.Parse<Couleurs>(userColor);

            Couleurs couleurFavorite;
            while(!Enum.TryParse<Couleurs>(userColor, out couleurFavorite))
            {
                Console.WriteLine($"La couleur {userColor} ne fait pas parti de la liste...");
                userColor = Console.ReadLine();
            }

            Console.WriteLine($"Votre couleur favorite et le {couleurFavorite}!");
        }
    }
}
