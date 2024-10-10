namespace Demo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Friday!");
            Console.Write("\tWhat is your name?");
            string? username = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Bonjour {username}!\nIl est actuellement {DateTime.Now.ToShortTimeString()}");
        }
    }
}
