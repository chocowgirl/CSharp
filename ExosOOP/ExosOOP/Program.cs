using ExosOOPMonopoly.Enums;
using ExosOOPMonopoly.Models;

namespace ExosOOPMonopoly

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //De.valeurMin = 1;
            //De.valeurMax = 6;
            //int[] result = De.Lancer(2);
            //Console.WriteLine($"Premier dé : {result[0]}\nSecond dé : {result[1]}");

            //Joueur j1 = new Joueur("Samuel",Pions.Dino); // This changes to a constructor with parameters because we created the Joueur constructor

            //Console.WriteLine($"{j1.Nom} c'est votre tour!  Bougez le pion {j1.Pion} de la case {j1.Position}!");
            //if (j1.Avancer())
            //{
            //    Console.WriteLine($"Bravo {j1.Nom}! Vous avez fait un double!");
            //}
            //Console.WriteLine($"{j1.Nom} vous êtes à présent sur la case {j1.Position}");
            //Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            //Console.WriteLine("Vos biens : ");
            //foreach (CasePropriete bien in j1.Proprietes)
            //{
            //    Console.WriteLine($"\t- {bien.Nom} ({bien.Couleur})");
            //}


            //test de la classe CasePropriete

            //CasePropriete i3Patio = new CasePropriete("Patio Interface 3", Couleurs.Marron, 20);


            //Console.WriteLine($"La première case du jeu Monopoly Version I3 est:");
            //Console.WriteLine(i3Patio.Nom);
            //Console.WriteLine($"De couleur {i3Patio.Couleur}");
            //Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            //if (i3Patio.EstHypoteqee) Console.WriteLine("Ce terrain est hypotequé...");
            //else Console.WriteLine("Ce terrain n'est pas hypotequé");
            //if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            //else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            //i3Patio.Acheter(j1);

            //Console.WriteLine($"La première case du jeu Monopoly Version I3 est:");
            //Console.WriteLine(i3Patio.Nom);
            //Console.WriteLine($"De couleur {i3Patio.Couleur}");
            //Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            //if (i3Patio.EstHypoteqee) Console.WriteLine("Ce terrain est hypotequé...");
            //else Console.WriteLine("Ce terrain n'est pas hypotequé");
            //if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            //else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            //Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            //Console.WriteLine("Vos biens : ");
            //foreach (CasePropriete bien in j1.Proprietes)
            //{
            //    Console.WriteLine($"\t- {bien.Nom} ({bien.Couleur})");
            //}

            //$$$$test de la classe Jeu$$$$$
            Jeu monopolyI3 = new Jeu(
                [
                    new CasePropriete("Patio", Couleurs.Marron, 20),
                    new CasePropriete("RDC Bat G", Couleurs.Marron, 20),
                    new CasePropriete("RDC Bat D", Couleurs.Marron, 22),
                    new CasePropriete("Ascen Bat D", Couleurs.BleuCiel, 26),
                    new CasePropriete("Ascen Bat G", Couleurs.BleuCiel, 26),
                    new CasePropriete("Toilette RDC", Couleurs.BleuCiel, 28),
                    new CasePropriete("Classe Unity", Couleurs.Violet, 32),
                    new CasePropriete("Classe Web", Couleurs.Violet, 32),
                    new CasePropriete("Classe Wad", Couleurs.Violet, 36),
                ]);

            monopolyI3.AjouterJoueur("Marwa", Pions.Dino);
            monopolyI3.AjouterJoueur("Dorothee", Pions.Voiture);
            monopolyI3.AjouterJoueur("Leslie", Pions.Chien);
            monopolyI3.AjouterJoueur("Melusine", Pions.DeACoudre);
            monopolyI3.AjouterJoueur("Emilie", Pions.Cuirasse);
            monopolyI3.AjouterJoueur("Jessica", Pions.Fer);
            monopolyI3.AjouterJoueur("Charifa", Pions.Chapeau);
            monopolyI3.AjouterJoueur("Anais", Pions.Brouette);
            monopolyI3.AjouterJoueur("Jenny", Pions.Chaussure);
            monopolyI3.AjouterJoueur("Amalia", Pions.Chien);
            monopolyI3.AjouterJoueur("Debby", Pions.Dino);

            Joueur joueurCourant = monopolyI3[Pions.Chapeau];
            joueurCourant = joueurCourant + 200;
            Console.WriteLine($"C'est au tour de pion {joueurCourant.Pion} ({joueurCourant.Nom}):");
            
            joueurCourant.Avancer();
            Console.WriteLine($"{joueurCourant.Nom} avancer à la case {joueurCourant.Position}.");
            Case caseJoueur = monopolyI3[joueurCourant.Position];
            Console.WriteLine($"Bienvenue sur la case {caseJoueur.Nom}.");

            //caseJoueur.Acheter(joueurCourant);

            if( caseJoueur is CasePropriete)
            {
                CasePropriete propriete = (CasePropriete)caseJoueur;
                CasePropriete[] proprietesJoueur = joueurCourant + propriete;
                Console.WriteLine($"{joueurCourant.Nom}: votre solde est de {joueurCourant.Solde}!");
            }

            //The above can be written as:
            //if (caseJoueur is CasePropriete propriete)
            //{ 
            //    Case
            //}



            //Test Case et case propriete:
            Case caseDepart = new Case("Case départ");

            CasePropriete prop1 = new CasePropriete("Prop1", Couleurs.Marron, 20);

            caseDepart.AjouterVisiteur(joueurCourant);
            caseDepart.AjouterVisiteur(monopolyI3[Pions.Dino]);
            Console.WriteLine($"les joueurs present sur la {caseDepart.Nom} sont:");
            foreach (Joueur visiteur in caseDepart.Visiteurs)
            {
                Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            }

            caseDepart.RetirerVisiteur(joueurCourant);
            prop1.AjouterVisiteur(joueurCourant);
            Console.WriteLine($"Les joueurs présent sur la {prop1.Nom} sont:");
            foreach(Joueur visiteur in prop1.Visiteurs)
            {
                Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            }

        }
    }
}
