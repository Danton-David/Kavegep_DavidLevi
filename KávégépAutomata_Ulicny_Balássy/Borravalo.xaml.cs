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
    /// Interaction logic for Borravalo.xaml
    /// </summary>
    public partial class Borravalo : Window
    {
        public double Ertek { get; private set; }

        public Borravalo()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int _egyedi = int.Parse(egyedi.Text);
                this.Ertek = _egyedi;
                this.DialogResult = true;
            }
            catch { egyedi.Text = "Számot kell megadni!!!!"; }
        }

        private void husz_Click(object sender, RoutedEventArgs e)
        {
            this.Ertek = 20;
            
        }

        private void harminc_Click(object sender, RoutedEventArgs e)
        {
            this.Ertek = 35;
            this.DialogResult = true;
        }

        private void ötven_Click(object sender, RoutedEventArgs e)
        {
            this.Ertek = 50;
            this.DialogResult = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
