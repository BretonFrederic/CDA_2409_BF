using Newtonsoft.Json;

namespace AnalyseVotes
{
    // TP: Yaourts
    // Vous êtes en charge de la réalisation d’un algorithme d’analyse d’une étude marketing sur l’emballage d’un nouveau yaourt bio issu de circuits courts.
    // Vous recevez à ce titre les résultats d’une étude où des consommateurs indiquent la couleur qu’ils préfèrent pour l’emballage.Vous décidez de présenter
    // les 2 couleurs les plus demandées à votre client.
    // Consignes
    // Développez l’algorithme répondant à la probématique ci-dessus.
    // Codez la solution dans le langage indiqué par votre formateur.

    // Données
    // Entrée

    // Colors :

    // Un tableau indexé contenant entre 500 et 5000 entrées.Chaque élément du tableau correspond à la couleur choisie par une personne interrogée.
    // Ces éléments du tableau sont générés aléatoirement à chaque appel de votre algorithme.
    // Exemple :

    // [ ‘rouge’, ‘jaune’, ‘bleu’, ‘jaune’, ‘rouge’, ‘jaune’ ]
    // Les données sont à charger à partir de l’url : https://api.devoldere.net/polls/yoghurts/.
    // Chaque appel à l’api génère un nouveau vote.

    class Program
    {
        /* FONCTIONS */

        // Fonction qui télécharge un fichier Json et le renvoie en string
        static async Task<string> DownloadAsyncJson(string _url)
        {
            HttpClient httpClient = new();

            return await httpClient.GetStringAsync(_url);
        }
        static async Task Main(string[] args)
        {
            /* VARIABLES */

            string url = "https://api.devoldere.net/polls/yoghurts/";

            AnalyseVotes? analyse;

            string fichierJson;

            Dictionary<string, int> couleurs = new();

            /* TRAITEMENT */

            Console.WriteLine("Début chargement...");

            fichierJson = await DownloadAsyncJson(url);

            // Initialisation de l'objet AnalyseVotes avec le Json déserialisé
            analyse = JsonConvert.DeserializeObject<AnalyseVotes>(fichierJson);

            Console.WriteLine("Fin chargement");
            Console.WriteLine();

            // Parcourir AnalyseVotes.results
            // Stocker couleurs references avec leurs occurences si première occurence sinon stocker juste occurences
            foreach (string c in analyse.results)
            {
                if (!couleurs.ContainsKey(c))
                {
                    couleurs.Add(c, 1);
                }
                else
                {
                    couleurs[c] += 1;
                }
            }

            // Dictionnaire trié par ordre décroissant
            couleurs = couleurs.OrderByDescending(key => key.Value).ToDictionary();

            /* AFFICHAGE */
            Console.WriteLine("Pour le tableau en entrée : ");
            analyse.AfficherCouleurs();
            Console.WriteLine();

            // Résultats 2 premières couleurs
            Console.Write("La réponse est : ");
            foreach (KeyValuePair<string, int> c in couleurs.Take(2).ToDictionary())
            {
                Console.Write(c.Key + " ");
            }

            Console.WriteLine();

            // Justification classement
            if (couleurs.Values.ElementAt(2) != couleurs.Values.ElementAt(3))
            {
                Console.WriteLine("Car le " + couleurs.Keys.ElementAt(1) +
                              " a obtenu " + couleurs.Values.ElementAt(1) +
                              " votes, le " + couleurs.Keys.ElementAt(2) +
                              " " + couleurs.Values.ElementAt(2) +
                              " votes et le " + couleurs.Keys.ElementAt(3) +
                              " " + couleurs.Values.ElementAt(3) + " votes.");
            }
            else
            {
                Console.WriteLine("Le " + couleurs.Keys.ElementAt(2) +
                                  " et le " + couleurs.Keys.ElementAt(3) +
                                  " ont " + couleurs.Values.ElementAt(2) + " votes.");
                Console.WriteLine("Le " + couleurs.Keys.ElementAt(2) + " apparait en 1er dans le tableau");
                Console.WriteLine("Le " + couleurs.Keys.ElementAt(2) + " l'emporte sur le " + couleurs.Keys.ElementAt(3));
            }
        }
    }
}
