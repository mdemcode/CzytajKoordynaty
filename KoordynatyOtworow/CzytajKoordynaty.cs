using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using AutoCAD;

namespace KoordynatyOtworow { 

    class CzytajKoordynaty {

        #region POLA KLASY
        private AcadApplication acadApp;
        private AcadDocument rysunek_ACAD;
        public List<Otwor> TablicaOtworow;
        #endregion

        #region KONSTRUKTOR
        public CzytajKoordynaty() {
            if (Przechwyc_AutoCAD()) {
                if (Otworz_Rysunek()) {
                    Petla_Glowna();
                }
            }
        }
        #endregion

        #region METODY
        private bool Przechwyc_AutoCAD() {
            try {
                acadApp = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
                return true;
            }
            catch {
                try {
                    // Create a new instance of AutoCAD -> NIE ZAWSZE DZIAŁA PRAWIDŁOWO!!!
                    acadApp = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID("AutoCAD.Application"), true);
                    acadApp.Visible = true;
                    MessageBox.Show("Otworzyłem AutoCad`a"); // <- wstrzymuje działanie programu do czasu pełnego otworzenia AutoCADa
                    return true;
                }
                catch (Exception e) {
                    MessageBox.Show("Mam problem z AutoCADem!\n" + e.Message);
                    return false;
                }
            }
        }

        private bool Otworz_Rysunek() {
            try {
            AcadDocuments listaRys = acadApp.Documents;
            rysunek_ACAD = listaRys.Open(PodajAdresRysunku());
                return true;
            }
            catch {
                MessageBox.Show("Nie udało się otworzyć rysunku! \n Spróbuj jeszcze raz.");
                return false;
            }
        }

        private string PodajAdresRysunku() {
            OpenFileDialog oknoDialogowe = new OpenFileDialog {
                Filter = "Pliki DWG (*.dwg)|*.dwg",
                InitialDirectory = "\\\\Pmssdlc16\\z1\\1ST\\"
            };
            if (oknoDialogowe.ShowDialog() == true) {
                return oknoDialogowe.FileName;
            }
            else return null;
        }
        public void Petla_Glowna() {                          
            try {
                TablicaOtworow = new List<Otwor>();
                AcadSelectionSet zestaw_el = rysunek_ACAD.SelectionSets.Add("zestaw_el");
                zestaw_el.Select(AcSelect.acSelectionSetAll);
                foreach (AcadEntity el in zestaw_el) {
                    if (el.Layer=="frezarka") {
                        AcadCircle element = (AcadCircle)el;
                        Otwor otw = new Otwor(
                            element.Diameter,
                            element.Center[0],
                            element.Center[1],
                            element.Center[2]
                            );
                        TablicaOtworow.Add(otw);
                    }
                }
                rysunek_ACAD.Close(false);
                foreach (Otwor otw in TablicaOtworow)
                {
                    MessageBox.Show(
                          "Średnica: " + otw.Srednica.ToString()+" \n"
                        + "Poz.X: " + otw.PozX.ToString()+ " \n" 
                        + "Poz.Y: " + otw.PozY.ToString()+ " \n"
                        + "Poz.Z: " + otw.PozZ.ToString()
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
