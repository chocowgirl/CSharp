﻿using Demo5Indexeurs.Models;

namespace Demo5Indexeurs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Paquet p = new Paquet();

            Carte? valetTrefle = p[Enums.ValeurCarte.Valet, Enums.CouleurCarte.Trefle];

            List<Carte> main = new List<Carte>();
            for (int i = 0; i < 7; i++)
            {
                main.Add(p[rnd.Next(p.Count)]); //after, here we will need to diminish the siwe of the paquet
            }

            Console.WriteLine("Voici votre main:");
            foreach (Carte c in main)
            {
                Console.WriteLine($" \t - le {c.Valeur} de {c.Couleur}");
            }
        }
    }
}
