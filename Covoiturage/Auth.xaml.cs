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
using System.Numerics;
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
    public sealed partial class Auth : Page
    {
        public Auth()
        {
            this.InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            valide += GestionBD.getInstance().verificationText(email, erremail);
            valide += GestionBD.getInstance().verificationMdp(mdp, errmdp);

            if (valide == 0)
            {
                if(GestionBD.getInstance().getUsager(email.Text, mdp.Password))
                    switch (GestionBD.U.TypeUsager)
                    {
                        case "chauffeur": this.Frame.Navigate(typeof(Historique)); break;
                        case "admin": this.Frame.Navigate(typeof(Info_trajet)); break;
                        case "passager": this.Frame.Navigate(typeof(Afficher_trajets)); ; break;
                    }
                
            }

        }
    }
}
