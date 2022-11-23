using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.Storage.AccessCache;

namespace Covoiturage
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Trajets> liste_trajet;
        ObservableCollection<Arrêt> liste_ville;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq16;Uid=2168091;Pwd=2168091;");
            liste_trajet = new ObservableCollection<Trajets>();
            liste_ville = new ObservableCollection<Arrêt>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<Trajets> GetListeTrajet()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                liste_trajet.Add(new Trajets()
                {
                    Chauffeur = r.GetString(""),
                    Voiture = r.GetString(""),
                    Nb_places = r.GetInt32(""),
                    Ville_depart = r.GetString(""),
                    Heure_depart = r.GetString(""),
                    Ville_arrivee = r.GetString(""),
                });
            }

            r.Close();
            con.Close();
            return liste_trajet;
        }

        public ObservableCollection<Arrêt> GetVilleArret()
        {
            MySqlCommand commande = new MySqlCommand("p_get_ville_arret");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                liste_ville.Add(new Arrêt()
                {
                    Ville_arret = r.GetString("nom_ville"),

                });
            }

            r.Close();
            con.Close();
            return liste_ville;
        }
    }
}
