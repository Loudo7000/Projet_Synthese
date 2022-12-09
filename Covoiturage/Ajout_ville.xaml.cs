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
    public sealed partial class Ajout_ville : Page
    {
        public Ajout_ville()
        {
            this.InitializeComponent();
            villeListe.ItemsSource = GestionBD.getInstance().GetVille();
        }

        private void ajoutVille_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            valide += GestionBD.getInstance().verificationText(ville, erreurAjout);

            if (Regex.IsMatch(ville.Text, @"\d"))
            {
                valide++;
                erreurAjout.Text = "Chiffres interdit dans ce champ";
                erreurAjout.Visibility = Visibility.Visible;
            }

            if (valide == 0)
            {
                if(GestionBD.getInstance().AjoutVille(ville.Text) != "")
                {
                    erreurAjout.Text = GestionBD.getInstance().AjoutVille(ville.Text);
                    erreurAjout.Visibility = Visibility.Visible;
                }
                else
                this.Frame.Navigate(typeof(Ajout_ville));
            }
        }
    }
}
