using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Models
{
    //public delegate bool CaseDelegate(Joueur visiteur); //this is replaced by Func<Joueur, bool> in the code
    

    public class CaseAction : Case
    {
        private Func<Joueur, bool> _action;

        public CaseAction(string nom, Func<Joueur, bool> action) : base(nom)
        {
            _action = action;
        }

        public override void Activer(Joueur visiteur)
        {
            if(visiteur is null) throw new ArgumentNullException(nameof(visiteur), $"Il nous faut un visiteur pour activer la case...");
            _action?.Invoke(visiteur);
        }
    }
}
