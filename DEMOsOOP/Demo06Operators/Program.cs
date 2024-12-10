using Demo06Operators.Models;

namespace Demo06Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ingredient tartine = new Ingredient("Tartine", 100);
            Console.WriteLine($"mon premier ingredient est {tartine.Nom} avec valeur nutritive de {tartine.ValeurNutritive}");

            Ingredient choco = new Ingredient("Pate à tartiner chocolat", 60);
            Console.WriteLine($"mon deuxieme ingredient est {choco.Nom} avec valeur nutritive de {choco.ValeurNutritive}");

            Recette tartineAuChoco = tartine + choco;
            tartineAuChoco += choco;

            Console.WriteLine($"en melangeant les ingredients suivant : ");
            foreach (Ingredient ingredient in tartineAuChoco.Ingredients)
            {
                Console.WriteLine($"\t {ingredient.Nom}");
            }
            Console.WriteLine($"j'obtiens la recette de :  {tartineAuChoco.Nom} !");
            Console.WriteLine($"qui a un totale de valeur nutritive de {tartineAuChoco.ValeurNutritiveTotal}!");

            Console.WriteLine($"Si je prends un qty de 3 de {tartine.Nom}, j'obtiens une valeur nutritive de {tartine * 3}.");

            if(tartine == choco)  //if the address in the memory is the same for tartine and for choco...
            {
                Console.WriteLine("Alors tartine vaut choco");  //n'affichera jamais
            }

            Ingredient tartine2 = tartine; // here we have created a REFERENTIAL ingredient variable called tartine 2 which is connected to tartine

            if (tartine2 == tartine)
            {
                Console.WriteLine("Alors tartine2 vaut tartine");  // les 2 addresses memoires sont identiques so this displays
            }

            Ingredient tartine3 = new Ingredient("Tartine", 100);
            if (tartine3 == tartine)
            {
                Console.WriteLine("Alors tartine3 vaut tartine");
            }

        }
    }
}
