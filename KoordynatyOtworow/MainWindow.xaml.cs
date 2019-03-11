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
using System.IO;

namespace KoordynatyOtworow
{
    public partial class MainWindow : Window {

        private string AdresRysunku;
        private CzytajKoordynaty odczyt;

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonCzytajKoordynaty_Click(object sender, RoutedEventArgs e) {
            grid_info.Visibility = Visibility.Visible;
            PodajAdresRysunku();
            if (AdresRysunku != null) {
                odczyt = new CzytajKoordynaty(AdresRysunku);
                if (odczyt.TablicaOtworow != null) {
                    DG_Otwory.ItemsSource = odczyt.TablicaOtworow;
                }
            }
            grid_info.Visibility = Visibility.Hidden;
        }

        private void PodajAdresRysunku() {
            OpenFileDialog oknoDialogowe = new OpenFileDialog {
                Title = "Wskaż rysunek:",
                Filter = "Pliki DWG (*.dwg)|*.dwg",
                InitialDirectory = "\\\\Pmssdlc16\\z1\\1ST\\"
            };
            if (oknoDialogowe.ShowDialog() == true) {
                TBplikRys.Text = "Plik rys.: " + oknoDialogowe.FileName;
                AdresRysunku = oknoDialogowe.FileName;
            }
        }

        private void ButtonZapiszDoPliku_Click(object sender, RoutedEventArgs e) {
            string plik = AdresRysunku.Substring(AdresRysunku.LastIndexOf('\\') + 1, AdresRysunku.Length - AdresRysunku.LastIndexOf('\\')-1);
            string plik1= "C:\\Users\\demianczukm\\Desktop\\PROTON\\" + plik + ".h";
            if (!File.Exists(plik1)) {
                StreamWriter sw = File.CreateText(plik1);
                foreach (Otwor otw in odczyt.TablicaOtworow)
                {
                    sw.WriteLine("Otw. " + otw.Nr + ":   Średnica: " + otw.Srednica + "   X: " + otw.PozX + "   Y: " + otw.PozY + "   Z: " + otw.PozZ);
                }
                sw.Close();
                MessageBox.Show("Zapisałem do pliku.");
            }
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
