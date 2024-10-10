namespace Exo1_4Oct2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            string firstStringNum = Console.ReadLine();
            Console.WriteLine("Please enter a second number");
            string secondStringNum = Console.ReadLine();
            int answer = int.Parse(firstStringNum) + int.Parse(secondStringNum);
            Console.WriteLine($"These two numbers added together = {answer}");

            Console.WriteLine("Please enter a number");
            string thirdStringNum = Console.ReadLine();
            Console.WriteLine("Please enter a second number");
            string fourthStringNum = Console.ReadLine();
            int thirdIntNum;
            bool thirdNumConverted = int.TryParse(thirdStringNum, out thirdIntNum);
            int fourthIntNum;
            bool fourthNumConverted = int.TryParse(fourthStringNum, out fourthIntNum);
            int finalResult = thirdIntNum + fourthIntNum;
            Console.WriteLine($"These two numbers ({thirdIntNum} and {fourthStringNum}) added together = {finalResult}");
        }
    }
}
