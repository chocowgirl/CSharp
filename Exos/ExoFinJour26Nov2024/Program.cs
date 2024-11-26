namespace ExoTechnicolor26Nov2024
{
    internal class Program
    {
        //Dans une application console creez une structure "ConsoleAvancee".
        //Cette structure doit contenir une procédure RainbowWrite(string texte).
        //Cette méthode doit utiliser l'énumeration de ConsoleColor pour changer la couleur de fond et de texte de chq
        //charactère de la console lors de l'affichage du texte, créant ainsi un texte arc-en-ciel
        //Pour modifiier la couleur de fond de la console: Console.BackgroundColor
        //Pour modifier la couleur de l'écriture de la console: Console.ForegroundColor
        //ATTN - à la fin de texte arc-en-ciel vous devez revenir aux couleurs de base de la console ( Console.ResetColor() )
        //ALSO - faite en sorte que la couleur du texte ne soit jamais la même couleur que celle du fond...

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a message so that I can deliver it in TECHNICOLOR!  :");
            string userentry = Console.ReadLine();

            // Create an instance of ConsoleAvancee (which I forgot to do.  And since we haven't learned static yet must do in order to call the associated method)
            
            ConsoleAvancee consoleAvancee = new ConsoleAvancee();

            // Call the method (now that you can after instantiation of the struct into a specific object)
            consoleAvancee.RainbowWrite(userentry);

        }
    }
}
