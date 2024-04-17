using System;
using System.Drawing;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace Calcolatrice_Avanzata
{
    public partial class SimilGeogebra : Form
    {
        private Form InterfacciaSimilGeogebra = new Form();
        private Chart chart = new Chart();
        private Series series = new Series();
        
        private Label label1 = new Label();
        private TextBox textBox1 = new TextBox();
        private Label label2 = new Label();
        private TextBox textBox2 = new TextBox();
        private Label label3 = new Label();
        private TextBox textBox3 = new TextBox();

        public SimilGeogebra()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            InterfacciaSimilGeogebra.Hide();
            Hide();
        }

        private void SimilGeogebra_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClasseBottoni classe = new ClasseBottoni();
            classe.chiudiTutto();
        }

        private void SimilGeogebra_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 200);
            InterfacciaSimilGeogebra.Show();

            InterfacciaSimilGeogebra.Size = new Size(830, 830);
            InterfacciaSimilGeogebra.Text = "InterfacciaSimilGeogebra";
            InterfacciaSimilGeogebra.AutoScaleDimensions = new SizeF(6F, 13F);
            InterfacciaSimilGeogebra.AutoScaleMode = AutoScaleMode.Font;
            InterfacciaSimilGeogebra.ClientSize = new Size(1114, 791);
            InterfacciaSimilGeogebra.Icon = Icon.ExtractAssociatedIcon("../../img/Z.ico");
            InterfacciaSimilGeogebra.Location = new Point(900, 70);
            InterfacciaSimilGeogebra.MaximizeBox = false;
            InterfacciaSimilGeogebra.MaximumSize = new Size(900, 900);
            InterfacciaSimilGeogebra.MinimizeBox = false;
            InterfacciaSimilGeogebra.MinimumSize = new Size(900, 900);
            InterfacciaSimilGeogebra.Name = "InterfacciaSimilGeogebra";
            InterfacciaSimilGeogebra.StartPosition = FormStartPosition.Manual;
            InterfacciaSimilGeogebra.Text = "InterfacciaSimilGeogebra";
            InterfacciaSimilGeogebra.FormClosed += SimilGeogebra_FormClosed;
            InterfacciaSimilGeogebra.ResumeLayout(false);
            InterfacciaSimilGeogebra_Load(sender, e);
        }
        
        private void InterfacciaSimilGeogebra_Load(object sender, EventArgs e)
        {
            chart.Parent = InterfacciaSimilGeogebra;
            chart.Dock = DockStyle.Fill;

            chart.ChartAreas.Add(new ChartArea());

            series.ChartType = SeriesChartType.Line;
            series.Points.AddXY(0, 0);
            series.Points.AddXY(2, 3);
            series.Points.AddXY(1, 4);
            series.Points.AddXY(0, 3);
            series.Points.AddXY(-1, 4);
            series.Points.AddXY(-2, 3);
            series.Points.AddXY(0, 0);
            chart.Series.Add(series);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
            switch (comboBoxFormule.SelectedIndex)
            {
                case 0:  //retta
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(128, 125);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(32, 36);
                    this.label1.TabIndex = 35;
                    this.label1.Text = "m";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(166, 122);
                    this.textBox1.Name = "txtM";
                    this.textBox1.Size = new System.Drawing.Size(100, 38);
                    this.textBox1.TabIndex = 36;
                    textBox1.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(373, 125);
                    this.label2.Size = new System.Drawing.Size(32, 36);
                    this.label2.TabIndex = 37;
                    this.label2.Text = "q";
                    label2.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(411, 122);
                    this.textBox2.Name = "txtQ";
                    this.textBox2.Size = new System.Drawing.Size(100, 38);
                    this.textBox2.TabIndex = 38;
                    textBox2.Visible = true;

                    label3.Visible = false;
                    textBox3.Visible = false;
                    break;
                
                case 1: //parabola
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(72, 78);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(30, 36);
                    this.label1.TabIndex = 51;
                    this.label1.Text = "a";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(108, 75);
                    this.textBox1.Name = "textBox1";
                    this.textBox1.Size = new System.Drawing.Size(155, 38);
                    this.textBox1.TabIndex = 52;
                    textBox1.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(406, 75);
                    this.textBox2.Name = "textBox2";
                    this.textBox2.Size = new System.Drawing.Size(155, 38);
                    this.textBox2.TabIndex = 54;
                    textBox2.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(370, 78);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(30, 36);
                    this.label2.TabIndex = 53;
                    this.label2.Text = "b";
                    label2.Visible = true;
                    
                    this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox3.Location = new System.Drawing.Point(245, 161);
                    this.textBox3.Name = "textBox3";
                    this.textBox3.Size = new System.Drawing.Size(155, 38);
                    this.textBox3.TabIndex = 56;
                    textBox3.Visible = true;
                    
                    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label3.Location = new System.Drawing.Point(209, 164);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(30, 36);
                    this.label3.TabIndex = 55;
                    label3.Text = "c";
                    label3.Visible = true;
                    break;
                
                case 2: //parabola coricata
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(72, 78);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(30, 36);
                    this.label1.TabIndex = 51;
                    this.label1.Text = "a";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(108, 75);
                    this.textBox1.Name = "textBox1";
                    this.textBox1.Size = new System.Drawing.Size(155, 38);
                    this.textBox1.TabIndex = 52;
                    textBox1.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(406, 75);
                    this.textBox2.Name = "textBox2";
                    this.textBox2.Size = new System.Drawing.Size(155, 38);
                    this.textBox2.TabIndex = 54;
                    textBox2.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(370, 78);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(30, 36);
                    this.label2.TabIndex = 53;
                    this.label2.Text = "b";
                    label2.Visible = true;
                    
                    this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox3.Location = new System.Drawing.Point(245, 161);
                    this.textBox3.Name = "textBox3";
                    this.textBox3.Size = new System.Drawing.Size(155, 38);
                    this.textBox3.TabIndex = 56;
                    textBox3.Visible = true;
                    
                    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label3.Location = new System.Drawing.Point(209, 164);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(30, 36);
                    this.label3.TabIndex = 55;
                    label3.Text = "c";
                    label3.Visible = true;
                    break;
                
                case 3: //circonferenza
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(72, 78);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(30, 36);
                    this.label1.TabIndex = 51;
                    this.label1.Text = "a";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(108, 75);
                    this.textBox1.Name = "textBox1";
                    this.textBox1.Size = new System.Drawing.Size(155, 38);
                    this.textBox1.TabIndex = 52;
                    textBox1.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(406, 75);
                    this.textBox2.Name = "textBox2";
                    this.textBox2.Size = new System.Drawing.Size(155, 38);
                    this.textBox2.TabIndex = 54;
                    textBox2.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(370, 78);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(30, 36);
                    this.label2.TabIndex = 53;
                    this.label2.Text = "b";
                    label2.Visible = true;
                    
                    this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox3.Location = new System.Drawing.Point(245, 161);
                    this.textBox3.Name = "textBox3";
                    this.textBox3.Size = new System.Drawing.Size(155, 38);
                    this.textBox3.TabIndex = 56;
                    textBox3.Visible = true;
                    
                    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label3.Location = new System.Drawing.Point(209, 164);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(30, 36);
                    this.label3.TabIndex = 55;
                    label3.Text = "c";
                    label3.Visible = true;
                    break;
            }

            if (Controls.Find("label1", true).Length == 0)
            {
                Controls.Add(label1);
                Controls.Add(label2);
                Controls.Add(textBox1);
                Controls.Add(textBox2);
            }
            
            if (Controls.Find("label3", true).Length == 0)
            {
                Controls.Add(label3);
                Controls.Add(textBox3);
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            double max, min;
            double a, b, c;
            double m, q;
            double r, Cy, Cx, Vx, Vy;
            
            if (comboBoxFormule.SelectedIndex == -1)
            {
                MessageBox.Show("Seleziona la formula da generare", "Formula");
                comboBoxFormule.Focus();
            }
            else
            {
                switch (comboBoxFormule.SelectedIndex)
                {
                    case 0: //retta
                        if (!double.TryParse(textBox1.Text, out m))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di m", "parametro m");
                            textBox1.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox2.Text, out q))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di q", "parametro q");
                            textBox2.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMax.Text, out max))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di max", "parametro max");
                            txtMax.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMin.Text, out min))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di min", "parametro min");
                            txtMin.Focus();
                            return;
                        }

                        chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
                        chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
                        
                        chart.ChartAreas[0].AxisX.Minimum = min;
                        chart.ChartAreas[0].AxisX.Maximum = max;

                        series.Points.Clear();
                        chart.Series.Clear();
                        
                        for (double x = min; x <= max; x++)
                            series.Points.AddXY(x, m * x + q);
                        
                        chart.Series.Add(series);
                        
                        if (!listBoxFormule.Items.Contains("y = " + m + (q >= 0 ? "x + " : "x ") + q))
                            listBoxFormule.Items.Add("y = " + m + (q >= 0 ? "x + " : "x ") + q);
                        break;
                    
                    case 1: //parabola
                        if (!double.TryParse(textBox1.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        if (a == 0)
                        {
                            MessageBox.Show("a non puo' essere 0", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox2.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            textBox2.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox3.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            textBox3.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMax.Text, out max))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di max", "parametro max");
                            txtMax.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMin.Text, out min))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di min", "parametro min");
                            txtMin.Focus();
                            return;
                        }
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);

                        chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
                        chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        series.Points.Clear();
                        chart.Series.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            series.Points.AddXY(x, x * x * a + b * x + c);
                        
                        chart.Series.Add(series);
                        
                        if (!listBoxFormule.Items.Contains("y = " 
                                                           + a + 
                                                           (b > 0 || c > 0 ? "x^2 + " : "x^2 ") 
                                                           +
                                                           (b != 0 ? b + (c > 0 ? "x + " : "x ") : "") +
                                                           (c != 0 ? c.ToString() : "")))
                            listBoxFormule.Items.Add("y = " 
                                                     + a + 
                                                     (b > 0 || c > 0 ? "x^2 + " : "x^2 ") 
                                                     +
                                                     (b != 0 ? b + (c > 0 ? b + "x + " : "x ") : "") +
                                                     (c != 0 ? c.ToString() : ""));
                        break;
                    
                    case 2: //parabola quadrilatera
                        if (!double.TryParse(textBox1.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        if (a == 0)
                        {
                            MessageBox.Show("a non puo' essere 0", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox2.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            textBox2.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox3.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            textBox3.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMax.Text, out max))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di max", "parametro max");
                            txtMax.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMin.Text, out min))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di min", "parametro min");
                            txtMin.Focus();
                            return;
                        }
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);

                        chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
                        chart.ChartAreas[0].AxisY.IsStartedFromZero = true;
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        series.Points.Clear();
                        chart.Series.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            series.Points.AddXY(x * x * a + b * x + c, x);
                        
                        chart.Series.Add(series);
                        
                        if (!listBoxFormule.Items.Contains("x = " 
                                                           + a + 
                                                           (b > 0 || c > 0 ? "y^2 + " : "y^2 ") 
                                                           +
                                                           (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") +
                                                           (c != 0 ? c.ToString() : "")))
                            listBoxFormule.Items.Add("x = " 
                                                     + a + 
                                                     (b > 0 || c > 0 ? "y^2 + " : "y^2 ") 
                                                     +
                                                     (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") +
                                                     (c != 0 ? c.ToString() : ""));
                        break;
                    
                    case 3: //circonferenza
                        if (!double.TryParse(textBox1.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox2.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            textBox2.Focus();
                            return;
                        }
                        if (!double.TryParse(textBox3.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            textBox3.Focus();
                            return;
                        }
                        if (a == 0 && b == 0 && c == 0)
                        {
                            MessageBox.Show("a, b e c non possono essere tutti uguali a 0", "parametri a, b e c");
                            textBox1.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMax.Text, out max))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di max", "parametro max");
                            txtMax.Focus();
                            return;
                        }
                        if (!double.TryParse(txtMin.Text, out min))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di min", "parametro min");
                            txtMin.Focus();
                            return;
                        }

                        try
                        {
                            r = Math.Sqrt(Math.Pow(a, 2) / 4 + Math.Pow(b, 2) / 4 - c);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Raggio imposibile da calcolare. Errore: " + ex.Message, "parametro raggio");
                            return;
                        }

                        chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
                        chart.ChartAreas[0].AxisY.IsStartedFromZero = true;

                        Cx = -(a / 2);
                        Cy = -(b / 2);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Cx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Cx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Cy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Cy + max;
                        
                        series.Points.Clear();
                        chart.Series.Clear();
                        
                        for (double angle = 0; angle <= 360; angle += 0.01)
                        {
                            double radians = angle * Math.PI / 180;
                            double x = Cx + r * Math.Cos(radians);
                            double y = Cy + r * Math.Sin(radians);
                            series.Points.AddXY(x, y);
                        }
                        
                        chart.Series.Add(series);
                        
                        if (!listBoxFormule.Items.Contains((a > 0 || b > 0 || c > 0 ? "x^2 + y^2 + " : "x^2 + y^2 ")
                                                           +
                                                           (a != 0 ? a + (b > 0 ? "x + " : "x ") : "") 
                                                           +
                                                           (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") 
                                                           + (c == 0 ? "" : c.ToString()) + 
                                                           " = 0"))
                            listBoxFormule.Items.Add((a > 0 || b > 0 || c > 0 ? "x^2 + y^2 + " : "x^2 + y^2 ")
                                                     +
                                                     (a != 0 ? a + (b > 0 ? "x + " : "x ") : "") 
                                                     + 
                                                     (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") 
                                                     + (c == 0 ? "" : c.ToString()) + 
                                                     " = 0");
                        break;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            
            textBox3.Visible = false;
            textBox3.Text = "";
            
            textBox2.Visible = false;
            textBox2.Text = "";
            
            textBox1.Visible = false;
            textBox1.Text = "";

            txtMax.Text = "";
            txtMin.Text = "";
            
            listBoxFormule.Items.Clear();
            
            chart.Series.Clear();
            series.Points.Clear();

            chart.ChartAreas[0].AxisX.Maximum = 3;
            chart.ChartAreas[0].AxisX.Minimum = -3;
            
            series.Points.AddXY(0, 0);
            series.Points.AddXY(2, 3);
            series.Points.AddXY(1, 4);
            series.Points.AddXY(0, 3);
            series.Points.AddXY(-1, 4);
            series.Points.AddXY(-2, 3);
            series.Points.AddXY(0, 0);
            chart.Series.Add(series);

            comboBoxFormule.SelectedIndex = -1;
        }
    }
}