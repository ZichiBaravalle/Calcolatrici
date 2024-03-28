using System;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace Calcolatrice_Avanzata
{
    public partial class SimilGeogebra : Form
    {
        public SimilGeogebra()
        {
            InitializeComponent();
        }

        private void SimilGeogebra_Load(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Parent = this;
            chart.Dock = DockStyle.Fill;

            chart.ChartAreas.Add(new ChartArea());

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            for (int x = -10; x <= 10; x++)
            {
                double y = x * x; // Esempio di equazione, qui puoi inserire la tua equazione
                series.Points.AddXY(x, y);
            }

            chart.Series.Add(series);
        }
    }
}