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

            //$$$$$$$ test de la classe Jeu $$$$$
            Jeu monopolyI3 = new Jeu(
                [
                    new CaseAction("Case départ", delegate(Joueur visiteur){
                        visiteur.EtrePaye(200);
                        return true;
                    }),
                    new CasePropriete("Patio", Couleurs.Marron, 200),
                    new CasePropriete("RDC Bat G", Couleurs.Marron, 200),
                    new CaseAction("Duplicata carte magnétique", delegate(Joueur visiteur){
                        try
                        {
                            visiteur.Payer(100);
                            return true;
                        }
                        catch (Exception)
                        {
		                    return false;
                        }
                    }),
                    new CasePropriete("RDC Bat D", Couleurs.Marron, 220),
                    new CasePropriete("Ascen Bat D", Couleurs.BleuCiel, 260),
                    new CasePropriete("Ascen Bat G", Couleurs.BleuCiel, 260),
                    new CaseAction("Femme de ménage bloque le passage", null),
                    new CasePropriete("Toilette RDC", Couleurs.BleuCiel, 280),
                    new CasePropriete("Classe Unity", Couleurs.Violet, 320),
                    new CasePropriete("Classe Web", Couleurs.Violet, 320),
                    new CasePropriete("Classe Wad", Couleurs.Violet, 360),
                ]);

            monopolyI3.AjouterJoueur("Marwa", Pions.Dino);
            monopolyI3.AjouterJoueur("Dorothee", Pions.Voiture);
            //monopolyI3.AjouterJoueur("Leslie", Pions.Chien);
            //monopolyI3.AjouterJoueur("Melusine", Pions.DeACoudre);
            //monopolyI3.AjouterJoueur("Emilie", Pions.Cuirasse);
            //monopolyI3.AjouterJoueur("Jessica", Pions.Fer);
            //monopolyI3.AjouterJoueur("Charifa", Pions.Chapeau);
            //monopolyI3.AjouterJoueur("Anais", Pions.Brouette);
            //monopolyI3.AjouterJoueur("Jenny", Pions.Chaussure);
            //monopolyI3.AjouterJoueur("Amalia", Pions.Chien);
            //monopolyI3.AjouterJoueur("Debby", Pions.Dino);

            //Joueur joueurCourant = monopolyI3[Pions.Chapeau];
            //joueurCourant = joueurCourant + 200;
            //Console.WriteLine($"C'est au tour de pion {joueurCourant.Pion} ({joueurCourant.Nom}):");

            //joueurCourant.Avancer();
            //Console.WriteLine($"{joueurCourant.Nom} avancer à la case {joueurCourant.Position}.");
            //Case caseJoueur = monopolyI3[joueurCourant.Position];
            //Console.WriteLine($"Bienvenue sur la case {caseJoueur.Nom}.");

            ////caseJoueur.Acheter(joueurCourant);

            //if( caseJoueur is CasePropriete)
            //{
            //    CasePropriete propriete = (CasePropriete)caseJoueur;
            //    CasePropriete[] proprietesJoueur = joueurCourant + propriete;
            //    Console.WriteLine($"{joueurCourant.Nom}: votre solde est de {joueurCourant.Solde}!");
            //}

            ////The above can be written as:
            ////if (caseJoueur is CasePropriete propriete)
            ////{ 
            ////    Case
            ////}



            ////$$$$$$$$$$Test Case et case propriete: $$$$$$$$$$$$
            //Case caseDepart = new Case("Case départ");

            //CasePropriete prop1 = new CasePropriete("Prop1", Couleurs.Marron, 20);

            //caseDepart.AjouterVisiteur(joueurCourant);
            //caseDepart.AjouterVisiteur(monopolyI3[Pions.Dino]);
            //Console.WriteLine($"les joueurs present sur la {caseDepart.Nom} sont:");
            //foreach (Joueur visiteur in caseDepart.Visiteurs)
            //{
            //    Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            //}

            //caseDepart.RetirerVisiteur(joueurCourant);
            //prop1.AjouterVisiteur(joueurCourant);
            //Console.WriteLine($"Les joueurs présent sur la {prop1.Nom} sont:");
            //foreach(Joueur visiteur in prop1.Visiteurs)
            //{
            //    Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            //}
            int nbJoueursSolvable = 0;
            foreach (Joueur j in monopolyI3.Joueurs)
            {
                if(j.Solde > 0) nbJoueursSolvable++;
            }

            int indexJoueur = 0;

            while (nbJoueursSolvable > 1)
            {
                Joueur joueurCourant = monopolyI3.Joueurs[indexJoueur % monopolyI3.Joueurs.Length];
                Console.WriteLine($"Au tour de {joueurCourant.Nom}.");
                if (joueurCourant.Proprietes.Length > 0)
                {
                    int choix;
                    do
                    {
                        Console.WriteLine($"voulez-vous effectuer une action sur un de vos {joueurCourant.Proprietes.Length} biens?");
                        for (int i = 0; i < joueurCourant.Proprietes.Length; i++)
                        {
                            CasePropriete prop = joueurCourant.Proprietes[i];
                            if (prop.EstHypotequee)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine($"{i + 1} - {prop.Nom} ({prop.Couleur}, {prop.Prix}$M) ");
                            Console.ResetColor();
                        }
                        do
                        {
                            Console.WriteLine($"Entrez la numéro du bien pour changer son status d'hypotheque, ou alors entrer 0 pour jouer votre tour."); 
                        } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 0 || choix > joueurCourant.Proprietes.Length);
                        
                        if (choix != 0)
                        {
                            IProprietaire propChoisi = joueurCourant.Proprietes[choix-1];
                            if (propChoisi.EstHypotequee)
                            {
                                propChoisi.Deshypothequer();
                            }
                            else
                            {
                                propChoisi.Hypothequer();
                            }
                        }
                    } while (choix !=0);
                }

                bool rejoue;
                do
                {
                    Case caseCourante = monopolyI3[joueurCourant.Position];
                    Console.WriteLine($"Il est actuellement sur la case {monopolyI3[joueurCourant.Position].Nom}."); 
                    caseCourante.RetirerVisiteur(joueurCourant);
                    try
                    {
                        rejoue = joueurCourant.Avancer();
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        Console.Beep(1000, 2000);
                        rejoue=false;
                    }

                    caseCourante = monopolyI3[joueurCourant.Position];
                    Console.WriteLine($"Il se deplace sur la case {caseCourante.Nom}.");
                    caseCourante.AjouterVisiteur(joueurCourant);
                    Console.WriteLine($"le nombre de propriété de {joueurCourant.Nom} est de {joueurCourant.Proprietes.Length}");
                    Console.WriteLine($"son solde actuel est de {joueurCourant.Solde} $Monopoly.");
                }while( rejoue);
                nbJoueursSolvable = 0;
                foreach (Joueur j in monopolyI3.Joueurs)
                {
                    if(j.Solde > 0)nbJoueursSolvable++;
                }
                indexJoueur++;
            }


        }
    }
}
