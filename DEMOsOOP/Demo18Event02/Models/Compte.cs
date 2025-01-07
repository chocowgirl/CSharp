using Demo18Event02.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo18Event02.Models
{

    //public delegate void OperationHandler(string opName, decimal nouvSolde);

    public class Compte
    {
        public event EventHandler onOperation;

        public decimal Solde { get; protected set; }

        public Compte()
        {
            Solde = 1000M;
        }

        public void Depot(decimal montant)
        {
            Solde += montant;
            onOperationRaise("Depot");
        }

        public void Retrait(decimal montant)
        {
            Solde -= montant;
            onOperationRaise("Retrait");
        }

        protected void onOperationRaise(string opName)
        {
            OperationEventArgs args = new OperationEventArgs()
            {
                OperationName = opName
            };
            onOperation?.Invoke(this, args);
        }
    }
}
