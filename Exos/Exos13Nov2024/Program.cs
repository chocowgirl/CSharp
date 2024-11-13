using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Exos13Nov2024
{
    //EXO 19 dans les corrections de Samuel
    //Dans un application console en .net 8, creez une structure "Calcul" comportant les variables:
    //nb1 and nb2 (decimal type double)
    //operat de type char
    //resultat de type double nullable
    //isValid de type boolean

    internal class Program
    {
        static void Main(string[] args)
        {
            //Demander a l'utilisateur d'introduire des valeurs dans nb1, nb2 et operat, et l'ordinateur doit resoudre le calcul fournit et enregistrer le resultat dans result.  Si le calcul est impossible, result doit etre null et isValid a false.  Dans le cas contraire, obtenir true dans isValid.
            bool givenFirstNumberStringParsable;
            bool givenSecondNumberStringParsable;
            bool givenOperatStringParsable;
            
            Calcul calc1;

            do
            {
                Console.WriteLine("Please enter a first number:");
                //string givenFirstNumberString = Console.ReadLine();
                //givenFirstNumberStringParsable = double.TryParse(givenFirstNumberString, out calc1.nb1);
            } while (!double.TryParse(Console.ReadLine(), out calc1.nb1));

            do
            {
                Console.WriteLine("Please enter another number:");
                //string givenSecondNumberString = Console.ReadLine();
                //givenSecondNumberStringParsable = double.TryParse(givenSecondNumberString, out calc1.nb2);
            } while (!double.TryParse(Console.ReadLine(), out calc1.nb2));

            do
            {
                Console.WriteLine("Please enter one of the following characters: +, -, *, / :");
                string givenOperatString = Console.ReadLine();
                calc1.operat = givenOperatString[0];
                //givenOperatStringParsable = char.TryParse(givenOperatString, out calc1.operat);
            } while (calc1.operat != '+' && calc1.operat != '-' && calc1.operat != '*' && calc1.operat != '/');

            if (calc1.operat == '+')
            {
                calc1.isValid = true;
                calc1.result = calc1.nb1 + calc1.nb2;
            }
            else if (calc1.operat == '-')
            { 
                calc1.isValid = true;
                calc1.result = calc1.nb1 - calc1.nb2;
            }
            else if (calc1.operat == '/') {
                if (calc1.nb2 == 0) {
                    calc1.result = null;
                    calc1.isValid = false;
                }
                else
                {
                    calc1.isValid = true;
                    calc1.result = calc1.nb1 / calc1.nb2;
                }
            }
            else {
                calc1.result = calc1.nb1 * calc1.nb2;
                calc1.isValid = true;  
            }

            Console.WriteLine($"you gave me {calc1.nb1} {calc1.operat} {calc1.nb2}, which results in:");
            Console.WriteLine(calc1.result);
            if (!calc1.isValid)
            {
                Console.WriteLine("this operation is impossible.");
            }

        }
    }
}
