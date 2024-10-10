namespace Demo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In which country do you live?");
            string country = Console.ReadLine();

            //string resident = (country.ToLower() == "belgium") ? "belge" :
            //                    (country.ToLower() == "france") ? "french" :
            //                    (country.ToLower() == "switzerland") ? "swiss" : "other";

            string resident = country.ToLower() switch
            {
                "belgium" => "belge",
                "france" => "french",
                "switzeland" => "swiss",
                _ => "autre"
            };
            //This is the new shiny compact version of the above...
            //note that ONLY the underscore can be used for the default statement here
            Console.WriteLine("How old are you?");
            string userInput = Console.ReadLine();
            int yearsOld = int.Parse(userInput);
            Console.WriteLine($"You are {resident} and are {yearsOld} year{((yearsOld > 1)? "s" : "")} old.");
        }
    }
}
