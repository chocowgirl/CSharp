using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.Net;
using System;
using System.Numerics;
using System.Reflection;

namespace exosFinJour_9Oct2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Calcule de la division entière, du modulo et de la division de deux entiers.
            ////Résultat attendu pour 5 et 2 → Division entière : 2, Modulo: 1, Division: 2,5.

            //Console.WriteLine("Please give me a whole number");
            //string firstNumstring = Console.ReadLine();
            //bool firstNumstringParsable = int.TryParse(firstNumstring, out int parsedFirstNumInt);
            //if (!firstNumstringParsable)
            //{
            //    Console.WriteLine("You are supposed to enter an INTEGER");
            //}
            //Console.WriteLine("Please give me another whole number");
            //string secondNumstring = Console.ReadLine();
            //bool secondNumstringParsable = int.TryParse(secondNumstring, out int parsedSecondNumInt);
            //if (!secondNumstringParsable)
            //{
            //    Console.WriteLine("You are supposed to enter an INTEGER");
            //}
            //Console.WriteLine($"{parsedFirstNumInt} STRICTLY divided by {parsedSecondNumInt} results in {(parsedFirstNumInt / parsedSecondNumInt)}");
            //Console.WriteLine($"The remainder of this strict division is {(parsedFirstNumInt % parsedSecondNumInt)}");
            //Console.WriteLine($"The result of FULL division of {(float)parsedFirstNumInt} by {(float)parsedSecondNumInt} is {((float)parsedFirstNumInt/(float)parsedSecondNumInt)}");




            //Vérification d’un compte bancaire BBAN, si le compte est bon affichez OK sur la console sinon KO.
            //Le modulo des 10 premiers chiffres par 97 donne les 2 derniers.Sauf si le modulo = 0 dans ce cas les 2 derniers chiffres sont 97.
            //(utilisez la méthode « Substring » de la classe « string »).
            //Code BBAN = 12 derniers chiffre du numéro de compte :
            //BE55 7320 3820 7644 → BBAN: 7320 3820 7644 → 7320382076 % 97 == 44
            //BE55 0000 0000 0097 → BBAN: 0000 0000 0097 → 0 % 97 == 0 donc 97

            Console.WriteLine("Please give me your 12 digit BBAN number (this is your IBAN minus the BE and the first two numbers)");
            Console.WriteLine("... when you enter this number, do not put any spaces between numbers or groups of numbers");
            string bbanStringGiven = Console.ReadLine();
            
            //try to parse the string to a long
            bool bbanStringGivenParsable = long.TryParse(bbanStringGiven, out long bbanParsedToLong);

            //check length of string and make sure it's not only parsable but the right length
            int lengthbban = bbanStringGiven.Length;

            if (bbanStringGivenParsable && bbanStringGiven.Length == 12)
            {
                Console.WriteLine("Thank you for these 12 digits, checking validity...");

                ////realised I forgot to use the substring method so below is the example of how to separate the digits using substring:
                string lastTwo = bbanStringGiven.Substring(bbanStringGiven.Length - 2);
                Console.WriteLine($"last two chars are {lastTwo}");
                string firstTen = bbanStringGiven.Substring(0, 10);
                Console.WriteLine($"first ten chars are {firstTen}");

                ////convert the substrings to do the same math that I did using my method
                long lastTwoDigits = bbanParsedToLong % 100;
                Console.WriteLine("last two digits = " + lastTwoDigits);
                long firstTenDigits = (bbanParsedToLong - lastTwoDigits) / 100;
                Console.WriteLine("first ten digits = " + firstTenDigits);

                if ((firstTenDigits % 97 == lastTwoDigits) || (firstTenDigits % 97 == 0 && lastTwoDigits == 97))
                {
                    Console.WriteLine("BBAN OK");
                    //Transformer un compte bancaire BBAN Belge(xxx-xxxxxxx - xx) en IBAN(BExx-xxxx - xxxx - xxxx). Trouvez la démarche via un moteur de recherche.
                    //BBAN: 732 - 0382076 - 44 → IBAN: BE55 7320 3820 7644
                    //1.Récupérez les 2 derniers nombres : 732 - 0382076 - 44
                    //2.Concaténez le 2 fois suivi du code 111400(représentant le code BE0) : 4444111400
                    //3.Effectuez l’opération de soustraction de 98 par le modulo 97 du code précédent: 98 - (4444111400 % 97) → 98 - 43 → 55
                    //4.Unifiez le tout : BE55 7320 3820 7644

                    long calculHelper = 111400;
                    string firstHelperBit = lastTwo + lastTwo;
                    long parsedFirstHelperBit = long.Parse(firstHelperBit);
                    //Console.WriteLine(firstHelperBit);
                    Console.WriteLine(parsedFirstHelperBit);
                    long finalFirstHelperBit = parsedFirstHelperBit * 1_000_000;
                    Console.WriteLine(finalFirstHelperBit);
                    long totalHelper = finalFirstHelperBit + calculHelper;
                    Console.WriteLine(totalHelper);
                    long remainder = (totalHelper % 97);
                    Console.WriteLine($"the remainder is {remainder}");
                    long ninetyEightMinusRemainder = 98 - remainder;

                    Console.WriteLine($"98 minus the remainder is {ninetyEightMinusRemainder}");
                    string postBE = ninetyEightMinusRemainder.ToString("D2");


                    string iban = "BE" + postBE + bbanStringGiven;
                    Console.WriteLine($"your IBAN is {iban}");
                }
                else
                {
                    Console.WriteLine("BBAN KO");
                }
            }
            else
            {
                Console.WriteLine("You have not provided a sequence of 12 numbers");
            }


        }
    }
}
