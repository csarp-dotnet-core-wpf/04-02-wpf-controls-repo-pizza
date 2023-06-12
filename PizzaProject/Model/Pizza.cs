using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model
{
    public enum PizzaMeret { KIS, KOZEPES, NAGY }

    public class Pizza : ICloneable
    {
        private int _id;
        public int Id { get; set; }

        private PizzaMeret _meret;
        public PizzaMeret Meret { get { return _meret; } set { _meret = value; } }

        private bool _ontet;
        public bool Ontet { get { return _ontet; } set { _ontet = value; } }

        private bool _sonka;
        public bool Sonka { get { return _sonka; } set { _sonka = value; } }

        private bool _kolbasz;
        public bool  Kolbasz { get { return _kolbasz; } set { _kolbasz = value; } }

        private bool _sajt;
        public bool Sajt { get { return _sajt; } set { _sajt = value; } }

        private int _db;
        public int Db { get { return _db; } set { _db = value; } }

        private List<string> _fogyasztasHelyek = new List<string> { "helyben", "elvitelre", "kiszállítva" };
        public List<string> FogyasztasHelyek { get { return _fogyasztasHelyek; } }

        private string _kivalasztottFogyasztasiHely=string.Empty;
        public string KivalasztottFogyasztasiHely { get { return _kivalasztottFogyasztasiHely; } set { _kivalasztottFogyasztasiHely = value; } }

        public Pizza()
        {
            _meret=PizzaMeret.KIS;
            _ontet=false;
            _sonka=false;
            _kolbasz=false;
            _sajt=false;
            _kivalasztottFogyasztasiHely = "helyben";
            _db=1;
        }

        public int Ar
        {
            get
            {
                int ar = 0;
                switch(_meret)
                {
                    case PizzaMeret.KIS:
                        ar = 300;
                        break;
                    case PizzaMeret.KOZEPES:
                        ar = 400;
                        break;
                    case PizzaMeret.NAGY:
                        ar = 500;
                        break;
                }
                if (_ontet)
                    ar = ar + 100;
                if (_kolbasz)
                    ar = ar + 200;
                if (_sonka)
                    ar = ar + 150;
                if (_sajt)
                    ar = ar + 100;

                if (_kivalasztottFogyasztasiHely == "elvitelre")
                    ar = ar + 100;
                else if (_kivalasztottFogyasztasiHely == "kiszállítva")
                    ar = ar + 300;
                return ar * _db;
            }
        }

        public object Clone()
        {
            return new Pizza
            {
                Id = this.Id,
                Sajt = this.Sajt,
                Sonka = this.Sonka,
                Kolbasz = this.Kolbasz,
                Ontet = this.Ontet,
                Meret = this.Meret,
                KivalasztottFogyasztasiHely = this.KivalasztottFogyasztasiHely,
                Db = this.Db
            };
        }

        public override string ToString()
        {
            string sajt = Sajt ? " sajt" : string.Empty;
            string sonka = Sonka? " sonka" : string.Empty;
            string kolbasz = Kolbasz ? " kolbász" : string.Empty;
            string ontet = Ontet ? " öntet" : string.Empty;
            string meret = string.Empty;
            switch (_meret)
            {
                case PizzaMeret.KIS:
                    meret = "kicsi";
                    break;
                case PizzaMeret.KOZEPES:
                    meret = "közepes";
                    break;
                case PizzaMeret.NAGY:
                    meret = "nagy";
                    break;
            }

            return $"{Id}. {meret}{sajt}{kolbasz}{sonka}{ontet} -> {Db} db és {Ar} Ft. Fogyasztási hely: {KivalasztottFogyasztasiHely}";
        }
    }
}
