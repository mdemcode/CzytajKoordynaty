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
        public List<Otwor> TablicaOtworow { get; set; }
        #endregion

        #region KONSTRUKTOR
        public CzytajKoordynaty(string adresRys) {
            if (Przechwyc_AutoCAD()) {
                if (Otworz_Rysunek(adresRys)) {
                    Wczytaj_Koordynaty();
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

        private bool Otworz_Rysunek(string adr) {
            try {
            AcadDocuments listaRys = acadApp.Documents;
            rysunek_ACAD = listaRys.Open(adr);
                return true;
            }
            catch {
                MessageBox.Show("Nie udało się otworzyć rysunku! \n Spróbuj jeszcze raz.");
                return false;
            }
        }

        public void Wczytaj_Koordynaty() {                          
            try {
                TablicaOtworow = new List<Otwor>();
                short i = 1;
                AcadSelectionSet zestaw_el = rysunek_ACAD.SelectionSets.Add("zestaw_el");
                Int16[] typ_filtra = new short[2] { 0, 8 };
                //typ_filtra[0] = 0;
                object[] dane_filtra = new object[2] { "Circle", "frezarka" };
                //dane_filtra[0]= "Circle";
                zestaw_el.Select(AcSelect.acSelectionSetAll,null,null, typ_filtra, dane_filtra);
                foreach (AcadCircle el in zestaw_el) {
                    //if (el.Layer=="frezarka") {
                        //AcadCircle element = (AcadCircle)el;
                        Otwor otw = new Otwor(
                            i,
                            el.Diameter,
                            el.Center[0],
                            el.Center[1],
                            el.Center[2]
                            );
                        TablicaOtworow.Add(otw);
                        i++;
                    //}
                }
                rysunek_ACAD.Close(false);
            }
            catch (Exception e) {
                rysunek_ACAD.Close(false);
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
