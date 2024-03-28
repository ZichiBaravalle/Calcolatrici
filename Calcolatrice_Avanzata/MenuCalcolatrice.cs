using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcolatrice_Avanzata
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnCalcolatrice_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Standard":
                    FormCalcStandard standard = new FormCalcStandard();
                    standard.Show();
                    this.Hide();
                    break;

                case "Scientifica":
                    FormCalcScientifica scientifica = new FormCalcScientifica();
                    scientifica.Show();
                    this.Hide();
                    break;
                
                case "SimilGeogebra":
                    SimilGeogebra geogebra = new SimilGeogebra();
                    geogebra.Show();
                    this.Hide();
                    break;

                default:
                    break;
            }
        }
    }
}