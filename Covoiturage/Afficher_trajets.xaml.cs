using ABI.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Covoiturage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Afficher_trajets : Page
    {
        public Afficher_trajets()
        {
            this.InitializeComponent();
            trajetListe.ItemsSource = GestionBD.getInstance().GetListeTrajet();
            if(GestionBD.U.TypeUsager == "passager")
            {
                stk.Visibility= Visibility.Visible;
                trajetListe.IsEnabled=true;
            }
            else
            {
                stk.Visibility= Visibility.Collapsed;
                trajetListe.IsEnabled = false;

            }
        }

        private void inscrit_Click(object sender, RoutedEventArgs e)
        {
            Trajets t = trajetListe.SelectedItem as Trajets;
            if (trajetListe.SelectedItem == null)
            {
                err.Text = "Sélectionner un trajet";
                err.Visibility = Visibility.Visible;
            }
            else
            {
                err.Visibility = Visibility.Collapsed;
                switch (choix.SelectedIndex)
                {
                    case 0:
                        if(t.Place_arret > 0 && t.Place_depart > 0)
                        {
                            if(GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arrivee) != "")
                            {
                                err.Text = GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arrivee);
                                err.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                err.Visibility = Visibility.Collapsed;
                                this.Frame.Navigate(typeof(Afficher_trajets));
                            }
                        }
                        else
                        {
                            err.Text = "trajet complet indisponible";
                            err.Visibility = Visibility.Visible;
                        }


                        break;
                    case 1:
                        if (t.Place_depart > 0 && t.Ville_arret != "Aucun arrêt")
                        {
                            if (GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arret) != "")
                            {
                                err.Text = GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arret);
                                err.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                err.Visibility = Visibility.Collapsed;
                                this.Frame.Navigate(typeof(Afficher_trajets));
                            }
                        }
                        else
                        {
                            err.Text = "Erreur inscription: Ville de départ à l'arrêt";
                            err.Visibility = Visibility.Visible;
                        }


                        break;
                    case 2:
                        if (t.Place_arret > 0 && t.Ville_arret != "Aucun arrêt")
                        {
                            if (GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_arret, t.Ville_arrivee) != "")
                            {
                                err.Text = GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_arret, t.Ville_arrivee);
                                err.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                err.Visibility = Visibility.Collapsed;
                                this.Frame.Navigate(typeof(Afficher_trajets));
                            }
                        }
                        else
                        {
                            err.Text = "Erreur inscription: Ville d'arrêt à l'arrivée";
                            err.Visibility = Visibility.Visible;
                        }
                        break;
                }
            }
        }

        //private void trajetListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        Trajets t = trajetListe.SelectedItem as Trajets;
        //        if (t.Ville_arret == "Aucun arrêt")
        //        {
        //            choix.Items.Clear();
        //            choix.Items.Add("Trajet complet");
        //            choix.SelectedIndex = choix.Items.IndexOf("Trajet complet");
        //        }
        //        else
        //        {
        //            choix.Items.Clear();
        //            choix.Items.Add("Trajet complet");
        //            choix.Items.Add("Ville de départ à l'arrêt");
        //            choix.Items.Add("Ville d'arrêt à l'arrivée");
        //            choix.SelectedIndex = choix.Items.IndexOf("Trajet complet");
        //        }
        //    }
        //    catch (System.NullReferenceException)
        //    {
        //        err.Text = "rat";

        //    }
        //}
    }
}
