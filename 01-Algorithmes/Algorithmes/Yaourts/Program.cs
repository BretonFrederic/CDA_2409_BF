using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

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

    internal class Program
    {
        class Yourt
        {
            string poll;
            int votes;
            public List<string> results = new();

            public Yourt(string poll, int votes, List<string> results)
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
        static async Task Main(string[] args)
        {
            /* VARIABLES */

            string url = "https://api.devoldere.net/polls/yoghurts/";

            HttpClient httpClient;

            Yourt? resultatCouleurs;

            string reponse;

            List<string> couleursRef = new List<string>() { "blue", "green", "orange", "red", "yellow" };

            List<int> occurencesCouleurs = new();

            /* TRAITEMENT */

            Console.WriteLine("Début chargement");

            httpClient = new();

            reponse = await httpClient.GetStringAsync(url);

            Console.WriteLine("Fin chargement");

            resultatCouleurs = JsonConvert.DeserializeObject<Yourt>(reponse);

            foreach(string c in couleursRef)
            {
                int occurence = resultatCouleurs.CalculerOccurrences(c, resultatCouleurs.results);
                occurencesCouleurs.Add(occurence);
            }


            
            /* AFFICHAGE */
            Console.WriteLine("Pour le tableau en entrée : ");
            resultatCouleurs.Afficher();

        }
    }
}
