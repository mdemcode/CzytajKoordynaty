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
using System.Collections.ObjectModel;
using AutoCAD;

namespace KoordynatyOtworow
{
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonCzytajKoordynaty_Click(object sender, RoutedEventArgs e) {
            CzytajKoordynaty odczyt = new CzytajKoordynaty();
            if (odczyt.TablicaOtworow!=null) {
                //foreach (Otwor ot in odczyt.TablicaOtworow) MessageBox.Show(ot.Srednica.ToString());
                DG_Otwory.ItemsSource = odczyt.TablicaOtworow;
            }
        }
    }
}
