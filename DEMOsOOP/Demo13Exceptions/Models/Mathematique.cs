using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo13Exceptions.Models
{
    internal static class Mathematique  //reminder this can only contain static members and (cannot be instantiated?)
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nb1"></param>
        /// <param name="nb2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int Division(int nb1, int nb2)
        {
            
            if (nb2 == 0) throw new ArgumentOutOfRangeException();
            return nb1 / nb2;

            //try
            //{
            //    return nb1 / nb2;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Attention, division par zero: {ex.Message}");
            //    return 0;
            //}

        }


        /// <summary>
        /// Méthode statique permettant d'obtenir une moyenne (int) à partir d'un tableau de valeurs de type int
        /// </summary>
        /// <param name="nombres">Ensemble de valeur soumis en format d'un tableu d'entiers (doit contenir au moins une valeur)</param>
        /// <returns>(ne s'affiche pas dans l'infobulle) Nombre entier correspondant à la moyenne d'un ensemble de valeurs</returns>
        /// <exception cref="ArgumentNullException">Certains params (nombres) ne doivent pas être null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Certains params (nombres) doivent avoir au moins une valeur.</exception>
        public static int Moyenne(int[] nombres)  // tableau is a referential type
        {
            if (nombres is null)
            {
                throw new ArgumentNullException("nombres", "Attention le paramètre est null.");
            }
            //instead of "nombres" in the first parameter of the ArgumentNullException we can also use nameof(nombres) - if we make a typo it will underline in red.

            if(nombres.Length <= 1)
            {
                throw new ArgumentOutOfRangeException(2, nombres.Length, nameof(nombres));
            }
            int somme = 0;
            foreach (int i in nombres)
            {
                somme += i;
            }
            return somme / nombres.Length;
        }
    }
}
