using Demo19Genericite.Models;

namespace Demo19Genericite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayListGenerique<int> arrayListInt = new ArrayListGenerique<int>();
            arrayListInt.Add(1);
            arrayListInt.Add(2);
            arrayListInt.Add(3);
            arrayListInt.Add(4);

            Console.WriteLine($"le nombre entier en indice 2 est {arrayListInt[2]}.");

            //ArrayListString arrayListString = new ArrayListString();
            //arrayListString.Add("Bonjour");
            //arrayListString.Add("Hello");
            //arrayListString.Add("Hi");
            //arrayListString.Add("Ciao");


            ArrayListGenerique<string> arrayListString = new ArrayListGenerique<string>();//way of implementing the generic item to create many diff types
            arrayListString.Add("Bonjour");
            arrayListString.Add("Hello");
            arrayListString.Add("Hi");
            arrayListString.Add("Ciao");

            Console.WriteLine($"le text en indice 3 est {arrayListString[3]}");

            ArrayListGenerique<Chien> arrayListChien = new ArrayListGenerique<Chien>();
            arrayListChien.Add(new Chien("medor"));
            arrayListChien.Add(new Chien("rex"));
            arrayListChien.Add(new Chien("rufus"));
            arrayListChien.Add(new Chien("sultan"));

            Console.WriteLine($"le chien en indice 0 se nomme {arrayListChien[0].Nom}");


            ArrayListGenerique<ConsoleColor> arrayListColor = new ArrayListGenerique<ConsoleColor>();
            arrayListColor.Add(ConsoleColor.Green);
            arrayListColor.Add(ConsoleColor.Red);
            arrayListColor.Add(ConsoleColor.Blue);
            arrayListColor.Add(ConsoleColor.Black);

            Console.WriteLine($"la couleur en indice 1 se nomme {arrayListColor[1]}");
        }
    }
}
