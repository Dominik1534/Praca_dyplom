using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Projekt_symulujący_strategie_sprzątania
{
    public partial class Form1 : Form
    {
        public bool czy_aktywna;
        private Odkurzacz odkurzacz;

        private Sciany sciany = new Sciany();
        private Trasa trasa = new Trasa();
        public static string TextIlosc;
        public static Mapa mapa = new Mapa();
        public int Mapa;
        private int NrAlgorytmu;
        private bool Ogranicznik_odswierzania;
        Stopwatch stopWatch = new Stopwatch();
        public int Nr = 0;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public Thread th;
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;

        public Form1()
        {
            InitializeComponent();
            czy_aktywna = false;
            timer1.Enabled = true;
           

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            mapa.Plansza = mapa.Plansza2;
            t.Interval = 15000;
            pauzaToolStripMenuItem.Enabled = false;
            restartToolStripMenuItem.Enabled = false;
            t.Tick += new EventHandler(StartThread);
            t.Start();

        }
        private void Odswierz()
        {
            Ekran_Symylacji.CreateGraphics().Clear(Color.White);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
            if (czy_aktywna)
            {
                restartToolStripMenuItem.Enabled = false;
                wybórAlgorytmuToolStripMenuItem.Enabled = false;
                wybórPlanszyToolStripMenuItem.Enabled = false;
                if (Ogranicznik_odswierzania == true)
                {
                    Odswierz();
                    Ogranicznik_odswierzania = false;
                }
                sciany.Rysuj(Ekran_Symylacji.CreateGraphics(), new SolidBrush(Color.Gray), odkurzacz.segment);

                trasa.Rysuj(Ekran_Symylacji.CreateGraphics(), new SolidBrush(Color.White), odkurzacz.segment);

                odkurzacz.Rysuj(Ekran_Symylacji.CreateGraphics(), new SolidBrush(Color.Black));

                if (odkurzacz.KoniecSprzatania == true)
                {
                    czy_aktywna = false;
                }


                switch (NrAlgorytmu)
                {
                    case 1:
                        odkurzacz.Random_move2();
                        break;
                    case 2:
                        odkurzacz.S_move();
                        break;
                    case 3:
                        odkurzacz.Wall_move();
                        break;
                    case 4:
                        odkurzacz.Map_move();
                        break;
                    case 5:
                        odkurzacz.Najblizszy_Bialy();
                        break;
                    case 6:
                        odkurzacz.Move_choise();
                        break;
                    default:
                        odkurzacz.Random_move2();
                        break;

                }
                odkurzacz.Trasa_Cieplna();
                Statystyki();
                Stoper();
            }
            else
            {
                WyswietlKomunukat();
            }
        }

        public void TakeScreenShot()
        {
            if (czy_aktywna == true)
            {
                Nr++;
                var CurrentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine(CurrentDirectory);
                bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save(AppDomain.CurrentDomain.BaseDirectory + $"{label7.Text}_{Nr}.Png", ImageFormat.Png);
                th.Abort();
            }
        }

        public void StartThread(object sender, EventArgs e)
        {
            if (czy_aktywna == true)
            {
                PauzaProgramu();
                th = new Thread(new ThreadStart(TakeScreenShot));
                PauzaProgramu();
                th.Start();
            }
        }

        private void Statystyki()
        {
            switch (NrAlgorytmu)
            {
                case 1:
                    label7.Text = "Losowych odbić";
                    break;
                case 2:
                    label7.Text = "Ruch S";
                    break;
                case 3:
                    label7.Text = "Wzdłóż ścian";
                    break;
                case 4:
                    label7.Text = "Z pamięcia trasy";
                    break;
                case 5:
                    label7.Text = "A Star";
                    break;
                case 6:
                    label7.Text = "Losowy z A Star";
                    break;
                default:
                    label7.Text = "Losowych odbić";
                    break;
            }
            label5.Text = odkurzacz.Ruchy.ToString();

            Ponowne_przejscia_liczba.Text = odkurzacz.Ponowne_przejscia.ToString();

            mapa.LiczbaCzystychPol = 0;
            mapa.LiczbaBrudnychPol = 0;
            mapa.LiczbaScian = 0;

            mapa.WyczyszczonePola();
            CzystePola.Text = mapa.LiczbaCzystychPol.ToString();
            BrudnePola.Text = mapa.LiczbaBrudnychPol.ToString();
            Wielkosc.Text = Math.Round(mapa.ProcentCzystosci, 2) + "%";

        }

        private void WyswietlKomunukat()
        {
            FontFamily fontFamily1 = new FontFamily("Arial");
            Font f = new Font(fontFamily1, 15);
            Brush b = new SolidBrush(Color.Red);
            Ekran_Symylacji.CreateGraphics().DrawString("Symulacja zatrzymana", f, b, 50, 150);
        }
        private void Stoper()
        {
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}",
                 ts.Minutes, ts.Seconds
                );
            LicznikCzasu.Text = elapsedTime;         
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            stopWatch.Start();
            pauzaToolStripMenuItem.Enabled = true;
            restartToolStripMenuItem.Enabled = true;
            czy_aktywna = true;
            odkurzacz = new Odkurzacz(Ekran_Symylacji.Width);
            Odswierz();
            startToolStripMenuItem.Enabled = false;
        }
        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauzaProgramu();
        }

        private void PauzaProgramu()
        {
            restartToolStripMenuItem.Enabled = true;
            wybórAlgorytmuToolStripMenuItem.Enabled = true;
            wybórPlanszyToolStripMenuItem.Enabled = true;
            stopWatch.Stop();

            if (czy_aktywna == false)
            {
                czy_aktywna = true;          
            }
            else
            {
                czy_aktywna = false;
            }
            Ogranicznik_odswierzania = true;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartMapy();   
            stopWatch.Restart();
        }
        private void RestartMapy()
        {
            Form1.mapa.Plansza[odkurzacz.Poz_startY, odkurzacz.Poz_startX] = 1;
            mapa.ResetPlanszy();
            czy_aktywna = true;
            pauzaToolStripMenuItem.Enabled = true;

            odkurzacz = new Odkurzacz(Ekran_Symylacji.Width);
            Odswierz();
        }
        private void WielePokoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(1);
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void JadalniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(2);
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void SalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(3);
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void pustyPokójToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(4);
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void losowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 1;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void smoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 2;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void wzdłóżŚcianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 3;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void zMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 4;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 5;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void losowyZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 6;
            pauzaToolStripMenuItem.Enabled = false;
        }
        private void Wyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            label11.Text = timer1.Interval.ToString();
        }
    }
}
