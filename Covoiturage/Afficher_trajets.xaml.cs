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
        }

        private void inscrit_Click(object sender, RoutedEventArgs e)
        {
            Trajets t = trajetListe.SelectedItem as Trajets;
            if (trajetListe.SelectedItem != null) {
                switch (choix.SelectedIndex) {
                    case 0:
                    GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arrivee);
                    break;
                    case 1:
                    GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_depart, t.Ville_arret);
                    break;
                    case 2:
                    GestionBD.getInstance().AjoutInscrit(t.Id, t.Ville_arret, t.Ville_arrivee);
                    break;
                }
            }
        }
    }
}
