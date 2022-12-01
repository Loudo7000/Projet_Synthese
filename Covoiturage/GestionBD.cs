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
        ObservableCollection<Arrêt> liste_ville_arret;
        ObservableCollection<Ville> liste_ville;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq16;Uid=2168091;Pwd=2168091;");
            liste_trajet = new ObservableCollection<Trajets>();
            liste_ville_arret = new ObservableCollection<Arrêt>();
            liste_ville = new ObservableCollection<Ville>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<Trajets> GetListeTrajet()
        {
            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_affiche_datenow_trajet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_trajet.Add(new Trajets()
                    {
                        Id = r.GetInt32(0),
                        Chauffeur = r.GetString(1),
                        Voiture = r.GetString(2),
                        Nb_places = r.GetInt32(3),
                        Date_depart = r.GetString(4),
                        Ville_depart = r.GetString(5),
                        Date_arrivee = r.GetString(6),
                    });

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return liste_trajet;
        }

        public ObservableCollection<Arrêt> GetVilleArret()
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_get_ville_arret");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                    liste_ville_arret.Add(new Arrêt()
                {
                    Ville_arret = r.GetString(0),

                });
            }

            r.Close();
            con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return liste_ville_arret;
        }

        public ObservableCollection<Ville> GetVille()
        {
            liste_ville.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("p_selectAll_ville");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_ville.Add(new Ville()
                    {
                        Villes = r.GetString(1),

                    });
                }

                r.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return liste_ville;
        }

        public String AjoutVille(String nom)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajout_ville");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@nom", nom);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                switch (ex.Number)
                {
                    case 1062:
                        return "Cette ville est déja présente";
                        break;
                    default:
                        throw;
                }
            }
            return "";
        }

        public void getVoiture(ComboBox cmb)
        {

            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_select_type_voiture");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                //Select

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {

                    cmb.Items.Add(r.GetString(0));


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

        }

        public void getVilleAjout(ComboBox cmb)
        {

            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_selectAll_ville");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                //Select

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {

                    cmb.Items.Add(r.GetString(1));


                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

        }

        public int verificationText(TextBox box, TextBlock erreur)
        {
            if (box.Text.Length <= 0)
            {
                erreur.Text = "Ce champ est obligatoire";
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                return 0;
            }
        }

        public int verificationBox(ComboBox box, TextBlock erreur)
        {
            if (box.SelectedItem == null)
            {
                erreur.Text = "Ce champ est obligatoire";
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                return 0;
            }
        }

        public int verificationDate(DatePicker date, TextBlock erreur)
        {
            if (date.SelectedDate == null)
            {
                erreur.Text = "Ce champ est obligatoire";
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                return 0;
            }
        }
    }
}
