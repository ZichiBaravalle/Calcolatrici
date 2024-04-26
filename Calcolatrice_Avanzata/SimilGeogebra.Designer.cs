using System.ComponentModel;

namespace Calcolatrice_Avanzata
{
    partial class SimilGeogebra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimilGeogebra));
            this.comboBoxFormule = new System.Windows.Forms.ComboBox();
            this.lblGrandezza = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblPuntoeVirgola = new System.Windows.Forms.Label();
            this.listBoxFormule = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenera = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.gestioneFunzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiFiguraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaFunzioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxFormule
            // 
            this.comboBoxFormule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFormule.FormattingEnabled = true;
            this.comboBoxFormule.Items.AddRange(new object[] { "RETTA", "PARABOLA", "PARABOLA CORICATA", "CIRCONFERENZA", "ELLISSE", "IPERBOLE", "IPERBOLE QUADRILATERA" });
            this.comboBoxFormule.Location = new System.Drawing.Point(182, 28);
            this.comboBoxFormule.Name = "comboBoxFormule";
            this.comboBoxFormule.Size = new System.Drawing.Size(287, 28);
            this.comboBoxFormule.TabIndex = 34;
            this.comboBoxFormule.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblGrandezza
            // 
            this.lblGrandezza.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandezza.Location = new System.Drawing.Point(16, 313);
            this.lblGrandezza.Name = "lblGrandezza";
            this.lblGrandezza.Size = new System.Drawing.Size(202, 23);
            this.lblGrandezza.TabIndex = 39;
            this.lblGrandezza.Text = "Grandezza della figura:";
            // 
            // lblMin
            // 
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(250, 342);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(48, 23);
            this.lblMin.TabIndex = 40;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(372, 342);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(49, 23);
            this.lblMax.TabIndex = 41;
            this.lblMax.Text = "Max";
            // 
            // txtMin
            // 
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.Location = new System.Drawing.Point(224, 310);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(100, 29);
            this.txtMin.TabIndex = 42;
            // 
            // txtMax
            // 
            this.txtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.Location = new System.Drawing.Point(351, 310);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 29);
            this.txtMax.TabIndex = 43;
            // 
            // lblPuntoeVirgola
            // 
            this.lblPuntoeVirgola.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntoeVirgola.Location = new System.Drawing.Point(330, 313);
            this.lblPuntoeVirgola.Name = "lblPuntoeVirgola";
            this.lblPuntoeVirgola.Size = new System.Drawing.Size(15, 23);
            this.lblPuntoeVirgola.TabIndex = 44;
            this.lblPuntoeVirgola.Text = ";";
            // 
            // listBoxFormule
            // 
            this.listBoxFormule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFormule.FormattingEnabled = true;
            this.listBoxFormule.ItemHeight = 20;
            this.listBoxFormule.Location = new System.Drawing.Point(17, 383);
            this.listBoxFormule.Name = "listBoxFormule";
            this.listBoxFormule.ScrollAlwaysVisible = true;
            this.listBoxFormule.Size = new System.Drawing.Size(308, 144);
            this.listBoxFormule.TabIndex = 47;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(424, 383);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 52);
            this.btnReset.TabIndex = 48;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenera
            // 
            this.btnGenera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenera.Location = new System.Drawing.Point(424, 475);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(155, 52);
            this.btnGenera.TabIndex = 50;
            this.btnGenera.Text = "GENERA";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.btnMenu, this.gestioneFunzioniToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(634, 25);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(53, 21);
            this.btnMenu.Text = "Menù";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // gestioneFunzioniToolStripMenuItem
            // 
            this.gestioneFunzioniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aggiungiFiguraToolStripMenuItem, this.eliminaFunzioneToolStripMenuItem });
            this.gestioneFunzioniToolStripMenuItem.Name = "gestioneFunzioniToolStripMenuItem";
            this.gestioneFunzioniToolStripMenuItem.Size = new System.Drawing.Size(113, 21);
            this.gestioneFunzioniToolStripMenuItem.Text = "Gestione Funzioni";
            // 
            // aggiungiFiguraToolStripMenuItem
            // 
            this.aggiungiFiguraToolStripMenuItem.Name = "aggiungiFiguraToolStripMenuItem";
            this.aggiungiFiguraToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aggiungiFiguraToolStripMenuItem.Text = "Aggiungi Funzione";
            this.aggiungiFiguraToolStripMenuItem.Click += new System.EventHandler(this.aggiungiFiguraToolStripMenuItem_Click);
            // 
            // eliminaFunzioneToolStripMenuItem
            // 
            this.eliminaFunzioneToolStripMenuItem.Name = "eliminaFunzioneToolStripMenuItem";
            this.eliminaFunzioneToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.eliminaFunzioneToolStripMenuItem.Text = "Elimina Funzione";
            this.eliminaFunzioneToolStripMenuItem.Click += new System.EventHandler(this.eliminaFunzioneToolStripMenuItem_Click);
            // 
            // SimilGeogebra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 541);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.listBoxFormule);
            this.Controls.Add(this.lblPuntoeVirgola);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblGrandezza);
            this.Controls.Add(this.comboBoxFormule);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 580);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 580);
            this.Name = "SimilGeogebra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SimilGeogebra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimilGeogebra_FormClosed);
            this.Load += new System.EventHandler(this.SimilGeogebra_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem eliminaFunzioneToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem gestioneFunzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiFiguraToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.Label lblMin;

        private System.Windows.Forms.Button btnGenera;

        private System.Windows.Forms.Label lblPuntoeVirgola;

        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.ListBox listBoxFormule;


        private System.Windows.Forms.Label lblMax;

        private System.Windows.Forms.Label lblGrandezza;

        private System.Windows.Forms.ComboBox comboBoxFormule;

        private System.Windows.Forms.ToolStripMenuItem btnMenu;

        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;

        #endregion
    }
}