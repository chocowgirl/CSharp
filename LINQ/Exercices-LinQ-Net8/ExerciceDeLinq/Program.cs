using LINQDataContext;

namespace ExerciceDeLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext dc = new DataContext();

            //Faites vos exos ici
            //2.1 --ecrire une requete pour presenter pour chaque étudiant le nom, la date de naissance, le login et le resultat pour l'année.

            var studNomDBLoginResult = dc.Students.Select((s) => new { s.Last_Name, s.BirthDate, s.Login, s.Year_Result });

            foreach var item in studNomDBLoginResult) { 
                
            }






            #region Console.ReadLine()
            Console.ReadLine();
            #endregion
        }
    }
}