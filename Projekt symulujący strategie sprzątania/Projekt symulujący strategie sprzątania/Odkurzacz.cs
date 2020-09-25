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
                y = y - segment;
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
            if (kierunek==5)
            {
                //prawy góra
                x = x + segment;
                px++;
                y = y - segment;
                py--;
            }

            if (kierunek == 6)
            {
                //lewa Górea
                x = x -segment;
                px--;
                y = y - segment;
                py--;
            }
            if (kierunek == 7)
            {
                //lewy dół
                x = x - segment;
                px--;
                y = y + segment;
                py++;
            }
            if (kierunek == 8)
            {
                //prawa dół
                x = x + segment;
                px++;
                y = y + segment;
                py++;
            }
            Form1.mapa.Plansza[py, px] = 10;
        }
  
        public bool SprawdzKolejnyRuchCzySciana(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px + 1] == 99) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py - 1, px] == 99) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px - 1] == 99) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py + 1, px] == 99) { return true; }

            if (ruch == 5 && Form1.mapa.Plansza[py-1 , px+1 ] == 99) { return true; }
            if (ruch == 6 && Form1.mapa.Plansza[py-1 , px -1] == 99) { return true; }
            if (ruch == 7 && Form1.mapa.Plansza[py+1 , px-1] == 99) { return true; }
            if (ruch == 8 && Form1.mapa.Plansza[py +1, px+1 ] == 99) { return true; }

        

            return false;
        }
        public bool SprawdzKolejnyRuchCzyPuste(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px + 1] != 99) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py - 1, px] != 99) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px - 1] != 99) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py + 1, px] != 99) { return true; }

            if (ruch == 5 && Form1.mapa.Plansza[py - 1, px + 1] != 99) { return true; }
            if (ruch == 6 && Form1.mapa.Plansza[py - 1, px - 1] != 99) { return true; }
            if (ruch == 7 && Form1.mapa.Plansza[py + 1, px - 1] != 99) { return true; }
            if (ruch == 8 && Form1.mapa.Plansza[py + 1, px + 1] != 99) { return true; }

           

            return false;
        }



        public void move()
        {
        


            if (ruch == 1 && SprawdzKolejnyRuchCzySciana(1) == true)
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
            int[] z = new int[4] { 1, 2, 3, 4 };
            int k = z[r.Next(4)];

        

            if (prawo == true && Form1.mapa.Plansza[py, px + 1] == 99)
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
            if (dol == true && Form1.mapa.Plansza[py + 1, px] == 99)
            {
                if (k != 2)
                {
                    ruch = k;

                }
            }
            if (dol == true && Form1.mapa.Plansza[py + 1, px] == 10)
            {
                if (k != 2)
                {
                    ruch = k;

                }
            }
            if (lewo == true && Form1.mapa.Plansza[py, px - 1] == 99)
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
            if (gora == true && Form1.mapa.Plansza[py - 1, px] == 99)
            {
                if (k != 4)
                {
                    ruch = k;

                }
            }
            if (gora == true && Form1.mapa.Plansza[py - 1, px] == 10)
            {
                if (k != 4)
                {
                    ruch = k;

                }
            }

         



        }
     
        public void move3()
        {
            //RUCH PRAWO
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == true)
            {
             
                Kierunek(1);
                ruch = 1;
                return;
            }
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == false )
            {

                Kierunek(6);
                ruch = 6;
                return;
            }


            // RUCh LEWO

            if (ruch == 3 && SprawdzKolejnyRuchCzyPuste(3) == true)
            {

                Kierunek(3);
                ruch = 3;
                return;
            }
            if (ruch == 3 && SprawdzKolejnyRuchCzyPuste(3) == false)
            {

                Kierunek(8);
                ruch = 8;
                return;
            }

            // RUCh GORA

            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == true)
            {

                Kierunek(2);
                ruch = 2;
                return;
            }
            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == false)
            {

                Kierunek(7);
                ruch = 7;
                return;
            }
            // RUCh DOL

            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(4) == true)
            {

                Kierunek(4);
                ruch = 4;
                return;
            }
            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(4) == false)
            {

                Kierunek(5);
                ruch = 5;
                return;
            }

            // RUCH 5
            if (ruch == 5 && SprawdzKolejnyRuchCzyPuste(5) == true)
            {
                ruch = 5;
                Kierunek(5);

                return;
            }

            if (ruch == 5 && SprawdzKolejnyRuchCzyPuste(5) == false && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(8))
            {
                ruch = 8;
                Kierunek(8);

                return;
            }
            if (ruch == 5 && SprawdzKolejnyRuchCzyPuste(5) == false && SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzyPuste(6))
            {
                ruch = 6;
                Kierunek(6);

                return;
            }

            
            //RUCH 6
            if (ruch == 6 && SprawdzKolejnyRuchCzyPuste(6)==true)
            {
                ruch = 6;
                Kierunek(6);
                
                return;
            }

            if (ruch == 6 && SprawdzKolejnyRuchCzyPuste(6) == false && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(7))
            {
                ruch = 7;
                Kierunek(7);

                return;
            }
            if (ruch == 6 && SprawdzKolejnyRuchCzyPuste(6) == false && SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzyPuste(5))
            {
                ruch = 5;
                Kierunek(5);

                return;
            }
            //RUCH 7
            if (ruch == 7 && SprawdzKolejnyRuchCzyPuste(7) == true)
            {
                ruch = 7;
                Kierunek(7);

                return;
            }
            if (ruch == 7 && SprawdzKolejnyRuchCzyPuste(7) == false && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(6))
            {
                ruch = 6;
                Kierunek(6);

                return;
            }

            if (ruch == 7 && SprawdzKolejnyRuchCzyPuste(7) == false && SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzyPuste(8))
            {
                ruch = 8;
                Kierunek(8);

                return;
            }
            //RUCH 8
            if (ruch == 8 && SprawdzKolejnyRuchCzyPuste(8) == true)
            {
                ruch = 8;
                Kierunek(8);

                return;
            }
            if (ruch == 8 && SprawdzKolejnyRuchCzyPuste(8) == false && SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzyPuste(7))
            {
                ruch = 7;
                Kierunek(7);

                return;
            }

            if (ruch == 8 && SprawdzKolejnyRuchCzyPuste(8) == false && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(5))
            {
                ruch = 5;
                Kierunek(5);

                return;
            }
            // ROGI ZAMKNIENTE
            if (ruch == 5  && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(5) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                ruch = 7;
                Kierunek(7);

                return;
            }
            if (ruch == 6 && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(6) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                ruch = 8;
                Kierunek(8);

                return;
            }
            if (ruch == 7 && SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzySciana(7) == true && SprawdzKolejnyRuchCzySciana(4) == true)
            {
                ruch = 5;
                Kierunek(5);

                return;
            }
            if (ruch == 8 && SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzySciana(8) == true && SprawdzKolejnyRuchCzySciana(4) == true)
            {
                ruch = 6;
                Kierunek(6);

                return;
            }

            // ROGI OTWARTE
            if (ruch == 5 && SprawdzKolejnyRuchCzySciana(2) == false && SprawdzKolejnyRuchCzySciana(5) == true && SprawdzKolejnyRuchCzySciana(1) == false)
            {
                ruch = 1;
                Kierunek(1);

                return;
            }
            if (ruch == 6 && SprawdzKolejnyRuchCzySciana(2) == false && SprawdzKolejnyRuchCzySciana(6) == true && SprawdzKolejnyRuchCzySciana(3) == false)
            {
                ruch = 3;
                Kierunek(3);

                return;
            }
            if (ruch == 7 && SprawdzKolejnyRuchCzySciana(3) == false && SprawdzKolejnyRuchCzySciana(7) == true && SprawdzKolejnyRuchCzySciana(4) == false)
            {
                ruch = 3;
                Kierunek(3);

                return;
            }
            if (ruch == 8 && SprawdzKolejnyRuchCzySciana(1) == false && SprawdzKolejnyRuchCzySciana(8) == true && SprawdzKolejnyRuchCzySciana(4) == false)
            {
                ruch = 1;
                Kierunek(1);

                return;
            }


        }
           
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
                // Random r = new Random();
                int rq = 1;

                // Kierunek(r.Next(1,4));
                Kierunek(rq);
                rq++;
                if (rq == 4) { rq = 1; }
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

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99 )
            {


                Kierunek(2);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 99)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 99 )
            {


                Kierunek(4);
                return;


            }

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 99)
            {


                Kierunek(1);
                return;


            }
            // Rogi zewnetrzne 2

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 0 )
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 0 )
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 0 )
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 0 )
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

       

        
    

