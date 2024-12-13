using Demo13Exceptions.Exceptions;
using Demo13Exceptions.Models;

namespace Demo13Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Veuillez introduire un premier nombre:");
            //int nombre1 = int.Parse(Console.ReadLine());

            //Console.WriteLine("Veuillez introduire un premier nombre:");
            //int nombre2 = int.Parse(Console.ReadLine());

            //try
            //{
            //    Console.WriteLine($"Le quotient de {nombre1} par {nombre2} vaut {Mathematique.Division(nombre1, nombre2)}");
            //}
            //catch
            //{
            //    Console.WriteLine($"Le quotient de {nombre1} par {nombre2} vaut l'infini!");
            //}


            Console.WriteLine("calculons une moyenne de valeurs");  //if the tableau is null or if it contains 0 values, this creates 2 different exceptions.
            int[] nbs = new int[0]; // null ;
            try
            {
                Console.WriteLine($"La moyenne est de {Mathematique.Moyenne(nbs)}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("il n'y a pas de valeur à traiter...");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("aucune valeur n'est présent dans le tableau de données");
            }
            catch (ArgumentArrayNeedValueException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Parameter name: {ex.ParamName}");
                Console.WriteLine($"nombre de valeurs necessaire: {ex.MinValueRequired}");
                Console.WriteLine($"nombre de valeurs actuel : {ex.CurrentQuantityValues}");
                if (ex.CurrentQuantityValues == 0) Console.WriteLine("pas de chiffre, pas de moyenne...");
                else if (ex.CurrentQuantityValues == 1) Console.WriteLine("Faire la moyenne d'un seul chiffre est inutile...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
                Console.WriteLine(ex.Message);
            }
            //finally { } this code will execute no matter what but if it's a return, remember you have to pass it to qqchose outside of the boucle.
            Console.WriteLine("Merci d'avoir utilisé Moyenne2000!");



        }
    }
}
