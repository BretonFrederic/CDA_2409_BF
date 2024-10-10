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
                    Console.WriteLine(_question);
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
            List<string> listeUtilisateurs;
            string nomPrenom;
            string dateNaissance;
            DateTime naissance;
            

            /* TRAITEMENT */
            // 1. Le programme demande à l'utilisateur de saisir un nom et un prénom.
            nomPrenom = DemanderInfoUtilisateur("Saisir votre nom et votre prénom : ");



            // 2.Le programme demande à l'utilisateur de saisir la date de naissance.
            dateNaissance = DemanderInfoUtilisateur("Saisir votre date de naissance : ");

            /* 3. Le programme calcule l'âge de la personne en cours d'ajout.
                -Si l’âge est supérieur ou égal à 18(majeur)
                - Le programme demande à l'utilisateur de saisir son métier.
                - Si l’âge est inférieur à 18(mineur)
                - Le programme demande à l'utilisateur de saisir sa couleur préférée.
            */
            
            if(DateTime.TryParse(dateNaissance, out naissance))
            {
                Console.WriteLine(naissance);
                DateTime dateActuelle = DateTime.Now;
                int age = dateActuelle.Year - naissance.Year;
                Console.WriteLine(age);
            }

            /* AFFICHAGE */

        }
    }
}
