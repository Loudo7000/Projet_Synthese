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
        string chauffeur;
        string voiture;
        int place_depart;
        string ville_depart;
        int place_arret;
        string ville_arret;
        string date_depart;
        string ville_arrivee;
        string personne;
        int nb_personne;
        double rev_brut;
        double rev_societe;
        double rev_chauffeur;
        string etat;


        public int Id { get => id; set => id = value; }
        public string Chauffeur { get => chauffeur; set => chauffeur = value; }
        public string Voiture { get => voiture; set => voiture = value; }
        public int Place_depart { get => place_depart; set => place_depart = value; }
        public string Ville_depart { get => ville_depart; set => ville_depart = value; }
        public string Date_depart { get => date_depart; set => date_depart = value; }
        public int Nb_personne { get => nb_personne; set => nb_personne = value; }
        public double Rev_brut { get => rev_brut; set => rev_brut = value; }
        public double Rev_societe { get => rev_societe; set => rev_societe = value; }
        public int Place_arret { get => place_arret; set => place_arret = value; }
        public string Ville_arret { get => ville_arret; set => ville_arret = value; }
        public string Ville_arrivee { get => ville_arrivee; set => ville_arrivee = value; }
        public int Id_chauffeur { get => id_chauffeur; set => id_chauffeur = value; }
        public double Rev_chauffeur { get => rev_chauffeur; set => rev_chauffeur = value; }
        public string Personne { get => personne; set => personne = value; }
        public string Etat { get => etat; set => etat = value; }

        public string ExportCSV()
        {
            return $"{id};{Chauffeur};{Voiture};{Date_depart};{Place_depart};{Ville_depart};{Place_arret};{Ville_arret};{Nb_personne};{Rev_chauffeur};{Rev_societe}";
        }
    }
    }


