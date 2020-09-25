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
        private Sciany sciany=new Sciany();
        private Trasa trasa = new Trasa();
        public static string TextIlosc;
        public static Mapa mapa = new Mapa();

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
                sciany.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.Orange));
                trasa.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.White));
                odkurzacz.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.Aqua));
                odkurzacz.move3();
                brud.rysuj_brud(panel1.CreateGraphics(), new SolidBrush(Color.Red));

                
                label1.Text = Brud.wynik.ToString();
              
                brud.Zbieranie(odkurzacz.x, odkurzacz.y,panel1.CreateGraphics(), new SolidBrush(Color.Green));
               // odkurzacz.Ruch1();
                if (mapa.IloscBrudu==Brud.wynik)
                {
                    //MessageBox.Show("Brak brudu");
                    Application.Exit();
                }
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
         
        }

       
        /*1-prawo
             * 2-lewo 3
             * 3-gora 4
             * 4-dol 2
             */
      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            mapa.SprawdzIloscBrudu();
            Brud.ilosc = mapa.IloscBrudu;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
