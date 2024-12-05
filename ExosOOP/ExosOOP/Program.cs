using ExosOOPMonopoly.Models;

namespace ExosOOPMonopoly

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //De.valeurMin = 1;
            //De.valeurMax = 6;
            //int[] result = De.Lancer(2);
            //Console.WriteLine($"Premier dé : {result[0]}\nSecond dé : {result[1]}");

            Joueur j1 = new Joueur()
            {
                nom = "Samuel",
                pion = Enums.Pions.Dino
            };

            Console.WriteLine($"{j1.nom} c'est votre tour!  Bougez le pion {j1.pion} de la case {j1.position}!");
            if (j1.Avancer())
            {
                Console.WriteLine($"Bravo {j1.nom}! Vous avez fait un double!");
            }
            Console.WriteLine($"{j1.nom} vous êtes à présent sur la case {j1.position}");
        }
    }
}
