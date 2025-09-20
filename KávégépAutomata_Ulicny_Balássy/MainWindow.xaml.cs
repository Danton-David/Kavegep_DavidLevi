using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KávégépAutomata_Ulicny_Balássy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //alapanyagok
        private int viz;
        private int tej;
        private int kavepor;
        private int cukor;
        private int kakaopor;
        private void Raktar()
        {
            string[] raktar = File.ReadAllLines("raktar.txt"); // beolvassuk a fájlt és eltároljuk egy tömbben
            
            foreach (string sor in raktar)//átmegyünk a fájl tartalmán
            {
                string[] alapanyag = sor.Split(' ');// az alapanyag neve és a mennyisége közötti space-t eltávolítjuk
                
                if (alapanyag.Length == 2) // ha tényleg csak 2 elemből áll egy sor
                {
                    int mennyiseg = int.Parse(alapanyag[1]); // mindig az első elem lesz a mennyiség (int lett belőle)
                    string nev = alapanyag[0].ToLower(); // mindig a nulladik elem lesz a név és kis karakterekre alakítjuk
                    if (nev == "víz") viz = mennyiseg;// ha nevnek vizet ad meg akkor a viz mennyiseget fogja eltárolni
                    else if (nev == "tej") tej = mennyiseg;// ugyanez csak más alapanyag
                    else if (nev == "kávépor") kavepor = mennyiseg;// ugyanez csak más alapanyag
                    else if (nev == "cukor") cukor = mennyiseg;// ugyanez csak más alapanyag
                    else if (nev == "kakaópor") kakaopor = mennyiseg;// ugyanez csak más alapanyag
                }
            }

        }
       
        private double fizetendo = 0; //Ez az aktuális ár amit ki kell fizetni
        private double beszedettpenz = 0; // Ez az amit már beszedtünk pénz a felhasználótól

        public bool elegalapanyag = false; //Ez csak egy place holder an alapanyag check nek

        public MainWindow()
        {
            InitializeComponent();
            Raktar();// raktárt meghívjuk hogy lehessen is használni
        }
        private void osszeg_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void FrissitFizetendo()// Ez frissíti a kezelőfelületen az árat
        {
            osszeg.Text = fizetendo.ToString();
        }

        private void Pay_Click(object sender, RoutedEventArgs e) 
        {
            Borravalo borravalo = new Borravalo();
            borravalo.ShowDialog();//Ez itt a felugró ablak a borravalóra
            fizetendo = ((fizetendo * (borravalo.Ertek / 100)) + fizetendo); // Ez hozzáadja a százalékot
            FrissitFizetendo();// Ez frissíti a kezelőfelületen az árat
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            fizetendo = 0;
            FrissitFizetendo();
        }
        //Itt lesznek a receptek:
        private bool EspressoRecept()
        {
            if (viz >= 30 && kavepor >= 7)
            {
                viz -= 30;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool AmericanoRecept()
        {
            if (viz >= 100 && kavepor >= 7)
            {
                viz -= 100;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool CappuccinoRecept()
        {
            if (viz >= 50 && tej >= 100 && kavepor >= 7)
            {
                viz -= 50;
                tej -= 100;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool LatteRecept()
        {
            if (viz >= 30 && tej >= 150 && kavepor >= 7)
            {
                viz -= 30;
                tej -= 150;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool MacchiatoRecept()
        {
            if (viz >= 30 && tej >= 10 && kavepor >= 7)
            {
                viz -= 30;
                tej -= 10;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool FLatWhiteRecept()
        {
            if (viz >= 30 && tej >= 60 && kavepor >= 7)
            {
                viz -= 30;
                tej -= 60;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool MochaRecept()
        {
            if (viz >= 30 && tej >= 150 && kavepor >= 7 && kakaopor >= 15)
            {
                viz -= 30;
                tej -= 150;
                kavepor -= 7;
                kakaopor -= 15;
                return true;
            }
            return false;
        }

        private bool CortadoRecept()
        {
            if (viz >= 30 && tej >= 40 && kavepor >= 7)
            {
                viz -= 30;
                tej -= 40;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool RistrettoRecept()
        {
            if (viz >= 20 && kavepor >= 7)
            {
                viz -= 20;
                kavepor -= 7;
                return true;
            }
            return false;
        }

        private bool AffogatoRecept()
        {
            if (viz >= 30 && kavepor >= 7 && tej >= 50)
            {
                viz -= 30;
                kavepor -= 7;
                tej -= 50;
                return true;
            }
            return false;
        }

        private bool IcedCoffeeREcept()
        {
            if (viz >= 100 && kavepor >= 7 && cukor >= 10)
            {
                viz -= 100;
                kavepor -= 7;
                cukor -= 10;
                return true;
            }
            return false;
        }

        private bool IcedLAtteREcept()
        {
            if (viz >= 80 && tej >= 120 && kavepor >= 7 && cukor >= 10)
            {
                viz -= 80;
                tej -= 120;
                kavepor -= 7;
                cukor -= 10;
                return true;
            }
            return false;
        }

        private bool HotCocoaRecept()
        {
            if (tej >= 200 && kakaopor >= 20 && cukor >= 10)
            {
                tej -= 200;
                kakaopor -= 20;
                cukor -= 10;
                return true;
            }
            return false;
        }
        //Innentől jönnek az italok
        private void Espresso_Click(object sender, RoutedEventArgs e) //Ez egy teszt volt
        {
            
            
            if (EspressoRecept())
            {
                Espresso.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else 
            { 
                Espresso.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Americano_Click(object sender, RoutedEventArgs e)
        {
            if (AmericanoRecept())
            {
                Americano.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Americano.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Cappuccino_Click(object sender, RoutedEventArgs e)
        {
            if (CappuccinoRecept())
            {
                Cappuccino.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Cappuccino.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Latte_Click(object sender, RoutedEventArgs e)
        {
            if (LatteRecept())
            {
                Latte.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Latte.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Macchiato_Click(object sender, RoutedEventArgs e)
        {
            if (MacchiatoRecept())
            {
                Macchiato.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Macchiato.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            if (FLatWhiteRecept())
            {
                White.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                White.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Mocha_Click(object sender, RoutedEventArgs e)
        {
            if (MochaRecept())
            {
                Mocha.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Mocha.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Cortado_Click(object sender, RoutedEventArgs e)
        {
            if (CortadoRecept())
            {
                Cortado.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Cortado.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Ristretto_Click(object sender, RoutedEventArgs e)
        {
            if (RistrettoRecept())
            {
                Ristretto.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Ristretto.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void Affogato_Click(object sender, RoutedEventArgs e)
        {
            if (AffogatoRecept())
            {
                Affogato.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                Affogato.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void IcedCoffee_Click(object sender, RoutedEventArgs e)
        {
            if (IcedCoffeeREcept())
            {
                IcedCoffee.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                IcedCoffee.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void IcedLatte_Click(object sender, RoutedEventArgs e)
        {
            if (IcedLAtteREcept())
            {
                IcedLatte.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                IcedLatte.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        private void HotCocoa_Click(object sender, RoutedEventArgs e)
        {
            if (HotCocoaRecept())
            {
                HotCocoa.Background = new SolidColorBrush(Colors.White); //láthatóbb hogy mit választott már ki a felhasználó
                fizetendo += 100; // valami ami az ára lessz
                beszedettpenz += 100; // az összes pénz amit a nap folyamán összeszedünk
                FrissitFizetendo();//Kiírja a fizetendő összeget
            }
            else
            {
                HotCocoa.Background = new SolidColorBrush(Colors.Red); //piros lesz hogy láthatóbb legyen hogy valami baj van
                osszeg.Text = "Nincs elég alapanyag"; // kiírjuk hogy nincs eleg alapanyag
            }
        }

        //nap végi mennyiségek kiírása
        private void MentesStatisztika()
        {
            //tömmbe eltároljuk
            string[] sorok =
            {
                $"Megmaradt víz: {viz} ml",
                $"Megmaradt tej: {tej} ml",
                $"Megmaradt kávépor: {kavepor} g",
                $"Megmaradt cukor: {cukor} g",
                $"Megmaradt kakaópor: {kakaopor} g",
                $"Beszedett pénz: {beszedettpenz} Ft"
            };

            File.WriteAllLines("statisztika.txt", sorok);//itt meg kiírjuk
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MentesStatisztika();// Akkor csinálja meg a fájlt, ha bezárjuk
        }
    }
}