using Demo12IDisposable.Models;

namespace Demo12IDisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TalkieWalkie tw1 = new TalkieWalkie("Samuel"), tw2 = new TalkieWalkie("les WADs")) //if we want to put objects of different types together in a using we would have to use their longer name (IDisposable.TalkieWalkie ->> see recording 10:15)
            {
                tw1.EmmetreMessage("Bonjour à vous les WAD!");
                tw2.EmmetreMessage("Bonjour Samuel");
                tw1.EmmetreMessage("Les destructeurs, c'est pas top!");
                tw1.EmmetreMessage("Préférez les objects IDisposable!");
                tw2.EmmetreMessage("Tu as raison, Nous ne le ferons pas");
            }

            //tw1.EmmetreMessage("Salut j'ai oublié d'éteindre le Talkie Walkie...");  we see if we uncomment this that tw1 has a red underline, b/c outside the using it no longer exists

        } //It's not really about the objects being collected, this is really more about cutting the connection with, for ex, a DB in a timely manner.
    }
}
