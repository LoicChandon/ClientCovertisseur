using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Runtime.CompilerServices;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Devise> listedevises;

        public event PropertyChangedEventHandler PropertyChanged;
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataLoadAsync();
        }

        public ObservableCollection<Devise> ListeDevises
        { 
            get { return listedevises; }
            set
            {
                listedevises = value;
                OnPropertyChanged();
            }
        }
        private Devise selectedDevise;

        public Devise SelectedDevise
        {
            get { return selectedDevise; }
            set { selectedDevise = value; OnPropertyChanged(); }
        }

        private double montantInitial;

        public double MontantInitial
        {
            get { return montantInitial; }
            set { montantInitial = value; OnPropertyChanged(); }
        }

        private double montantPostDevise;

        public double MontantPostDevise
        {
            get { return montantPostDevise; }
            set { montantPostDevise = value; OnPropertyChanged(); }
        }


        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        private async void GetDataLoadAsync()
        {
            WSService service = new WSService("http://localhost:12278/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                throw new Exception("null");
                //MessageAsync("API non disponible !", "Erreur");
            }
            else
                ListeDevises = new ObservableCollection<Devise>(result);
        }

        private void BtConvert_Click(object sender, RoutedEventArgs e)
        {
            //if (SelectedDevise == null)
            //{
            //    MontantPostDevise = 0.000001;
            //    return;
            //}
            MontantPostDevise = MontantInitial * SelectedDevise.Taux;
        }
    }
}
