namespace ExoDistribBoiss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Distributeur d = new Distributeur();
            d.Demarrer();
            //d.Demarrer(new Dictionary<string, int>
            //{
            //    {"Soda", 3 },
            //    {"Orangeade", 3 },
            //    {"Eau", 3 },
            //    {"Citronade", 3 },

            //});
        }
    }
}
