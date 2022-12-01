// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Covoiturage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajout_trajet : Page
    {
        public Ajout_trajet()
        {
            this.InitializeComponent();
            dateDepart.MinYear = DateTimeOffset.Now;
            GestionBD.getInstance().getVoiture(voiture);
            GestionBD.getInstance().getVilleAjout(villeDepart);
            GestionBD.getInstance().getVilleAjout(villeArret);
            GestionBD.getInstance().getVilleAjout(villeArrivee);
        }

        private void BtnAddProjet_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            valide += GestionBD.getInstance().verificationText(chauffeur, errChauffeur);
            valide += GestionBD.getInstance().verificationBox(voiture, errVoiture);
            valide += GestionBD.getInstance().verificationBox(villeDepart, errVdepart);
            valide += GestionBD.getInstance().verificationBox(villeArrivee, errVarrivee);
            valide += GestionBD.getInstance().verificationDate(dateDepart, errDdepart);

            if (Regex.IsMatch(chauffeur.Text, @"\d"))
            {
                valide++;
                errChauffeur.Text = "Chiffres interdit dans ce champ";
                errChauffeur.Visibility = Visibility.Visible;
            }

            if(villeArret.SelectedIndex != -1)
            {
                if(villeArret.SelectedIndex == villeDepart.SelectedIndex)
                {
                    valide++;
                    errVarret.Text = "La ville d'arrêt ne peut pas être la ville de départ";
                    errVarret.Visibility = Visibility.Visible;
                }
                else if(villeArret.SelectedIndex == villeArrivee.SelectedIndex)
                {
                    valide++;
                    errVarret.Text = "La ville d'arrêt ne peut pas être la ville d'arrivée";
                    errVarret.Visibility = Visibility.Visible;
                }
                else
                    errVarret.Visibility = Visibility.Collapsed;
            }

            if (valide == 0)
            {

            }
        }
    }
}
