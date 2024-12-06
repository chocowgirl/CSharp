using Demo4Constructor.Models;

namespace Demo4Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal pet = new Animal("Bugs"); //Because we defined the constructor as needing a name parameter, we HAVE to put a name in the brackets.
            //If no string is placed in Animal() above, Animal will have an underline in red b/c necessary information is missing to construct an Animal
            // here b/C there's no defined constructor in the CLass Animal, we instantiate an Animal with attributes but all set to default values

            Console.WriteLine($"Here are the animals properties:");
            Console.WriteLine($"Nom : {((pet.Nom is null)? "NULL" : pet.Nom)}");
            Console.WriteLine($"Points de vie : {pet.PointDeVie}");
            Console.WriteLine($"Points de bonheur : {pet.PointDeBonheur}");
            Console.WriteLine($"Liste de jouets:");
            foreach(string jouet in pet.Jouets)
            {
                Console.WriteLine($"\t- {jouet}");
            }




            Animal savedAnimal = new Animal("Bugs", 5, 0, ["balle", "carotte kuin-kuin", "grelot géant"]);

            Console.WriteLine($"Here are the animals properties:");
            Console.WriteLine($"Nom : {((savedAnimal.Nom is null) ? "NULL" : savedAnimal.Nom)}");
            Console.WriteLine($"Points de vie : {savedAnimal.PointDeVie}");
            Console.WriteLine($"Points de bonheur : {savedAnimal.PointDeBonheur}");
            Console.WriteLine($"Liste de jouets:");
            foreach (string jouet in savedAnimal.Jouets)
            {
                Console.WriteLine($"\t- {jouet}");
            }
        }
    }
}
