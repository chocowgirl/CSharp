using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo18Event02.Models
{
    public class CompteEpargne : Compte
    {
        public void CalculInteret()
        {
            decimal interet;
            if(Solde > 0)
            {
                interet = Solde * 0.05M;
            }
            else
            {
                interet = Solde * 0.25M;
            }
            Solde += interet;
            onOperationRaise("Calcul des interets");
        }
    }
}
