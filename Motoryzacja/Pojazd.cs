using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Motoryzacja
{
    struct RejestrNazw
    {
        DateTime DataModyfikacji;
        string Nazwa;

        public RejestrNazw(DateTime data, string nazwa)
        {
            this.DataModyfikacji = data;
            this.Nazwa = nazwa;
        }

        public override string ToString()
        {
            return "data modyfikacji: " + DataModyfikacji + ", nazwa: " + Nazwa; 
        }
    }
    public class Pojazd : IComparable<Pojazd>
    {
        public string Nazwa 
        {
            get { return this.nazwa; }
            set
            {
                this.nazwa = value;
                RejestrNazw staraData = new RejestrNazw(DateTime.Now, value);
                HistoriaNazw.Add(staraData);
            }
        }
        private string nazwa;
        private int liczbaKol;
        private double predkosc;
        private static int liczbaPojazdow;
        public int lp;
        private List<RejestrNazw> HistoriaNazw = new List<RejestrNazw>();
        public int CompareTo(Pojazd other)
        {
            if (other == null)
            {
                return 1;
            }
            return other.predkosc.CompareTo(predkosc);
        }
        public int Lp 
        {
            get { return this.lp; }
            set { this.lp = value; } 
        }
        public int LiczbaKol
        {
            get { return this.liczbaKol; }
            set
            {
                if (value < 2 || value > 8)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.liczbaKol = value;
                }
            }
        }

        public double Predkosc
        {
            get { return this.predkosc; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.predkosc = value;
                }
            }
        }
        public Pojazd()
        {
            liczbaPojazdow++;
            this.Lp = liczbaPojazdow;
            
        }

        static Pojazd()
        {
            liczbaPojazdow = 0;
        }

        public Pojazd(int liczbaKol, double predkosc, string nazwa): this()
        {
            this.LiczbaKol = liczbaKol; this.Predkosc = predkosc; this.Nazwa = nazwa;
            
        }
        public Pojazd(double predkosc, string nazwa): this(4, predkosc, nazwa)
        { 
            this.Predkosc = predkosc; 
            this.Nazwa = nazwa; 
        }

        public void WyswietlHistorię(ref ListBox listaHistorii)
        {
            foreach (var item in HistoriaNazw)
            {
                listaHistorii.Items.Add(item);
            }
        }

        public override string ToString()
        {
            return "Nazwa: " + this.Nazwa + ", Prędkość: " + this.predkosc + "Km/h, Liczba kół: " + this.liczbaKol + ", Lp: " + this.lp + "/" + Pojazd.liczbaPojazdow;
        }

        public (T, T) Zamien<T>(T pierwszy, T drugi)
        {
            T pomocnicza = pierwszy;

            pierwszy = drugi;

            drugi = pomocnicza;
            
            return (pierwszy, drugi);
        }
    }

    public class PojazdMechaniczny:Pojazd
    {
        private int mocSilnika;

        public int MocSilnika
        {
            get { return this.mocSilnika; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.mocSilnika = value;
                }
            }
        }

        public PojazdMechaniczny(int liczbaKol, double predkosc, string nazwa, int mocsilnika):base(liczbaKol, predkosc, nazwa)
        {
            this.MocSilnika = mocsilnika;
        }

        public override string ToString()
        {
            return base.ToString() + ", Moc silnika: " + this.mocSilnika + "KM";
        }
    }

    public class Samochod:Pojazd
    {
        private int liczbaPasazerow;

        public string Marka { get; set; }
        public int LiczbaPasazerow
        {
            get { return this.liczbaPasazerow; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.liczbaPasazerow = value;
                }
            }
        }

        public Samochod(int liczbaKol, double predkosc, string nazwa, int liczbapasazerow, string marka):base(liczbaKol, predkosc, nazwa)
        {
            this.LiczbaPasazerow = liczbapasazerow;
            this.Marka = marka;
        }

        public override string ToString()
        {
            return base.ToString() + ", Pasażerowie: " + this.liczbaPasazerow + ", Marka: " + this.Marka;
        }
    }
}
