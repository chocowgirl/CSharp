using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07Heritage.Models
{
    public class Employe : Personne
    {
        public string Departement { get; set; }

        public bool EstOccupe {  get; set; }


        public Employe(string firstName, string lastName, DateTime birthDate, string departement) : base (firstName, lastName, birthDate)
        {
            //FirstName = firstName;
            //LastName = lastName;
            //BirthDate = birthDate;  //BirthDate will show a redline b/c not accessible to the enfant
            Departement = departement;
            EstOccupe = false;
        }

        public void Travailler()
        {
            EstOccupe = true;
        }

        public override string SePresenter()
        {
            //return base.SePresenter();
            return $"voici {FirstName} {LastName}, il travaille pour le département '{Departement}' il est né le {BirthDate}."; 
            //we can't add when he's born b/c the child doesn't have access to this (it's private in parent class)
            //we would have to change the private to protected to give the child access.
            //(In this demo we placed a private set so that the child class can only get Birthdate)
        }

        public new string SePresenter2()
        {
            return $"voici {FirstName} {LastName}, il travaille pour le département '{Departement}' il est né le {BirthDate}.";
        }


        public override string ToString()
        {
            return $"employé : {base.ToString()}";
        }

    }
}
