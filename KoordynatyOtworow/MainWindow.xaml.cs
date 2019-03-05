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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCzytajKoordynaty_Click(object sender, RoutedEventArgs e)
        {
            CzytajKoordynaty odczyt = new CzytajKoordynaty();
            MessageBox.Show("W MainWindow:");
            foreach (Otwor otwor in odczyt.TablicaOtworow)
            {
                try {
                    MessageBox.Show(otwor.Srednica.ToString());
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
    }
}
