using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtensionMethods;
using Motoryzacja;

namespace Zadanie_A
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void WyswietlPojazdy(IEnumerable<Pojazd> Pojazdy)
        {
            lstPojazdy.Items.Clear();

            foreach (var pojazd in Pojazdy)
            {
                lstPojazdy.Items.Add(pojazd.ToString());
            }
        }
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pojazd p1 = new Pojazd(2, 87, "Motorówka");
                Pojazd p2 = new Pojazd(4, 124, "Osobówka");
                Pojazd p3 = new Pojazd(6, 67, "Autobus");
                Pojazd p4 = new Pojazd(4, 31, "Osobówka");
                Pojazd p5 = new Pojazd(6, 26, "Dostawczak");
                Pojazd p6 = new Pojazd(3, 86, "Motor");
                Pojazd p7 = new Pojazd(4, 9, "Osobówka");
                Pojazd p8 = new Pojazd(4, 44, "Osobówka");
                Samochod s1 = new Samochod(4, 99, "Ciężarówka", 6, "Dacia");
                Samochod s2 = new Samochod(4, 156, "Wyścigówka", 2, "Mercedes");
                PojazdMechaniczny pm1 = new PojazdMechaniczny(4, 72, "Quad", 15);
                //Pojazd[] tablica = new Pojazd[4] { p5, p6, p7, p8 };

                List<Pojazd> pojazdy = new List<Pojazd>();
                pojazdy.Add(p1);
                pojazdy.Add(p2);
                pojazdy.Add(p3);
                pojazdy.Add(p4);
                pojazdy.Add(p5);
                pojazdy.Add(p6);
                pojazdy.Add(p7);
                pojazdy.Add(p8);
                pojazdy.Add(s1);
                pojazdy.Add(s2);
                pojazdy.Add(pm1);
                pojazdy.Sort();
                
                WyswietlPojazdy(pojazdy);
                p1.Nazwa = "Traktor";
                p1.Nazwa = "Czołg";
               
                p1.WyswietlHistorię(ref lstHistoriaNazw);
                
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Niepoprawne dane!");
            }
        }

        private void btnExtension_Click(object sender, RoutedEventArgs e)
        {
            Pojazd p1 = new Pojazd(4, 55, "Auto");
            PojazdMechaniczny pm1 = new PojazdMechaniczny(4, 88, "Osobówka", 120);
            Samochod s1 = new Samochod(4, 190, "RS7", 2, "Audi");

            p1.Wyswietl();
            pm1.Wyswietl();
            s1.Wyswietl();
            MessageBox.Show(Convert.ToString(p1.Zamien<int>(5, 10)));
        }
    }
}

namespace ExtensionMethods
{
    public static class ExtensionMethod
    {
        public static void Wyswietl(this Pojazd p)
        {
            //if (p is Pojazd)
            //{
            //    MessageBox.Show(p.ToString() + ", rodzaj obiektu: Pojazd");
            //}
            //else if ((PojazdMechaniczny)p is PojazdMechaniczny)
            //{
            //    MessageBox.Show(p.ToString() + ", rodzaj obiektu: Pojazd mechaniczny");
            //}
            MessageBox.Show(p.ToString());
        }
    }
}


