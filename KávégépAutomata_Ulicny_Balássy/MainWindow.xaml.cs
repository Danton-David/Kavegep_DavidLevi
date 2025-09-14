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
        private double fizetendo = 0; //Ez az aktuális ár amit ki kell fizetni

        public bool elegalapanyag = false; //Ez csak egy place holder an alapanyag check nek

        public MainWindow()
        {
            InitializeComponent();
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
        //Innentől jönnek az italok
        private void Espresso_Click(object sender, RoutedEventArgs e) //Ez egy teszt volt
        {
            
            elegalapanyag = true; // Itt lehetne megnézni hogy az adtott dologhoz van e elég alapanyag ha igen akkor true ha nem akkor false! DE megcsinálhatjuk másképp is ha úgy akkarjuk hogy még az elején megnézze
            if (elegalapanyag)
            {
                Espresso.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else 
            { 
                Espresso.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Americano_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Americano.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Americano.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Cappuccino_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Cappuccino.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Cappuccino.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Latte_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Latte.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Latte.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Macchiato_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Macchiato.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Macchiato.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                White.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                White.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Mocha_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Mocha.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Mocha.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Cortado_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Cortado.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Cortado.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Ristretto_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Ristretto.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Ristretto.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Affogato_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                Affogato.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                Affogato.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void IcedCoffee_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                IcedCoffee.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                IcedCoffee.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void IcedLatte_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                IcedLatte.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                IcedLatte.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void HotCocoa_Click(object sender, RoutedEventArgs e)
        {
            if (elegalapanyag)
            {
                HotCocoa.Background = new SolidColorBrush(Colors.White);
                fizetendo += 100; // valami ami az ára lessz
                FrissitFizetendo();
            }
            else
            {
                HotCocoa.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}