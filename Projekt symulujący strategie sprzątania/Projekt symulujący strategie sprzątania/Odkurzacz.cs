using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
        Mapa mapa = new Mapa();
        

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

     





        public void Kierunek(int kierunek)
        {
            gora = false;
            lewo = false;
            prawo = false;
            dol = false;
            
            if (kierunek == 4)
            {
                y = y -segment;
                py--;
                gora = true;
                
            }
            if (kierunek == 3)
            {
                x = x - segment;
                px--;
                lewo = true;
                
            }
            if (kierunek == 2)
            {
                y = y + segment;
                py++;
                dol = true;
                
            }
            if (kierunek == 1)
            {
                x = x + segment;
                px++;
                prawo = true;
               
            }
            Form1.mapa.Plansza[py, px] = 10;
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

        public bool SprawdzKolejnyRuchCzySciana(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px+1] == 99 ) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py+1, px] == 99 ) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px-1] == 99 ){ return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py-1, px] == 99 ) { return true; }

            return false;
        }

       

        public void move()
        {
            /*1-prawo
             * 2-lewo 3
             * 3-gora 4
             * 4-dol 2
             * 
             */
          
            
            if (ruch == 1 && SprawdzKolejnyRuchCzySciana(1)==true)
            {
                x = x + segment;
                px++;
                Kierunek(1);
                Form1.mapa.Plansza[py, px] = 10;

            }
            if (ruch == 2 && SprawdzKolejnyRuchCzySciana(2) == true)
            {
                y = y + segment;
                py++;
                Kierunek(2);
                Form1.mapa.Plansza[py, px] = 10;

            }
            if (ruch == 3 && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                x = x - segment;
                px--;
                Kierunek(3);
                Form1.mapa.Plansza[py, px] = 10;

            }
            if (ruch == 4 && SprawdzKolejnyRuchCzySciana(4) == true)
            {              
                y = y - segment;
                py--;      
                Kierunek(4);
                Form1.mapa.Plansza[py, px] = 10;


            }

            Random r = new Random();
             int[] z = new int[4] {1,2,3,4 };
            int k = z[r.Next(4)];

            //if (prawo == true && Form1.mapa.Plansza[py, px + 1] == 99 ^ prawo == true && Form1.mapa.Plansza[py, px + 1] == 10)
            //{

            //    if (k!=1)
            //    {
            //        ruch=k;

            //    }
            //}
            //if (dol == true && Form1.mapa.Plansza[py + 1, px] == 99 ^ dol == true && Form1.mapa.Plansza[py + 1, px ] == 10)
            //{
            //    if (k != 2)
            //    {
            //        ruch = k;

            //    }
            //}
            //if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99 ^ lewo == true && Form1.mapa.Plansza[py, px - 1] == 10)
            //{
            //    if (k != 3)
            //    {
            //        ruch = k;

            //    }
            //}
            //if (gora == true && Form1.mapa.Plansza[py - 1, px] == 99 ^ gora == true && Form1.mapa.Plansza[py - 1, px ] == 10)
            //{
            //    if (k != 4)
            //    {
            //        ruch = k;

            //    }
            //}

            if (prawo == true && Form1.mapa.Plansza[py, px + 1] == 99 )
            {

                if (k != 1)
                {
                    ruch = k;

                }
            }
            if (prawo == true && Form1.mapa.Plansza[py, px + 1] == 10)
            {

                if (k != 1)
                {
                    ruch = k;

                }
            }
            if (dol == true && Form1.mapa.Plansza[py + 1, px] == 99 )
            {
                if (k != 2)
                {
                    ruch = k;

                }
            }
            if ( dol == true && Form1.mapa.Plansza[py + 1, px] == 10)
            {
                if (k != 2)
                {
                    ruch = k;

                }
            }
            if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99 )
            {
                if (k != 3)
                {
                    ruch = k;

                }
            }
            if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 10)
            {
                if (k != 3)
                {
                    ruch = k;

                }
            }
            if (gora == true && Form1.mapa.Plansza[py - 1, px] == 99 )
            {
                if (k != 4)
                {
                    ruch = k;

                }
            }
            if  (gora == true && Form1.mapa.Plansza[py - 1, px] == 10)
            {
                if (k != 4)
                {
                    ruch = k;

                }
            }

            //else
            //{
            //    stop = true;
            //}
            //if (prawo==true && Form1.mapa.Plansza[py, px+1 ] == 99)
            //{
            //    ruch = 2;
            //}
            //if (dol == true && Form1.mapa.Plansza[py+1, px ] == 99)
            //{
            //    ruch = 3;
            //}
            //if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99)
            //{
            //    ruch = 4;
            //}
            //if (gora == true && Form1.mapa.Plansza[py-1, px ] == 99)
            //{
            //    ruch = 1;
            //}



        }
        //public void Ruch1()
        //{

        //    Random r = new Random();

        //    if (prawo == true && Form1.mapa.Plansza[py, px + 1] == 99)
        //    {

        //        move(r.Next(2, 4));
        //    }
        //    if (dol == true && Form1.mapa.Plansza[py + 1, px] == 99)
        //    {
        //        move(r.Next(3, 4));
        //    }
        //    if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99)
        //    {
        //        move(r.Next(1, 2));
        //    }
        //    if (gora == true && Form1.mapa.Plansza[py - 1, px] == 99)
        //    {
        //        move(r.Next(1, 3));
        //    }


        //}

        public void move2()
        {
            /*1-prawo
             * 2-lewo 3
             * 3-gora 4
             * 4-dol 2
             * 
             */

            if (ruch == 1 && SprawdzKolejnyRuchCzySciana(1) == false)
            {
                Form1.mapa.Plansza[py, px] = 10;
                Kierunek(1);           
                ruch = 0;
                return;
            }
        
            if (Form1.mapa.Plansza[py + 1, px] == 0 && SprawdzKolejnyRuchCzySciana(2) == false && Form1.mapa.Plansza[py, px - 1] == 10)
            {
                
              
                Kierunek(2);

                return;

            }
         
            if (Form1.mapa.Plansza[py, px - 1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py - 1, px] == 10)
            {


                Kierunek(3);
                return;


            }
           
            if (Form1.mapa.Plansza[py - 1, px] == 0 && SprawdzKolejnyRuchCzySciana(4) == false && Form1.mapa.Plansza[py, px + 1] == 10)
            {


                Kierunek(4);

                return;


            }
        
            if (Form1.mapa.Plansza[py, px + 1] == 0 && SprawdzKolejnyRuchCzySciana(1) == false && Form1.mapa.Plansza[py + 1, px] == 10)
            {


                Kierunek(1);
                return;


            }

            if (Form1.mapa.Plansza[py+1, px ] == 0 && SprawdzKolejnyRuchCzySciana(2) == false && Form1.mapa.Plansza[py - 1, px] == 10)
            {


                Kierunek(2);
                return;


            }

            if (Form1.mapa.Plansza[py , px-1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py, px+1] == 10)
            {


                Kierunek(3);
                return;


            }

            if (Form1.mapa.Plansza[py+1, px ] == 0 && SprawdzKolejnyRuchCzySciana(2) == false && Form1.mapa.Plansza[py, px + 1] == 10)
            {


                Kierunek(2);
                return;


            }

            if (Form1.mapa.Plansza[py , px+1] == 0 && SprawdzKolejnyRuchCzySciana(1) == false && Form1.mapa.Plansza[py-1, px] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py, px + 1] == 0 && SprawdzKolejnyRuchCzySciana(1) == false && Form1.mapa.Plansza[py , px-1] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py-1, px ] == 0 && SprawdzKolejnyRuchCzySciana(4) == false && Form1.mapa.Plansza[py, px-1 ] == 10)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py -1, px] == 0 && SprawdzKolejnyRuchCzySciana(4) == false && Form1.mapa.Plansza[py+1, px ] == 10)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py, px-1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py+1, px] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py, px - 1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py, px+1] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py-1, px - 1] == 10 && Form1.mapa.Plansza[py+1, px - 1] == 10 && Form1.mapa.Plansza[py-1, px + 1] == 10 && Form1.mapa.Plansza[py+1, px + 1] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 99 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 99 && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 99)
            {


                Kierunek(2);
                return;


            }

            //ROGI wewnętrzne
            if (Form1.mapa.Plansza[py - 1, px] == 99 && Form1.mapa.Plansza[py, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 99 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 99)
            {


                Kierunek(2);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 99 && Form1.mapa.Plansza[py, px - 1] == 99)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px] == 99 && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(4);
                return;


            }
            //Rogi zewnetrzne

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99 && prawo == true)
            {


                Kierunek(2);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 99 && dol == true)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 99 && lewo == true)
            {


                Kierunek(4);
                return;


            }

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 99 && gora == true)
            {


                Kierunek(1);
                return;


            }
            // Rogi zewnetrzne 2

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99 && gora == true)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 99 && prawo == true)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 9 && dol == true)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 99 && lewo == true)
            {


                Kierunek(2);
                return;


            }
            //prosta wypełniona 
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px + 1] == 99 &&  gora==true)
            {


                Kierunek(3);
                return;


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

       

        
    

