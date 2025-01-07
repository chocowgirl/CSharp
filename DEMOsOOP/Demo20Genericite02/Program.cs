using Demo20Genericite02.Models;

namespace Demo20Genericite02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Usine<Usine<Soldat>> usineAUsine = new Usine<Usine<Soldat>>(); won't work because we have defined that a Usine can't make a Usine

            Barraque barraque = new Barraque();

            List<Soldat> troupes = new List<Soldat>();

            troupes.Add(barraque.CreerOfficier());
            for (int i = 0; i < 10; i++)
            {
                troupes.Add(barraque.CreerSoldat());
                //troupes.Add(barraque.Produire<Models.Char>()); doesn't work because Char(U) doesn't inherit from Soldat(T)

            }

            foreach (IUnite unite in troupes)
            {
                Console.WriteLine(unite);
            }

            UsineVehicule usine = new UsineVehicule();
            Models.Char tank = usine.CreerChar();

        }
    }
}
