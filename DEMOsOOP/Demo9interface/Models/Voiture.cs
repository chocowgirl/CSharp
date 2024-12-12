﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9interface.Models
{
    internal class Voiture : IVoiture
    {
        public string Matricule {  get; private set; }
        public Voiture(string matricule) {
            Matricule = matricule;
        }

        public void Rouler()
        {
            Console.WriteLine("vroouum vroouum!");
        }


    }
}
