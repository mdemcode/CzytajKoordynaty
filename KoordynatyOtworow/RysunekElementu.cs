using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace KoordynatyOtworow {

    class RysunekElementu {

        #region POLA KLASY
        public string PlikRysunku { get; }
        #endregion

        #region KONSTRUKTOR
        public RysunekElementu() {
            OpenFileDialog oknoDialogowe = new OpenFileDialog {                                     
                Filter = "Pliki DWG (*.dwg)|*.dwg",                                                     
                InitialDirectory = "\\\\Pmssdlc16\\z1\\1ST\\"
            };                                                                                          
            if (oknoDialogowe.ShowDialog() == true) {
                this.PlikRysunku = oknoDialogowe.FileName;
            }
        }
        #endregion
    }
}
