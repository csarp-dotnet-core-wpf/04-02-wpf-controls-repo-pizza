using PizzaProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BaseClass;

namespace PizzaProject.ViewModel
{
    public class PizzaViewModel : ViewModelBase
    {
        private Pizza _pizza;

        public PizzaViewModel()
        {
            _pizza= new Pizza();
        }

        public string Ar
        {
            get { return $"{_pizza.Ar} Ft."; }
        }

        public bool KicsiPizza 
        {
            get 
            {
                if (_pizza.Meret == PizzaMeret.KIS)
                    return true;
                else
                    return false;
            }
            set
            { 
                if (value==true)
                    _pizza.Meret= PizzaMeret.KIS;
                OnPropertyChanged(nameof(Ar));
            }
        }
        public bool KozepesPizza 
        {
            get
            {
                if (_pizza.Meret == PizzaMeret.KOZEPES)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    _pizza.Meret = PizzaMeret.KOZEPES;
                OnPropertyChanged(nameof(Ar));
            }
        }
        public bool NagyPizza 
        {
            get
            {
                if (_pizza.Meret == PizzaMeret.NAGY)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    _pizza.Meret = PizzaMeret.NAGY;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public bool Ontet
        {
            get { return _pizza.Ontet; }
            set 
            { 
                _pizza.Ontet = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public bool Sonka
        {
            get { return _pizza.Sonka; }
            set
            {
                _pizza.Sonka = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public bool Kolbasz
        {
            get { return _pizza.Kolbasz; }
            set
            {
                _pizza.Kolbasz = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public bool Sajt
        {
            get { return _pizza.Sajt; }
            set
            {
                _pizza.Sajt = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public string KivalasztottFogysztasiHely
        {
            get { return _pizza.KivalasztottFogyasztasiHely; }
            set
            {
                _pizza.KivalasztottFogyasztasiHely = value;
                OnPropertyChanged(nameof(Ar));
            }
        }

        public List<string> FogyasztasiHelyek
        {
            get { return _pizza.FogyasztasHelyek; }
        }

        public int Db
        {
            get { return _pizza.Db; }
            set
            {
                _pizza.Db = value;
                OnPropertyChanged(nameof(Ar));
                OnPropertyChanged(nameof(Mennyiseg));
            }
        }

        public string Mennyiseg
        {
            get { return $"{Db} db pizza."; }
        }
    }
}
