using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

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
                odkurzacz.S_move();
                //odkurzacz.move3();
                label1.Text = odkurzacz.ruch.ToString();
                label5.Text = odkurzacz.Krok.ToString();
                label6.Text = odkurzacz.RLewo.ToString();
                label7.Text = odkurzacz.RPrawo.ToString();

                //brud.rysuj_brud(panel1.CreateGraphics(), new SolidBrush(Color.Red));


                //label1.Text = Brud.wynik.ToString();

                //brud.Zbieranie(odkurzacz.x, odkurzacz.y,panel1.CreateGraphics(), new SolidBrush(Color.Green));

                //if (mapa.IloscBrudu==Brud.wynik)
                //{
                //    //MessageBox.Show("Brak brudu");
                //    Application.Exit();
                //}
            }
            else
            { 
                WyswietlKomunukat();
            }
        }

        private void WyswietlKomunukat()
        {
            FontFamily fontFamily1 = new FontFamily("Arial");
            Font f = new Font(fontFamily1, 15);
            Brush b = new SolidBrush(Color.Red);
            panel1.CreateGraphics().DrawString("Symulacja zatrzymana", f, b, 40, 125);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
                czy_aktywna = true;
            

            odkurzacz = new Odkurzacz(panel1.Width, panel1.Height);
           
            
            //brud = new Brud(odkurzacz.segment);
        }
        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (czy_aktywna == false)
            {
                
                czy_aktywna = true;
                mapa.LiczbaCzystychPol = 0;
                mapa.LiczbaBrudnychPol = 0;
                mapa.LiczbaScian = 0;
            }
            else
            {
                mapa.WyczyszczonePola();
                CzystePola.Text = mapa.LiczbaCzystychPol.ToString();
                BrudnePola.Text = mapa.LiczbaBrudnychPol.ToString();
                Wielkosc.Text = Math.Round(mapa.ProcentCzystosci, 2) + "%";
                czy_aktywna = false;
            }
            
        }
     
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.ResetPlanszy();
            czy_aktywna = true;
            odkurzacz = new Odkurzacz(panel1.Width, panel1.Height);
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //mapa.SprawdzIloscBrudu();
            //Brud.ilosc = mapa.IloscBrudu;
        }

    

        private void WyborPlanszy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
        private void WielePokoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.Plansza = mapa.Plansza1;
        }

        private void JadalniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.Plansza = mapa.Plansza2;
        }

        private void SalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.Plansza = mapa.Plansza3;
        }

      

        private void SprawdzWyczyszczenie_Click(object sender, EventArgs e)
        {
            if (czy_aktywna == false)
            {
                mapa.WyczyszczonePola();
                CzystePola.Text = mapa.LiczbaCzystychPol.ToString();
                BrudnePola.Text = mapa.LiczbaBrudnychPol.ToString();
                Wielkosc.Text = Math.Round(mapa.ProcentCzystosci,2) +"%";
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
