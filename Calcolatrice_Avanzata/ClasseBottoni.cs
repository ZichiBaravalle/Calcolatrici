using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcolatrice_Avanzata
{
    public class ClasseBottoni
    {
        public bool verificaCondizione(int ripetizione, int j, int lun)
        {
            if (ripetizione == 0)
            {
                if (j < lun)
                    return true;
                else
                    return false;
            }
            else
            {
                if (j < lun)
                    return true;
                else
                    return false;
            }
        }
        
        public int ricercaParantesi(List<string> vet)
        {
            int i = -1;
            
            for (int j = 0; j < vet.Count; j++)
                if (vet[j] == "parentesi")
                    i = j;
            
            return i;
        }
        
        public int ricercaNaN(List<double> vet)
        {
            int posNaN = 0;
            
            for (int i = 0; i < vet.Count; i++)
                if (double.IsNaN(vet[i]))
                    posNaN = i;
            
            return posNaN;
        }
        
        public void calcolo(string ope, ref double n1, double n2, TextBox txtIO, bool stampa)
        {
            switch (ope)
            {
                case "+":
                    n1 += n2;
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                case "-":
                    n1 -= n2;
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                case "*":
                    n1 *= n2;
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;

                case "/":
                    if (n2 != 0)
                    {
                        n1 /= n2;
                        if (stampa)
                            txtIO.Text = Convert.ToString(n1);
                    }
                    else
                    {
                        txtIO.Text = "Impossibile";
                    }
                    break;
                
                case "mod":
                    n1 %= n2;
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;

                case "e+":
                    n1 *= Math.Pow(10, n2);
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                case "xʸ":
                    n1 = Math.Pow(n1, n2);
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                case "log base y di x":
                    n1 = Math.Log(n2, n1);
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                case "ʸ√x":
                    n1 = Math.Pow(n1, 1 / n2);
                    if (stampa)
                        txtIO.Text = Convert.ToString(n1);
                    break;
                
                default:
                    break;
            }
        }
        
        public double calcolo(string ope, double n1, double n2)
        {
            double ris = 0;
            
            switch (ope)
            {
                case "+":
                    ris = n1 + n2;
                    break;
    
                case "-":
                    ris = n1 - n2;
                    break;
    
                case "*":
                    ris = n1 * n2;
                    break;

                case "/":
                    if (n2 != 0)
                        ris = n1 / n2;
                    else
                        ris = Double.NaN;
                    break;
    
                case "%":
                    ris = n1 % n2;
                    break;
                
                case "^":
                    ris = Math.Pow(n1, n2);
                    break;
                
                case "log":
                    ris = Math.Log(n1, n2);
                    break;
            }
            
            return ris;
        }

        public string converti(string text, TextBox txtIO)
        {
            double ris = 0;

            switch (text)
            {
                case "e":
                    ris = Math.E;
                    break;

                case "π":
                    ris = Math.PI;
                    break;

                case "|x|":
                    ris = Math.Abs(Convert.ToDouble(txtIO.Text));
                    break;

                case "%":
                    ris = Convert.ToDouble(txtIO.Text) / 100;
                    break;

                case "+/-":
                    ris = Convert.ToDouble(txtIO.Text) * -1;
                    break;

                case "x²":
                    ris = Math.Pow(Convert.ToDouble(txtIO.Text), 2);
                    break;

                case "⅟x":
                    ris = 1 / Convert.ToDouble(txtIO.Text);
                    break;

                case "√x":
                    ris = Math.Sqrt(Convert.ToDouble(txtIO.Text));
                    break;

                case "←":
                    if (txtIO.Text.Length > 1)
                        ris = Convert.ToDouble(txtIO.Text.Substring(0, txtIO.Text.Length - 1));
                    else
                        ris = 0;
                    break;

                case ",":
                    return txtIO.Text + ",";

                case "10ˣ":
                    ris = Math.Pow(10, Convert.ToDouble(txtIO.Text));
                    break;

                case "log":
                    ris = Math.Log10(Convert.ToDouble(txtIO.Text));
                    break;

                case "In":
                    ris = Math.Log(Convert.ToDouble(txtIO.Text));
                    break;
                
                case "x³":
                    ris = Math.Pow(Convert.ToDouble(txtIO.Text), 3);
                    break;
                
                case "∛x":
                    ris = Math.Pow(Convert.ToDouble(txtIO.Text), 1.0 / 3.0);
                    break;

                case "2ˣ":
                    ris = Math.Pow(2, Convert.ToDouble(txtIO.Text));
                    break;
                
                case "eˣ":
                    ris = Math.Pow(Math.E, Convert.ToDouble(txtIO.Text));
                    break;
                
                default:
                    break;
            }

            return Convert.ToString(ris);
        }
    }
}
