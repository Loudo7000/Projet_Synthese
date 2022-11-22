using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covoiturage
{
    internal class Trajets
    {
        String chauffeur;
        String voiture;
        int nb_places;
        String ville_depart;
        String heure_depart;
        String ville_arrivee;

        public string Chauffeur { get => chauffeur; set => chauffeur = value; }
        public string Voiture { get => voiture; set => voiture = value; }
        public int Nb_places { get => nb_places; set => nb_places = value; }
        public string Ville_depart { get => ville_depart; set => ville_depart = value; }
        public string Heure_depart { get => heure_depart; set => heure_depart = value; }
        public string Ville_arrivee { get => ville_arrivee; set => ville_arrivee = value; }
    }
}
