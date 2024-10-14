using System.Text;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.Design;

namespace exos_FinJour_10Oct2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.. 1 .. A l'aide d'une boucle, afficher la table de multiplication par 2.
            //la table cite les calculs avec les multiplicateurs de 1 à 10.
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine($"{i} fois 2 est {i * 2}");
            //}


            // .. 2 .. a l'aide de deux boucles, afficher les tables de multiplication de 1 a 9.
            //Chaque table cite les calculs avec les multiplicateurs de 1 à 10
            //for (int i = 1; i <= 9; i++) {
            //    Console.WriteLine($"Here is the multiplication table of {i}");
            //    for (int j = 1; j <=10; j++)
            //    {
            //        Console.WriteLine($"{j} fois {i} est {j*i}");
            //    }
            //}




            // .. 3 .. Realiser un application console qui demande un nombre a l'utilisateur et affiche autant de
            //ligne que le nombre spécifié par l'utilisateur.  Chaque ligne contiendrea un nombre d'asterisques,
            //le nombre correspondra au numéro de la ligne.  Exemple, l'utilisateur donne le nombre 3 et le console affiche:
            // *
            // **
            // ***

            //bool inputParsable;
            //int userNum = 0;
            //do
            //{
            //    Console.WriteLine("Please enter a whole number greater than 0");
            //    string userInput = Console.ReadLine();
            //    inputParsable = int.TryParse(userInput, out userNum);
            //} while (!inputParsable || userNum < 1);

            //if (inputParsable && userNum > 0)  <<THIS IF ISN'T NECESSARY B:C WE'Ve ALREADY MADE SURE IT'S OK
            //{
            //    string symbol = "*"; << THIS CAN BE DECLARED AS A CONST OUTSIDE OF EVERYTHING
            //    string current = "";
            //    for (int i = 1; i <= userNum; i++)
            //    {
            //        current += symbol;  // Add one more symbol to the current string
            //        Console.WriteLine(current);  // Print the current string
            //    }
            //}



            //.. 4 ..Realisez le jeu de plus ou moins.  L'ordi selectionne une # au hazard entre 1 et 100.  L'utilisateur est invité à entrer
            //un # et l'algo nous répond "c'est plus" ou "c'est moins" selon la valeur à deviner.  Lorsque'on a trouvé le bon nombre, l'algo affiche
            //le nombre de tentatives effectuees pour trouver le resultat


            Random rndgen = new Random();
            int hazard = rndgen.Next(1, 101);

            string userInput = "";
            bool userInputParsable = false;
            int userNumGuess = 0;

            Console.WriteLine(hazard);

            Console.WriteLine("I've picked an integer that could be anything between and including 1 and 100...");
            Console.WriteLine("Please try to guess what number I've picked: ");
            userInput = Console.ReadLine();
            userInputParsable = int.TryParse(userInput, out userNumGuess);

            while (!userInputParsable || (userNumGuess < 1 || userNumGuess > 100))
            {
                Console.WriteLine("You must enter a NUMBER between 1 and 100: ");
                userInput = Console.ReadLine();
                userInputParsable = int.TryParse(userInput, out userNumGuess);
            }

            int triesCount = 1;

            while (userNumGuess != hazard)
            {
                Console.WriteLine($"your guess was {userNumGuess}");
                //if (userNumGuess != hazard)
                //{
                if (userNumGuess > hazard)
                {
                    Console.WriteLine("guess lower: ");
                }
                else
                {
                    Console.WriteLine("guess higher:");
                }
                //}
                userInput = Console.ReadLine();
                userInputParsable = int.TryParse(userInput, out userNumGuess);

                while (!userInputParsable || (userNumGuess < 1 || userNumGuess > 100))
                {
                    Console.WriteLine("You must enter a NUMBER between 1 and 100: ");
                    userInput = Console.ReadLine();
                    userInputParsable = int.TryParse(userInput, out userNumGuess);
                }

            }
            Console.WriteLine($"Congratulations!  You guessed that my number was {hazard} in {triesCount} guesses!");
        }




        ////.. 5 ..Ecrire un algo qui demand à l'utilisateur de taper 10 entiers et qui affiche le plus petit de ces entiers

        //int lowestNum = 2147483647;
        //int userNum = 2147483647;

        //for (int i = 1; i <= 10; i++)
        //{
        //    Console.WriteLine($"Turn {i}: Please give me a whole number");
        //    string userInput = Console.ReadLine();
        //    bool userInputParsable = int.TryParse(userInput, out userNum);

        //        while (!userInputParsable)
        //        {
        //            Console.WriteLine("That is not a whole number, try again: ");
        //            userInput = Console.ReadLine();
        //            userInputParsable = int.TryParse(userInput, out userNum);
        //        }
        //        if (userInputParsable && userNum < lowestNum)
        //        {
        //            lowestNum = userNum;
        //        }
        //}
        //Console.WriteLine($"The lowest number you gave me was {lowestNum}");



        //.. 6 ..Algo qui demande 3 nombres: nbRepetition, nbTiret, nbEspace.  Ce dernier affiche à l'écran autant des tirets
        //que la valeur de nbTiret, suivi d'autant d'espaces que la valeur de nbEspace.  Le tout autant de fois que la valeur
        //de nbRepetition.  Eg nbTiret = 1, nbEspace = 3 et nbRepetition = 2 donnera:
        //  [-   -   ]
        //bool userHyphenInputParseable;
        //bool userSpaceInputParseable;
        //bool userRepInputParseable;
        //int userHyphenNumber = -1;
        //int userSpaceNumber = -1;
        //int userRepNumber = -1;

        //do
        //{
        //    Console.WriteLine("Please give me a (postive) integer for hyphens: ");
        //    string userHyphenInput = Console.ReadLine();
        //    userHyphenInputParseable = int.TryParse(userHyphenInput, out userHyphenNumber);
        //} while (!userHyphenInputParseable || userHyphenNumber < 0);

        //do
        //{
        //    Console.WriteLine("Please give me a (postive) integer for spaces: ");
        //    string userSpaceInput = Console.ReadLine();
        //    userSpaceInputParseable = int.TryParse(userSpaceInput, out userSpaceNumber);
        //} while (!userSpaceInputParseable || userSpaceNumber < 0);

        //do
        //{
        //    Console.WriteLine("Please give me a (postive) first integer for repetitions: ");
        //    string userRepInput = Console.ReadLine();
        //    userRepInputParseable = int.TryParse(userRepInput, out userRepNumber);
        //} while (!userRepInputParseable || userRepNumber < 0);

        //Console.WriteLine($"ok, so you want {userHyphenNumber} hyphens, and {userSpaceNumber} spaces, repeated {userRepNumber} times...");
        //Console.WriteLine("Here I go...");
        //string hyphens = "";
        //string spaces = "";
        //for (int i = 1; i <= userHyphenNumber; i++)
        //{
        //    hyphens += "-";
        //}
        //for (int i = 1; i <= userSpaceNumber; i++)
        //{
        //    spaces += " ";
        //}
        //for (int i = 1; i <= userRepNumber; i++)
        //{
        //    Console.Write(hyphens + spaces);
        //}


        //Calculer les 25 premiers nombres de la sequence Fibonacci(0,1,1,2,3,5,8,13,21,34,55,89,144)

        //int prevValue = 1;
        //int avantPrevValue = 0;
        //int currentValue = 0;

        //for (int i = 1; i <=25; i++)
        //{
        //    currentValue = prevValue + avantPrevValue;
        //    Console.WriteLine($"iteration {i} = {currentValue}");
        //    avantPrevValue = prevValue;
        //    prevValue = currentValue;
        //}





    }
}

