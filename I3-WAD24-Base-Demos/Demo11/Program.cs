namespace Demo11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liste des presences :");
            List<string> presence = new List<string>();
            string name = "";
            do
            {
                Console.WriteLine($"Please enter the name of a student who is here");
                Console.WriteLine($"to finalize the attendance list write \"FIN\")");
                name = Console.ReadLine();
                if (!presence.Contains(name.ToUpperInvariant()))
                {
                    presence.Add(name.ToUpperInvariant());
                }
                else
                {
                    Console.WriteLine($"The student {name} is already marked as here...");
                }
            } while (name != "FIN");

            presence.Remove("FIN");

            while (presence.Count>0)
            {
                Console.WriteLine("currently here: ");
                int i = 0;
                foreach (string eleve in presence)
                {
                    Console.WriteLine($"\t- {++i}) {eleve}");
                }
                int choix;
                do
                {
                    Console.WriteLine($"Indicate the number of the student leaving :");

                } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > presence.Count);

                string elevePartant = presence[choix - 1];
                Console.WriteLine($"Are you sure you want to delete the student {elevePartant}? (Yes - No)");
                if (Console.ReadLine().ToUpper() == "YES")
                {
                    presence.Remove(elevePartant);
                } 
            }
            Console.WriteLine("Thank you for using attendance 3000!");
        }
    }
}
