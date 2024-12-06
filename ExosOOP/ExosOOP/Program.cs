using ExosOOPMonopoly.Enums;
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

            Joueur j1 = new Joueur("Samuel",Pions.Dino); // This changes to a constructor with parameters because we created the Joueur constructor

            Console.WriteLine($"{j1.Nom} c'est votre tour!  Bougez le pion {j1.Pion} de la case {j1.Position}!");
            if (j1.Avancer())
            {
                Console.WriteLine($"Bravo {j1.Nom}! Vous avez fait un double!");
            }
            Console.WriteLine($"{j1.Nom} vous êtes à présent sur la case {j1.Position}");
            Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            Console.WriteLine("Vos biens : ");
            foreach (CasePropriete bien in j1.Proprietes)
            {
                Console.WriteLine($"\t- {bien.Nom} ({bien.Couleur})");
            }


            //test de la classe CasePropriete

            CasePropriete i3Patio = new CasePropriete("Patio Interface 3", Couleurs.Marron, 20);


            Console.WriteLine($"La première case du jeu Monopoly Version I3 est:");
            Console.WriteLine(i3Patio.Nom);
            Console.WriteLine($"De couleur {i3Patio.Couleur}");
            Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            if (i3Patio.EstHypoteqee) Console.WriteLine("Ce terrain est hypotequé...");
            else Console.WriteLine("Ce terrain n'est pas hypotequé");
            if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            i3Patio.Acheter(j1);

            Console.WriteLine($"La première case du jeu Monopoly Version I3 est:");
            Console.WriteLine(i3Patio.Nom);
            Console.WriteLine($"De couleur {i3Patio.Couleur}");
            Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            if (i3Patio.EstHypoteqee) Console.WriteLine("Ce terrain est hypotequé...");
            else Console.WriteLine("Ce terrain n'est pas hypotequé");
            if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            Console.WriteLine("Vos biens : ");
            foreach (CasePropriete bien in j1.Proprietes)
            {
                Console.WriteLine($"\t- {bien.Nom} ({bien.Couleur})");
            }





        }
    }
}
