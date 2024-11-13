namespace Demo_14
{
    public struct TempsHorloge
    {
        public const int HOURS_LIMIT = 23;
        public int hours;
        public int minutes;
        public int seconds;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //int hours = 10;
            //int minutes = 11;
            //int seconds = 59;

            TempsHorloge debutDemo;
            debutDemo.hours = 10;
            debutDemo.minutes = 11;
            debutDemo.seconds = 59;
            Console.WriteLine($"The demo started at {debutDemo.hours}:{debutDemo.minutes}:{debutDemo.seconds}");

            TempsHorloge finDemo = new TempsHorloge();
            Console.WriteLine($"The demo started at {finDemo.hours}:{finDemo.minutes}:{finDemo.seconds}");

            TempsHorloge finDemo = debutDemo;
            //this makes a copy of debut demo and puts the same values in finDemo
            finDemo.minutes = 30;
            finDemo.seconds = 00;

        }
    }
}
