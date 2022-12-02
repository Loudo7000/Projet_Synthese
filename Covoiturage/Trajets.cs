using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covoiturage
{
    internal class Trajets
    {
        int id;
        String chauffeur;
        String voiture;
        int nb_places;
        String ville_depart;
        String date_depart;
        String date_arrivee;
        int nb_personne;
        int rev_brut;
        int rev_societe;

        public int Id { get => id; set => id = value; }
        public string Chauffeur { get => chauffeur; set => chauffeur = value; }
        public string Voiture { get => voiture; set => voiture = value; }
        public int Nb_places { get => nb_places; set => nb_places = value; }
        public string Ville_depart { get => ville_depart; set => ville_depart = value; }
        public string Date_depart { get => date_depart; set => date_depart = value; }
        public string Date_arrivee { get => date_arrivee; set => date_arrivee = value; }
        public int Nb_personne { get => nb_personne; set => nb_personne = value; }
        public int Rev_brut { get => rev_brut; set => rev_brut = value; }
        public int Rev_societe { get => rev_societe; set => rev_societe = value; }
    }
}
