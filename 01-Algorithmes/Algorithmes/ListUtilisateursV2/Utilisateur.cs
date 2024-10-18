using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ListUtilisateursV2
{
    public class Utilisateur
    {
        //private Guid id;

        private string nom;

        private string prenom;

        private DateTime dateDeNaissance;

        private string? metier;

        private string? couleurPreferee;

        public Utilisateur(string _nomPrenom, string _dateDeNaissance)
        {
            string[] nomPrenomSepare = _nomPrenom.Split(" ");
            this.nom = nomPrenomSepare[0];
            this.prenom = nomPrenomSepare[1];
            if (!DateTime.TryParse(_dateDeNaissance, out dateDeNaissance))
            {
                throw new Exception("Date de naissance invalide !");
            }
            if (dateDeNaissance > DateTime.Now)
            {
                throw new Exception("La date doit être dans le passé.");
            }
        }

        /* Setters */

        public void SetMetier(string _valeur)
        {
            this.metier = _valeur;
        }

        public void SetCouleurPreferee(string _valeur)
        {
            this.couleurPreferee = _valeur;
        }

        /* Getters */
        public int GetAge()
        {
            TimeSpan intervalle = DateTime.Now - dateDeNaissance;
            int age = (int)(intervalle.Days / 365.25);
            return age;
        }

        public bool IsMajeur()
        {
            return this.GetAge() >= 18;
        }

        public string? GetCouleurOuMetier()
        {
            if(metier == null && couleurPreferee == null)
            {
                throw new Exception("Le métier ou la couleur préférée doivent être renseignés.");
            }
            return this.IsMajeur() ? this.metier : this.couleurPreferee;
        }

        public string GetDateDeNaissance()
        {
            return dateDeNaissance.ToShortDateString();
        }

        public string GetNomComplet()
        {
            return prenom + " " + nom;
        }
    }
}
