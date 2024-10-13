using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace ListUtilisateurs
{
    internal class Program
    {
        /*
        Au démarrage, il n'y a aucun utilisateur enregistré.

        ## Déroulement du programme

        1. Le programme demande à l'utilisateur de saisir un nom et un prénom.
              - L’utilisateur saisit un nom et un prénom.

        2. Le programme demande à l'utilisateur de saisir la date de naissance.
              - L'utilisateur saisit la date de naissance.

        3. Le programme calcule l'âge de la personne en cours d'ajout.
              - Si l’âge est supérieur ou égal à 18 (majeur)
                    - Le programme demande à l'utilisateur de saisir son métier.
              - Si l’âge est inférieur à 18 (mineur)
                    - Le programme demande à l'utilisateur de saisir sa couleur préférée.

        4. Lorsque toutes les informations sont saisies
              - Le programme enregistre l'utilisateur

        5. Le programme demande à l'utilisateur s'il souhaite ajouter une autre personne.
              - Si oui
                    - Retour à l'étape 1 (saisir nom et prénom)
              - Si non
                    - Afficher tous les utilisateurs enregistrés en respectant ce format :
                    - Nom Prénom - Date de naissance (âge) - Métier/Couleur préférée

        6. Le programme remercie l'utilisateur et se termine
        */

        /* FONCTIONS */
        static string DemanderInfoUtilisateur(string _question)
        {
            string saisie = "";
            do
            {
                try
                {
                    // -L’utilisateur saisit un nom et un prénom.
                    Console.Write(_question);
                    saisie = Console.ReadLine() ?? "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (saisie == "");
            return saisie;
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            List<List<string>> listeUtilisateurs = new List<List<string>>();
            string nomPrenom = "";
            string dateNaissance = "";
            string metierCouleur = "";
            int age = 0;
            char choix = ' ';

            /* TRAITEMENT */

            do
            {
                // 1. Le programme demande à l'utilisateur de saisir un nom et un prénom.
                nomPrenom = DemanderInfoUtilisateur("Saisir un nom et un prénom : ");



                // 2.Le programme demande à l'utilisateur de saisir la date de naissance.
                dateNaissance = DemanderInfoUtilisateur("Saisir une date de naissance : ");

                
                if (DateTime.TryParse(dateNaissance, out DateTime naissanceDateTime))
                {
                    DateTime dateActuelle = DateTime.Now;

                    // 3. Le programme calcule l'âge de la personne en cours d'ajout.
                    TimeSpan interval = dateActuelle - naissanceDateTime;
                    age = (int)(interval.Days / 365.25);
                    
                    // -Si l’âge est supérieur ou égal à 18(majeur) Le programme demande à l'utilisateur de saisir son métier.
                    if (age >= 18)
                    {
                        metierCouleur = DemanderInfoUtilisateur("Saisir un métier : ");
                    }
                    // - Si l’âge est inférieur à 18(mineur) Le programme demande à l'utilisateur de saisir sa couleur préférée.
                    else
                    {
                        metierCouleur = DemanderInfoUtilisateur("Saisir une couleur préférée : ");
                    }
                }
                dateNaissance = age.ToString();

                // 4.Lorsque toutes les informations sont saisies Le programme enregistre l'utilisateur
                listeUtilisateurs.Add(new List<string>() { nomPrenom, dateNaissance, metierCouleur });

                // 5.Le programme demande à l'utilisateur s'il souhaite ajouter une autre personne.
                Console.Write("Souhaitez-vous ajouter une autre personne ? (o / n) : ");
                choix = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
            } while (choix == 'o' || choix == 'O');

            /* AFFICHAGE */

            // - Afficher tous les utilisateurs enregistrés en respectant ce format : -Nom Prénom - Date de naissance(âge) -Métier / Couleur préférée
            Console.WriteLine();
            Console.WriteLine("Liste des personnes enregistrées : ");
            for (int i = 0; i < listeUtilisateurs.Count; i++)
            {
                Console.WriteLine("- " + listeUtilisateurs[i][0] + " - " + listeUtilisateurs[i][1] + " ans" + " - " + listeUtilisateurs[i][2]);
            }

            // 6.Le programme remercie l'utilisateur et se termine
            Console.WriteLine();
            Console.WriteLine("Merci programme terminé.");
        }
    }
}
