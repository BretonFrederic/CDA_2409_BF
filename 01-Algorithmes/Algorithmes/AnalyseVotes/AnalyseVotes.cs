using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyseVotes
{
    public class AnalyseVotes
    {
        public string? poll { get; private set; }
        public int votes { get; private set; }
        public List<string>? results { get; private set; }

        public AnalyseVotes(string poll, int votes, List<string> results)
        {
            this.poll = poll;
            this.votes = votes;
            this.results = results;
        }

        public void AfficherCouleurs()
        {
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
        }

        public int CalculerOccurrences(string _couleurReference, List<string> _echantillonCouleurs)
        {
            int occurences = 0;
            foreach (string couleur in _echantillonCouleurs)
            {
                if (_couleurReference.Equals(couleur))
                {
                    occurences++;
                }
            }
            return occurences;
        }
    }
}