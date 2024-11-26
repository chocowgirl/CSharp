namespace Demo16Stoplight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrafficLight feu_rouge = new TrafficLight();
            feu_rouge.color = TrafficLightColor.Green;
            //feu_rouge.color = (TrafficLightColor).0;
            Console.WriteLine($"Presently, the traffic light is {feu_rouge.color}");
            feu_rouge.ChangeColor();
            Console.WriteLine($"Presently, the traffic light is {feu_rouge.color}");
            feu_rouge.ChangeColor();
            Console.WriteLine($"Presently, the traffic light is {feu_rouge.color}");
        }
    }
}
