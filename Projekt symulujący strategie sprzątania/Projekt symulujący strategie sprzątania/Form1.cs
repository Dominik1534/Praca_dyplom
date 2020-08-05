using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_symulujący_strategie_sprzątania
{
    public partial class Form1 : Form
    {
        public bool czy_aktywna;
        private  Odkurzacz odkurzacz;
        private Brud brud;
        public static string TextIlosc;

       
        public Form1()
        {
            InitializeComponent();
            czy_aktywna = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (czy_aktywna)
            {
                panel1.CreateGraphics().Clear(Color.Black);
                
                odkurzacz.move();
                odkurzacz.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.Aqua));
                brud.rysuj_brud(panel1.CreateGraphics(), new SolidBrush(Color.Red));

                if (brud.czy_nowy_brud(odkurzacz.x[0], odkurzacz.y[0]))
                {
                    label1.Text = Brud.wynik.ToString();
                }
                brud.Zbieranie(odkurzacz.x[0], odkurzacz.y[0],panel1.CreateGraphics(), new SolidBrush(Color.Green));

            }
            else
            {
                FontFamily fontFamily1 = new FontFamily("Arial");
                Font f = new Font(fontFamily1, 15);
                Brush b = new SolidBrush(Color.Aqua);
                panel1.CreateGraphics().DrawString("Naciśnij Start",f,b,80,135);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            czy_aktywna = true;
            odkurzacz = new Odkurzacz(panel1.Width, panel1.Height);
            brud = new Brud(odkurzacz.segment);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Up) odkurzacz.ruch = "gora";
            if (e.KeyCode == Keys.Down) odkurzacz.ruch = "dol";
            if (e.KeyCode == Keys.Right) odkurzacz.ruch = "prawo";
            if (e.KeyCode == Keys.Left) odkurzacz.ruch = "lewo";
        }

        private void IloscButton_Click(object sender, EventArgs e)
        {
            TextIlosc = IloscBrudu.Text;
            Brud.IlośćBrudu(TextIlosc);
            
          
        }
    }
}
