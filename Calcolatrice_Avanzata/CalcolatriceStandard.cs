using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calcolatrice_Avanzata;

namespace Calcolatrice_Avanzata
{
    public partial class FormCalcStandard : Form
    {
        ClasseBottoni classe = new ClasseBottoni();
        private ListBox listMemoria = new ListBox();
        private Button btnCancellaCronologia = new Button();

        string operazione = " ", stringaOperazione = "";
        double n1 = 0, n2 = 0;
        bool cancella = false;

        public FormCalcStandard()
        {
            InitializeComponent();
        }

        private void btnNumeri_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (cancella)
            {
                txtIO.Text = "0";
                cancella = false;
            }

            if (txtIO.Text == "0" || txtIO.Text == "+" || txtIO.Text == "-" || txtIO.Text == "*" || txtIO.Text == "/")
                txtIO.Text = btn.Text;
            else
                txtIO.Text += btn.Text;
        }

        private void btnUguale_Click(object sender, EventArgs e)
        {
            if (operazione == " ")
            {
                n1 = 0;
                n2 = 0;
                txtIO.Text = "0";
            }
            else if (double.TryParse(txtIO.Text, out n2))
            {
                if (n2 != 0)
                {
                    classe.calcolo(operazione, ref n1, n2, txtIO, true);
                    stringaOperazione += " " + operazione + " " + n2;
                    stringaOperazione += " =";
                    listMemoria.Items.Add(stringaOperazione);
                    listMemoria.Items.Add(n1.ToString());
                    operazione = " ";
                    n1 = 0;
                    n2 = 0;
                    cancella = true;
                }
            }
        }

        private void btnConvertitori_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtIO.Text != "+" && txtIO.Text != "-" && txtIO.Text != "*" && txtIO.Text != "/" && !cancella)
                txtIO.Text = classe.converti(btn.Text, txtIO);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "C":
                    txtIO.Text = "0";
                    break;

                case "CE":
                    txtIO.Text = "0";
                    operazione = " ";
                    n1 = 0;
                    n2 = 0;
                    cancella = true;
                    break;
            }
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
            this.Hide();
        }

        private void FormCalcStandard_Load(object sender, EventArgs e)
        {
            listMemoria.Visible = false;
            listMemoria.Location = new Point(11, 150);
            listMemoria.Size = new Size(272, 300);
            listMemoria.Font = new Font("Arial", 10);

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
        }

        private void btnOperazione_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (n1 != 0 && operazione != " " && double.TryParse(txtIO.Text, out n2))
            {
                stringaOperazione += " " + operazione + " ";
                operazione = btn.Text;
                txtIO.Text = btn.Text;
                classe.calcolo(operazione, ref n1, n2, txtIO, false);
                stringaOperazione += Convert.ToString(Math.Round(n2, 5));
            }
            else
            {
                if (n1 == 0 && txtIO.Text != "+" && txtIO.Text != "-" && txtIO.Text != "*" && txtIO.Text != "/" &&
                    txtIO.Text != "mod" && txtIO.Text != "e+" && txtIO.Text != "ʸ√x" && txtIO.Text != "xʸ" &&
                    txtIO.Text != "log base y di x")
                {
                    n1 = Convert.ToDouble(txtIO.Text);
                    stringaOperazione = Math.Round(n1, 5).ToString();
                }
                txtIO.Text = btn.Text;
                operazione = btn.Text;
            }
        }
    }
}
