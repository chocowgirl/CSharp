namespace Demo9___random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random RNG = new Random();

            Console.WriteLine($"Here is a random number : {RNG.Next(1,100)}");
        }
    }
}
