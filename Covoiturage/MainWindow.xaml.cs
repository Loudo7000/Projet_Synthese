using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Covoiturage
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
            GestionBD.getInstance().Nav = nav;
            GestionBD.getInstance().NavC = chauffeur;
            GestionBD.getInstance().NavA = admin;
            GestionBD.getInstance().NavCon = iConnexion;
            GestionBD.getInstance().NavDec = iDeconnexion;
            GestionBD.getInstance().Compte = compte;
            mainFrame.Navigate(typeof(Afficher_trajets));
            
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            if (item.Name.ToString() == "")
            {
                tblentete.Text = item.Content.ToString();
                switch (item.Tag.ToString())
                {
                    case "trajet":
                        mainFrame.Navigate(typeof(Afficher_trajets));
                        break;
                    case "Trajetch":
                        mainFrame.Navigate(typeof(Ajout_trajet));
                        break;
                    case "Histo":
                        mainFrame.Navigate(typeof(Historique));
                        break;
                    case "ville":
                        mainFrame.Navigate(typeof(Ajout_ville));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if(item.Tag.ToString()!="default")
                tblentete.Text = item.Tag.ToString();
                switch (item.Name.ToString()) {
                    case "TrajetInf":
                        mainFrame.Navigate(typeof(Info_trajet));
                        break;
                    case "revenue":
                        mainFrame.Navigate(typeof(Revenue));
                        break;
                    case "compte":
                        mainFrame.Navigate(typeof(Ajout_compte));
                        break;
                    default:
                        break;
                }
            }
           
        }

        private void iDeconnexion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GestionBD.getInstance().decon();
            mainFrame.Navigate(typeof(Afficher_trajets));
        }

        private void iConnexion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tblentete.Text = "Connexion";
            mainFrame.Navigate(typeof(Auth));
        }
    }
}
