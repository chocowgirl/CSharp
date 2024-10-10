namespace Exo_9Oct2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a whole number");
            string givenNumberString = Console.ReadLine();
            bool givenNumberStringParsable = int.TryParse(givenNumberString, out int parsedGivenNumber);

            if (givenNumberStringParsable)
            {
                Console.WriteLine("The number you gave me is " + parsedGivenNumber);

                if (parsedGivenNumber / 2 + parsedGivenNumber / 2 == parsedGivenNumber)
                {
                    Console.WriteLine("The number you gave me is an even number");
                }
                else
                {
                    Console.WriteLine("The number you gave me is odd");
                }
            }
            else
            {
                Console.WriteLine("Hmmm... You don't seem to have given me a whole number...");
            }

        }
    }
}
