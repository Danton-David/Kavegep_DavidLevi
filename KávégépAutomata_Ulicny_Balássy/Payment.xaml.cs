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
using System.Windows.Shapes;

namespace KávégépAutomata_Ulicny_Balássy
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// Gyakorlatilag csak díszzítés, hogy a felhasználó lássa a végösszeget
    /// </summary>
    public partial class Payment : Window
    {
        public Payment(double fizetendo)
        {
            
            InitializeComponent();
            vegosszeg.Text = fizetendo.ToString() + "Ft"; //A fizetendő összeg megjelenítése a fizetés ablakban
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; //A bezárás gomb megnyomására az ablak bezárul
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; //A bezárás gomb megnyomására az ablak bezárul
        }

        private void vegosszeg_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
