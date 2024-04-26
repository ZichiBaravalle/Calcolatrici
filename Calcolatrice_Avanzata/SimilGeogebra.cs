using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace Calcolatrice_Avanzata
{
    public partial class SimilGeogebra : Form
    {
        private Random rnd = new Random();
        
        private Form InterfacciaSimilGeogebra = new Form();
        private Chart chart = new Chart(); //creazione grafico su dove disegnare
        private List<Series> serie = new List<Series>(); //lista di serie (le serie servono per disegnare le funzioni dando dei punti con X e Y), ad ogni lista corrispondente una funzione
        
        private Label label1 = new Label(); //li usiamo per la creazione dinamica
        private TextBox textBox1 = new TextBox(); //li usiamo per la creazione dinamica
        private Label label2 = new Label(); //li usiamo per la creazione dinamica
        private TextBox textBox2 = new TextBox(); //li usiamo per la creazione dinamica
        private Label label3 = new Label(); //li usiamo per la creazione dinamica
        private TextBox textBox3 = new TextBox(); //li usiamo per la creazione dinamica
        private Label lblVettoreDiSpostamento = new Label(); //li usiamo per la creazione dinamica
        private RadioButton radioBtnFuochiX = new RadioButton(); //li usiamo per la creazione dinamica
        private RadioButton radioBtnFuochiY = new RadioButton(); //li usiamo per la creazione dinamica

        private int nFigura = 0; //corrisponde a quale figura ci troviamo in questo momento
        private bool iperbole = false; //variabile di appoggio per dire se abbiamo un'iperbole oppure no
        private List<int> posizioniIperbole = new List<int>();

        public SimilGeogebra()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //per andare al menu
            FormMenu menu = new FormMenu();
            menu.Show();
            InterfacciaSimilGeogebra.Hide();
            Hide();
        }

        private void SimilGeogebra_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClasseBottoni classe = new ClasseBottoni();
            classe.chiudiTutto(); //chiude tutte le form
        }

        private void SimilGeogebra_Load(object sender, EventArgs e)
        {
            // creo una form in modo dinamico
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

            chart.ChartAreas.Add(new ChartArea()); //aggiungiamo una nuova chart area al chart
            chart.Series.Add(new Series()); //aggiungiamo una nuova serie al chart per stamparci la nostra funzione
            
            serie.Add(new Series()); //aggiungiamo una nuova serie alla lista
            serie[nFigura].ChartType = SeriesChartType.Line; //definiamo il tipo di dati della serie che stiamo creando
            serie[nFigura].Color = Color.Black;
            
            serie[nFigura].Points.AddXY(0, 0); //aggiungiamo un punto alla serie in posizione dentro alla lista corrispondente a nFigura
            serie[nFigura].Points.AddXY(2, 3);
            serie[nFigura].Points.AddXY(1, 4);
            serie[nFigura].Points.AddXY(0, 3);
            serie[nFigura].Points.AddXY(-1, 4);
            serie[nFigura].Points.AddXY(-2, 3);
            serie[nFigura].Points.AddXY(0, 0);
            chart.Series[nFigura] = serie[nFigura]; //facendo così assegnamo alla series di chart in posizione nFigura la serie in posizione nFigura appena caricata con tutti i punti

            listBoxFormule.Items.Add(""); //aggiungiamo un oggetto alla lista
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            if (comboBoxFormule.SelectedIndex == 5 || comboBoxFormule.SelectedIndex == 6)
            {
                radioBtnFuochiX.Visible = true;
                radioBtnFuochiY.Visible = true;
            }
            else
            {
                radioBtnFuochiX.Visible = false;
                radioBtnFuochiY.Visible = false;
            }
            
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
                
                case 4: //ellisse
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(128, 125);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(52, 36);
                    this.label1.TabIndex = 35;
                    this.label1.Text = "a²";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(186, 122);
                    this.textBox1.Name = "txtA";
                    this.textBox1.Size = new System.Drawing.Size(100, 38);
                    this.textBox1.TabIndex = 36;
                    textBox1.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(373, 125);
                    this.label2.Size = new System.Drawing.Size(52, 36);
                    this.label2.TabIndex = 37;
                    this.label2.Text = "b²";
                    label2.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(431, 122);
                    this.textBox2.Name = "txtB";
                    this.textBox2.Size = new System.Drawing.Size(100, 38);
                    this.textBox2.TabIndex = 38;
                    textBox2.Visible = true;

                    label3.Visible = false;
                    textBox3.Visible = false;
                    break;
                
                case 5: //iperbole
                    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label1.Location = new System.Drawing.Point(128, 125);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(52, 36);
                    this.label1.TabIndex = 35;
                    this.label1.Text = "a²";
                    label1.Visible = true;
                    
                    this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox1.Location = new System.Drawing.Point(186, 122);
                    this.textBox1.Name = "txtA";
                    this.textBox1.Size = new System.Drawing.Size(100, 38);
                    this.textBox1.TabIndex = 36;
                    textBox1.Visible = true;
                    
                    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label2.Location = new System.Drawing.Point(373, 125);
                    this.label2.Size = new System.Drawing.Size(52, 36);
                    this.label2.TabIndex = 37;
                    this.label2.Text = "b²";
                    label2.Visible = true;
                    
                    this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.textBox2.Location = new System.Drawing.Point(431, 122);
                    this.textBox2.Name = "txtB";
                    this.textBox2.Size = new System.Drawing.Size(100, 38);
                    this.textBox2.TabIndex = 38;
                    textBox2.Visible = true;
                    
                    this.radioBtnFuochiX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.radioBtnFuochiX.Location = new System.Drawing.Point(105, 250);
                    this.radioBtnFuochiX.Name = "radioBtnFuochiX";
                    this.radioBtnFuochiX.Size = new System.Drawing.Size(183, 24);
                    this.radioBtnFuochiX.TabIndex = 52;
                    this.radioBtnFuochiX.TabStop = true;
                    this.radioBtnFuochiX.Text = "Fuochi sull\'asse X";
                    this.radioBtnFuochiX.UseVisualStyleBackColor = true;
                    
                    this.radioBtnFuochiY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.radioBtnFuochiY.Location = new System.Drawing.Point(372, 250);
                    this.radioBtnFuochiY.Name = "radioBtnFuochiY";
                    this.radioBtnFuochiY.Size = new System.Drawing.Size(183, 24);
                    this.radioBtnFuochiY.TabIndex = 53;
                    this.radioBtnFuochiY.TabStop = true;
                    this.radioBtnFuochiY.Text = "Fuochi sull\'asse Y";
                    this.radioBtnFuochiY.UseVisualStyleBackColor = true;

                    radioBtnFuochiX.Checked = true;
                    label3.Visible = false;
                    textBox3.Visible = false;
                    break;
            }

            if (Controls.Find("label1", true).Length == 0)
            {
                Controls.Add(label1);
                Controls.Add(label2);
                Controls.Add(textBox1);
                Controls.Add(textBox2);
                Controls.Add(radioBtnFuochiX);
                Controls.Add(radioBtnFuochiY);
            }
            
            if (Controls.Find("label3", true).Length == 0)
            {
                Controls.Add(label3);
                Controls.Add(textBox3);
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            double max, min; //variabili di appoggio per riuscire a disegnare la funzione
            double a, b, c; //variabili di appoggio per la parabola, cerchio, ellisse e iperbole
            double m, q; //variabili di appoggio per la retta
            double r, Cy, Cx, Vx, Vy; //variabili di appoggio (raggio, centro e vertice)
            
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
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(nFigura + 1);
                            chart.Series.RemoveAt(nFigura + 1);
                            posizioniIperbole.RemoveAt(nFigura);
                            posizioniIperbole.RemoveAt(nFigura + 1);
                            iperbole = false;
                        }
                        
                        chart.ChartAreas[0].AxisX.Minimum = min;
                        chart.ChartAreas[0].AxisX.Maximum = max;
                        
                        listBoxFormule.Items[nFigura] = "y = " + m + (q >= 0 ? "x + " : "x ") + q;

                        if (serie[nFigura].Points.Count > 0)
                            serie[nFigura].Points.Clear();
                        
                        for (double x = min; x <= max; x++)
                            serie[nFigura].Points.AddXY(x, m * x + q);
                        
                        chart.Series[nFigura] = serie[nFigura];
                        
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
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(nFigura + 1);
                            chart.Series.RemoveAt(nFigura + 1);
                            posizioniIperbole.RemoveAt(nFigura);
                            posizioniIperbole.RemoveAt(nFigura + 1);
                            iperbole = false;
                        }
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        listBoxFormule.Items[nFigura] = "y = " + a + (b > 0 || c > 0 ? "x² + " : "x² ") + (b != 0 ? b + (c > 0 ? b + "x + " : "x ") : "") + (c != 0 ? c.ToString() : "");
                        
                        if (serie[nFigura].Points.Count > 0)
                            serie[nFigura].Points.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            serie[nFigura].Points.AddXY(x, x * x * a + b * x + c);
                        
                        chart.Series[nFigura] = serie[nFigura];
                        break;
                    
                    case 2: //parabola coricata
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
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(nFigura + 1);
                            chart.Series.RemoveAt(nFigura + 1);
                            posizioniIperbole.RemoveAt(nFigura);
                            posizioniIperbole.RemoveAt(nFigura + 1);
                            iperbole = false;
                        }
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        listBoxFormule.Items[nFigura] = "x = " + a + (b > 0 || c > 0 ? "y² + " : "y² ") + (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") + (c != 0 ? c.ToString() : "");
                        
                        if (serie[nFigura].Points.Count > 0)
                            serie[nFigura].Points.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            serie[nFigura].Points.AddXY(x * x * a + b * x + c, x);
                        
                        chart.Series[nFigura] = serie[nFigura];
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
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(nFigura + 1);
                            chart.Series.RemoveAt(nFigura + 1);
                            posizioniIperbole.RemoveAt(nFigura);
                            posizioniIperbole.RemoveAt(nFigura + 1);
                            iperbole = false;
                        }

                        Cx = -(a / 2);
                        Cy = -(b / 2);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Cx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Cx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Cy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Cy + max;

                        listBoxFormule.Items[nFigura] = (a > 0 || b > 0 || c > 0 ? "x² + y² + " : "x² + y² ") + (a != 0 ? a + (b > 0 ? "x + " : "x ") : "") + (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") + (c == 0 ? "" : c.ToString()) + " = 0";
                        
                        if (serie[nFigura].Points.Count > 0)
                            serie[nFigura].Points.Clear();
                        
                        for (double angle = 0; angle <= 360; angle += 0.01)
                        {
                            double radians = angle * Math.PI / 180;
                            double x = Cx + r * Math.Cos(radians);
                            double y = Cy + r * Math.Sin(radians);
                            serie[nFigura].Points.AddXY(x, y);
                        }
                        
                        chart.Series[nFigura] = serie[nFigura];
                        break;
                    
                    case 4: //ellisse
                        if (!double.TryParse(textBox1.Text, out a) || a <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a, positivo e diverso da 0", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        a = Math.Sqrt(a);
                        
                        if (!double.TryParse(textBox2.Text, out b) || b <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b, positivo e diverso da 0", "parametro b");
                            textBox2.Focus();
                            return;
                        }
                        b = Math.Sqrt(b);

                        if (a == b)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a diverso da b", "parametri a, b");
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
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(nFigura + 1);
                            chart.Series.RemoveAt(nFigura + 1);
                            posizioniIperbole.RemoveAt(nFigura);
                            posizioniIperbole.RemoveAt(nFigura + 1);
                            iperbole = false;
                        }
                        
                        chart.ChartAreas[0].AxisX.Minimum = min;
                        chart.ChartAreas[0].AxisX.Maximum = max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = min;
                        chart.ChartAreas[0].AxisY.Maximum = max;
                        
                        listBoxFormule.Items[nFigura] = "x²/" + a + "² + y²/" + b + "² = 1";
                        
                        if (serie[nFigura].Points.Count > 0)
                            serie[nFigura].Points.Clear();
                        
                        
                        for (double angle = 0; angle <= 360; angle += 0.01)
                        {
                            double radians = angle * Math.PI / 180;
                            double x = a * Math.Cos(radians);
                            double y = b * Math.Sin(radians);
                            serie[nFigura].Points.AddXY(x, y);
                        }
                        
                        chart.Series[nFigura] = serie[nFigura];
                        break;
                    
                    case 5: //iperebole
                        if (!double.TryParse(textBox1.Text, out a) || a <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a, positivo e diverso da 0", "parametro a");
                            textBox1.Focus();
                            return;
                        }
                        a = Math.Sqrt(a);
                        
                        if (!double.TryParse(textBox2.Text, out b) || b <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b, positivo e diverso da 0", "parametro b");
                            textBox2.Focus();
                            return;
                        }
                        b = Math.Sqrt(b);

                        if (a == b)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a diverso da b", "parametri a, b");
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
                        
                        chart.ChartAreas[0].AxisX.Minimum = min;
                        chart.ChartAreas[0].AxisX.Maximum = max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = min;
                        chart.ChartAreas[0].AxisY.Maximum = max;
                        
                        if (serie[nFigura].Points.Count > 0) //se la serie è già stata caricata andiamo a pulirla
                            serie[nFigura].Points.Clear();

                        if (!iperbole) //se stiamo creando una iperbole ed è la prima che la creiamo allora dobbiamo creare una nuova serie di appoggio per fare la seconda parte
                        {
                            serie.Add(new Series());
                            chart.Series.Add(new Series());
                            serie[nFigura + 1].ChartType = SeriesChartType.Line;
                            Color colore = serie[nFigura].Color;
                            serie[nFigura + 1].Color = colore;
                            posizioniIperbole.Add(nFigura);
                            posizioniIperbole.Add(nFigura + 1);
                        }
                        
                        if (radioBtnFuochiX.Checked)
                        {
                            listBoxFormule.Items[nFigura] = "x²/" + a + "² - y²/" + b + "² = 1";
                            
                            for (double theta = -Math.PI; theta <= Math.PI; theta += 0.1)
                            {
                                double x = a * Math.Cosh(theta);
                                double y = b * Math.Sinh(theta);

                                if (Math.Abs(x / a) >= 1 || Math.Abs(y / b) >= 1)
                                {
                                    serie[nFigura].Points.AddXY(x, y);
                                }
                            }
                            
                            for (double theta = -Math.PI; theta <= Math.PI; theta += 0.1)
                            {
                                double x = a * Math.Cosh(theta);
                                double y = b * Math.Sinh(theta);

                                if (Math.Abs(x / a) >= 1 || Math.Abs(y / b) >= 1)
                                {
                                    serie[nFigura + 1].Points.AddXY(-x, y);
                                }
                            }
                        }
                        else
                        {
                            listBoxFormule.Items[nFigura] = "x²/" + a + "² - y²/" + b + "² = -1";

                            for (double x = min; x <= max; x += 0.1)
                            {
                                double y = Math.Sqrt(Math.Pow(a, 2) +
                                                      (Math.Pow(a, 2) / Math.Pow(b, 2)) * Math.Pow(x, 2));
                                serie[nFigura].Points.AddXY(x, y);
                            }

                            for (double x = min; x <= max; x += 0.1)
                            {
                                double y = -Math.Sqrt(Math.Pow(a, 2) +
                                                       (Math.Pow(a, 2) / Math.Pow(b, 2)) * Math.Pow(x, 2));
                                serie[nFigura + 1].Points.AddXY(x, y);
                            }
                        }
                        
                        chart.Series[nFigura] = serie[nFigura]; //assegnamo alla serie di chart in posizione nFigura la serie in posizione nFigura appena caricata con tutti i punti
                        chart.Series[nFigura + 1] = serie[nFigura + 1]; //assegnamo alla serie di chart in posizione nFigura la serie in posizione nFigura appena caricata con tutti i punti
                        break;
                }

                if (comboBoxFormule.SelectedIndex == 5 || comboBoxFormule.SelectedIndex == 6) //stiamo dicendo che abbiamo appena creato una iperbole
                    iperbole = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        { 
            //reset per tutti i campi ancora da caricare 
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            radioBtnFuochiX.Visible = false;
            radioBtnFuochiY.Visible = false;
            
            textBox3.Visible = false;
            textBox3.Text = "";
            
            textBox2.Visible = false;
            textBox2.Text = "";
            
            textBox1.Visible = false;
            textBox1.Text = "";

            txtMax.Text = "";
            txtMin.Text = "";
            
            listBoxFormule.Items.Clear();

            nFigura = 0;
            
            chart.Series.Clear();
            serie.Clear();
            
            chart.Series.Add(new Series());
            serie.Add(new Series()); //aggiungiamo una nuova serie alla lista
            serie[nFigura].ChartType = SeriesChartType.Line; //definiamo il tipo di dati della serie che stiamo creando
            serie[nFigura].Color = Color.Black;
            
            chart.ChartAreas[nFigura].AxisX.Maximum = 3;
            chart.ChartAreas[nFigura].AxisX.Minimum = -3;
            
            chart.ChartAreas[nFigura].AxisY.Minimum = 0;
            chart.ChartAreas[nFigura].AxisY.Maximum = 5;
            
            serie[nFigura].Points.AddXY(0, 0);
            serie[nFigura].Points.AddXY(2, 3);
            serie[nFigura].Points.AddXY(1, 4);
            serie[nFigura].Points.AddXY(0, 3);
            serie[nFigura].Points.AddXY(-1, 4);
            serie[nFigura].Points.AddXY(-2, 3);
            serie[nFigura].Points.AddXY(0, 0);
            chart.Series[nFigura] = serie[nFigura];

            comboBoxFormule.SelectedIndex = -1;
            listBoxFormule.Items.Add(""); //aggiungiamo un oggetto alla lista
        }

        private void aggiungiFiguraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxFormule.Items[nFigura].ToString() != "")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBoxFormule.SelectedIndex = -1;
                serie.Add(new Series());
                chart.Series.Add(new Series());
                listBoxFormule.Items.Add("");
                if (iperbole)
                    nFigura += 2;
                else
                    nFigura++;
                serie[nFigura].ChartType = SeriesChartType.Line;
                serie[nFigura].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                
            }
            else
                MessageBox.Show("Prima di creare una nuova funzione da inserire, devi inserirne una qua", "Errore");
        }

        private void eliminaFunzioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxFormule.Items.Count > 0)
            {
                int i = -1;

                while (!int.TryParse(Interaction.InputBox("Inserisci il numero della funzione da eliminare"), out i) ||
                       i <= 0)
                {
                }
                
                if (i > listBoxFormule.Items.Count)
                    MessageBox.Show("Indice troppo grande", "Errore");
                else
                {
                    listBoxFormule.Items.RemoveAt(i - 1);
                    nFigura--;
                    if (posizioniIperbole.Contains(i))
                    {
                        chart.Series.RemoveAt(i);
                        chart.Series.RemoveAt(i - 1);
                        serie.RemoveAt(i);
                        serie.RemoveAt(i - 1);
                        posizioniIperbole.RemoveAt(posizioniIperbole.Find(x => x == i - 1));
                        posizioniIperbole.RemoveAt(posizioniIperbole.Find(x => x == i));
                    }
                    else
                    {
                        chart.Series.RemoveAt(i - 1);
                        serie.RemoveAt(i - 1);
                    }
                }
            }
            else
                MessageBox.Show("Non ci sono funzioni da eliminare", "Errore");
        }
    }
}