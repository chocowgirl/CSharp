namespace Demo17Flags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeChoices choices = 0;
            Console.WriteLine("Bienvenue sur Coffee2000!");
            Console.WriteLine("Comment voulez-vous votre café?");
            Console.WriteLine("Avec du lait? (O)ui - (N)on");
            choices = (Console.ReadKey().Key == ConsoleKey.O) ? (CoffeeChoices)((int)choices + (int)CoffeeChoices.WithMilk) : choices;
            Console.WriteLine("Avec du sucre? (O)ui - (N)on");
            choices = (Console.ReadKey().Key == ConsoleKey.O) ? (CoffeeChoices)((int)choices + (int)CoffeeChoices.WithSugar) : choices;
            Console.WriteLine("Avec de la crème? (O)ui - (N)on");
            choices = (Console.ReadKey().Key == ConsoleKey.O) ? (CoffeeChoices)((int)choices + (int)CoffeeChoices.WithCream) : choices;
            Console.WriteLine("Avec du caramel? (O)ui - (N)on");
            choices = (Console.ReadKey().Key == ConsoleKey.O) ? (CoffeeChoices)((int)choices + (int)CoffeeChoices.WithCaramel) : choices;
            Console.WriteLine("Avec du cacao? (O)ui - (N)on");
            choices = (Console.ReadKey().Key == ConsoleKey.O) ? (CoffeeChoices)((int)choices + (int)CoffeeChoices.WithCocoa) : choices;

            Console.WriteLine("Préparation de votre café...");
            if (choices.HasFlag(CoffeeChoices.WithMilk))
            {
                Console.WriteLine("J'ajoute du lait");
            }
            if (choices.HasFlag(CoffeeChoices.WithSugar))
            {
                Console.WriteLine("J'ajoute du sucre");
            }
            if (choices.HasFlag(CoffeeChoices.WithCream))
            {
                Console.WriteLine("J'ajoute de la crème");
            }
            if (choices.HasFlag(CoffeeChoices.WithCaramel))
            {
                Console.WriteLine("J'ajoute du caramel");
            }
            if (choices.HasFlag(CoffeeChoices.WithCocoa))
            {
                Console.WriteLine("J'ajoute du cacao");
            }



        }
    }
}
