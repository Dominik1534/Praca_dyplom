using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Odkurzacz
    {

        public int segment;

        Mapa mapa = new Mapa();
        Random random = new Random();

        public int x;
        public int y;
        public int px;
        public int py;
        public int Poz_startX;
        public int Poz_startY;

        public int ruch;
        private int q = 0;

        private bool gora;
        private bool lewo;
        private bool prawo;
        private bool dol;
        public bool Krok = false;
        public bool RLewo = false;
        public bool RPrawo = false;
        public bool Inicjacja = true;
        public bool Krok1 = false;
        public bool Krok2 = false;
        public bool Krok3 = false;
        public bool Krok4 = false;
        public int Ponowne_przejscia;
        public int Ruchy;
        public int obszar = 2;
        public void Kierunek(int kierunek)
        {
            Ruchy++;
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
            if (kierunek == 5)
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
                x = x - segment;
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

            if (Form1.mapa.Plansza[py, px] == 0)
            {
                Form1.mapa.Plansza[py, px] = 10;
            }



        }

        public void Ścieżka(int PY, int PX)
        {
            List<N_List> n_list = new List<N_List>();
            int P0Y = PY;
            int P0X = PX;

            int P1G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y);
            int P2G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y);
            int P3G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y);
            int P4G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y);

            int P5G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y);
            int P6G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y);
            int P7G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y);
            int P8G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y);



            int P1H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py);
            int P2H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py);
            int P3H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py);
            int P4H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py);

            int P5H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py);
            int P6H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py);
            int P7H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py);
            int P8H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py);

            int P1F = P1G + P1H;
            int P2F = P2G + P2H;
            int P3F = P3G + P3H;
            int P4F = P4G + P4H;

            int P5F = P5G + P5H;
            int P6F = P6G + P6H;
            int P7F = P7G + P7H;
            int P8F = P8G + P8H;
            if (SprawdzKolejnyRuchCzySciana(3) == false)
            {
                n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py), F = P1G + P1H, R = 3 });

            }

            if (SprawdzKolejnyRuchCzySciana(4) == false)
            {
                n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F = P2G + P2H, R = 4 });


            }

            if (SprawdzKolejnyRuchCzySciana(1) == false)
            {
                n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H, R = 1 });

            }

            if (SprawdzKolejnyRuchCzySciana(2) == false)
            {
                n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H, R = 2 });

            }

            if (SprawdzKolejnyRuchCzySciana(7) == false)
            {
                n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H, R = 7 });

            }

            if (SprawdzKolejnyRuchCzySciana(8) == false)
            {
                n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H, R = 8 });

            }

            if (SprawdzKolejnyRuchCzySciana(5) == false)
            {
                n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H, R = 5 });

            }

            if (SprawdzKolejnyRuchCzySciana(6) == false)
            {
                n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H, R = 6 });

            }
            //n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py),F= P1G + P1H ,R=3});
            //n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F= P2G + P2H , R =4});
            //n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H , R =1});
            //n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H , R =2});

            //n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H, R = 7 });
            //n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H, R = 8 });
            //n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H, R = 5 });
            //n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H, R = 6 });



            n_list = n_list.OrderBy(x => x.F)
           .ToList();
            int i = 0;
         
            if (n_list[i].F == n_list[i + 1].F)
            {
                if (n_list[i].R < n_list[i + 1].R)
                {
                    Kierunek(n_list[i].R);
                    ruch = n_list[i].R;

                }
                else
                {
                    Kierunek(n_list[i + 1].R);
                    ruch = n_list[i + 1].R;
                }

            }
            else
            {
                Kierunek(n_list[i].R);
                ruch = n_list[i].R;
            }

           

        }
        public void Najblizszy_Bialy()
        {

            List<NP_List> nP_list = new List<NP_List>();
            int Dopx = px + obszar;
            int Dopy = py + obszar;
            int Uopx = px - obszar;
            int Uopy = py - obszar;

            //xy
            if (Dopy >= 0 && Dopy < mapa.Tab)
            {
                for (int yy = py; yy <= Dopy; yy++)
                {

                    if (Dopx >= 0 && Dopx < mapa.Tab)
                    {
                        for (int xx = px; xx <= Dopx; xx++)
                        {



                            if (Form1.mapa.Plansza[yy, xx] == 0)
                            {
                                nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });

                            }

                        }

                    }

                }
            }

            //-x-y
            if (Uopy >= 0 && Uopy < mapa.Tab)
            {
                for (int yy = py; yy >= Uopy; yy--)
                {

                    if (Uopx >= 0 && Uopx < mapa.Tab)
                    {
                        for (int xx = px; xx >= Uopx; xx--)
                        {



                            if (Form1.mapa.Plansza[yy, xx] == 0)
                            {
                                nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });

                            }

                        }

                    }

                }
            }

            //x-y
            if (Uopy >= 0 && Uopy < mapa.Tab)
            {
                for (int yy = py; yy >= Uopy; yy--)
                {

                    if (Dopx >= 0 && Dopx < mapa.Tab)
                    {
                        for (int xx = px; xx <= Dopx; xx++)
                        {



                            if (Form1.mapa.Plansza[yy, xx] == 0)
                            {
                                nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });

                            }

                        }

                    }

                }
            }
            //-xy
            if (Dopy >= 0 && Dopy < mapa.Tab)
            {
                for (int yy = py; yy <= Dopy; yy++)
                {

                    if (Uopx >= 0 && Uopx <= mapa.Tab)
                    {
                        for (int xx = px; xx > Uopx; xx--)
                        {



                            if (Form1.mapa.Plansza[yy, xx] == 0)
                            {
                                nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });

                            }

                        }

                    }

                }
            }
            if (nP_list.Count != 0)
            {

                //int count = nP_list.Min(item => item.Distance );
                nP_list = nP_list.OrderBy(x => x.Distance)
                .ToList();
                Ścieżka(nP_list[0].Coord_Y, nP_list[0].Coord_X);
                //foreach (NP_List np in nP_list)
                //{
                //    for (int i = 0; i <= nP_list.Max(item => item.Distance); i++)
                //    {
                //        if (np.Distance == i)
                //        {
                //            if (Form1.mapa.Plansza[np.Coord_Y, np.Coord_X] == 0)
                //            {
                //                Ścieżka(np.Coord_Y, np.Coord_X);
                //                //Form1.mapa.Plansza[np.Coord_Y, np.Coord_X] = 18;
                //            }

                //            //  Console.WriteLine(count);
                //        }


                //    }



                //}
            }
            else
            {
                obszar++;
                Najblizszy_Bialy();
            }

        }

        public void Move_choise()
        {

            int r = 0;
            List<int> T_list = new List<int>();
            List<int> P_list = new List<int>();
            List<int> S_list = new List<int>();
            for (int i = 1; i <= 8; i++)
            {
                if (SprawdzKolejnyRuchCzyPuste(i))
                {
                    P_list.Add(i);
                }
                if (SprawdzKolejnyRuchCzyTrasa(i) == false)
                {
                    T_list.Add(i);
                }



            }
            foreach (int T in T_list)
            {
                foreach (int P in P_list)
                {
                    if (T == P)
                    {
                        S_list.Add(P);


                    }
                }

            }

            var arr1 = S_list.ToArray();
            if (arr1.Length == 0)
            {
                
                Najblizszy_Bialy();
            }
            else
            {

                r = arr1[random.Next(arr1.Length)];

                Kierunek(r);
                ruch = r;
            }






        }
        public bool SprawdzKolejnyRuchCzyTrasa(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px + 1] >= 10 && Form1.mapa.Plansza[py, px + 1] < 99 && Form1.mapa.Plansza[py, px + 1] != 1) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py + 1, px] >= 10 && Form1.mapa.Plansza[py + 1, px] < 99 && Form1.mapa.Plansza[py + 1, px] != 1) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px - 1] >= 10 && Form1.mapa.Plansza[py, px - 1] < 99 && Form1.mapa.Plansza[py, px - 1] != 1) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py - 1, px] >= 10 && Form1.mapa.Plansza[py - 1, px] < 99 && Form1.mapa.Plansza[py - 1, px] != 1) { return true; }

            if (ruch == 5 && Form1.mapa.Plansza[py - 1, px + 1] >= 10 && Form1.mapa.Plansza[py - 1, px + 1] < 99 && Form1.mapa.Plansza[py - 1, px + 1] != 1) { return true; }
            if (ruch == 6 && Form1.mapa.Plansza[py - 1, px - 1] >= 10 && Form1.mapa.Plansza[py - 1, px - 1] < 99 && Form1.mapa.Plansza[py - 1, px - 1] != 1) { return true; }
            if (ruch == 7 && Form1.mapa.Plansza[py + 1, px - 1] >= 10 && Form1.mapa.Plansza[py + 1, px - 1] < 99 && Form1.mapa.Plansza[py + 1, px - 1] != 1) { return true; }
            if (ruch == 8 && Form1.mapa.Plansza[py + 1, px + 1] >= 10 && Form1.mapa.Plansza[py + 1, px + 1] < 99 && Form1.mapa.Plansza[py + 1, px + 1] != 1) { return true; }
            return false;
        }
        public bool SprawdzKolejnyRuchCzySciana(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px + 1] == 99) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py + 1, px] == 99) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px - 1] == 99) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py - 1, px] == 99) { return true; }

            if (ruch == 5 && Form1.mapa.Plansza[py - 1, px + 1] == 99) { return true; }
            if (ruch == 6 && Form1.mapa.Plansza[py - 1, px - 1] == 99) { return true; }
            if (ruch == 7 && Form1.mapa.Plansza[py + 1, px - 1] == 99) { return true; }
            if (ruch == 8 && Form1.mapa.Plansza[py + 1, px + 1] == 99) { return true; }



            return false;
        }
        public bool SprawdzKolejnyRuchCzyPuste(int ruch)
        {
            if (ruch == 1 && Form1.mapa.Plansza[py, px + 1] != 99) { return true; }
            if (ruch == 2 && Form1.mapa.Plansza[py + 1, px] != 99) { return true; }
            if (ruch == 3 && Form1.mapa.Plansza[py, px - 1] != 99) { return true; }
            if (ruch == 4 && Form1.mapa.Plansza[py - 1, px] != 99) { return true; }

            if (ruch == 5 && Form1.mapa.Plansza[py - 1, px + 1] != 99) { return true; }
            if (ruch == 6 && Form1.mapa.Plansza[py - 1, px - 1] != 99) { return true; }
            if (ruch == 7 && Form1.mapa.Plansza[py + 1, px - 1] != 99) { return true; }
            if (ruch == 8 && Form1.mapa.Plansza[py + 1, px + 1] != 99) { return true; }



            return false;
        }

        public void S_move()
        {
            //RUCH prawo INICJACJA


            if (Inicjacja == true && ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == true)
            {
                Kierunek(1);
                ruch = 1;
                RPrawo = true;
                return;
            }
            if (Inicjacja == true && ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == false && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(4);
                ruch = 4;
                Inicjacja = false;
                return;
            }


            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(4) == true)
            {
                Kierunek(4);
                ruch = 4;
                return;
            }

            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == true)
            {
                Kierunek(2);
                ruch = 2;
                return;
            }

            //PRAWY GORNY ROG

            if (ruch == 4 && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(3);
                ruch = 3;
                Krok1 = true;
                RPrawo = false;
                RLewo = true;
                return;
            }
            //PRAWY DOLNY ROG
            if (ruch == 2 && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(3);
                ruch = 3;
                Krok2 = true;
                RPrawo = false;
                RLewo = true;
                return;
            }
            //PRAWY GORNY RÓG RUCH W PRAWY 
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(2) == true && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(2);
                ruch = 2;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //PRAWY DOLNY RÓG RUCH W PRAWY
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(4);
                ruch = 4;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //KROK W LEWO GORNY BEZ SCIANY
            if (RLewo == true && ruch == 4 && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(3) == true && SprawdzKolejnyRuchCzyPuste(1) == true && Krok1 == false)
            {
                Kierunek(3);
                ruch = 3;
                Krok1 = true;
                return;
            }
            //KROK W LEWO GORNY
            if (RLewo == true && ruch == 3 && SprawdzKolejnyRuchCzyPuste(2) == true && Krok1 == true)
            {
                Kierunek(2);
                ruch = 2;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //

            //KROK W LEWO DOLNY BEZ SCIANY
            if (RLewo == true && ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == false && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzyPuste(3) == true && Krok2 == false)
            {
                Kierunek(3);
                ruch = 3;
                Krok2 = true;
                return;
            }
            //KROK W LEWO DOLNY
            if (RLewo == true && ruch == 3 && SprawdzKolejnyRuchCzyPuste(4) == true && Krok2 == true)
            {
                Kierunek(4);
                ruch = 4;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //LEWY GORNY RÓG RUCH W LEWO 
            if (ruch == 3 && SprawdzKolejnyRuchCzyPuste(2) == true && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                Kierunek(2);
                ruch = 2;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //LEWY DOLNY RÓG RUCH W LEWO
            if (ruch == 3 && SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                Kierunek(4);
                ruch = 4;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //LEWY GORNY RÓG RUCH W GORE 
            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                Kierunek(1);
                ruch = 1;
                RLewo = false;
                RPrawo = true;
                Krok3 = true;
                return;
            }

            //LEWY DOLNY RÓG RUCH W DOL
            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                Kierunek(1);
                ruch = 1;
                RLewo = false;
                RPrawo = true;
                Krok4 = true;
                return;
            }

            //KROK W PRAWO GORNY BEZ SCIANY
            if (ruch == 4 && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(3) == true && SprawdzKolejnyRuchCzyPuste(1) == true && Krok3 == false)
            {
                Kierunek(1);
                ruch = 1;
                Krok3 = true;
                return;
            }
            //KROK W PRAWO GORNY
            if (RPrawo == true && ruch == 1 && SprawdzKolejnyRuchCzyPuste(2) == true && Krok3 == true)
            {
                Kierunek(2);
                ruch = 2;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }
            //

            //KROK W PRAWO DOLNY BEZ SCIANY
            if (RPrawo == true && ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == false && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzyPuste(3) == true && Krok4 == false)
            {
                Kierunek(1);
                ruch = 1;
                Krok4 = true;
                return;
            }
            //KROK W PRAWO DOLNY
            if (RPrawo == true && ruch == 1 && SprawdzKolejnyRuchCzyPuste(4) == true && Krok4 == true)
            {
                Kierunek(4);
                ruch = 4;
                Krok1 = false;
                Krok2 = false;
                Krok3 = false;
                Krok4 = false;
                return;
            }


            //if (RLewo== true && ruch==2 && SprawdzKolejnyRuchCzyPuste(1)==true)
            //{
            //    RPrawo = true;
            //    RLewo = false;
            //}
            //if (RPrawo == true && ruch == 2 && SprawdzKolejnyRuchCzyPuste(3) == true)
            //{
            //    RPrawo = false;
            //    RLewo = true;
            //}

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
        public void Random_move()
        {
            //RUCH PRAWO
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == true)
            {

                Kierunek(1);
                ruch = 1;
                return;
            }
            if (ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == false)
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

            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(4) == true)
            {

                Kierunek(2);
                ruch = 2;
                return;
            }
            if (ruch == 4 && SprawdzKolejnyRuchCzyPuste(4) == false)
            {

                Kierunek(7);
                ruch = 7;
                return;
            }
            // RUCh DOL

            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == true)
            {

                Kierunek(2);
                ruch = 2;
                return;
            }
            if (ruch == 2 && SprawdzKolejnyRuchCzyPuste(2) == false)
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

            if (ruch == 5 && SprawdzKolejnyRuchCzyPuste(5) == false && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(8))
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
            if (ruch == 6 && SprawdzKolejnyRuchCzyPuste(6) == true)
            {
                ruch = 6;
                Kierunek(6);

                return;
            }

            if (ruch == 6 && SprawdzKolejnyRuchCzyPuste(6) == false && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(7))
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
            if (ruch == 7 && SprawdzKolejnyRuchCzyPuste(7) == false && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(6))
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

            if (ruch == 8 && SprawdzKolejnyRuchCzyPuste(8) == false && SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(5))
            {
                ruch = 5;
                Kierunek(5);

                return;
            }
            // ROGI ZAMKNIENTE
            if (ruch == 5 && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(5) == true && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                ruch = 7;
                Kierunek(7);

                return;
            }
            if (ruch == 6 && SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzySciana(6) == true && SprawdzKolejnyRuchCzySciana(3) == true)
            {
                ruch = 8;
                Kierunek(8);

                return;
            }
            if (ruch == 7 && SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzySciana(7) == true && SprawdzKolejnyRuchCzySciana(2) == true)
            {
                ruch = 5;
                Kierunek(5);

                return;
            }
            if (ruch == 8 && SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzySciana(8) == true && SprawdzKolejnyRuchCzySciana(2) == true)
            {
                ruch = 6;
                Kierunek(6);

                return;
            }

            // ROGI OTWARTE
            if (ruch == 5 && SprawdzKolejnyRuchCzySciana(4) == false && SprawdzKolejnyRuchCzySciana(5) == true && SprawdzKolejnyRuchCzySciana(1) == false)
            {
                ruch = 1;
                Kierunek(1);

                return;
            }
            if (ruch == 6 && SprawdzKolejnyRuchCzySciana(4) == false && SprawdzKolejnyRuchCzySciana(6) == true && SprawdzKolejnyRuchCzySciana(3) == false)
            {
                ruch = 3;
                Kierunek(3);

                return;
            }
            if (ruch == 7 && SprawdzKolejnyRuchCzySciana(3) == false && SprawdzKolejnyRuchCzySciana(7) == true && SprawdzKolejnyRuchCzySciana(2) == false)
            {
                ruch = 3;
                Kierunek(3);

                return;
            }
            if (ruch == 8 && SprawdzKolejnyRuchCzySciana(1) == false && SprawdzKolejnyRuchCzySciana(8) == true && SprawdzKolejnyRuchCzySciana(2) == false)
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

            if (Form1.mapa.Plansza[py + 1, px] == 0 && SprawdzKolejnyRuchCzySciana(2) == false && Form1.mapa.Plansza[py - 1, px] == 10)
            {


                Kierunek(2);
                return;


            }

            if (Form1.mapa.Plansza[py, px - 1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py, px + 1] == 10)
            {


                Kierunek(3);
                return;


            }

            if (Form1.mapa.Plansza[py + 1, px] == 0 && SprawdzKolejnyRuchCzySciana(2) == false && Form1.mapa.Plansza[py, px + 1] == 10)
            {


                Kierunek(2);
                return;


            }

            if (Form1.mapa.Plansza[py, px + 1] == 0 && SprawdzKolejnyRuchCzySciana(1) == false && Form1.mapa.Plansza[py - 1, px] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py, px + 1] == 0 && SprawdzKolejnyRuchCzySciana(1) == false && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 0 && SprawdzKolejnyRuchCzySciana(4) == false && Form1.mapa.Plansza[py, px - 1] == 10)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 0 && SprawdzKolejnyRuchCzySciana(4) == false && Form1.mapa.Plansza[py + 1, px] == 10)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py, px - 1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py + 1, px] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py, px - 1] == 0 && SprawdzKolejnyRuchCzySciana(3) == false && Form1.mapa.Plansza[py, px + 1] == 10)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 10)
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

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99)
            {


                Kierunek(2);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 99)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 99)
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

            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 0)
            {


                Kierunek(3);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px + 1] == 0)
            {


                Kierunek(4);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 0)
            {


                Kierunek(1);
                return;


            }
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 10 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 0)
            {


                Kierunek(2);
                return;


            }
            //prosta wypełniona 
            if (Form1.mapa.Plansza[py - 1, px] == 10 && Form1.mapa.Plansza[py, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px] == 10 && Form1.mapa.Plansza[py, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px - 1] == 10 && Form1.mapa.Plansza[py + 1, px - 1] == 10 && Form1.mapa.Plansza[py - 1, px + 1] == 99 && Form1.mapa.Plansza[py + 1, px + 1] == 99 && gora == true)
            {


                Kierunek(3);
                return;


            }








        }
        public void Wall_move()
        {
            if (Inicjacja == true && ruch == 1 && SprawdzKolejnyRuchCzyPuste(1) == true)
            {
                Kierunek(1);
                ruch = 1;
                return;
            }
            if (Inicjacja == true && ruch == 1 && SprawdzKolejnyRuchCzySciana(1) == true)
            {
                Kierunek(4);
                ruch = 4;
                Inicjacja = false;
                return;
            }
            if (ruch == 4)
            {
                if (SprawdzKolejnyRuchCzyPuste(4) == true)
                {
                    if (SprawdzKolejnyRuchCzySciana(1) == true)
                    {
                        Kierunek(4);
                        ruch = 4;
                        return;
                    }
                    else
                    {
                        Kierunek(1);
                        ruch = 1;
                        return;
                    }

                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true)
                {
                    Kierunek(3);
                    ruch = 3;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true)
                {
                    Kierunek(1);
                    ruch = 1;
                    return;
                }

            }
            if (ruch == 3)
            {
                if (SprawdzKolejnyRuchCzyPuste(3) == true)
                {
                    if (SprawdzKolejnyRuchCzySciana(4) == true)
                    {
                        Kierunek(3);
                        ruch = 3;
                        return;
                    }
                    else
                    {
                        Kierunek(4);
                        ruch = 4;
                        return;
                    }

                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    Kierunek(2);
                    ruch = 2;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    Kierunek(4);
                    ruch = 4;
                    return;
                }

            }
            if (ruch == 2)
            {
                if (SprawdzKolejnyRuchCzyPuste(2) == true)
                {
                    if (SprawdzKolejnyRuchCzySciana(3) == true)
                    {
                        Kierunek(2);
                        ruch = 2;
                        return;
                    }
                    else
                    {
                        Kierunek(3);
                        ruch = 3;
                        return;
                    }

                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true)
                {
                    Kierunek(1);
                    ruch = 1;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true)
                {
                    Kierunek(3);
                    ruch = 3;
                    return;
                }

            }
            if (ruch == 1)
            {
                if (SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    if (SprawdzKolejnyRuchCzySciana(2) == true)
                    {
                        Kierunek(1);
                        ruch = 1;
                        return;
                    }
                    else
                    {
                        Kierunek(2);
                        ruch = 2;
                        return;
                    }

                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    Kierunek(4);
                    ruch = 4;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    Kierunek(2);
                    ruch = 2;
                    return;
                }

            }


        }
        public void Random_move2()
        {
            //RUCH PRAWO

            int r = 0;

            if (ruch == 1)
            {
                if (SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    Kierunek(1);
                    ruch = 1;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    var arr1 = new[] { 2, 7 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    var arr1 = new[] { 6, 4 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzyPuste(2) == true && SprawdzKolejnyRuchCzyPuste(6) == true && SprawdzKolejnyRuchCzyPuste(7) == true)
                {
                    var arr1 = new[] { 4, 2, 6, 7 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }


            }

            // RUCh LEWO


            if (ruch == 3)
            {
                if (SprawdzKolejnyRuchCzyPuste(3) == true)
                {
                    Kierunek(3);
                    ruch = 3;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    var arr1 = new[] { 2, 8 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    var arr1 = new[] { 4, 5 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzyPuste(2) == true && SprawdzKolejnyRuchCzyPuste(5) == true && SprawdzKolejnyRuchCzyPuste(8) == true)
                {
                    var arr1 = new[] { 4, 5, 8, 2 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }

            // RUCh GORA


            if (ruch == 4)
            {
                if (SprawdzKolejnyRuchCzyPuste(4) == true)
                {
                    Kierunek(4);
                    ruch = 4;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true)
                {
                    var arr1 = new[] { 1, 8 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true)
                {
                    var arr1 = new[] { 3, 7 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzyPuste(3) == true && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzyPuste(7) == true && SprawdzKolejnyRuchCzyPuste(8) == true)
                {
                    var arr1 = new[] { 1, 8, 7, 3 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }
            // RUCh DOL

            if (ruch == 2)
            {
                if (SprawdzKolejnyRuchCzyPuste(2) == true)
                {
                    Kierunek(2);
                    ruch = 2;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true)
                {
                    var arr1 = new[] { 1, 5 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true)
                {
                    var arr1 = new[] { 3, 6 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzyPuste(3) == true && SprawdzKolejnyRuchCzyPuste(1) == true && SprawdzKolejnyRuchCzyPuste(5) == true && SprawdzKolejnyRuchCzyPuste(6) == true)
                {
                    var arr1 = new[] { 3, 6, 5, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }

            // RUCH 5

            if (ruch == 5)
            {
                if (SprawdzKolejnyRuchCzyPuste(5) == true)
                {
                    Kierunek(5);
                    ruch = 5;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    var arr1 = new[] { 1, 8, 2, 3 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;

                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzyPuste(4) == true)
                {
                    var arr1 = new[] { 4, 6, 3, 2 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    var arr1 = new[] { 3, 2 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
                else if (SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    var arr1 = new[] { 4, 6, 3, 2, 8, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }


            //RUCH 6

            if (ruch == 6)
            {
                if (SprawdzKolejnyRuchCzyPuste(6) == true)
                {
                    Kierunek(6);
                    ruch = 6;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(4) == true && SprawdzKolejnyRuchCzyPuste(3) == true)
                {
                    var arr1 = new[] { 3, 7, 2, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;

                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzyPuste(4) == true)
                {
                    var arr1 = new[] { 4, 5, 1, 2 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzySciana(4) == true)
                {
                    var arr1 = new[] { 2, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
                else if (SprawdzKolejnyRuchCzyPuste(4) == true && SprawdzKolejnyRuchCzyPuste(3) == true)
                {
                    var arr1 = new[] { 4, 5, 1, 2, 7, 3 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }
            //RUCH 7

            if (ruch == 7)
            {
                if (SprawdzKolejnyRuchCzyPuste(7) == true)
                {
                    Kierunek(7);
                    ruch = 7;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzyPuste(2) == true)
                {
                    var arr1 = new[] { 2, 8, 1, 4 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;

                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(3) == true)
                {
                    var arr1 = new[] { 3, 6, 4, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(3) == true && SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    var arr1 = new[] { 4, 1 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
                else if (SprawdzKolejnyRuchCzyPuste(3) == true && SprawdzKolejnyRuchCzyPuste(2) == true)
                {
                    var arr1 = new[] { 2, 8, 1, 4, 6, 3 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }
            //RUCH 8

            if (ruch == 8)
            {
                if (SprawdzKolejnyRuchCzyPuste(8) == true)
                {
                    Kierunek(8);
                    ruch = 8;
                    return;
                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzyPuste(2) == true)
                {
                    var arr1 = new[] { 2, 7, 3, 4 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;

                }
                else if (SprawdzKolejnyRuchCzySciana(2) == true && SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    var arr1 = new[] { 1, 5, 4, 3 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;


                }
                else if (SprawdzKolejnyRuchCzySciana(1) == true && SprawdzKolejnyRuchCzySciana(2) == true)
                {
                    var arr1 = new[] { 3, 4 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
                else if (SprawdzKolejnyRuchCzyPuste(2) == true && SprawdzKolejnyRuchCzyPuste(1) == true)
                {
                    var arr1 = new[] { 1, 5, 4, 3, 7, 2 };
                    r = arr1[random.Next(arr1.Length)];
                    Kierunek(r);
                    ruch = r;
                    return;
                }
            }

        }
        public void Trasa_Cieplna()
        {
            if (Form1.mapa.Plansza[py, px] == 10)
            {
                Form1.mapa.Plansza[py, px] = 11;
                return;
            }
            if (Form1.mapa.Plansza[py, px] >= 11 && Form1.mapa.Plansza[py, px] < 99 && Form1.mapa.Plansza[py, px] != 1)
            {
                if (Form1.mapa.Plansza[py, px] < 19)
                {
                    int zm = Form1.mapa.Plansza[py, px];
                    Form1.mapa.Plansza[py, px] = zm + 1;
                    Ponowne_przejscia++;
                    return;


                }
            }


        }

        public void Map_move()
        {
            
            int r = 0;
            List<int> T_list = new List<int>();
            List<int> P_list = new List<int>();
            List<int> S_list = new List<int>();
            for (int i = 1; i <= 8; i++)
            {
                if (SprawdzKolejnyRuchCzyPuste(i) == true && SprawdzKolejnyRuchCzySciana(i) == false && SprawdzKolejnyRuchCzyTrasa(i) == false)
                {
                    P_list.Add(i);
                }
                if (SprawdzKolejnyRuchCzyPuste(i))
                {
                    T_list.Add(i);
                }



            }
            foreach (int T in T_list)
            {
                foreach (int P in P_list)
                {
                    if (P == T)
                    {
                        S_list.Add(T);


                    }
                }

            }

            var arr1 = P_list.ToArray();
            if (arr1.Length == 0)
            {
                arr1 = T_list.ToArray();
                //Najblizszy_Bialy();
                r = random.Next(arr1.Length);
                Kierunek(arr1[r]);
                ruch = r;
            }
            else
            {
                Array.Sort(arr1);
                //int i = 0;

                //r = random.Next(arr1.Length);

                for (int i = 0; i < arr1.Length; i++)
                {

                    if (arr1[i] == 1)
                    {
                        r = arr1[i];
                        break;


                    }
                    else
                    {
                        if (arr1[i] == 2)
                        {
                            r = arr1[i];
                            break;


                        }
                        else
                        {
                            if (arr1[i] == 3)
                            {
                                r = arr1[i];
                                break;


                            }
                            else
                            {
                                if (arr1[i] == 4)
                                {
                                    r = arr1[i];
                                    break;

                                }
                                else
                                {
                                    if (arr1[i] == 5)
                                    {
                                        r = arr1[i];
                                        break;


                                    }
                                    else
                                    {
                                        if (arr1[i] == 6)
                                        {
                                            r = arr1[i];
                                            break;


                                        }
                                        else
                                        {
                                            if (arr1[i] == 7)
                                            {
                                                r = arr1[i];
                                                break;


                                            }
                                            else
                                            {
                                                if (arr1[i] == 8)
                                                {
                                                    r = arr1[i];
                                                    break;


                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Kierunek(r);
                ruch = r;
                //if (arr1.Length > 1)
                //{
                //    Kierunek(arr1[i]);
                //    ruch = arr1[i];


                //    //if (arr1[i] < arr1[i + 1])
                //    //    {
                //    //        Kierunek(arr1[i]);
                //    //        ruch = arr1[i];

                //    //    }
                //    //    else
                //    //    {
                //    //        Kierunek(arr1[i + 1]);
                //    //        ruch = arr1[i + 1];
                //    //    }



                //}
                //else
                //{
                //    Kierunek(arr1[i]);
                //    ruch = arr1[i];
                //}

            }







        }
        public void rysuj(Graphics g, Brush b)
        {


            if (q == 0)
            {
                for (int ppy = 0; ppy < mapa.Tab; ppy++)
                {
                    for (int ppx = 0; ppx < mapa.Tab; ppx++)
                    {
                        if (Form1.mapa.Plansza[ppy, ppx] == 1)
                        {
                            x = ppx * segment;
                            y = ppy * segment;
                            px = ppx;
                            py = ppy;
                            Poz_startX = px;
                            Poz_startY = py;
                            Form1.mapa.Plansza[py, px] = 10;

                        }


                    }

                }

            }

            q++;
            g.FillRectangle(b, x, y, segment, segment);


        }

        public Odkurzacz(int szerokosc, int wysokosc)
        {

            segment = szerokosc / mapa.Tab;

            ruch = 1;



        }

    }
}






