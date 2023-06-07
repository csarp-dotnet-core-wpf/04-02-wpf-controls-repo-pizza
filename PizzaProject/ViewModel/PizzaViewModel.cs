using PizzaProject.Model;
using PizzaProject.Repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BaseClass;

namespace PizzaProject.ViewModel
{
    public class PizzaViewModel : ViewModelBase
    {
        private PizzaRepo _repo;

        public PizzaViewModel()
        {
            _pizza= new Pizza();
            _repo= new PizzaRepo();

            RendelesCommand = new RelayCommand(execute => RendelesLeadas());
            TorlesCommand = new RelayCommand(execute => RendelesTorles());
            ModositasCommand = new RelayCommand(execute => RendelesModositas());
        }

        public ObservableCollection<Pizza> Pizzak
        {
            get
            {
                return new ObservableCollection<Pizza>(_repo.Pizzak);
            }
        }

        private void RendelesLeadas()
        {
            _pizza.Id = _repo.KovetkezoId;
            _repo.Hozzad(_pizza);
            OnPropertyChanged(nameof(Pizzak));
            _pizza=new Pizza();
        }

        private void RendelesTorles()
        {
            _repo.Torol(_pizza);
            OnPropertyChanged(nameof(Pizzak));
        }

        private void RendelesModositas()
        {
            _repo.Modosit(_pizza);
            OnPropertyChanged(nameof(Pizzak));
        }


        public RelayCommand RendelesCommand { get; set; }
        public RelayCommand TorlesCommand { get; set; }
        public RelayCommand ModositasCommand { get; set; }

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

        public string Ar
        {
            get { return $"{_pizza.Ar} Ft."; }
        }

        private Pizza _pizza;
        public Pizza Pizza
        {
            get { return _pizza; }
            set 
            { 
                _pizza = value; 
                OnPropertyChanged(nameof(KicsiPizza));
                OnPropertyChanged(nameof(KozepesPizza));
                OnPropertyChanged(nameof(NagyPizza));
                OnPropertyChanged(nameof(Db));
                OnPropertyChanged(nameof(Ontet));
                OnPropertyChanged(nameof(Sajt));
                OnPropertyChanged(nameof(Kolbasz));
                OnPropertyChanged(nameof(Sonka));
                OnPropertyChanged(nameof(KivalasztottFogysztasiHely));
            } 
        }

        public Pizza KivalasztottPizza
        {
            get { return _pizza; }
            set
            {
                Pizza = value;
                OnPropertyChanged(nameof(Pizza));
            }
        }
    }
}
