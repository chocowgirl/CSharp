namespace Demo7_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //EN VERSION WHILE:

            //Console.WriteLine("Please enter your BBAN (12 digits with no spaces between them");
            //string userInput = Console.ReadLine(); //Initialise

            ////Condition
            //while (userInput.Length != 12 || !long.TryParse(userInput, out _)) //in the case it's not 12 digits or it doesn't parse out
            //{
            //    Console.WriteLine("Invalid entry");
            //    Console.WriteLine("Please enter your BBAN (12 digits with no spaces between them");
            //    userInput = Console.ReadLine();  //iteration
            //}
            //Console.WriteLine("Valid entry");




            //EN VERSION DO WHILE:
            string message = "Please enter your BBAN (12 digits with no spaces between them";
            string userInput; //Declaration

            do
            {
                Console.WriteLine(message);
                userInput = Console.ReadLine(); //Initialise first time
                                                //iteration following error in entry
                message = "invalid entry, please enter a 12 digit number with no spaces.";
            } while (userInput.Length != 12 || !long.TryParse(userInput, out _)); //in the case it's not 12 digits or it doesn't parse out
            Console.WriteLine("Valid entry");



        }
    }
}
