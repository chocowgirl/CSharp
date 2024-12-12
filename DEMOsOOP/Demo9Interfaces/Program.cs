using Demo9Interfaces.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bateau b = new Bateau("La toison d'or");

            Canoe c = new Canoe();

            IBateau monBateau = b; //We can see here that we can use an interface to be the TYPE for these two classes
            IBateau monSecondBateau = c;  //This allows us to group classes together that DONT share heritage

            List<IBateau> monPort = new List<IBateau>();

            monPort.Add(b);
            monPort.Add(c);

            Random rnd = new Random();
            IBateau choixBateau = monPort[rnd.Next(monPort.Count)];

            choixBateau.Naviguer();
            if(choixBateau is Bateau bateau)
            {
                Console.WriteLine("");
            }
        }
    }
}
