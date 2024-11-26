using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoTechnicolor26Nov2024
{
    //Dans une application console creez une structure "ConsoleAvancee".

    //Cette structure doit contenir une procédure RainbowWrite(string texte).
    //Cette méthode doit utiliser l'énumeration de ConsoleColor pour changer la couleur de fond et de texte de chq
    //charactère de la console lors de l'affichage du texte, créant ainsi un texte arc-en-ciel

    //Pour modifiier la couleur de fond de la console: Console.BackgroundColor
    //Pour modifier la couleur de l'écriture de la console: Console.ForegroundColor
    //ATTN - à la fin de texte arc-en-ciel vous devez revenir aux couleurs de base de la console ( Console.ResetColor() )
    //ALSO - faite en sorte que la couleur du texte ne soit jamais la même couleur que celle du fond...
    public struct ConsoleAvancee
    {
        public void RainbowWrite (string usermessage)
        {
            // Get all possible ConsoleColor values (using generic syntax).
            ConsoleColor[] colors = Enum.GetValues<ConsoleColor>();
            int totalColors = colors.Length;
            Console.WriteLine($"I have a total of {totalColors} colours to work with... I will try to use them to the best of my ability.");
            Console.WriteLine($"...Your message is {usermessage.Length} characters in length!  I'm working on it... ");

            for (int i = 0; i < usermessage.Length; i++)
            {
                // Calculate the foreground and background indices
                //modulo is to ensure not going out of range
                int foregroundIndex = i % totalColors;
                int backgroundIndex = (i + 2) % totalColors; // Offset by 2 for better readability btw background & letter colours

                // Set console colors
                Console.ForegroundColor = colors[foregroundIndex];
                Console.BackgroundColor = colors[backgroundIndex];

                // Print the character
                Console.Write(usermessage[i]);
            }

            // Reset console colors
            Console.ResetColor();

            // Print a newline for better readability
            Console.WriteLine();
            Console.WriteLine($"TADAAAA!  Your message appears above in TECHNICOLOR!  \n(Are your eyes burning?).");
        }
    }

}
