using Demo07Heritage.Models;

namespace Demo07Heritage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne(
                firstName:"John",
                lastName:"Doe",
                birthDate: new DateTime(1987, 1, 1)
            );
       
            //Console.WriteLine($"Voici {p.FirstName} {p.LastName}, ne le {p.BirthDate.ToShortDateString()}");
            Console.WriteLine(p.SePresenter()); //
            Console.WriteLine(p.SePresenter2()); //




            Personne e = new Employe("Henry", "Verne", new DateTime(1991, 1, 1), "Developpement"); 
            //{ 
            //    FirstName = "Henry",
            //    LastName = "Verne",
            //    BirthDate = new DateTime(1991, 1, 1),
            //    Departement="Developpement"
            //};

            //Console.WriteLine($"Voici {e.FirstName} {e.LastName}, il est ne le { e.BirthDate.ToShortDateString()}");
            //We can do this because employee inherits the methods from person.

            Console.WriteLine(e.SePresenter()); //avec l'override
            Console.WriteLine(e.SePresenter2()); // avec la dissimulation so it behaves like the parent.


            //e.Travailler();

            //if (e.EstOccupe)
            //{
            //    Console.WriteLine("Deso je travaille je n'ai pas le temps");
            //}
            //else {
            //    Console.WriteLine("Oui que puis-je faire pour toi?");
            //}




        }
    }
}
