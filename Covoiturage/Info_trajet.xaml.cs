// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
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
    public sealed partial class Info_trajet : Page
    {
        public Info_trajet()
        {
            this.InitializeComponent();
            infoListe.ItemsSource = GestionBD.getInstance().GetListeTrajet();
        }

        private void btnDat_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            valide += GestionBD.getInstance().verificationDate(datDeb, errDatDeb);
            valide += GestionBD.getInstance().verificationDate(datFin, errDatFin);

            if(valide == 0)
            infoListe.ItemsSource = GestionBD.getInstance().GetListeDateinfo(datDeb.Date.Date, datFin.Date.Date);
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            /******************** POUR WINUI3 ***************************/
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(GestionBD.getInstance().Main);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            /************************************************************/

            picker.SuggestedFileName = "ExportInfo";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            //cr?e le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();


            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, GestionBD.getInstance().toList().ConvertAll(x => x.ExportCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
            errExp.Visibility = Visibility.Collapsed;

            }
            catch (Exception)
            {
                errExp.Text = "Probl?me d'exportaion";
                errExp.Visibility = Visibility.Visible;
            }

        }
    }
}
