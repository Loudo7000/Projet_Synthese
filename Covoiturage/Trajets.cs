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
        int id_chauffeur;
        String chauffeur;
        String voiture;
        int place_depart;
        String ville_depart;
        int place_arret;
        String ville_arret;
        String date_depart;
        String ville_arrivee;
        int nb_personne;
        int rev_brut;
        int rev_societe;

        public int Id { get => id; set => id = value; }
        public string Chauffeur { get => chauffeur; set => chauffeur = value; }
        public string Voiture { get => voiture; set => voiture = value; }
        public int Place_depart { get => place_depart; set => place_depart = value; }
        public string Ville_depart { get => ville_depart; set => ville_depart = value; }
        public string Date_depart { get => date_depart; set => date_depart = value; }
        public int Nb_personne { get => nb_personne; set => nb_personne = value; }
        public int Rev_brut { get => rev_brut; set => rev_brut = value; }
        public int Rev_societe { get => rev_societe; set => rev_societe = value; }
        public int Place_arret { get => place_arret; set => place_arret = value; }
        public string Ville_arret { get => ville_arret; set => ville_arret = value; }
        public string Ville_arrivee { get => ville_arrivee; set => ville_arrivee = value; }
        public int Id_chauffeur { get => id_chauffeur; set => id_chauffeur = value; }
    }
}
