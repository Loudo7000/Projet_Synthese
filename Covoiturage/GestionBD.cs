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
using Org.BouncyCastle.Asn1.Cms;

namespace Covoiturage
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Trajets> liste_trajet;
        ObservableCollection<Arrêt> liste_ville_arret;
        ObservableCollection<Ville> liste_ville;
        static GestionBD gestionBD = null;
        static Usager u;

        internal static Usager U { get => u; set => u = value; }

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
                        Date_depart = r.GetString(3),
                        Place_depart = r.GetInt32(4),
                        Ville_depart = r.GetString(5),
                        Place_arret = r.GetInt32(6),
                        Ville_arret = r.GetString(7),
                        Ville_arrivee = r.GetString(8),
                        Nb_personne = r.GetInt32(9),
                        Rev_brut = r.GetInt32(10),
                        Rev_societe = r.GetInt32(11),
                        Id_chauffeur = r.GetInt32(13),
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

        public ObservableCollection<Trajets> GetListehisto()
        {
            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_affiche_trajet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_trajet.Add(new Trajets()
                    {
                        Id = r.GetInt32(0),
                        Date_depart = r.GetString(3),
                        Place_depart = r.GetInt32(4),
                        Ville_depart = r.GetString(5),
                        Ville_arret = r.GetString(7),
                        Ville_arrivee = r.GetString(8),
                        Nb_personne = r.GetInt32(9),
                        Rev_brut = r.GetInt32(10),
                        Rev_societe = r.GetInt32(11),
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


        public ObservableCollection<Trajets> GetListeDateinfo(DateTime dateA, DateTime dateB)
        {
            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_affiche_date_info");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@dateA", dateA);
                commande.Parameters.AddWithValue("@dateB", dateB);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_trajet.Add(new Trajets()
                    {
                        Id = r.GetInt32(0),
                        Chauffeur = r.GetString(1),
                        Voiture = r.GetString(2),
                        Date_depart = r.GetString(3),
                        Place_depart = r.GetInt32(4),
                        Ville_depart = r.GetString(5),
                        Place_arret = r.GetInt32(6),
                        Ville_arret = r.GetString(7),
                        Ville_arrivee = r.GetString(8),
                        Nb_personne = r.GetInt32(9),
                        Rev_brut = r.GetInt32(10),
                        Rev_societe = r.GetInt32(11),
                        Id_chauffeur = r.GetInt32(13),
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

        public void AjoutTrajet(int id, String type, String depart, String arrivee, String arret, DateTime date)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajout_trajet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@date", date);
                commande.Parameters.AddWithValue("@voiture", type);
                commande.Parameters.AddWithValue("@villeDepart", depart);
                commande.Parameters.AddWithValue("@villeArret", arret);
                commande.Parameters.AddWithValue("@villeFinale", arrivee);
                commande.Parameters.AddWithValue("@usager", id);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void AjoutInscrit(int id_t, /*int id_u,*/ string ville_d, string ville_a, string ville_stop)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_inscription");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@trajet", id_t);
                //commande.Parameters.AddWithValue("@usager", id_u);
                commande.Parameters.AddWithValue("@depart", ville_d);
                commande.Parameters.AddWithValue("@arrive", ville_a);
                commande.Parameters.AddWithValue("@arret", ville_stop);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
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

        public Usager getUsager(string email, string mdp)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand("p_select_user");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@mail", email);
                commande.Parameters.AddWithValue("@pass", mdp);

                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();
                r.Read();
                u = new Usager()
                {
                    Id = r.GetInt32(0),
                    Nom = r.GetString(1),
                    Prenom = r.GetString(2),
                    Adresse = r.GetString(3),
                    NumTel = r.GetString(4),
                    Email = r.GetString(5),
                    Mdp = r.GetString(6),
                    TypeUsager = r.GetString(7),

                };
                r.Close();
                con.Close();
                return u;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return u;
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

        internal void AjoutInscrit(ObservableCollection<Trajets> liste_trajet)
        {
            throw new NotImplementedException();
        }
    }
}
