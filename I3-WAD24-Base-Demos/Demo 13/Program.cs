namespace Demo_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menuOptions = { "Female", "Male", "Other" };
            int selectedPosition = 0;
            //string userChoice;
            ConsoleKey userChoice;

            do
            {
                Console.Clear(); //gives the illusion of deplacing the choice rather than regenerating everything and showing the new choice
                Console.WriteLine("Please indicate your gender: ");
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    string option = menuOptions[i];
                    if (i == selectedPosition)
                    {
                        Console.WriteLine($"[{option}]");
                    }
                    else
                    {
                        Console.WriteLine(option);
                    }
                }
                Console.WriteLine("Type (U)p or (D)own or (S)ubmit");
                //userChoice = Console.ReadLine().ToUpper();
                userChoice = Console.ReadKey(true).Key;//the (true) intercepts the key without displaying the hit key onscreen.
                //if (userChoice == "U" && selectedPosition > 0)
                if (userChoice == ConsoleKey.U && selectedPosition > 0)
                {
                    selectedPosition--;
                }
                //else if (userChoice == "D" && selectedPosition < menuOptions.Length - 1)
                else if (userChoice == ConsoleKey.D && selectedPosition < menuOptions.Length - 1)
                {
                    selectedPosition++;
                }
            }
            //while (userChoice != "S");
            while (userChoice != ConsoleKey.S);

            Console.WriteLine($"You have chosen {menuOptions[selectedPosition]}");





        }
    }
}
