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
    public partial class FormCalcScientifica : Form
    {
        private const int MAX_PARENTESI = 10; //numero massimo di parentesi 9 perchè il primo "strato" dove non ne abbiamo vale 1
        
        ClasseBottoni classe = new ClasseBottoni();
        ListBox listMemoria = new ListBox();
        Button btnCancellaCronologia = new Button();
        
        List<double>[] vetNumeri = new List<double>[MAX_PARENTESI];
        List<string>[] vetOperazioni = new List<string>[MAX_PARENTESI];

        private bool visualizzaLYX = false, parentesiChiusa = false, ugualePremuto = false;
        private string stringaOperazione = "";
        private int contParentesi = 0;
        private string n = "0";

        public FormCalcScientifica()
        {
            InitializeComponent();
        }

        private void btnUguale_Click(object sender, EventArgs e)
        {
            bool parentesiTrovata = false;
            int i, ripetizione = 0;
            
            if ((contParentesi == 0 && n != "0") || parentesiChiusa)
            {
                if (!parentesiChiusa && !ugualePremuto && vetOperazioni[0].Count != 0)
                {
                    stringaOperazione += Convert.ToString(n);
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetNumeri[contParentesi].Add(Convert.ToDouble(n));
                }

                parentesiChiusa = false;
                
                for (i = MAX_PARENTESI - 1; i > 0; i--)
                {
                    if (vetNumeri[i].Count != 0)
                    {
                        int j, limite = classe.ricercaParantesi(vetOperazioni[i]);

                        if (limite != -1)
                            parentesiTrovata = true;
                        else
                            limite = 0;
                        
                        for (j = limite; j < vetOperazioni[i].Count; j++)
                        {
                            if (vetOperazioni[i][j] == "^" || vetOperazioni[i][j] == "log" ||
                                vetOperazioni[i][j] == "%")
                            {
                                if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                                {
                                    MessageBox.Show("Errore di calcolo", "Calcolo");
                                    return;
                                }
                                else
                                {
                                    vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                                    vetNumeri[i].RemoveAt(j + 1);
                                    vetOperazioni[i].RemoveAt(j);
                                    ripetizione++;
                                    j--;
                                }
                            }
                        }

                        ripetizione = 0;
                        
                        for (j = limite; j < vetOperazioni[i].Count; j++)
                        {
                            if (vetOperazioni[i][j] == "*" || vetOperazioni[i][j] == "/")
                            {
                                if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                                {
                                    MessageBox.Show("Errore di calcolo", "Calcolo");
                                    return;
                                }
                                else
                                {
                                    vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                                    vetNumeri[i].RemoveAt(j + 1);
                                    vetOperazioni[i].RemoveAt(j);
                                    ripetizione++;
                                    j--;
                                }
                            }
                        }

                        ripetizione = 0;
                        
                        for (j = limite; j < vetOperazioni[i].Count; j++)
                        {
                            if (vetOperazioni[i][j] == "+" || vetOperazioni[i][j] == "-")
                            {
                                if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                                {
                                    MessageBox.Show("Errore di calcolo", "Calcolo");
                                    return;
                                }
                                else
                                {
                                    vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                                    vetNumeri[i].RemoveAt(j + 1);
                                    vetOperazioni[i].RemoveAt(j);
                                    ripetizione++;
                                    j--;
                                }
                            }
                        }

                        ripetizione = 0;

                        if (parentesiTrovata)
                        {
                            vetOperazioni[i].RemoveAt(limite);
                            vetNumeri[i - 1][classe.ricercaNaN(vetNumeri[i - 1])] = vetNumeri[i][limite + 1];
                            vetNumeri[i].RemoveAt(limite + 1);
                        }
                        else
                        {
                            vetNumeri[i - 1][classe.ricercaNaN(vetNumeri[i - 1])] = vetNumeri[i][0];
                            vetNumeri[i].RemoveAt(0);
                        }
                    }

                    if (parentesiTrovata)
                        i++;
                    parentesiTrovata = false;
                }
                ripetizione = 0;
                        
                for (int j = 0; j < vetOperazioni[i].Count; j++)
                {
                    if (vetOperazioni[i][j] == "^" || vetOperazioni[i][j] == "log" ||
                        vetOperazioni[i][j] == "%")
                    {
                        if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                        {
                            MessageBox.Show("Errore di calcolo", "Calcolo");
                            return;
                        }
                        else
                        {
                            vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                            vetNumeri[i].RemoveAt(j + 1);
                            vetOperazioni[i].RemoveAt(j);
                            ripetizione++;
                            j--;
                        }
                    }
                }

                ripetizione = 0;
                        
                for (int j = 0; j < vetOperazioni[i].Count; j++)
                {
                    if (vetOperazioni[i][j] == "*" || vetOperazioni[i][j] == "/")
                    {
                        if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                        {
                            MessageBox.Show("Errore di calcolo", "Calcolo");
                            return;
                        }
                        else
                        {
                            vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                            vetNumeri[i].RemoveAt(j + 1);
                            vetOperazioni[i].RemoveAt(j);
                            ripetizione++;
                            j--;
                        }
                    }
                }

                ripetizione = 0;
                        
                for (int j = 0; j < vetOperazioni[i].Count; j++)
                {
                    if (vetOperazioni[i][j] == "+" || vetOperazioni[i][j] == "-")
                    {
                        if (double.IsNaN(classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1])))
                        {
                            MessageBox.Show("Errore di calcolo", "Calcolo");
                            return;
                        }
                        else
                        {
                            vetNumeri[i][j] = classe.calcolo(vetOperazioni[i][j], vetNumeri[i][j], vetNumeri[i][j + 1]);
                            vetNumeri[i].RemoveAt(j + 1);
                            vetOperazioni[i].RemoveAt(j);
                            ripetizione++;
                            j--;
                        }
                    }
                }
                  
                if (vetNumeri[0].Count() != 0)
                {
                    txtIO.Text = vetNumeri[0][0].ToString();
                    listMemoria.Items.Add(stringaOperazione);
                    listMemoria.Items.Add("= " + txtIO.Text);
                }
            }
            else if (contParentesi == 0)
                MessageBox.Show("Prima di calcolare il risultato devi chiudere tutte le parentese aperte", "Parentesi");
            else
                MessageBox.Show("Prima di calcolare il risultato devi inserire l'ultimo numero", "Calcolo");

            ugualePremuto = true;
        }

        private void btnConvertitori_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            txtIO.Text = classe.converti(btn.Text, txtIO);
            n = txtIO.Text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            stringaOperazione = "";
            txtOperazioneIntera.Text = "0";
            txtIO.Text = "0";
            contParentesi = 0;
            lblParentesiAperte.Text = Convert.ToString(contParentesi);
            n = "0";
            
            for (int i = 0; i < MAX_PARENTESI; i++)
            {
                vetNumeri[i] = new List<double>();
                vetOperazioni[i] = new List<string>();
            }

            parentesiChiusa = false;
        }
        private void btnOperazione_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if ((n != "0" || parentesiChiusa) && !ugualePremuto)
            {
                if (!parentesiChiusa)
                {
                    stringaOperazione += Convert.ToString(n);
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetNumeri[contParentesi].Add(Convert.ToDouble(n));
                }
                if (btn.Text == "lyx")
                {
                    stringaOperazione += "log";
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add("log");
                }
                else if (btn.Text == "xʸ")
                {
                    stringaOperazione += "^";
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add("^");
                }
                else if (btn.Text == "ʸ√x")
                {
                    stringaOperazione += "^(1/";
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add("^");
                    vetNumeri[contParentesi].Add(double.MaxValue);
                    contParentesi++;
                    lblParentesiAperte.Text = Convert.ToString(contParentesi);
                    vetNumeri[contParentesi].Add(1);
                    vetOperazioni[contParentesi].Add("/");
                }
                else if (btn.Text == "exp")
                {
                    stringaOperazione += "*10^";
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add("*");
                    vetNumeri[contParentesi].Add(10);
                    vetOperazioni[contParentesi].Add("^");
                }
                else if (btn.Text == "mod")
                {
                    stringaOperazione += "%";
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add("%");
                }
                else
                {
                    stringaOperazione += btn.Text;
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetOperazioni[contParentesi].Add(btn.Text);
                }
                n = "0";
                txtIO.Text = "0";
                parentesiChiusa = false;
            }
        }
        private void btnAssumiNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (!parentesiChiusa)
            {
                if (ugualePremuto)
                {
                    btnReset_Click(sender, e);
                    ugualePremuto = false;
                }
                
                if (n != "0")
                    n += btn.Text;
                else 
                    n = btn.Text;
                txtIO.Text = n;
            }
            else
                MessageBox.Show("Prima di mettere un numero devi premere l'operazione che vuoi fare", "Numeri");
        }

        private void btnParentesiAperta_Click(object sender, EventArgs e)
        { 
            if (n == "0" && contParentesi < MAX_PARENTESI - 1 && !parentesiChiusa)
            {
                vetNumeri[contParentesi].Add(double.NaN);
                contParentesi++;
                if (vetOperazioni[contParentesi].Count != 0)
                    vetOperazioni[contParentesi].Add("parentesi");
                stringaOperazione += "(";
                txtOperazioneIntera.Text = stringaOperazione;
                lblParentesiAperte.Text = Convert.ToString(contParentesi);
            }
            else if (contParentesi == MAX_PARENTESI - 1)
                MessageBox.Show($"Hai raggiunto il massimo numero di parentesi ({MAX_PARENTESI - 1})", "Parentesi");
            else
                MessageBox.Show("Prima di mettere una parentesi aperta devi premere l'operazione che vuoi fare", "Parentesi");
        }

        private void btnParentesiChiusa_Click(object sender, EventArgs e)
        {
            if ((n != "0" && contParentesi != 0) || (parentesiChiusa && contParentesi != 0))
            {
                if (n != "0" && contParentesi != 0)
                {
                    stringaOperazione += Convert.ToString(n);
                    txtOperazioneIntera.Text = stringaOperazione;
                    vetNumeri[contParentesi].Add(Convert.ToDouble(n));
                }
                n = "0";
                txtIO.Text = "0";
                contParentesi--;
                stringaOperazione += ")";
                txtOperazioneIntera.Text = stringaOperazione;
                lblParentesiAperte.Text = Convert.ToString(contParentesi);
                parentesiChiusa = true;
            }
            else if (n != "0")
                MessageBox.Show("Prima di mettere una parentesi chiusa devi digitare un numero", "Parentesi");
            else if (contParentesi == 0)
                MessageBox.Show("Non puoi mettere una parentesi chiusa senza averne messa una aperta", "Parentesi");
        }
        
        
        private void btnMemoria_Click(object sender, EventArgs e)
        {
            if (listMemoria.Visible)
            {
                listMemoria.Visible = false;
                btnCancellaCronologia.Visible = false;
            }
            else
            {
                btnCancellaCronologia.Visible = true;
                listMemoria.Visible = true;
            }
        }

        private void btnCancellaCronologia_Click(object sender, EventArgs e)
        {
            listMemoria.Items.Clear();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            Hide();
        }

        private void FormCalcScientifica_Load(object sender, EventArgs e)
        {
            listMemoria.Visible = false;
            listMemoria.Location = new Point(11, 150);
            listMemoria.Size = new Size(272, 300);
            listMemoria.Font = new Font("Arial", 10);
            listMemoria.HorizontalScrollbar = true;

            btnCancellaCronologia.Visible = false;
            btnCancellaCronologia.Size = new Size(60, 60);
            btnCancellaCronologia.Location = new Point(215, 380);
            btnCancellaCronologia.BackgroundImage = Properties.Resources.cestino;
            btnCancellaCronologia.BackgroundImageLayout = ImageLayout.Zoom;
            btnCancellaCronologia.Click += new EventHandler(btnCancellaCronologia_Click);

            this.Controls.Add(listMemoria);
            this.Controls.Add(btnCancellaCronologia);

            this.Controls.SetChildIndex(listMemoria, 0);
            this.Controls.SetChildIndex(btnCancellaCronologia, 0);

            for (int i = 0; i < MAX_PARENTESI; i++)
            {
                vetNumeri[i] = new List<double>();
                vetOperazioni[i] = new List<string>();
            }
        }

        private void btnSecondiTasti_Click(object sender, EventArgs e)
        {
            if (btnSecondiTasti.BackColor == Color.Fuchsia)
            {
                btnSecondiTasti.BackColor = Color.White;
                btnCambiato1.Text = "x²";
                btnCambiato2.Text = "√x";
                btnCambiato3.Text = "xʸ";
                btnCambiato4.Text = "10ˣ";
                btnCambiato5.Text = "log";
                btnCambiato5.Click -= new EventHandler(btnOperazione_Click);
                btnCambiato5.Click += new EventHandler(btnConvertitori_Click);
                btnCambiato6.Text = "In";
            }
            else
            {
                btnSecondiTasti.BackColor = Color.Fuchsia;
                btnCambiato1.Text = "x³";
                btnCambiato2.Text = "∛x";
                btnCambiato3.Text = "ʸ√x";
                btnCambiato4.Text = "2ˣ";
                btnCambiato5.Text = "lyx";
                btnCambiato5.Click -= new EventHandler(btnConvertitori_Click);
                btnCambiato5.Click += new EventHandler(btnOperazione_Click);
                btnCambiato6.Text = "eˣ";
            }

            if (!visualizzaLYX)
            {
                MessageBox.Show("Questo bottone permette di fare il logaritmo per il numero x in base y", "Bottone lyx");
                visualizzaLYX = true;
                btnCambiato5.Focus();
            }
        }
        
        private void FormCalcScientifica_FormClosed(object sender, FormClosedEventArgs e)
        {
            classe.chiudiTutto();
        }
    }
}
