using Demo17Event01.Models;

namespace Demo17Event01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EtreVivant p1 = new Poisson("Nemo");
            p1.onPVChanged += PVChangedNotified;
            p1.onDeath += DeathNotified;

            EtreVivant a1 = new Algue();
            a1.onPVChanged += PVChangedNotified;
            a1.onDeath += DeathNotified;

            //Console.WriteLine($"notre poisson a {p1.PV} point(s) de vie.");Plus besoin de ces lines car nous avons fait la PVChangedNotified underneath
            //Console.WriteLine($"notre algue a {a1.PV} point(s) de vie.");


            for (int i = 0; i < 20; i++)
            {
                p1.Vieillir();
                //Console.WriteLine($"notre poisson a {p1.PV} points de vie"); plus besoin de ces lines car nous avons fait la PVChangedNotified underneath
                a1.Vieillir();
                //Console.WriteLine($"notre algue a {p1.PV} points de vie");
            }

        }

        static void PVChangedNotified(EtreVivant etreVivant, int pvEtreVivant)
        {
            if (etreVivant is Poisson p) Console.WriteLine($"notre poisson {p.Name} a {pvEtreVivant} points de vie.");
            else Console.WriteLine($"notre algue a {pvEtreVivant} points de vie");
        }

        static void DeathNotified(EtreVivant etreVivant)
        {
            if (etreVivant is Poisson p) Console.WriteLine($"malheureusement le poisson {p.Name} est mort.");
            else Console.WriteLine($"C'est triste, une algue vient de fanée...");
            //etreVivant.onPVChanged -= PVChangedNotified;
        }
    }
}
