using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewModels
{
    internal class ConvertisseurEuroViewModel : ObservableObject
    {
        private ObservableCollection<Devise> listedevises;

        //public event PropertyChangedEventHandler PropertyChanged;
        //public ConvertisseurEuroPage()
        //{
        //    this.InitializeComponent();
        //    this.DataContext = this;
        //    GetDataLoadAsync();
        //}

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

        public ConvertisseurEuroViewModel()
        {
            GetDataLoadAsync();
            //Boutons
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public double MontantPostDevise
        {
            get { return montantPostDevise; }
            set { montantPostDevise = value; OnPropertyChanged(); }
        }

        public IRelayCommand BtnSetConversion { get; }
        private async void GetDataLoadAsync()
        {
            WSService service = new WSService("http://localhost:12278/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            ListeDevises = new ObservableCollection<Devise>(result);
        }
        private void ActionSetConversion()
        {
            //Code du calcul à écrire
            MontantPostDevise = MontantInitial * SelectedDevise.Taux;
        }
    }
}
