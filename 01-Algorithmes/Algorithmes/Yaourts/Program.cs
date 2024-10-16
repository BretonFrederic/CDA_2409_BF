using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Yaourts
{
    // TP: Yaourts
    // Vous êtes en charge de la réalisation d’un algorithme d’analyse d’une étude marketing sur l’emballage d’un nouveau yaourt bio issu de circuits courts.Vous recevez à ce titre les résultats d’une étude où des consommateurs indiquent la couleur qu’ils préfèrent pour l’emballage.Vous décidez de présenter les 2 couleurs les plus demandées à votre client.
    // Consignes
    // Développez l’algorithme répondant à la probématique ci-dessus.
    // Codez la solution dans le langage indiqué par votre formateur.

    // Données
    // Entrée

    // Colors :

    // Un tableau indexé contenant entre 500 et 5000 entrées.Chaque élément du tableau correspond à la couleur choisie par une personne interrogée.Ces éléments du tableau sont générés aléatoirement à chaque appel de votre algorithme.
    // Exemple :

    // [ ‘rouge’, ‘jaune’, ‘bleu’, ‘jaune’, ‘rouge’, ‘jaune’ ]
    // Les données sont à charger à partir de l’url : https://api.devoldere.net/polls/yoghurts/.
    // Chaque appel à l’api génère un nouveau vote.

    class Program
    {
        // Class Yaourt pour créer un objet de type Yaourt à partir du Json déserialisé
        class Yaourt
        {
            string poll;
            int votes;
            public List<string> results = new();

            public Yaourt(string poll, int votes, List<string> results)
            {
                this.poll = poll;
                this.votes = votes;
                this.results = results;
            }

            public void Afficher()
            {
                foreach(string s in results)
                {
                    Console.WriteLine(s);
                }
            }

            public int CalculerOccurrences(string _couleurReference, List<string> _echantillonCouleurs)
            {
                int occurences = 0;
                foreach(string couleur in _echantillonCouleurs)
                {
                    if (_couleurReference.Equals(couleur))
                    {
                        occurences++;
                    }
                }
                return occurences;
            }
        }

        // Fonction qui télécharge un fichier Json et le renvoie en string
        static async Task<string> DownloadAsyncJson(string _url)
        {
            HttpClient httpClient = new();
            return await httpClient.GetStringAsync(_url); ;
        }
        static async Task Main(string[] args)
        {
            /* VARIABLES */

            string url = "https://api.devoldere.net/polls/yoghurts/";

            Yaourt? yourts;

            string fichierJson;

            Dictionary<string, int> couleursRefOccurences = new();

            /* TRAITEMENT */

            Console.WriteLine("Début chargement...");

            fichierJson = await DownloadAsyncJson(url);
            
            // Initialisation de l'objet yaourt avec le Json déserialisé
            yourts = JsonConvert.DeserializeObject<Yaourt>(fichierJson);

            Console.WriteLine("Fin chargement");
            Console.WriteLine();

            // Parcourir Yaourt.results
            // Stocker couleurs references avec leurs occurences si première occurence sinon stocker juste occurences
            foreach(string c in yourts.results)
            {
                if (!couleursRefOccurences.ContainsKey(c))
                {
                    couleursRefOccurences.Add(c, 1);
                }
                else
                {
                    couleursRefOccurences[c] += 1;
                }
            }
            // Dictionnaire trié par ordre décroissant
            couleursRefOccurences = couleursRefOccurences.OrderByDescending(key => key.Value).ToDictionary();
            
            /* AFFICHAGE */
            Console.WriteLine("Pour le tableau en entrée : ");
            yourts.Afficher();
            Console.WriteLine();
            Console.Write("La réponse est : ");
            foreach(KeyValuePair<string, int> c in couleursRefOccurences.Take(2).ToDictionary())
            {
                Console.Write(c.Key + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Car le " + couleursRefOccurences.Keys.First() + " a obtenu ");
        }
    }
}
