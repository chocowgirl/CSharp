using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9Interfaces.Models
{
    public class Bateau : object, IBateau //after the two points we put a parent class if there is one, a comma, and then the interface to implement
    {
        public string Matricule {  get; set; } //Matricule is Capitalised here b/c PROPERTIES start with capitals, whereas variables don't

        public Bateau(string matricule)
        {
            Matricule = matricule;
        }

        public void Naviguer() //obliged to put public b/c class methods are by default private
        {
            Console.WriteLine("Je navigue sur mon bateau");
        }


    }
}
