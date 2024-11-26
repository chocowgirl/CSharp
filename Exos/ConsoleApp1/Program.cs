using ExoCelFarStructs25Nov2024;

namespace ConsoleApp1
{
    internal class Program
    {
        //Ecrire deux structures Celsius et Fahrenheit toutes deux ayant une variable de type double appelée "Temperature".
        //Dans les structures, écrire la fonction de conversion de l'une vers l'autre.
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour, quel temperature fait-il actuellement à Bruxelles? (en Celsius?)");
            Celsius c_bru = new Celsius();

            c_bru.temperature = double.Parse(Console.ReadLine());

            Console.WriteLine($"En fahrenheit il fait {c_bru.Convert().temperature} degrees F.");

            Console.WriteLine("Et quelle temperature fait-il à New York? (en Fahrenheit?)");

            Fahrenheit f_ny = new Fahrenheit();
            f_ny.temperature = double.Parse(Console.ReadLine());
            Console.WriteLine($"En Celsius il fait {f_ny.Convert().temperature} degrees C.");
        }
    }
}
