namespace Demo10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayNames = {
                "dimanche",
                "lundi",
                "mardi",
                "mercredi",
                "jeudi",
                "vendredi",
                "samedi",
            };
            // an array can also be declared inside [] ...

            Console.WriteLine($"There are {dayNames.Length} days in the week.");

            foreach (string dayName in dayNames)
            {
                Console.WriteLine($"\t- {dayName}");
            }

            //Console.Write("En anglais comment, traduisez-vous...");
            //for (int i = 0; i < dayNames.Length; i++)
            //{
            //    Console.Write($"\t-{dayNames[i]}\t:");
            //    dayNames[i] = Console.ReadLine();
            //}

            //foreach (string dayName in dayNames)
            //{
            //    Console.WriteLine($"\t- {dayName}");
            //}

            Console.WriteLine($"ajd nous sommes {dayNames[(int)DateTime.Now.DayOfWeek]} le {DateTime.Now.ToString("dd MMMM yyyy")}.");
        }
    }
}
