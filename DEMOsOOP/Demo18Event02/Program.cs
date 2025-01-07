using Demo18Event02.Handlers;
using Demo18Event02.Models;

namespace Demo18Event02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompteEpargne c1 = new CompteEpargne();
            c1.onOperation += NotifiedOperation;
            c1.Depot(500M);
            c1.Retrait(750M);
            c1.CalculInteret();
        }

        static void NotifiedOperation(object sender, EventArgs args)
        {
            OperationEventArgs opArgs = (OperationEventArgs) args;
            Console.WriteLine($"L'operation de {opArgs.OperationName} a été effectuée avec succès!\n Votre nouveau solde est de {((Compte)sender).Solde} euro(s).");
        }

    }
}
