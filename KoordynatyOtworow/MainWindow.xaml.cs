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
using Microsoft.Win32;

namespace KoordynatyOtworow
{
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonCzytajKoordynaty_Click(object sender, RoutedEventArgs e) {
            grid_info.Visibility = Visibility.Visible;
            string adres = PodajAdresRysunku();
            if (adres != null) {
                CzytajKoordynaty odczyt = new CzytajKoordynaty(adres);
                if (odczyt.TablicaOtworow != null) {
                    DG_Otwory.ItemsSource = odczyt.TablicaOtworow;
                }
            }
            grid_info.Visibility = Visibility.Hidden;
        }

        private string PodajAdresRysunku() {
            OpenFileDialog oknoDialogowe = new OpenFileDialog {
                Title = "Wskaż rysunek:",
                Filter = "Pliki DWG (*.dwg)|*.dwg",
                InitialDirectory = "\\\\Pmssdlc16\\z1\\1ST\\"
            };
            if (oknoDialogowe.ShowDialog() == true) {
                return oknoDialogowe.FileName;
            }
            else return null;
        }

    }
}
