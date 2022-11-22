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

namespace Covoiturage
{
    internal class GestionBD2
    {
        MySqlConnection con;
        ObservableCollection<Maison> liste;

        static GestionBD gestionBD = null;

        public GestionBD()
        {
            con = new MySqlConnection("Server=localhost;Database=prog;Uid=root;Pwd=root;");
            liste = new ObservableCollection<Maison>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
    }
}
