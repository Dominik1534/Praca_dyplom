﻿namespace Projekt_symulujący_strategie_sprzątania
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybórPlanszyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wielePokoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jadalniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybórAlgorytmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.losowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wzdłóżŚcianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CzystePola = new System.Windows.Forms.Label();
            this.BrudnePola = new System.Windows.Forms.Label();
            this.Wielkosc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ponowne_przejscia = new System.Windows.Forms.Label();
            this.Ponowne_przejscia_liczba = new System.Windows.Forms.Label();
            this.Wyjscie = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.losowyZAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 320);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauzaToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.wybórPlanszyToolStripMenuItem,
            this.wybórAlgorytmuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauzaToolStripMenuItem
            // 
            this.pauzaToolStripMenuItem.Name = "pauzaToolStripMenuItem";
            this.pauzaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauzaToolStripMenuItem.Text = "Pauza";
            this.pauzaToolStripMenuItem.Click += new System.EventHandler(this.pauzaToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // wybórPlanszyToolStripMenuItem
            // 
            this.wybórPlanszyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wielePokoiToolStripMenuItem,
            this.jadalniaToolStripMenuItem,
            this.salonToolStripMenuItem});
            this.wybórPlanszyToolStripMenuItem.Name = "wybórPlanszyToolStripMenuItem";
            this.wybórPlanszyToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.wybórPlanszyToolStripMenuItem.Text = "Wybór planszy";
            // 
            // wielePokoiToolStripMenuItem
            // 
            this.wielePokoiToolStripMenuItem.Name = "wielePokoiToolStripMenuItem";
            this.wielePokoiToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.wielePokoiToolStripMenuItem.Text = "Wiele pokoi";
            this.wielePokoiToolStripMenuItem.Click += new System.EventHandler(this.WielePokoiToolStripMenuItem_Click);
            // 
            // jadalniaToolStripMenuItem
            // 
            this.jadalniaToolStripMenuItem.Name = "jadalniaToolStripMenuItem";
            this.jadalniaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.jadalniaToolStripMenuItem.Text = "Jadalnia";
            this.jadalniaToolStripMenuItem.Click += new System.EventHandler(this.JadalniaToolStripMenuItem_Click);
            // 
            // salonToolStripMenuItem
            // 
            this.salonToolStripMenuItem.Name = "salonToolStripMenuItem";
            this.salonToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.salonToolStripMenuItem.Text = "Salon";
            this.salonToolStripMenuItem.Click += new System.EventHandler(this.SalonToolStripMenuItem_Click);
            // 
            // wybórAlgorytmuToolStripMenuItem
            // 
            this.wybórAlgorytmuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.losowyToolStripMenuItem,
            this.smoveToolStripMenuItem,
            this.wzdłóżŚcianToolStripMenuItem,
            this.zMapaToolStripMenuItem,
            this.aToolStripMenuItem,
            this.losowyZAToolStripMenuItem});
            this.wybórAlgorytmuToolStripMenuItem.Name = "wybórAlgorytmuToolStripMenuItem";
            this.wybórAlgorytmuToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.wybórAlgorytmuToolStripMenuItem.Text = "Wybór algorytmu";
            // 
            // losowyToolStripMenuItem
            // 
            this.losowyToolStripMenuItem.Name = "losowyToolStripMenuItem";
            this.losowyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.losowyToolStripMenuItem.Text = "Losowy";
            this.losowyToolStripMenuItem.Click += new System.EventHandler(this.losowyToolStripMenuItem_Click);
            // 
            // smoveToolStripMenuItem
            // 
            this.smoveToolStripMenuItem.Name = "smoveToolStripMenuItem";
            this.smoveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smoveToolStripMenuItem.Text = "S-move";
            this.smoveToolStripMenuItem.Click += new System.EventHandler(this.smoveToolStripMenuItem_Click);
            // 
            // wzdłóżŚcianToolStripMenuItem
            // 
            this.wzdłóżŚcianToolStripMenuItem.Name = "wzdłóżŚcianToolStripMenuItem";
            this.wzdłóżŚcianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wzdłóżŚcianToolStripMenuItem.Text = "Wzdłuż ścian";
            this.wzdłóżŚcianToolStripMenuItem.Click += new System.EventHandler(this.wzdłóżŚcianToolStripMenuItem_Click);
            // 
            // zMapaToolStripMenuItem
            // 
            this.zMapaToolStripMenuItem.Name = "zMapaToolStripMenuItem";
            this.zMapaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zMapaToolStripMenuItem.Text = "Z mapa";
            this.zMapaToolStripMenuItem.Click += new System.EventHandler(this.zMapaToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CzystePola
            // 
            this.CzystePola.AutoSize = true;
            this.CzystePola.Location = new System.Drawing.Point(338, 76);
            this.CzystePola.Name = "CzystePola";
            this.CzystePola.Size = new System.Drawing.Size(13, 13);
            this.CzystePola.TabIndex = 3;
            this.CzystePola.Text = "0";
            // 
            // BrudnePola
            // 
            this.BrudnePola.AutoSize = true;
            this.BrudnePola.Location = new System.Drawing.Point(337, 102);
            this.BrudnePola.Name = "BrudnePola";
            this.BrudnePola.Size = new System.Drawing.Size(13, 13);
            this.BrudnePola.TabIndex = 4;
            this.BrudnePola.Text = "0";
            // 
            // Wielkosc
            // 
            this.Wielkosc.AutoSize = true;
            this.Wielkosc.Location = new System.Drawing.Point(338, 128);
            this.Wielkosc.Name = "Wielkosc";
            this.Wielkosc.Size = new System.Drawing.Size(13, 13);
            this.Wielkosc.TabIndex = 6;
            this.Wielkosc.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Czyste pola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Brudne pola";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Procent Wyczyszczenia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Użyty algorytm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(339, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ilość kroków";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(339, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "-";
            // 
            // Ponowne_przejscia
            // 
            this.Ponowne_przejscia.AutoSize = true;
            this.Ponowne_przejscia.Location = new System.Drawing.Point(338, 142);
            this.Ponowne_przejscia.Name = "Ponowne_przejscia";
            this.Ponowne_przejscia.Size = new System.Drawing.Size(96, 13);
            this.Ponowne_przejscia.TabIndex = 12;
            this.Ponowne_przejscia.Text = "Ponowne przejścia";
            // 
            // Ponowne_przejscia_liczba
            // 
            this.Ponowne_przejscia_liczba.AutoSize = true;
            this.Ponowne_przejscia_liczba.Location = new System.Drawing.Point(338, 155);
            this.Ponowne_przejscia_liczba.Name = "Ponowne_przejscia_liczba";
            this.Ponowne_przejscia_liczba.Size = new System.Drawing.Size(13, 13);
            this.Ponowne_przejscia_liczba.TabIndex = 13;
            this.Ponowne_przejscia_liczba.Text = "0";
            // 
            // Wyjscie
            // 
            this.Wyjscie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Wyjscie.Location = new System.Drawing.Point(465, 324);
            this.Wyjscie.Name = "Wyjscie";
            this.Wyjscie.Size = new System.Drawing.Size(75, 23);
            this.Wyjscie.TabIndex = 14;
            this.Wyjscie.Text = "Wyjscie";
            this.Wyjscie.UseVisualStyleBackColor = true;
            this.Wyjscie.Click += new System.EventHandler(this.Wyjscie_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(458, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Czas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(461, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "-";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(341, 211);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.Value = 500;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(339, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Timer Interval";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(451, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "0";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aToolStripMenuItem.Text = "A*";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // losowyZAToolStripMenuItem
            // 
            this.losowyZAToolStripMenuItem.Name = "losowyZAToolStripMenuItem";
            this.losowyZAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.losowyZAToolStripMenuItem.Text = "Losowy z A*";
            this.losowyZAToolStripMenuItem.Click += new System.EventHandler(this.losowyZAToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 351);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Wyjscie);
            this.Controls.Add(this.Ponowne_przejscia_liczba);
            this.Controls.Add(this.Ponowne_przejscia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Wielkosc);
            this.Controls.Add(this.BrudnePola);
            this.Controls.Add(this.CzystePola);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem wybórPlanszyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wielePokoiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jadalniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salonToolStripMenuItem;
        private System.Windows.Forms.Label CzystePola;
        private System.Windows.Forms.Label BrudnePola;
        private System.Windows.Forms.Label Wielkosc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Ponowne_przejscia;
        private System.Windows.Forms.Label Ponowne_przejscia_liczba;
        private System.Windows.Forms.ToolStripMenuItem wybórAlgorytmuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem losowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wzdłóżŚcianToolStripMenuItem;
        private System.Windows.Forms.Button Wyjscie;
        private System.Windows.Forms.ToolStripMenuItem zMapaToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem losowyZAToolStripMenuItem;
    }
}

