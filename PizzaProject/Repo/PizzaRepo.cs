using PizzaProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace PizzaProject.Repo
{
    public class PizzaRepo
    {
        private List<Pizza> _pizzak;
        public List<Pizza> Pizzak {
            get { return _pizzak; }
            set { _pizzak = value; }
        }

        public PizzaRepo()
        {
            _pizzak= new List<Pizza>();
        }

        // CRUD

        public void Hozzad(Pizza pizza)
        {
            _pizzak.Add(pizza);
        }

        public void Torol(Pizza pizza)
        {
            _pizzak.Remove(pizza);
        }

        public void Modosit(Pizza pizza)
        {
            Pizza? modositando = _pizzak.Where(p => p.Id==pizza.Id).FirstOrDefault();
            if (modositando !=null)
            {
                modositando=pizza.Clone() as Pizza;
            }
        }

        public int KovetkezoId
        {
            get
            {
                if (_pizzak.Count > 0)
                    return _pizzak.Select(p => p.Id).Max() + 1;
                else
                    return 1;
            }
        }
    }
}
