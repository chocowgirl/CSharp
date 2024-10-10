namespace Demo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*DateTime today = DateTime.Now;
            Console.WriteLine(today.ToString());
            Console.WriteLine(today.ToString("yyyy MMMM dd"));*/

            //with parse
            /*Console.WriteLine("What day is it?");
            string userAnswer = Console.ReadLine();
            int dayInMonth = int.Parse(userAnswer);
            Console.WriteLine($"Ok, there are +/- {31-dayInMonth} days left in this month...");*/

            //with tryParse
            Console.WriteLine("What day is it?");
            string userAnswer = Console.ReadLine();
            
            int dayInMonth;
            bool isConverted;
            
            isConverted = int.TryParse(userAnswer, out dayInMonth);
            
            
            Console.WriteLine($"Conversion worked? {isConverted}");
            Console.WriteLine($"Ok, there are +/- {31 - dayInMonth} days left in this month...");
        }
    }
}
