using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Bouteille
    {
        // CHAMPS
        public string? marque { private set; get; }
        public string? typeContenu { private set; get; }
        public double volume { private set; get; }
        public double quantite { private set; get; }
        public bool estOuverte { private set; get; }

        // CONSTRUCTEUR PAR DEFAUT
        public Bouteille()
        {
            this.marque = "inconnu";
            this.typeContenu = "eau";
            this.volume = 1.0;
            this.quantite = 0.0;
            this.estOuverte = false;
        }

        // CONSTRUCTEUR
        public Bouteille(string _marque, string _typeContenu, double _volume, double _quantite)
        {
            this.marque = _marque;
            this.typeContenu = _typeContenu;
            this.volume = _volume;
            this.quantite = _quantite;
            this.estOuverte = false;
        }

        // METHODES
        public bool Ouvrir()
        {
            if (!this.estOuverte)
            {
                // je peux ouvrir la bouteille si elle est fermée
                this.estOuverte = true;
                // l'action ouvrir a été réalisé
                return true;
            }
            else
            {
                // bouteille déjà ouverte je pas pas l'ouvrir
                // l'action ouvrir n'a pas été réalisé
                return false;
            }
        }

        public bool Fermer()
        {
            if (this.estOuverte)
            {
                // je peux fermer la bouteille si elle est ouverte
                this.estOuverte = false;
                // l'action fermer a été réalisé
                return true;
            }
            else
            {
                // bouteille déjà fermée je pas pas la fermer
                // l'action fermer n'a pas été réalisé
                return false;
            }
        }
        public bool Vider()
        {
            if (this.estOuverte && this.quantite > 0)
            {
                // Bouteille ouverte on vide la bouteille
                this.quantite = 0.0;
                // l'action vider a été réalisé
                return true;
            }
            else
            {
                // bouteille fermée impossible de vider
                // l'action vider n'a pas été réalisé
                return false;
            }
        }
        public bool Remplir()
        {
            if (this.estOuverte && this.quantite < this.volume)
            {
                // Bouteille ouverte on rempli la bouteille
                this.quantite = this.volume;
                // l'action remplir a été réalisé
                return true;
            }
            else
            {
                // bouteille fermée impossible de remplir
                // l'action remplir n'a pas été réalisé
                return false;
            }
        }
    }

}
