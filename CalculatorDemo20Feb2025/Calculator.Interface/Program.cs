namespace Calculator.Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur la calculette facile!");
            Console.WriteLine("Quels sont les nombres à additionner?");
            Console.Write("Nombre 1:");
            int nb1 = int.Parse(Console.ReadLine());
            Console.Write("Nombre 2:");
            int nb2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Le resultat de {nb1} plus {nb2} est: {Calculatrice.Addition(nb1, nb2)}");


            //Console.WriteLine("Phase de test:");
            //Console.WriteLine("Test Calculatrice.Addition : ");

            //Console.WriteLine($"Exécution de {nameof(CalculatriceTests)}.{nameof(CalculatriceTests.Addition_With4and2_ShouldReturn6)}");
            //CalculatriceTests.Addition_With4and2_ShouldReturn6();

            //Console.WriteLine($"Exécution de {nameof(CalculatriceTests)}.{nameof(CalculatriceTests.Addition_WithTwoBigValue_ShouldThrowOverflowException)}");
            //CalculatriceTests.Addition_WithTwoBigValue_ShouldThrowOverflowException();
        }
    }
}
