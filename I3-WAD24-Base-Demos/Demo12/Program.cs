using System.Diagnostics.CodeAnalysis;

namespace Demo12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agenda :");
            Dictionary<DateTime, string> agenda = new Dictionary<DateTime, string>();
            string choix = "";
            do


            {
                if (agenda.Count > 0)
                {
                    foreach (KeyValuePair<DateTime, string> entree in agenda)
                    {
                        Console.WriteLine($"{entree.Key} \t: \t{entree.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("no rdv yet...");
                }
                Console.WriteLine("(A)dd - (Q)uit");
                choix = Console.ReadLine().ToUpper();

                switch (choix)
                {
                    case "A":
                        Console.WriteLine("What date is this rdv?");
                        Console.WriteLine("What day?");
                        int day = int.Parse(Console.ReadLine());
                        Console.WriteLine("What month?");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("What year");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("What hour?");
                        int hour = int.Parse(Console.ReadLine());
                        Console.WriteLine("What minute?");
                        int minute = int.Parse(Console.ReadLine());
                        DateTime dateKey = new DateTime(year, month, day, hour, minute, 0);
                        if (agenda.ContainsKey(dateKey))
                        {
                            Console.WriteLine($"Another rdv is already placed at this date :");
                            Console.WriteLine(agenda[dateKey]);
                        }
                        else
                        {
                        Console.WriteLine("What do you want to call this rdv?");
                        string objet = Console.ReadLine();
                        agenda.Add(dateKey, objet);
                        }
                        break;
                }
            }while (choix != "Q");
                
            Console.WriteLine("Thank you for using Agenda 3000!");




        }
    }
}
