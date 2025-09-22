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
    /// Ez a borravaló ablak megjelenése
    /// </summary>
    public partial class Borravalo : Window
    {
        public double Ertek { get; private set; }
        public Borravalo() //konstruktor
        {
            InitializeComponent();
        }
        
        private void confirm_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                //Egyedi borravaló értékének beállítása
                int _egyedi = int.Parse(egyedi.Text);
                this.Ertek = _egyedi;
                this.DialogResult = true;

                
            }
            catch { egyedi.Text = "Számot kell megadni!!!!"; }
        }

        private void husz_Click(object sender, RoutedEventArgs e) //20-as borravaló gomb
        {
            this.Ertek = 20;
            this.DialogResult = true;

          

        }

        private void harminc_Click(object sender, RoutedEventArgs e) //30-as borravaló gomb
        {
            this.Ertek = 35;
            this.DialogResult = true;

           

        }

        private void ötven_Click(object sender, RoutedEventArgs e) //50-es borravaló gomb
        {
            this.Ertek = 50;
            this.DialogResult = true;

           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //placeholder
        }
    }
}
