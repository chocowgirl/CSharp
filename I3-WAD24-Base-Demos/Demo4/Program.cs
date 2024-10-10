namespace Demo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter your year of birth");
            string userInput = Console.ReadLine();
            int userBirthyear;
            //bool isConverted = int.TryParse(userInput, out userBirthyear);
            //if (isConverted)
            if(int.TryParse(userInput, out userBirthyear)) //this line is a way of simplifying the above 2 lines
            {
                int yearsOld = DateTime.Now.Year - userBirthyear;
                if (yearsOld >= 18)
                {
                    Console.WriteLine("Please indicate your country of residence :");
                    string country = Console.ReadLine();
                    //if (country.ToLower() == "belgique")
                    //{
                    //Console.WriteLine("Welcome to the National Lottery website.");
                    //}
                    //else if (country.ToLower() == "france")
                    //{
                    //    Console.WriteLine("Welcome to the National Lottery cocorico!");
                    //}
                    //else if(country.ToLower() == "suisse")
                    //{
                    //    Console.WriteLine("Welcome to the National Lotteryyyyyyy");
                    //}
                    //else if(country.ToLower() == "canada")
                    //{
                    //    Console.WriteLine("Welcome to the lottery, eh?");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Sorry you don't live in the right place");
                    //}
                    switch (country.ToLower())
                    {
                        case "belgique":
                            Console.WriteLine("Welcome to the National Lottery website.");
                            break;
                        case "france":
                            Console.WriteLine("Welcome to the National Lottery cocorico!");
                            break;
                        case "suisse":
                            Console.WriteLine("Welcome to the National Lotteryyyyyyy");
                            break;
                        case "canada":
                            Console.WriteLine("Welcome to the lottery, eh?");
                            break;
                        default:
                            Console.WriteLine("Sorry you don't live in the right place");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine($"Come back in {18 - yearsOld} years!");
                }
            }

            else {
                Console.WriteLine("Invalid entry...");
            }
        }
    }
}