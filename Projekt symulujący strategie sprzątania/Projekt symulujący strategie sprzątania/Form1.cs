using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_symulujący_strategie_sprzątania
{
    public partial class Form1 : Form
    {
        public bool czy_aktywna;
        private Odkurzacz odkurzacz;
        private Brud brud;
        private Sciany sciany = new Sciany();
        private Trasa trasa = new Trasa();
        public static string TextIlosc;
        public static Mapa mapa = new Mapa();
        public int Mapa;
        private int NrAlgorytmu;
        private bool Ogranicznik_odswierzania;
        Stopwatch stopWatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            czy_aktywna = false;
            timer1.Enabled = true;
            //timer1.Interval = 1;

        }

        private void Odswierz()
        {
            panel1.CreateGraphics().Clear(Color.White);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (czy_aktywna)
            {
                if (Ogranicznik_odswierzania == true)
                {
                    Odswierz();
                    Ogranicznik_odswierzania = false;
                }

                Stoper();
                sciany.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.Gray), odkurzacz.segment);

                trasa.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.White), odkurzacz.segment);

                odkurzacz.rysuj(panel1.CreateGraphics(), new SolidBrush(Color.Aqua));
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
                    default:
                        odkurzacz.Map_move();
                        break;

                }

                odkurzacz.Trasa_Cieplna();
                Statystyki();

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
                    label7.Text = "Z mapą";
                    break;
                default:
                    label7.Text = "Losowych odbić";
                    break;
            }
            label5.Text = odkurzacz.Ruchy.ToString();

            Ponowne_przejscia_liczba.Text = odkurzacz.Ponowne_przejscia.ToString();
        }

        private void WyswietlKomunukat()
        {
            FontFamily fontFamily1 = new FontFamily("Arial");
            Font f = new Font(fontFamily1, 15);
            Brush b = new SolidBrush(Color.Red);
            panel1.CreateGraphics().DrawString("Symulacja zatrzymana", f, b, 40, 125);

        }
        private void Stoper ()
            {
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}",
                 ts.Minutes, ts.Seconds
                );
           label9.Text=elapsedTime;
            if (elapsedTime=="00:05")
            {
                
                

                Zdjecie();
            }

            }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mapa.WymiaryTablicy();
            stopWatch.Start();
           

            czy_aktywna = true;
            odkurzacz = new Odkurzacz(panel1.Width, panel1.Height);
            Odswierz();
            
            //brud = new Brud(odkurzacz.segment);
        }
        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
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
            Ogranicznik_odswierzania = true;
        }
     
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.ResetPlanszy();
            czy_aktywna = true;
            
            odkurzacz = new Odkurzacz(panel1.Width, panel1.Height);
            Odswierz();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void WyborPlanszy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
        private void WielePokoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(1);
           
        }

        private void JadalniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(2);

        }

        private void SalonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapa.WyborPlanszy(3);

        
        }

        private void losowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 1;
        }

        private void smoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 2;

        }

        private void wzdłóżŚcianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 3;

        }

        private void zMapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrAlgorytmu = 4;

            

        }
        private void Wyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Zdjecie()
        {
            int Nr=0;
            Nr++;
            var CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(CurrentDirectory);

            var frm = Form.ActiveForm;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(AppDomain.CurrentDomain.BaseDirectory + $"CONFIG{Nr}.png");
            }
            int width = panel1.Size.Width;
            int height = panel1.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(AppDomain.CurrentDomain.BaseDirectory + $"CONFIGq{Nr}.Bmp", ImageFormat.Bmp);

            //MemoryStream ms = new MemoryStream();
            //Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            //panel1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height));
            //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //you could ave in BPM, PNG  etc format.
            //byte[] Pic_arr = new byte[ms.Length];
            //ms.Position = 0;
            //ms.Read(Pic_arr, 0, Pic_arr.Length);
            //ms.Close();


            //Bitmap theScreenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
            //Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            //Graphics theGraphics = Graphics.FromImage(theScreenShot);
            //theScreenShot.Save(AppDomain.CurrentDomain.BaseDirectory + $"CONFIGqq{Nr}", ImageFormat.Jpeg);
            //theScreenShot.Dispose();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine(currentProcess.Id);
            var frm = Form.ActiveForm;
            Console.WriteLine(frm);





        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
