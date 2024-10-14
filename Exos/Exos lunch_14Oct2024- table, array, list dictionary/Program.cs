using System.Text;
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




            //4.Créez une application Console permettant de gérer une To-Do List(liste de choses à faire).
            //L’utilisateur doit pouvoir introduire une tâches, supprimer une tâche et modifier une tâche.

            List<string> todoList = new List<string>();
            Console.Write("Welcome to your personal to-do list!  To add an item, enter A.  To delete an item, enter D.  To modify an item, enter M.  To quit, enter Q.");
            string choice = Console.ReadLine().ToUpper();

            while (choice != "Q")
            {

                switch (choice)
                {
                    case "A":
                        Console.WriteLine("Please enter the new item :");
                        todoList.Add(Console.ReadLine());
                        choice = ""; //provokes infinite item 1 added!
                        break;

                    case "D":
                        if (todoList.Count == 0)
                        {
                            Console.WriteLine("There are no items to delete!");
                        }
                        else
                        {
                            Console.WriteLine("Please type the number of the item to delete");
                            int deleteChoice = int.Parse(Console.ReadLine()) - 1;
                            todoList.RemoveAt(deleteChoice);
                        }
                        break;

                    case "M":
                        if (todoList.Count == 0)
                        {
                            Console.WriteLine("There are no items to modify!");
                        }
                        else
                        {
                            Console.WriteLine("Please type the number of the item to modify:");
                            int modifyChoice = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Please type what you would prefer this item show");
                            string modifEntry = Console.ReadLine();
                            todoList[modifyChoice] = modifEntry;
                        }
                        break;


                }
                if (todoList.Count > 0)
                {
                    for (int i = 0; i < todoList.Count; i++)
                    {
                        Console.WriteLine($"item {i + 1}: {todoList[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("Your to-do list is currently empty.");
                }



            }

            Console.WriteLine("Thanks for using your personal to-do list, and goodbye!");











        }
    }
}
