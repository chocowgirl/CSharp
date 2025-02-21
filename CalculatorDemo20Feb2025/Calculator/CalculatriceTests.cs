using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatriceTests
    {
        public static void Addition_With4and2_ShouldReturn6()
        {
            //Arrange (arrange the circumstances being tested)
            int nb1 = 4;
            int nb2 = 2;
            int result;


            //Act (goal to execute the action)
            result = Calculatrice.Addition(nb1, nb2);


            //Assert (is the result obtained what was expected?)
            if (result == 6)
            {
                Console.WriteLine($"Test réussi!");
            }
            else
            {
                Console.WriteLine($"Test échoué :( ");
            }
        }


        public static void Addition_WithTwoBigValue_ShouldThrowOverflowException()
        {
            //Arrange
            int nb1 = 1500000000;
            int nb2 = 1_500_000_000; //reminder that underscore can be used to clarify numbers without consequence in c#
            int result;

            //Act
            try
            {
                result = Calculatrice.Addition(nb1,nb2);
            }
            catch (Exception ex)
            {
                //Assert
                if (ex is OverflowException)
                {
                    Console.WriteLine("Test réussi");
                }
                else
                {
                    Console.WriteLine("Test échoué ... ");
                }
            }
        }




    }
}
