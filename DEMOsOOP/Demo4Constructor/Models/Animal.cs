using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4Constructor.Models
{
    internal class Animal
    {
        public string Nom {  get; set; }

        public int NbPattes {  get; set; }

        public int PointDeVie { get; private set; }
        public int PointDeBonheur { get; private set; }

        private List<string> _jouets;
        public string[] Jouets 
        {
            get { return _jouets.ToArray(); }
        }


        //in making this constructor, we override the default constructor
        public Animal(string name) : this(name, 10,30,new string[0]) // using this here erases the need for the commented code because this constructor looks to the other
            //Here we define the name and the constructor adds our defaults as below
        { 
            //PointDeVie = 10;
            //PointDeBonheur = 3;
            //_jouets = new List<string>();
            //Nom = name;
        }

        //Below we overload the constructor.
        public Animal(string nom, int pv, int pb, string[] jouets) // This is a function that would permit the reconstruction of an animal
            //Here we have the option to define all of the things and not lean on defaults
        { 
            _jouets = new List<string>(jouets);
            PointDeVie = pv;
            PointDeBonheur = pb;
            Nom = nom;
        }



        public void Jouer(string jouet)
        {
            if (jouet is null) return;
            if (_jouets.Contains(jouet)) PointDeBonheur++;
            else PointDeBonheur--; 
            //The above if else can also be written using the ternary below:
            //PointDeBonheur += (_jouets.Contains(jouet))? 1 : -1;
        }


        public void OffrirJouet(string jouet)
        {
            if (jouet is null)
            {
                PointDeBonheur = 0;
                return;
            }
            if (_jouets.Contains(jouet)) PointDeBonheur++;
            else
            {
                PointDeBonheur += 2;
                _jouets.Add(jouet);
            }
        }


        public void Manger()
        {
            PointDeVie++;
        }


    }
}
