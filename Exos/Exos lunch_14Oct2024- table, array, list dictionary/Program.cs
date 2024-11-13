using System.Text;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exos_lunch_14Oct2024__table__array__list_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.Dans une application Console, initialiser un tableau de 10 entiers avec les valeurs 2, 4, 8, 16, 
            //32, 64, 128, 256, 512, 1024 à l’aide d’une boucle(c’est l’ordinateur qui doit calculer les
            //valeurs, pas l’utilisateur). 
            //Ensuite, à l’aide d’une boucle afficher la valeur de chaque cellule du tableau. 

            //int[] valeurs = new int[10];
            //int twoStart = 2;

            //for (int i = 1; i < valeurs.Length; i++)
            //{
            //    valeurs[i] = twoStart;
            //    twoStart += twoStart;
            //}
            //foreach (int i in valeurs)
            //{
            //    Console.WriteLine(i);
            //}


            //2.Écrire une application Console demandant à l’utilisateur le nombre de joueurs(max 10
            //joueurs).Ensuite, à l’aide d’un tableau, demandez à l’utilisateur d’encoder le score de chaque
            //joueur.Une fois ceci fini, il faut afficher la moyenne des scores.

            //Console.WriteLine("How many players will there be?");
            //int[] scores = new int [int.Parse(Console.ReadLine())];

            //for (int i = 0; i < scores.Length; i++)
            //{
            //    Console.WriteLine($"what is the score of player {i+1}? :");
            //    scores[i]= int.Parse(Console.ReadLine());
            //}
            //double total = 0;
            //for (int i = 0; i < scores.Length; i++)
            //{
            //    total += scores[i];
            //}
            //double moyenne = total / scores.Length;
            //Console.WriteLine($"The average score of all {scores.Length} players is {moyenne}");


            ////3. Inverser un tableau: soit un tableau T. Saisir ce tableau.  Changer de place les éléments de ce
            ////tableau de façon à ce que le nouveau tableau soit une sorte de miroir de l'ancien et afficher le 
            ////nouveau tableau.  NOTE: *** voir en dessous: LES TABLEAUX NE PEUVENT PAS CHANGER LEUR TAILLE.
            //int[] toFive = {1, 2, 3, 4, 5,};//ceci est la bonne ligne à decommenter pour faire le table exigé
            ////List<int> toFive = new List<int>();
            //////toFive.Add(5);
            ////toFive.AddRange(new int[] { 1, 2, 3, 4, 5 });

            ////Ce bloc en-dessous marche toujours pour display de la table original
            //Console.WriteLine("Here is the original table:");
            //foreach (var item in toFive)
            //{
            //    Console.WriteLine(item);
            //}

            //***** faut attaquer ici pour refaire l'algo de la reste.******* WAS SUPPOSED TO DO THIS USING A ONE DIMENSIONAL TABLE.
            ////editing the table by taking the last item, copying and placing it again on the end, then removing the original.
            //for (int i = toFive.Count - 1; i >= 0; i--)
            //{
            //    toFive.Add(toFive[i]);
            //    toFive.RemoveAt(i);
            //}

            //Console.WriteLine("Here is the same table, edited to a mirror reflection of how it started out:");
            //foreach (var item in toFive)
            //{
            //    Console.WriteLine(item);
            //}




            ////4.Créez une application Console permettant de gérer une To-Do List(liste de choses à faire).
            ////L’utilisateur doit pouvoir introduire une tâche, supprimer une tâche et modifier une tâche.

            //List<string> todoList = new List<string>();
            //Console.Write("Welcome to your personal to-do list!  To add an item, enter A.  To delete an item, enter D.  To modify an item, enter M.  To quit, enter Q.");
            //string choice = Console.ReadLine().ToUpper();

            //while (choice != "Q")
            //{

            //    switch (choice)
            //    {

            //        case "D":
            //            if (todoList.Count == 0)
            //            {
            //                Console.WriteLine("There are no items to delete!");
            //                choice = "";
            //                break;
            //            }
            //            else
            //            {
            //                Console.WriteLine("Please type the number of the item to delete");
            //                string deleteString = Console.ReadLine();
            //                bool deleteStringOk = int.TryParse(deleteString, out int deleteChoice);
            //                if (deleteStringOk && deleteChoice > 0 && deleteChoice <= todoList.Count)
            //                {
            //                    deleteChoice = deleteChoice - 1;
            //                    todoList.RemoveAt(deleteChoice);
            //                    choice = "";
            //                    break;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("invalid choice, you must enter a number that corresponds with a list item");
            //                    choice = "";
            //                }

            //            }
            //            break;

            //        case "M":
            //            if (todoList.Count == 0)
            //            {
            //                Console.WriteLine("There are no items to modify!");
            //                choice = "";
            //            }
            //            else
            //            {
            //                Console.WriteLine("Please type the number of the item to modify:");
            //                string modifString = Console.ReadLine();
            //                bool modifStringOk = int.TryParse(modifString, out int modifChoice);
            //                if (modifStringOk && modifChoice > 0 && modifChoice <= todoList.Count)
            //                {
            //                    modifChoice = modifChoice - 1;
            //                    Console.WriteLine("Please type what you would prefer this item show");
            //                    string modifEntry = Console.ReadLine();
            //                    todoList[modifChoice] = modifEntry;
            //                    choice = "";
            //                }
            //                else
            //                {
            //                    Console.WriteLine("invalid choice, you must enter a number that corresponds with a list item");
            //                    choice = "";
            //                }
            //            }
            //            break;


            //        case "A":
            //            Console.WriteLine("Please enter the new item :");
            //            todoList.Add(Console.ReadLine());
            //            choice = "";
            //            break;

            //        case "":
            //            Console.Write("To add an item, enter A.  To delete an item, enter D.  To modify an item, enter M.  To quit, enter Q.");
            //            choice = Console.ReadLine().ToUpper(); ;
            //            break;

            //        default:
            //            Console.WriteLine("Invalid option. To add an item, enter A.  To delete an item, enter D.  To modify an item, enter M.  To quit, enter Q.");
            //            choice = "";
            //            choice = Console.ReadLine().ToUpper();
            //            break;

            //    }

            //    if (todoList.Count > 0)
            //    {
            //        for (int i = 0; i < todoList.Count; i++)
            //        {
            //            Console.WriteLine($"item {i + 1}: {todoList[i]}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Your to-do list is currently empty.");
            //        choice = "";
            //        break;
            //    }
            //}
            //Console.WriteLine("Thanks for using your personal to-do list, and goodbye!");



            //5.Réalisez une application Console nous permettant de déplacer un pion dans un tableau de 10
            //éléments.Au début, le pion se trouve dans la première case du tableau. Nous pouvons ensuite
            //le déplacer par la gauche(g), par la droite(d) ou de stopper l'algorithme (q).


            //string[] game = { " x ", " 0 ", " 0 ", " 0 ", " 0 ", " 0 ", " 0 ", " 0 ", " 0 ", " 0 " };
            //string userInput;
            //int positionPawn = 0;
            //do
            //{

            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.Write(game[i]);
            //    }
            //    Console.WriteLine("Please indicate in which direction you'd like to move the pawn (the x).  Type L for left, R for right and Q to quit this program.");

            //    userInput = Console.ReadLine().ToUpper();
            //    if (userInput == "L" && positionPawn == 0)
            //    {
            //        Console.WriteLine("Sorry, the pawn is already as far left as it can go!");
            //    }
            //    else if (userInput == "L" && positionPawn != 0)
            //    {
            //        game[positionPawn] = " 0 ";
            //        positionPawn--;
            //        game[positionPawn] = " x ";
            //    }
            //    if (userInput == "R" && positionPawn == 9)
            //    {
            //        Console.WriteLine("Sorry, the pawn is already as far right as it can go!");
            //    }
            //    else if (userInput == "R" && positionPawn != 9)
            //    {
            //        game[positionPawn] = " 0 ";
            //        positionPawn++;
            //        game[positionPawn] = " x ";
            //    }


            //} while (userInput != "Q");
            //if (userInput == "Q")
            //{
            //    Console.WriteLine("Thanks for playing with the pawn!  Byeeeeee.");
            //}


            //6.A l’aide d’un Dictionary, créez un jeu du « Pierre - Papier - Ciseaux » (utilisez le Random pour
            //faire choisir l’ordinateur) 

            Dictionary<int, string> choices = new Dictionary<int, string>();
            choices.Add(1, "rock");
            choices.Add(2, "paper");
            choices.Add(3, "scissors");

            Random rnd = new Random();
            int ordiChoice = rnd.Next(1, 4);
            int userChoice;
            Console.WriteLine(ordiChoice);
            do
            {
                ordiChoice = rnd.Next(1, 4);
                //Console.WriteLine(ordiChoice);
                Console.WriteLine("Enter one of the following: 1 (for ROCK), 2 (for PAPER), or 3 (for SCISSORS).  Enter 4 to quit.");
                bool userChoiceParsable = int.TryParse(Console.ReadLine(), out userChoice);
                if (userChoiceParsable && userChoice != 4)
                {
                    Console.WriteLine($"I chose {choices[ordiChoice]}");
                    Console.WriteLine($"you chose {choices[userChoice]}");
                    if ((ordiChoice == 1 && userChoice == 3) || (ordiChoice == 2 && userChoice == 1) || (ordiChoice == 3 && userChoice == 2))
                    {
                        Console.WriteLine("I win!");
                    }
                    else if (ordiChoice == userChoice)
                    {
                        Console.WriteLine("It's a tie");
                    }
                    else
                    {
                        Console.WriteLine("You won!");
                    }
                }
                else if (userChoice != 4)
                {
                    Console.WriteLine("You must enter either 1 (for ROCK), 2 (for PAPER), or 3 (for SCISSORS).");
                }
            } while (userChoice != 4);
            Console.WriteLine("Thanks for playing!");







        }
    }   
}
