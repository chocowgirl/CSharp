using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    public abstract class Case
    {
        private List<Joueur> _visiteurs;// = new List<Joueur>();

        public string Nom { get; private set; }

        public Joueur[] Visiteurs {
            get { return _visiteurs.ToArray(); }
        }


        public Case (string nom)
        {
            Nom = nom;
            _visiteurs = new List<Joueur>();
        }

        public void AjouterVisiteur(Joueur visiteur)
        {
            if (visiteur is null) return;
            if (_visiteurs.Contains(visiteur)) return;
            _visiteurs.Add(visiteur);
        }

        public void RetirerVisiteur(Joueur visiteur)
        {
            if (visiteur is null) return;
            if (!_visiteurs.Contains (visiteur)) return;
            _visiteurs.Remove(visiteur);
        }

        public abstract void Activer(Joueur visiteur);

    }
}
