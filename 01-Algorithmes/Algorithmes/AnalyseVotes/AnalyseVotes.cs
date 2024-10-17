using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyseVotes
{
    public class AnalyseVotes
    {
        /* VARIABLES INSTANCE */
        public string? poll { get; init; }
        public int votes { get; init; }
        public List<string>? results { get; init; }

        /* CONSTRUCTEUR */
        public AnalyseVotes(string poll, int votes, List<string> results)
        {
            this.poll = poll;
            this.votes = votes;
            this.results = results;
        }

        /* METHODES */
        public void AfficherCouleurs()
        {
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
        }

        public Dictionary<string, int> CompterVotesParCouleur()
        {
            Dictionary<string, int> couleurs = new();
            foreach (string c in this.results)
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
            return couleurs;
        }
    }
}