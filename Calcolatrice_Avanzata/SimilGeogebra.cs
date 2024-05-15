using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xaml;
using Microsoft.VisualBasic;

namespace Calcolatrice_Avanzata
{
    public partial class SimilGeogebra : Form
    {
        
        /*
         * MODIFICHE DA FINIRE:
         * 1. AGGIUNTA IPERBOLE QUADRILATERA
         * 2. IMPLEMENTAZIONE DELLE ULTIME FUNZIONI E DELLE ULTIME OPZIONI
         */
        
        private Random rnd = new Random();
        
        private Form InterfacciaSimilGeogebra = new Form();
        private Chart chart = new Chart(); //creazione grafico su dove disegnare
        private List<Series> serie = new List<Series>(); //lista di serie (le serie servono per disegnare le funzioni dando dei punti con X e Y), ad ogni lista corrispondente una funzione

        private Label lblA_M = new Label(); //li usiamo per la creazione dinamica
        private TextBox txtA_M = new TextBox(); //li usiamo per la creazione dinamica
        private Label lblB_Q = new Label(); //li usiamo per la creazione dinamica
        private TextBox txtB_Q = new TextBox(); //li usiamo per la creazione dinamica
        private Label lblC = new Label(); //li usiamo per la creazione dinamica
        private TextBox txtC = new TextBox(); //li usiamo per la creazione dinamica
        private Label lblD = new Label(); //li usiamo per la creazione dinamica
        private TextBox txtD = new TextBox(); //li usiamo per la creazione dinamica
        private Label lblVet = new Label(); //li usiamo per la creazione dinamica
        private TextBox txtVetX = new TextBox(); //li usiamo per la creazione dinamica
        private TextBox txtVetY = new TextBox(); //li usiamo per la creazione dinamica
        private RadioButton radioBtnFuochiX = new RadioButton(); //li usiamo per la creazione dinamica
        private RadioButton radioBtnFuochiY = new RadioButton(); //li usiamo per la creazione dinamica

        private bool iperbole = false; //variabile di appoggio per dire se abbiamo un'iperbole oppure no
        private List<int> posizioneFigureReale = new List<int>(); //posizione reale delle figure dentro il grafico

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
            
            Controls.Add(lblA_M);
            Controls.Add(lblB_Q);
            Controls.Add(txtA_M);
            Controls.Add(txtB_Q);
            Controls.Add(radioBtnFuochiX);
            Controls.Add(radioBtnFuochiY);
            Controls.Add(lblC);
            Controls.Add(txtC);
            Controls.Add(lblVet);
            Controls.Add(txtVetX);
            Controls.Add(txtVetY);
            Controls.Add(lblD);
            Controls.Add(txtD);
            
            posizioneFigureReale.Add(0);
        }
        
        private void InterfacciaSimilGeogebra_Load(object sender, EventArgs e)
        {
            chart.Parent = InterfacciaSimilGeogebra;
            chart.Dock = DockStyle.Fill;

            chart.ChartAreas.Add(new ChartArea()); //aggiungiamo una nuova chart area al chart
            chart.Series.Add(new Series()); //aggiungiamo una nuova serie al chart per stamparci la nostra funzione
            
            serie.Add(new Series()); //aggiungiamo una nuova serie alla lista
            serie[chart.Series.Count - 1].ChartType = SeriesChartType.Line; //definiamo il tipo di dati della serie che stiamo creando
            serie[chart.Series.Count - 1].Color = Color.Black;
            
            serie[chart.Series.Count - 1].Points.AddXY(0, 0); //aggiungiamo un punto alla serie in posizione dentro alla lista corrispondente a l'ultimo elemento presente
            serie[chart.Series.Count - 1].Points.AddXY(2, 3);
            serie[chart.Series.Count - 1].Points.AddXY(1, 4);
            serie[chart.Series.Count - 1].Points.AddXY(0, 3);
            serie[chart.Series.Count - 1].Points.AddXY(-1, 4);
            serie[chart.Series.Count - 1].Points.AddXY(-2, 3);
            serie[chart.Series.Count - 1].Points.AddXY(0, 0);
            chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1]; //facendo così assegnamo alla series di chart in ultima posizione la serie in ultima posizione appena caricata con tutti i punti

            listBoxFormule.Items.Add(""); //aggiungiamo un oggetto alla lista
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtA_M.Text = "";
            txtB_Q.Text = "";
            txtC.Text = "";
            txtVetX.Text = "0";
            txtVetY.Text = "0";
            txtVetY.Enabled = true;
            txtVetX.Enabled = true;

            if (comboBoxFormule.SelectedIndex == 4 || comboBoxFormule.SelectedIndex == 5 || comboBoxFormule.SelectedIndex == 7)
            {
                lblVet.Visible = true;
                txtVetX.Visible = true;
                txtVetX.BringToFront();
                txtVetY.Visible = true;
                txtVetY.BringToFront();
                if (comboBoxFormule.SelectedIndex == 5)
                {
                    radioBtnFuochiX.Visible = true;
                    radioBtnFuochiY.Visible = true;
                }
                else
                {
                    radioBtnFuochiX.Visible = false;
                    radioBtnFuochiY.Visible = false;
                }
            }
            else
            {
                lblVet.Visible = false;
                txtVetX.Visible = false;
                txtVetY.Visible = false;
                radioBtnFuochiX.Visible = false;
                radioBtnFuochiY.Visible = false;
            }

            if (comboBoxFormule.SelectedIndex == 6)
            {
                lblD.Visible = true;
                txtD.Visible = true;
            }
            else
            {
                lblD.Visible = false;
                txtD.Visible = false;
            }
            
            switch (comboBoxFormule.SelectedIndex)
            {
                case 0:  //retta
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(128, 125);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(32, 36);
                    this.lblA_M.TabIndex = 35;
                    this.lblA_M.Text = "m";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(166, 122);
                    this.txtA_M.Name = "txtM";
                    this.txtA_M.Size = new System.Drawing.Size(100, 38);
                    this.txtA_M.TabIndex = 36;
                    txtA_M.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(373, 125);
                    this.lblB_Q.Size = new System.Drawing.Size(32, 36);
                    this.lblB_Q.TabIndex = 37;
                    this.lblB_Q.Text = "q";
                    lblB_Q.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(411, 122);
                    this.txtB_Q.Name = "txtQ";
                    this.txtB_Q.Size = new System.Drawing.Size(100, 38);
                    this.txtB_Q.TabIndex = 38;
                    txtB_Q.Visible = true;

                    lblC.Visible = false;
                    txtC.Visible = false;
                    break;
                
                case 1: //parabola
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(72, 78);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(30, 36);
                    this.lblA_M.TabIndex = 51;
                    this.lblA_M.Text = "a";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(108, 75);
                    this.txtA_M.Name = "textBox1";
                    this.txtA_M.Size = new System.Drawing.Size(155, 38);
                    this.txtA_M.TabIndex = 52;
                    txtA_M.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(406, 75);
                    this.txtB_Q.Name = "textBox2";
                    this.txtB_Q.Size = new System.Drawing.Size(155, 38);
                    this.txtB_Q.TabIndex = 54;
                    txtB_Q.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(370, 78);
                    this.lblB_Q.Name = "lblB_Q";
                    this.lblB_Q.Size = new System.Drawing.Size(30, 36);
                    this.lblB_Q.TabIndex = 53;
                    this.lblB_Q.Text = "b";
                    lblB_Q.Visible = true;
                    
                    this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtC.Location = new System.Drawing.Point(245, 161);
                    this.txtC.Name = "textBox3";
                    this.txtC.Size = new System.Drawing.Size(155, 38);
                    this.txtC.TabIndex = 56;
                    txtC.Visible = true;
                    
                    this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblC.Location = new System.Drawing.Point(209, 164);
                    this.lblC.Name = "label3";
                    this.lblC.Size = new System.Drawing.Size(30, 36);
                    this.lblC.TabIndex = 55;
                    lblC.Text = "c";
                    lblC.Visible = true;
                    break;
                
                case 2: //parabola coricata
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(72, 78);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(30, 36);
                    this.lblA_M.TabIndex = 51;
                    this.lblA_M.Text = "a";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(108, 75);
                    this.txtA_M.Name = "textBox1";
                    this.txtA_M.Size = new System.Drawing.Size(155, 38);
                    this.txtA_M.TabIndex = 52;
                    txtA_M.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(406, 75);
                    this.txtB_Q.Name = "textBox2";
                    this.txtB_Q.Size = new System.Drawing.Size(155, 38);
                    this.txtB_Q.TabIndex = 54;
                    txtB_Q.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(370, 78);
                    this.lblB_Q.Name = "lblB_Q";
                    this.lblB_Q.Size = new System.Drawing.Size(30, 36);
                    this.lblB_Q.TabIndex = 53;
                    this.lblB_Q.Text = "b";
                    lblB_Q.Visible = true;
                    
                    this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtC.Location = new System.Drawing.Point(245, 161);
                    this.txtC.Name = "textBox3";
                    this.txtC.Size = new System.Drawing.Size(155, 38);
                    this.txtC.TabIndex = 56;
                    txtC.Visible = true;
                    
                    this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblC.Location = new System.Drawing.Point(209, 164);
                    this.lblC.Name = "label3";
                    this.lblC.Size = new System.Drawing.Size(30, 36);
                    this.lblC.TabIndex = 55;
                    lblC.Text = "c";
                    lblC.Visible = true;
                    break;
                
                case 3: //circonferenza
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(72, 78);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(30, 36);
                    this.lblA_M.TabIndex = 51;
                    this.lblA_M.Text = "a";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(108, 75);
                    this.txtA_M.Name = "textBox1";
                    this.txtA_M.Size = new System.Drawing.Size(155, 38);
                    this.txtA_M.TabIndex = 52;
                    txtA_M.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(406, 75);
                    this.txtB_Q.Name = "textBox2";
                    this.txtB_Q.Size = new System.Drawing.Size(155, 38);
                    this.txtB_Q.TabIndex = 54;
                    txtB_Q.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(370, 78);
                    this.lblB_Q.Name = "lblB_Q";
                    this.lblB_Q.Size = new System.Drawing.Size(30, 36);
                    this.lblB_Q.TabIndex = 53;
                    this.lblB_Q.Text = "b";
                    lblB_Q.Visible = true;
                    
                    this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtC.Location = new System.Drawing.Point(245, 161);
                    this.txtC.Name = "textBox3";
                    this.txtC.Size = new System.Drawing.Size(155, 38);
                    this.txtC.TabIndex = 56;
                    txtC.Visible = true;
                    
                    this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblC.Location = new System.Drawing.Point(209, 164);
                    this.lblC.Name = "label3";
                    this.lblC.Size = new System.Drawing.Size(30, 36);
                    this.lblC.TabIndex = 55;
                    lblC.Text = "c";
                    lblC.Visible = true;
                    break;
                
                case 4: //ellisse
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(128, 125);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(52, 36);
                    this.lblA_M.TabIndex = 35;
                    this.lblA_M.Text = "a²";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(186, 122);
                    this.txtA_M.Name = "txtA";
                    this.txtA_M.Size = new System.Drawing.Size(100, 38);
                    this.txtA_M.TabIndex = 36;
                    txtA_M.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(373, 125);
                    this.lblB_Q.Size = new System.Drawing.Size(52, 36);
                    this.lblB_Q.TabIndex = 37;
                    this.lblB_Q.Text = "b²";
                    lblB_Q.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(431, 122);
                    this.txtB_Q.Name = "txtB";
                    this.txtB_Q.Size = new System.Drawing.Size(100, 38);
                    this.txtB_Q.TabIndex = 38;
                    txtB_Q.Visible = true;
                    
                    this.lblVet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblVet.Location = new System.Drawing.Point(200, 207);
                    this.lblVet.Name = "lblVet";
                    this.lblVet.Size = new System.Drawing.Size(287, 27);
                    this.lblVet.TabIndex = 52;
                    this.lblVet.Text = "vet(                 ;                   )";
                    
                    this.txtVetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetX.Location = new System.Drawing.Point(250, 205);
                    this.txtVetX.Name = "txtVetX";
                    this.txtVetX.Size = new System.Drawing.Size(84, 29);
                    this.txtVetX.TabIndex = 53;
                    
                    this.txtVetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetY.Location = new System.Drawing.Point(361, 205);
                    this.txtVetY.Name = "txtVetY";
                    this.txtVetY.Size = new System.Drawing.Size(90, 29);
                    this.txtVetY.TabIndex = 55;

                    txtVetX.Text = "0";
                    txtVetY.Text = "0";

                    lblC.Visible = false;
                    txtC.Visible = false;
                    break;
                
                case 5: //iperbole
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(128, 125);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(52, 36);
                    this.lblA_M.TabIndex = 35;
                    this.lblA_M.Text = "a²";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(186, 122);
                    this.txtA_M.Name = "txtA";
                    this.txtA_M.Size = new System.Drawing.Size(100, 38);
                    this.txtA_M.TabIndex = 36;
                    txtA_M.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(373, 125);
                    this.lblB_Q.Size = new System.Drawing.Size(52, 36);
                    this.lblB_Q.TabIndex = 37;
                    this.lblB_Q.Text = "b²";
                    lblB_Q.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(431, 122);
                    this.txtB_Q.Name = "txtB";
                    this.txtB_Q.Size = new System.Drawing.Size(100, 38);
                    this.txtB_Q.TabIndex = 38;
                    txtB_Q.Visible = true;
                    
                    this.lblVet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblVet.Location = new System.Drawing.Point(200, 207);
                    this.lblVet.Name = "lblVet";
                    this.lblVet.Size = new System.Drawing.Size(287, 27);
                    this.lblVet.TabIndex = 52;
                    this.lblVet.Text = "vet(                 ;                   )";
                    
                    this.txtVetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetX.Location = new System.Drawing.Point(250, 205);
                    this.txtVetX.Name = "txtVetX";
                    this.txtVetX.Size = new System.Drawing.Size(84, 29);
                    this.txtVetX.TabIndex = 53;
                    
                    this.txtVetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetY.Location = new System.Drawing.Point(361, 205);
                    this.txtVetY.Name = "txtVetY";
                    this.txtVetY.Size = new System.Drawing.Size(90, 29);
                    this.txtVetY.TabIndex = 55;
                    
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

                    txtVetX.Text = "0";
                    txtVetY.Text = "0";

                    radioBtnFuochiX.Checked = true;
                    lblC.Visible = false;
                    txtC.Visible = false;
                    break;
                
                case 6: //iperbole quadrilatera
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(128, 126);
                    this.lblA_M.Name = "lblA_M";
                    this.lblA_M.Size = new System.Drawing.Size(20, 23);
                    this.lblA_M.TabIndex = 52;
                    this.lblA_M.Text = "a";
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(166, 123);
                    this.txtA_M.Name = "txtA_M";
                    this.txtA_M.Size = new System.Drawing.Size(100, 29);
                    this.txtA_M.TabIndex = 53;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(371, 126);
                    this.lblB_Q.Name = "label3";
                    this.lblB_Q.Size = new System.Drawing.Size(20, 23);
                    this.lblB_Q.TabIndex = 56;
                    this.lblB_Q.Text = "b";
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(409, 123);
                    this.txtB_Q.Name = "textBox3";
                    this.txtB_Q.Size = new System.Drawing.Size(100, 29);
                    this.txtB_Q.TabIndex = 57;
                    
                    this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblC.Location = new System.Drawing.Point(128, 216);
                    this.lblC.Name = "label2";
                    this.lblC.Size = new System.Drawing.Size(20, 23);
                    this.lblC.TabIndex = 54;
                    this.lblC.Text = "c";
                    
                    this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtC.Location = new System.Drawing.Point(166, 213);
                    this.txtC.Name = "txtC";
                    this.txtC.Size = new System.Drawing.Size(100, 29);
                    this.txtC.TabIndex = 55;
                    
                    this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblD.Location = new System.Drawing.Point(371, 216);
                    this.lblD.Name = "label4";
                    this.lblD.Size = new System.Drawing.Size(20, 23);
                    this.lblD.TabIndex = 58;
                    this.lblD.Text = "d";
                    
                    this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtD.Location = new System.Drawing.Point(409, 213);
                    this.txtD.Name = "textBox4";
                    this.txtD.Size = new System.Drawing.Size(100, 29);
                    this.txtD.TabIndex = 59;
                    break;
                
                case 7: // esponenziale
                    lblC.Visible = false;
                    txtC.Visible = false;
                    
                    lblB_Q.Visible = false;
                    txtB_Q.Visible = false;
                    
                    this.lblA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblA_M.Location = new System.Drawing.Point(128 - 40, 125);
                    this.lblA_M.Name = "label1";
                    this.lblA_M.Size = new System.Drawing.Size(32 + 40, 36);
                    this.lblA_M.TabIndex = 35;
                    this.lblA_M.Text = "a^x";
                    lblA_M.Visible = true;
                    
                    this.txtA_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtA_M.Location = new System.Drawing.Point(166, 122);
                    this.txtA_M.Name = "txtM";
                    this.txtA_M.Size = new System.Drawing.Size(100, 38);
                    this.txtA_M.TabIndex = 36;
                    txtA_M.Visible = true;
                    
                    this.lblB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblB_Q.Location = new System.Drawing.Point(373 - 40, 125);
                    this.lblB_Q.Size = new System.Drawing.Size(32 + 40, 36);
                    this.lblB_Q.TabIndex = 37;
                    this.lblB_Q.Text = "n * x";
                    lblB_Q.Visible = true;
                    
                    this.txtB_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtB_Q.Location = new System.Drawing.Point(411, 122);
                    this.txtB_Q.Name = "txtQ";
                    this.txtB_Q.Size = new System.Drawing.Size(100, 38);
                    this.txtB_Q.TabIndex = 38;
                    txtB_Q.Visible = true;
                    
                    this.lblVet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.lblVet.Location = new System.Drawing.Point(200, 207);
                    this.lblVet.Name = "lblVet";
                    this.lblVet.Size = new System.Drawing.Size(287, 27);
                    this.lblVet.TabIndex = 52;
                    this.lblVet.Text = "vet(                 ;                   )";
                    
                    this.txtVetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetX.Location = new System.Drawing.Point(250, 205);
                    this.txtVetX.Name = "txtVetX";
                    this.txtVetX.Size = new System.Drawing.Size(84, 29);
                    this.txtVetX.TabIndex = 53;
                    
                    this.txtVetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.txtVetY.Location = new System.Drawing.Point(361, 205);
                    this.txtVetY.Name = "txtVetY";
                    this.txtVetY.Size = new System.Drawing.Size(90, 29);
                    this.txtVetY.TabIndex = 55;
                    break;
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            double max, min; //variabili di appoggio per riuscire a disegnare la funzione
            double a, b, c, d; //variabili di appoggio per la parabola, cerchio, ellisse, iperbole quadrilatera e iperbole
            double m, q; //variabili di appoggio per la retta
            double r, Cy, Cx, Vx, Vy; //variabili di appoggio (raggio, centro e vertice)
            double vetX, vetY; //variabili di appoggio per il vettore
            
            if (comboBoxFormule.SelectedIndex == -1)
            {
                MessageBox.Show("Seleziona la formula da generare", "Formula");
                comboBoxFormule.Focus();
            }
            else
            {
                if (posizioneFigureReale.Count > 1)
                    if (verificaSeIperbole(posizioneFigureReale.Count - 1))
                        iperbole = true;
                
                switch (comboBoxFormule.SelectedIndex)
                {
                    case 0: //retta
                        if (!double.TryParse(txtA_M.Text, out m))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di m", "parametro m");
                            txtA_M.Focus();
                            return;
                        }
                        if (!double.TryParse(txtB_Q.Text, out q))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di q", "parametro q");
                            txtB_Q.Focus();
                            return;
                        }

                        if (m == 0 && q == 0)
                        {
                            MessageBox.Show("I valori di q e m non possono entrambi essere 0", "parametro q e m");
                            txtB_Q.Focus();
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
                            serie.RemoveAt(chart.Series.Count - 1);
                            chart.Series.RemoveAt(chart.Series.Count - 1);
                            iperbole = false;
                        }
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;
                        
                        chart.ChartAreas[0].AxisX.Minimum = min;
                        chart.ChartAreas[0].AxisX.Maximum = max;
                        
                        listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "y = " + (m != 0 ? m + (q > 0 ? "x + " : "x ") : "") +
                                                                               (q != 0 ? q.ToString() : "");

                        if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        for (double x = min; x <= max; x++)
                            serie[chart.Series.Count - 1].Points.AddXY(x, m * x + q);
                        
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];
                        
                        break;
                    
                    case 1: //parabola
                        if (!double.TryParse(txtA_M.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        if (a == 0)
                        {
                            MessageBox.Show("a non puo' essere 0", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        if (!double.TryParse(txtB_Q.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            txtB_Q.Focus();
                            return;
                        }
                        if (!double.TryParse(txtC.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            txtC.Focus();
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
                            serie.RemoveAt(chart.Series.Count - 1);
                            chart.Series.RemoveAt(chart.Series.Count - 1);
                            iperbole = false;
                        }
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "y = " + a + (b > 0 || c > 0 ? "x² + " : "x² ") + (b != 0 ? b + (c > 0 ? "x + " : "x ") : "") + (c != 0 ? c.ToString() : "");
                        
                        if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            serie[chart.Series.Count - 1].Points.AddXY(x, x * x * a + b * x + c);
                        
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];
                        break;
                    
                    case 2: //parabola coricata
                        if (!double.TryParse(txtA_M.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        if (a == 0)
                        {
                            MessageBox.Show("a non puo' essere 0", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        if (!double.TryParse(txtB_Q.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            txtB_Q.Focus();
                            return;
                        } 
                        if (!double.TryParse(txtC.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            txtC.Focus();
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
                            serie.RemoveAt(chart.Series.Count - 1);
                            chart.Series.RemoveAt(chart.Series.Count - 1);
                            iperbole = false;
                        }
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;
                        
                        Vx = -(b / (2 * a));
                        Vy = -(Math.Pow(b, 2) - 4 * a * c) / (4 * a);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Vx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Vx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Vy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Vy + max;

                        listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "x = " + a + (b > 0 || c > 0 ? "y² + " : "y² ") + (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") + (c != 0 ? c.ToString() : "");
                        
                        if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        for (double x = min; x <= max; x += 0.1)
                            serie[chart.Series.Count - 1].Points.AddXY(x * x * a + b * x + c, x);
                        
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];
                        break;
                    
                    case 3: //circonferenza
                        if (!double.TryParse(txtA_M.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        if (!double.TryParse(txtB_Q.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            txtB_Q.Focus();
                            return;
                        }
                        if (!double.TryParse(txtC.Text, out c))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c", "parametro c");
                            txtC.Focus();
                            return;
                        }
                        if (a == 0 && b == 0 && c == 0)
                        {
                            MessageBox.Show("a, b e c non possono essere tutti uguali a 0", "parametri a, b e c");
                            txtA_M.Focus();
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
                        
                        if (Double.IsNaN(Math.Sqrt(Math.Pow(a, 2) / 4 + Math.Pow(b, 2) / 4 - c)))
                        {
                            MessageBox.Show("Raggio imposibile da calcolare", "parametro raggio");
                            return;
                        }
                        else
                            r = Math.Sqrt(Math.Pow(a, 2) / 4 + Math.Pow(b, 2) / 4 - c);
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(chart.Series.Count - 1);
                            chart.Series.RemoveAt(chart.Series.Count - 1);
                            iperbole = false;
                        }
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;

                        Cx = -(a / 2);
                        Cy = -(b / 2);
                        
                        chart.ChartAreas[0].AxisX.Minimum = Cx + min;
                        chart.ChartAreas[0].AxisX.Maximum = Cx + max;
                        
                        chart.ChartAreas[0].AxisY.Minimum = Cy + min;
                        chart.ChartAreas[0].AxisY.Maximum = Cy + max;

                        listBoxFormule.Items[listBoxFormule.Items.Count - 1] = (a > 0 || b > 0 || c > 0 ? "x² + y² + " : "x² + y² ") + (a != 0 ? a + (b > 0 ? "x + " : "x ") : "") + (b != 0 ? b + (c > 0 ? "y + " : "y ") : "") + (c == 0 ? "" : c.ToString()) + " = 0";
                        
                        if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        for (double angle = 0; angle <= 360; angle += 0.01)
                        {
                            double radians = angle * Math.PI / 180;
                            double x = Cx + r * Math.Cos(radians);
                            double y = Cy + r * Math.Sin(radians);
                            serie[chart.Series.Count - 1].Points.AddXY(x, y);
                        }
                        
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];
                        break;
                    
                    case 4: //ellisse
                        if (!double.TryParse(txtA_M.Text, out a) || a <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a, positivo e diverso da 0", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        a = Math.Sqrt(a);
                        
                        if (!double.TryParse(txtB_Q.Text, out b) || b <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b, positivo e diverso da 0", "parametro b");
                            txtB_Q.Focus();
                            return;
                        }
                        b = Math.Sqrt(b);

                        if (a == b)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a diverso da b", "parametri a, b");
                            txtA_M.Focus();
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

                        if (!double.TryParse(txtVetX.Text, out vetX))
                        {
                            MessageBox.Show("Inserisci correttamente la X del vettore", "parametro vetX");
                            txtVetX.Focus();
                            return;
                        }

                        if (!double.TryParse(txtVetY.Text, out vetY))
                        {
                            MessageBox.Show("Inserisci correttamente la Y del vettore", "parametro vetY");
                            txtVetY.Focus();
                            return;
                        }
                        
                        if (iperbole) //se abbiamo una iperbole e vogliamo disegnare un'altra funzione al suo posto allora dobbiamo cancellare la serie che contiene la seconda parte di iperbole
                        {
                            serie.RemoveAt(chart.Series.Count - 1);
                            chart.Series.RemoveAt(chart.Series.Count - 1);
                            iperbole = false;
                        }
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;
                        
                        chart.ChartAreas[0].AxisX.Minimum = min + vetX;
                        chart.ChartAreas[0].AxisX.Maximum = max + vetX;
                        
                        chart.ChartAreas[0].AxisY.Minimum = min + vetY;
                        chart.ChartAreas[0].AxisY.Maximum = max + vetY;
                        
                        listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "x²/" + a + "² + y²/" + b + "² = 1";
                        
                        if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        
                        for (double angle = 0; angle <= 360; angle += 0.01)
                        {
                            double radians = angle * Math.PI / 180;
                            double x = a * Math.Cos(radians);
                            double y = b * Math.Sin(radians);
                            serie[chart.Series.Count - 1].Points.AddXY(x + vetX, y + vetY);
                        }
                        
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];
                        break;
                    
                    case 5: //iperebole
                        if (!double.TryParse(txtA_M.Text, out a) || a <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a, positivo e diverso da 0", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        a = Math.Sqrt(a);
                        
                        if (!double.TryParse(txtB_Q.Text, out b) || b <= 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b, positivo e diverso da 0", "parametro b");
                            txtB_Q.Focus();
                            return;
                        }
                        b = Math.Sqrt(b);

                        if (a == b)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a diverso da b", "parametri a, b");
                            txtA_M.Focus();
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

                        if (!double.TryParse(txtVetX.Text, out vetX))
                        {
                            MessageBox.Show("Inserisci correttamente la X del vettore", "parametro vetX");
                            txtVetX.Focus();
                            return;
                        }

                        if (!double.TryParse(txtVetY.Text, out vetY))
                        {
                            MessageBox.Show("Inserisci correttamente la Y del vettore", "parametro vetY");
                            txtVetY.Focus();
                            return;
                        }
                        
                        chart.ChartAreas[0].AxisX.Minimum = min + vetX;
                        chart.ChartAreas[0].AxisX.Maximum = max + vetX;
                        
                        chart.ChartAreas[0].AxisY.Minimum = min + vetY;
                        chart.ChartAreas[0].AxisY.Maximum = max + vetY;
                        
                        if (iperbole)
                        {
                            if (serie[chart.Series.Count - 2].Points.Count >
                                0) //se la serie è già stata caricata andiamo a pulirla
                                serie[chart.Series.Count - 2].Points.Clear();
                        }
                        else if (serie[chart.Series.Count - 1].Points.Count > 0)
                                serie[chart.Series.Count - 1].Points.Clear();

                        if (!iperbole) //se stiamo creando una iperbole ed è la prima che la creiamo allora dobbiamo creare una nuova serie di appoggio per fare la seconda parte
                        {
                            serie.Add(new Series());
                            chart.Series.Add(new Series());
                            serie[chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                            Color colore = serie[chart.Series.Count - 2].Color;
                            serie[chart.Series.Count - 1].Color = colore;
                        }
                        else if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;
                        
                        if (radioBtnFuochiX.Checked)
                        {
                            listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "x²/" + a + "² - y²/" + b + "² = 1";
                            
                            for (double theta = -Math.PI; theta <= Math.PI; theta += 0.1)
                            {
                                double x = a * Math.Cosh(theta);
                                double y = b * Math.Sinh(theta);

                                if (Math.Abs(x / a) >= 1 || Math.Abs(y / b) >= 1)
                                {
                                    serie[chart.Series.Count - 2].Points.AddXY(x + vetX, y + vetY);
                                }
                            }
                            
                            for (double theta = -Math.PI; theta <= Math.PI; theta += 0.1)
                            {
                                double x = a * Math.Cosh(theta);
                                double y = b * Math.Sinh(theta);

                                if (Math.Abs(x / a) >= 1 || Math.Abs(y / b) >= 1)
                                {
                                    serie[chart.Series.Count - 1].Points.AddXY(-x + vetX, y + vetY);
                                }
                            }
                        }
                        else
                        {
                            listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "x²/" + a + "² - y²/" + b + "² = -1";

                            for (double x = min; x <= max; x += 0.1)
                            {
                                double y = Math.Sqrt(Math.Pow(a, 2) +
                                                      (Math.Pow(a, 2) / Math.Pow(b, 2)) * Math.Pow(x, 2));
                                serie[chart.Series.Count - 2].Points.AddXY(x + vetX, y + vetY);
                            }

                            for (double x = min; x <= max; x += 0.1)
                            {
                                double y = -Math.Sqrt(Math.Pow(a, 2) +
                                                       (Math.Pow(a, 2) / Math.Pow(b, 2)) * Math.Pow(x, 2));
                                serie[chart.Series.Count - 1].Points.AddXY(x + vetX, y + vetY);
                            }
                        }
                        
                        chart.Series[chart.Series.Count - 2] = serie[chart.Series.Count - 2]; //assegnamo alla serie di chart in penultima posizione la serie in penultima posizione appena caricata con tutti i punti
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1]; //assegnamo alla serie di chart in ultima posizione la serie in ultima posizione appena caricata con tutti i punti
                        break;
                    
                    case 6: //iperebole equilatera
                        if (!double.TryParse(txtA_M.Text, out a))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di a", "parametro a");
                            txtA_M.Focus();
                            return;
                        }
                        
                        if (!double.TryParse(txtB_Q.Text, out b))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di b", "parametro b");
                            txtB_Q.Focus();
                            return;
                        }
                        
                        if (!double.TryParse(txtC.Text, out c) || c == 0)
                        {
                            MessageBox.Show("Inserisci correttamente il valore di c, dev'essere anche diverso da 0", "parametro b");
                            txtC.Focus();
                            return;
                        }
                        
                        if (!double.TryParse(txtD.Text, out d))
                        {
                            MessageBox.Show("Inserisci correttamente il valore di d", "parametro b");
                            txtD.Focus();
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
                        
                        if (a * d - b * c == 0)
                        {
                            MessageBox.Show("L'operazione: a * d - b * c non può essere uguale a 0", "Errore");
                            txtA_M.Focus();
                            return;
                        }

                        Cx = -(d / c);
                        Cy = a / c;
                        
                        chart.ChartAreas[0].AxisX.Minimum = min + Cx;
                        chart.ChartAreas[0].AxisX.Maximum = max + Cx;
                        
                        chart.ChartAreas[0].AxisY.Minimum = min + Cy;
                        chart.ChartAreas[0].AxisY.Maximum = max + Cy;
                        
                        if (iperbole)
                        {
                            if (serie[chart.Series.Count - 2].Points.Count >
                                0) //se la serie è già stata caricata andiamo a pulirla
                                serie[chart.Series.Count - 2].Points.Clear();
                        }
                        else if (serie[chart.Series.Count - 1].Points.Count > 0)
                                serie[chart.Series.Count - 1].Points.Clear();

                        if (!iperbole) //se stiamo creando una iperbole ed è la prima che la creiamo allora dobbiamo creare una nuova serie di appoggio per fare la seconda parte
                        {
                            serie.Add(new Series());
                            chart.Series.Add(new Series());
                            serie[chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                            Color colore = serie[chart.Series.Count - 2].Color;
                            serie[chart.Series.Count - 1].Color = colore;
                        }
                        else if (serie[chart.Series.Count - 1].Points.Count > 0)
                            serie[chart.Series.Count - 1].Points.Clear();
                        
                        posizioneFigureReale[posizioneFigureReale.Count - 1] = chart.Series.Count - 1;

                        for (double x = min + Cx; x < max + Cx; x += 0.01)
                        {
                            double y = (a * x + b) / (c * x + d);
                            if (x < Cx)
                                serie[chart.Series.Count - 2].Points.AddXY(x, y);
                            else
                                serie[chart.Series.Count - 1].Points.AddXY(x, y);
                        }
                        if (!listBoxFormule.Items.Contains("y = (" + a + "x + " + b + ") / (" + c + "x + " + d + ")"))
                            listBoxFormule.Items[listBoxFormule.Items.Count - 1] = "y = (" + a + "x + " + b + ") / (" + c + "x + " + d + ")";
                        
                        chart.Series[chart.Series.Count - 2] = serie[chart.Series.Count - 2]; //assegnamo alla serie di chart in penultima posizione la serie in penultima posizione appena caricata con tutti i punti
                        chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1]; //assegnamo alla serie di chart in ultima posizione la serie in ultima posizione appena caricata con tutti i punti
                        break;
                    
                    case 7: //esponenziale
                        
                        break;
                }

                if (comboBoxFormule.SelectedIndex == 5 || comboBoxFormule.SelectedIndex == 6) //stiamo dicendo che abbiamo appena creato una iperbole
                    iperbole = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        { 
            //reset per tutti i campi ancora da caricare 
            lblA_M.Visible = false;
            lblB_Q.Visible = false;
            lblC.Visible = false;
            lblD.Visible = false;
            txtD.Visible = false;
            txtD.Text = "";
            radioBtnFuochiX.Visible = false;
            radioBtnFuochiY.Visible = false;
            lblVet.Visible = false;
            txtVetX.Visible = false;
            txtVetX.Text = "";
            txtVetY.Text = "";
            txtVetY.Visible = false;
            
            txtC.Visible = false;
            txtC.Text = "";
            
            txtB_Q.Visible = false;
            txtB_Q.Text = "";
            
            txtA_M.Visible = false;
            txtA_M.Text = "";

            txtMax.Text = "";
            txtMin.Text = "";
            
            listBoxFormule.Items.Clear();
            chart.Series.Clear();
            serie.Clear();
            posizioneFigureReale.Clear();
            
            chart.Series.Add(new Series());
            serie.Add(new Series()); //aggiungiamo una nuova serie alla lista
            serie[chart.Series.Count - 1].ChartType = SeriesChartType.Line; //definiamo il tipo di dati della serie che stiamo creando
            serie[chart.Series.Count - 1].Color = Color.Black;
            
            chart.ChartAreas[0].AxisX.Maximum = 3;
            chart.ChartAreas[0].AxisX.Minimum = -3;
            
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 5;
            
            serie[chart.Series.Count - 1].Points.AddXY(0, 0);
            serie[chart.Series.Count - 1].Points.AddXY(2, 3);
            serie[chart.Series.Count - 1].Points.AddXY(1, 4);
            serie[chart.Series.Count - 1].Points.AddXY(0, 3);
            serie[chart.Series.Count - 1].Points.AddXY(-1, 4);
            serie[chart.Series.Count - 1].Points.AddXY(-2, 3);
            serie[chart.Series.Count - 1].Points.AddXY(0, 0);
            chart.Series[chart.Series.Count - 1] = serie[chart.Series.Count - 1];

            comboBoxFormule.SelectedIndex = -1;
            posizioneFigureReale.Add(0);
            listBoxFormule.Items.Add(""); //aggiungiamo un oggetto alla lista
        }

        private void aggiungiFiguraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxFormule.Items[listBoxFormule.Items.Count - 1].ToString() != "")
            {
                posizioneFigureReale.Add(0);
                comboBoxFormule.SelectedIndex = -1;
                serie.Add(new Series());
                chart.Series.Add(new Series());  
                listBoxFormule.Items.Add("");
                serie[chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                serie[chart.Series.Count - 1].Color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                iperbole = false;
                lblA_M.Visible = false;
                lblB_Q.Visible = false;
                lblC.Visible = false;
                radioBtnFuochiX.Visible = false;
                radioBtnFuochiY.Visible = false;
                lblVet.Visible = false;
                txtVetX.Visible = false;
                txtVetX.Text = "";
                txtVetY.Text = "";
                txtVetY.Visible = false;
                txtC.Visible = false;
                txtC.Text = "";
                txtB_Q.Visible = false;
                txtB_Q.Text = "";
                txtA_M.Visible = false;
                txtA_M.Text = "";
            }
            else
                MessageBox.Show("Prima di creare una nuova funzione da inserire, devi inserirne una qua", "Errore");
        }

        private void eliminaFunzioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxFormule.Items.Count > 1)
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
                    if (verificaSeIperbole(i - 1))
                    {
                        chart.Series.RemoveAt(posizioneFigureReale[i - 1]);
                        chart.Series.RemoveAt(posizioneFigureReale[i - 1] - 1);
                        serie.RemoveAt(posizioneFigureReale[i - 1]);
                        serie.RemoveAt(posizioneFigureReale[i - 1] - 1);
                        if (posizioneFigureReale.Count > i)
                            for (int j = i; j < posizioneFigureReale.Count; j++)
                                    posizioneFigureReale[j] -= 2;
                        posizioneFigureReale.RemoveAt(i - 1);
                    }
                    else
                    {
                        chart.Series.RemoveAt(posizioneFigureReale[i - 1]);
                        serie.RemoveAt(posizioneFigureReale[i - 1]);
                        if (posizioneFigureReale.Count > i)
                            for (int j = i; j < posizioneFigureReale.Count; j++)
                                    posizioneFigureReale[j]--;
                        posizioneFigureReale.RemoveAt(i - 1);
                    }
                    iperbole = false;
                }
            }
            else if (listBoxFormule.Items.Count == 0)
                MessageBox.Show("Non ci sono funzioni da eliminare", "Errore");
            else
                MessageBox.Show("Per eliminare una funzione devi averne almeno due, modifica quell'attuale", "Errore");
        }

        private bool verificaSeIperbole(int i)
        {
            if (i == 0)
            {
                if (posizioneFigureReale[i] == 1)
                    return true;
                else
                    return false;
            }
            else if (posizioneFigureReale[i] - posizioneFigureReale[i - 1] == 2)
                return true;
            else 
                return false;
        }
    }
}