using Demo08Abstract.Models;

namespace Demo08Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> foyer = new List<Animal>();
            foyer.Add(new Souris() { Nom = "Jerry" });
            foyer.Add(new Chat() { Nom = "Tom" });
            foyer.Add(new Tigre() { Nom = "Tony" });

            foreach (Animal animal in foyer)
            {
                animal.Crier();
            }
        }
    }
}
