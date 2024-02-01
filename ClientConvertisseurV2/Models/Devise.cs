using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }


        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }
        public Devise()
        {

        }

        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }
    }
}
