using Demo10Abstraction.Models;

namespace Demo10Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessageWriter writer = new HtmlWriter();

            writer.Write("Hello");


        }
    }
}
