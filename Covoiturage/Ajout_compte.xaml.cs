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
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Text.RegularExpressions;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Covoiturage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ajout_compte : Page
    {
        public Ajout_compte()
        {
            this.InitializeComponent();
        }

        private void BtnAddCompte_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            valide += GestionBD.getInstance().verificationText(prenom, errPrenom);
            valide += GestionBD.getInstance().verificationText(nom, errNom);
            valide += GestionBD.getInstance().verificationText(adresse, errAdresse);
            valide += GestionBD.getInstance().verificationText(numTel, errNumTel);
            valide += NumRegexp(numTel, errNumTel);
            valide += GestionBD.getInstance().verificationText(email, errEmail);
            valide += GestionBD.getInstance().verificationMdp(mdp, mdpConf, errMdp, errMdpConf);
            valide += GestionBD.getInstance().verificationBox(typeUsager, errTypeUsager);

            if (valide == 0)
            {
                GestionBD.getInstance().AjoutUsager(new Usager()
                {
                    Nom = prenom.Text,
                    Prenom = nom.Text,
                    Adresse = adresse.Text,
                    NumTel = numTel.Text,
                    Email = email.Text,
                    Mdp = mdp.Password,
                    TypeUsager = typeUsager.SelectedItem.ToString(),
                }
                );
            }

        }

        private int NumRegexp(TextBox num, TextBlock err)
        {
            string expression = "^\\([0-9]{3}\\)[0-9]{3}-[0-9]{4}$";

            if (Regex.IsMatch(num.Text, expression))
            {
                err.Text = "Correspond";
                err.Foreground = new SolidColorBrush(Colors.Green);
                err.Visibility = Visibility.Collapsed;
                return 0;
            }
            else
            {
                err.Text = "Ne correspond pas";
                err.Foreground = new SolidColorBrush(Colors.Red);
                err.Visibility = Visibility.Visible;
                return 1;
            }

        }
    }
}
