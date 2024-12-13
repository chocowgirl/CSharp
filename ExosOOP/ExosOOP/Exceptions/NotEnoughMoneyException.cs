using ExosOOPMonopoly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExosOOPMonopoly.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public Joueur Payeur { get; private set; }

        public int Montant {  get; private set; }

        public CasePropriete Bien {  get; private set; }



        public NotEnoughMoneyException(Joueur playerPayer, int amount) : base($"{playerPayer.Nom} n'a pas su payer la somme de {amount}") //
        {
            Montant = amount;
            Payeur = playerPayer;
        }

        public NotEnoughMoneyException(Joueur playerPayer, int amount, CasePropriete bien) : base($"{playerPayer.Nom} n'a pas su payer la somme de {amount} pour aquerir le bien {bien.Nom}")
        {
            Montant = amount;
            Payeur = playerPayer;
            Bien = bien;
        }


        //private NotEnoughMoneyException(Joueur playerPayer, int amount, CasePropriete bien, string message) : base(message)
        //{
        //    Payeur = playerPayer;
        //    Montant = amount;
        //    Bien = bien;
        //}

        //The above would allow the change to :this(playerPayer, amount, null, $"{playerPayer.Nom} n'a pas su payer la somme de {amount}") in the end of the 2 param constructor,
        //and :this(playerPayer, amount, null, $"{playerPayer.Nom} n'a pas su payer la somme de {amount} pour aquerir le bien {bien.Nom}") for the 3 param, along with emptying the code block that gets Montant, Payeur and Bien

    }

}
