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

        NavigationView nav;
        NavigationViewItem navC;
        NavigationViewItem navA;
        NavigationViewItem navCon;
        NavigationViewItem navDec;
        NavigationViewItem compte;

        internal static Usager U { get => u; set => u = value; }
        public NavigationView Nav { get => nav; set => nav = value; }
        public NavigationViewItem NavC { get => navC; set => navC = value; }
        public NavigationViewItem NavA { get => navA; set => navA = value; }
        public NavigationViewItem NavCon { get => navCon; set => navCon = value; }
        public NavigationViewItem NavDec { get => navDec; set => navDec = value; }
        public NavigationViewItem Compte { get => compte; set => compte = value; }

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
            catch (MySqlException)
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
            catch (MySqlException)
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
            catch (MySqlException)
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
            catch (MySqlException)
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
            catch (MySqlException)
            {
                con.Close();
            }
            return liste_ville;
        }

        public ObservableCollection<Trajets> GetRevenu(DateTime date)
        {
            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_affiche_revenue");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@date", date);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_trajet.Add(new Trajets()
                    {
                        Id = r.GetInt32(0),
                        Rev_brut = r.GetInt32(1),
                        Rev_chauffeur = r.GetInt32(2),
                        Rev_societe = r.GetInt32(3),
                    });

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return liste_trajet;
        }

        public ObservableCollection<Trajets> GetPersonne(int id)
        {
            liste_trajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("p_affiche_personne");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@trajet", id);

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste_trajet.Add(new Trajets()
                    {
                        Personne = r.GetString(1),
                    });

                }
                r.Close();
                con.Close();
            }
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            return liste_trajet;
        }
        public Boolean getUsager(string email, string mdp)
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
                nav.PaneTitle = u.Prenom + " " +u.Nom;
                switch (u.TypeUsager)
                {
                    case "chauffeur": navC.Visibility=Visibility.Visible ; break;
                    case "admin": navA.Visibility=Visibility.Visible ; break;
                }
                navCon.Visibility = Visibility.Collapsed;
                navDec.Visibility = Visibility.Visible;
                compte.Visibility = Visibility.Collapsed;
                r.Close();
                con.Close();
                return true;
            }
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return false;
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
            catch (MySqlException)
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
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

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
                    default:
                        throw;
                }
            }
            return "";
        }

        public void AjoutTrajet(String type, String depart, String arrivee, String arret, DateTime date)
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
                commande.Parameters.AddWithValue("@usager", u.Id);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public String AjoutInscrit(int id_t, string ville_d, string ville_a)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_inscription");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@trajet", id_t);
                commande.Parameters.AddWithValue("@depart", ville_d);
                commande.Parameters.AddWithValue("@arrive", ville_a);

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
                        return "Vous êtes déja inscrit à ce trajet";
                    default:
                        throw;
                }
            }
            return "";
        }

        public void AjoutUsager(Usager u)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajout_user");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@pnom", u.Nom);
                commande.Parameters.AddWithValue("@pprenom", u.Prenom);
                commande.Parameters.AddWithValue("@padresse", u.Adresse);
                commande.Parameters.AddWithValue("@pnum_tel", u.NumTel);
                commande.Parameters.AddWithValue("@pemail", u.Email);
                commande.Parameters.AddWithValue("@pmdp", u.Mdp);
                commande.Parameters.AddWithValue("@ptype", u.TypeUsager);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void decon()
        {
            nav.PaneTitle = "Invité";
            switch (u.TypeUsager)
            {
                case "chauffeur": navC.Visibility = Visibility.Collapsed; break;
                case "admin": navA.Visibility = Visibility.Collapsed; break;
            }
            navCon.Visibility = Visibility.Visible;
            navDec.Visibility = Visibility.Collapsed;
            compte.Visibility = Visibility.Visible;
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
        public int verificationMdp(PasswordBox box, TextBlock erreur)
        {
            if (box.Password.Length <= 0)
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

        public int verificationMdp(PasswordBox box, PasswordBox Confbox, TextBlock erreur, TextBlock Conferr)
        {
            if (box.Password.Length <= 0)
            {
                erreur.Text = "Ce champ est obligatoire";
                erreur.Visibility = Visibility.Visible;
                return 1;
            }
            else if(box.Password != Confbox.Password)
            {
                Conferr.Text = "Le mot de passe n'est pas identique";
                Conferr.Visibility = Visibility.Visible;
                return 0;
            }
            else
            {
                erreur.Visibility = Visibility.Collapsed;
                Conferr.Visibility = Visibility.Collapsed;
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
                erreur.Text = "Sélectionner une date";
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
