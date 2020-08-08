using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Odkurzacz
    {

        public int segment;
        //public int[] x = new int[1000];
        //public int[] y = new int[1000];
        //public int[] z = new int[1];
        
        

        public int x;
        public int y;
        private int px;
        private int py;

        public int ruch;
        private int q = 0;
        bool stop = false;

    
        private bool gora;
        private bool lewo;
        private bool prawo;
        private bool dol;

        public void RysujPozycjaStartowa()
        {

            for (int py = 0; py < 20; py++)
            {
                for (int px = 0; px < 20; px++)
                {
                    if (Form1.mapa.Plansza[py, px] == 1) { x = px * segment; y = py * segment; }


                }

            }
        }





        public void Kierunek(int kierunek)
        {
            gora = false;
            lewo = false;
            prawo = false;
            dol = false;
            
            if (kierunek == 4)
            {
                gora = true;
            }
            if (kierunek == 3)
            {
                lewo = true;
            }
            if (kierunek == 2)
            {
                dol = true;
            }
            if (kierunek == 1)
            {
                prawo = true;
            }
        }
        //public void move1(string krok)
        //{
        //    kroki = i;
        //    i++;
        //    if ()

        //    krok1 = krok;
        //    if (i=i+1)
        //    {

        //    }
        //    move2(krok1);
        //}

        public bool SprawdzKolejnyRuch(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px+1] != 99) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py+1, px] != 99) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px-1] != 99) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py-1, px] != 99) { return true; }

            return false;
        }

        public void Ruch1()
        {
            if (stop == true)
            {


                for (int i = 0; i < 4; i++)
                {
                    if (SprawdzKolejnyRuch(i))
                    {
                        ruch = i;
                        stop = false;
                    }

                }
            }
            
        }

        public void move()
        {
            /*1-prawo
             * 2-lewo 3
             * 3-gora 4
             * 4-dol 2
             */
            if (ruch == 1 && SprawdzKolejnyRuch(1)==true)
            {
                x = x + segment;
                px++;
                Kierunek(1);
            }
            if (ruch == 2 && SprawdzKolejnyRuch(2) == true)
            {
                y = y + segment;
                py++;
                Kierunek(2);

            }
            if (ruch == 3 && SprawdzKolejnyRuch(3) == true)
            {
                x = x - segment;
                px--;
                Kierunek(3);

            }
            if (ruch == 4 && SprawdzKolejnyRuch(4) == true)
            {              
                y = y - segment;
                py--;      
                Kierunek(4);

            }
            //else
            //{
            //    stop = true;
            //}
            if (prawo==true && Form1.mapa.Plansza[py, px+1 ] == 99)
            {
                ruch = 2;
            }
            if (dol == true && Form1.mapa.Plansza[py+1, px ] == 99)
            {
                ruch = 3;
            }
            if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99)
            {
                ruch = 4;
            }
            if (gora == true && Form1.mapa.Plansza[py-1, px ] == 99)
            {
                ruch = 1;
            }



        }
        
        public void rysuj(Graphics g, Brush b)
        {
            
           
            if (q==0)
            {
                for (int ppy = 0; ppy < 20; ppy++)
                {
                    for (int ppx = 0; ppx < 20; ppx++)
                    {
                        if (Form1.mapa.Plansza[ppy, ppx] == 1) 
                        {
                            x = ppx * segment;
                            y = ppy * segment;
                            px = ppx;
                            py = ppy;
                            

                        }


                    }

                }
              
            }
            q++;
            g.FillRectangle(b, x, y, segment, segment);


        }

        public Odkurzacz(int szerokosc, int wysokosc)
        {
            segment = szerokosc / 20;

               ruch = 1;



        }
    }
}

       

        
    

