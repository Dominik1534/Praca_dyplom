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
        public int obszar = 1;
        public int B = 1;
        public bool KoniecSprzatania = false;
     
        public void Kierunek(int kierunek)
        {
            Ruchy++;                
            //góra
            if (kierunek == 4)
            {
                y = y - segment;
                py--;
            }
            //lewo
            if (kierunek == 3)
            {
                x = x - segment;
                px--;          
            }
            //dół
            if (kierunek == 2)
            {
                y = y + segment;
                py++;            
            }
            //prawo
            if (kierunek == 1)
            {
                x = x + segment;
                px++;
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

            if (Ekran_Glowny.mapa.Plansza[py, px] == 0)
            {
                Ekran_Glowny.mapa.Plansza[py, px] = 10;
            }
        }
        public bool SprawdzKolejnyRuchCzyPuste(int ruch)
        {
            if (ruch == 1 && Ekran_Glowny.mapa.Plansza[py, px + 1] != 99) { return true; }
            if (ruch == 2 && Ekran_Glowny.mapa.Plansza[py + 1, px] != 99) { return true; }
            if (ruch == 3 && Ekran_Glowny.mapa.Plansza[py, px - 1] != 99) { return true; }
            if (ruch == 4 && Ekran_Glowny.mapa.Plansza[py - 1, px] != 99) { return true; }

            if (ruch == 5 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] != 99) { return true; }
            if (ruch == 6 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] != 99) { return true; }
            if (ruch == 7 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] != 99) { return true; }
            if (ruch == 8 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] != 99) { return true; }



            return false;
        }
        public bool SprawdzKolejnyRuchCzySciana(int ruch)
        {
            if (ruch == 1 && Ekran_Glowny.mapa.Plansza[py, px + 1] == 99) { return true; }
            if (ruch == 2 && Ekran_Glowny.mapa.Plansza[py + 1, px] == 99) { return true; }
            if (ruch == 3 && Ekran_Glowny.mapa.Plansza[py, px - 1] == 99) { return true; }
            if (ruch == 4 && Ekran_Glowny.mapa.Plansza[py - 1, px] == 99) { return true; }

            if (ruch == 5 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] == 99) { return true; }
            if (ruch == 6 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] == 99) { return true; }
            if (ruch == 7 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] == 99) { return true; }
            if (ruch == 8 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] == 99) { return true; }



            return false;
        }
        public bool SprawdzKolejnyRuchCzyTrasa(int ruch)
        {
            if (ruch == 1 && Ekran_Glowny.mapa.Plansza[py, px + 1] >= 10 && Ekran_Glowny.mapa.Plansza[py, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py, px + 1] != 1) { return true; }
            if (ruch == 2 && Ekran_Glowny.mapa.Plansza[py + 1, px] >= 10 && Ekran_Glowny.mapa.Plansza[py + 1, px] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px] != 1) { return true; }
            if (ruch == 3 && Ekran_Glowny.mapa.Plansza[py, px - 1] >= 10 && Ekran_Glowny.mapa.Plansza[py, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py, px - 1] != 1) { return true; }
            if (ruch == 4 && Ekran_Glowny.mapa.Plansza[py - 1, px] >= 10 && Ekran_Glowny.mapa.Plansza[py - 1, px] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px] != 1) { return true; }

            if (ruch == 5 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] >= 10 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] != 1) { return true; }
            if (ruch == 6 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] >= 10 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] != 1) { return true; }
            if (ruch == 7 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] >= 10 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] != 1) { return true; }
            if (ruch == 8 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] >= 10 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] != 1) { return true; }
            return false;
        }
        public bool SprawdzKolejnyRuchCzyTrasa2(int ruch)
        {
            if (ruch == 1 && Ekran_Glowny.mapa.Plansza[py, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py, px + 1] != 1 && Ekran_Glowny.mapa.Plansza[py, px + 1] < 13) { return true; }
            if (ruch == 2 && Ekran_Glowny.mapa.Plansza[py + 1, px] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px] != 1 && Ekran_Glowny.mapa.Plansza[py + 1, px] < 13) { return true; }
            if (ruch == 3 && Ekran_Glowny.mapa.Plansza[py, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py, px - 1] != 1 && Ekran_Glowny.mapa.Plansza[py, px - 1] < 13) { return true; }
            if (ruch == 4 && Ekran_Glowny.mapa.Plansza[py - 1, px] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px] != 1 && Ekran_Glowny.mapa.Plansza[py - 1, px] < 13) { return true; }

            if (ruch == 5 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] != 1 && Ekran_Glowny.mapa.Plansza[py - 1, px + 1] < 13) { return true; }
            if (ruch == 6 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] != 1 && Ekran_Glowny.mapa.Plansza[py - 1, px - 1] < 13) { return true; }
            if (ruch == 7 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] != 1 && Ekran_Glowny.mapa.Plansza[py + 1, px - 1] < 13) { return true; }
            if (ruch == 8 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] < 99 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] != 1 && Ekran_Glowny.mapa.Plansza[py + 1, px + 1] < 13) { return true; }
            return false;
        }
        public bool SprawdzCzyPunktGraniczyZTrasa(int yp, int xp)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (i == 1 && Ekran_Glowny.mapa.Plansza[yp, xp + 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp, xp + 1] < 99 && Ekran_Glowny.mapa.Plansza[yp, xp + 1] != 1) { return true; }
                if (i == 2 && Ekran_Glowny.mapa.Plansza[yp + 1, xp] >= 10 && Ekran_Glowny.mapa.Plansza[yp + 1, xp] < 99 && Ekran_Glowny.mapa.Plansza[yp + 1, xp] != 1) { return true; }
                if (i == 3 && Ekran_Glowny.mapa.Plansza[yp, xp - 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp, xp - 1] < 99 && Ekran_Glowny.mapa.Plansza[yp, xp - 1] != 1) { return true; }
                if (i == 4 && Ekran_Glowny.mapa.Plansza[yp - 1, xp] >= 10 && Ekran_Glowny.mapa.Plansza[yp - 1, xp] < 99 && Ekran_Glowny.mapa.Plansza[yp - 1, xp] != 1) { return true; }

                if (i == 5 && Ekran_Glowny.mapa.Plansza[yp - 1, xp + 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp - 1, xp + 1] < 99 && Ekran_Glowny.mapa.Plansza[yp - 1, xp + 1] != 1) { return true; }
                if (i == 6 && Ekran_Glowny.mapa.Plansza[yp - 1, xp - 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp - 1, xp - 1] < 99 && Ekran_Glowny.mapa.Plansza[yp - 1, xp - 1] != 1) { return true; }
                if (i == 7 && Ekran_Glowny.mapa.Plansza[yp + 1, xp - 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp + 1, xp - 1] < 99 && Ekran_Glowny.mapa.Plansza[yp + 1, xp - 1] != 1) { return true; }
                if (i == 8 && Ekran_Glowny.mapa.Plansza[yp + 1, xp + 1] >= 10 && Ekran_Glowny.mapa.Plansza[yp + 1, xp + 1] < 99 && Ekran_Glowny.mapa.Plansza[yp + 1, xp + 1] != 1) { return true; }
            }


            return false;
        }

        public bool CzyWszystkoWyczyszczono()
        {
            for (int i = 0; i < mapa.Tab; i++)
            {
                for (int j = 0; j < mapa.Tab; j++)
                {
                    if (Ekran_Glowny.mapa.Plansza[j, i] == 0)
                    { return false; }
                }
            }

            return true;
        }



        public void Sciezka(int PY, int PX)
        {
            obszar = 2;
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
                if (SprawdzKolejnyRuchCzyTrasa2(3) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py), F = P1G + P1H, R = 3 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py), F = P1G + P1H, R = 3 });
                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(3) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(3) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py), F = P1G + P1H + 1000, R = 3 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 1, G = Math.Abs((P0X + 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs(P0Y - py), F = P1G + P1H + 1000, R = 3 });
                    B++;
                }


            }

            if (SprawdzKolejnyRuchCzySciana(4) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(4) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F = P2G + P2H, R = 4 });


                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F = P2G + P2H, R = 4 });

                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(4) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(4) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F = P2G + P2H + 1000, R = 4 });


                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 2, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y + 1) - py), F = P2G + P2H + 1000, R = 4 });

                    B++;
                }


            }

            if (SprawdzKolejnyRuchCzySciana(1) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(1) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H, R = 1 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H, R = 1 });


                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(1) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(1) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H + 1000, R = 1 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 3, G = Math.Abs((P0X - 1) - P0X) + Math.Abs(P0Y - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs(P0Y - py), F = P3G + P3H + 1000, R = 1 });


                    B++;
                }


            }

            if (SprawdzKolejnyRuchCzySciana(2) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(2) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H, R = 2 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H, R = 2 });
                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(2) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(2) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H + 1000, R = 2 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 4, G = Math.Abs(P0X - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs(P0X - px) + Math.Abs((P0Y - 1) - py), F = P4G + P4H + 1000, R = 2 });
                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(7) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(7) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H - 1, R = 7 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H - 1, R = 7 });
                    B++;
                }



            }
            if (SprawdzKolejnyRuchCzySciana(7) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(7) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H + 1000 - 1, R = 7 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 5, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y - 1) - py), F = P5G + P5H + 1000 - 1, R = 7 });
                    B++;
                }



            }
            if (SprawdzKolejnyRuchCzySciana(8) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(8) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H - 1, R = 8 });
                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H - 1, R = 8 });
                    B++;
                }


            }

            if (SprawdzKolejnyRuchCzySciana(8) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(8) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H + 1000 - 1, R = 8 });
                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 6, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y - 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y - 1) - py), F = P6G + P6H + 1000 - 1, R = 8 });
                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(5) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(5) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H - 1, R = 5 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H - 1, R = 5 });
                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(5) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(5) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H + 1000 - 1, R = 5 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 7, G = Math.Abs((P0X - 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X - 1) - px) + Math.Abs((P0Y + 1) - py), F = P7G + P7H + 1000 - 1, R = 5 });
                    B++;
                }


            }

            if (SprawdzKolejnyRuchCzySciana(6) == false)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(6) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H - 1, R = 6 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H - 1, R = 6 });

                    B++;
                }


            }
            if (SprawdzKolejnyRuchCzySciana(6) == true)
            {
                if (SprawdzKolejnyRuchCzyTrasa2(6) == true && B > 1)
                {
                    n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H + 1000 - 1, R = 6 });

                }
                if (B == 1)
                {
                    n_list.Add(new N_List() { PID = 8, G = Math.Abs((P0X + 1) - P0X) + Math.Abs((P0Y + 1) - P0Y), H = Math.Abs((P0X + 1) - px) + Math.Abs((P0Y + 1) - py), F = P8G + P8H + 1000 - 1, R = 6 });

                    B++;
                }


            }

            n_list = n_list.OrderBy(x => x.F)
           .ToList();
            int i = 0;
           
            if (n_list.Count > 1)
            {

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

            if (Dopx > mapa.Tab)
            {
                Dopx = mapa.Tab - 1;
            }
            if (Dopy > mapa.Tab)
            {
                Dopy = mapa.Tab - 1;
            }
            if (Uopx < mapa.Tab)
            {
                Uopx = 0;
            }
            if (Uopy < mapa.Tab)
            {
                Uopy = 0;
            }

            //xy

            for (int yy = py; yy <= Dopy; yy++)
            {
                if (Dopx >= 0 && Dopx < mapa.Tab)
                {
                    for (int xx = px; xx <= Dopx; xx++)
                    {
                        int kara = 0;
                        if (Ekran_Glowny.mapa.Plansza[yy, xx] == 0 && SprawdzCzyPunktGraniczyZTrasa(yy, xx) == true)
                        {
                            nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) + kara });
                        }
                    }

                }

            }


            //-x-y

            for (int yy = py; yy >= Uopy; yy--)
            {
                if (Uopx >= 0 && Uopx < mapa.Tab)
                {
                    for (int xx = px; xx >= Uopx; xx--)
                    {
                        int kara = 0;

                        if (Ekran_Glowny.mapa.Plansza[yy, xx] == 0 && SprawdzCzyPunktGraniczyZTrasa(yy, xx) == true)
                        {
                            nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) + kara });
                        }

                    }

                }

            }


            //x-y

            for (int yy = py; yy >= Uopy; yy--)
            {
                if (Dopx >= 0 && Dopx < mapa.Tab)
                {
                    for (int xx = px; xx <= Dopx; xx++)
                    {
                        if (Ekran_Glowny.mapa.Plansza[yy, xx] == 0 && SprawdzCzyPunktGraniczyZTrasa(yy, xx) == true)
                        {
                            nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });
                        }
                    }

                }

            }

            //-xy

            for (int yy = py; yy <= Dopy; yy++)
            {
                if (Uopx >= 0 && Uopx < mapa.Tab)
                {
                    for (int xx = px; xx > Uopx; xx--)
                    {
                        if (Ekran_Glowny.mapa.Plansza[yy, xx] == 0 && SprawdzCzyPunktGraniczyZTrasa(yy, xx) == true)
                        {
                            nP_list.Add(new NP_List() { Coord_Y = yy, Coord_X = xx, Distance = Math.Abs(px - xx) + Math.Abs(py - yy) });
                        }
                    }

                }

            }

            if (nP_list.Count == 0)
            {
                if (CzyWszystkoWyczyszczono() == true)
                {
                    KoniecSprzatania = true;
                    return;
                }
                if (obszar < 39)
                {
                    obszar++;
                    Najblizszy_Bialy();
                }
            }
            else
            {
                nP_list = nP_list.OrderBy(x => x.Distance)
                .ToList();
                Sciezka(nP_list[0].Coord_Y, nP_list[0].Coord_X);
            }

        }
        public void Ruch_S()
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


          

        }
        public void PodazanieZaSciana()
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
        public void Losowe_odbicia()
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
        public void ZPamieciaTrasy()
        {
            int r = 0;         
            List<int> P_list = new List<int>();     
            for (int i = 1; i <= 8; i++)
            {
                if (SprawdzKolejnyRuchCzyPuste(i) == true && SprawdzKolejnyRuchCzySciana(i) == false && SprawdzKolejnyRuchCzyTrasa(i) == false)
                {
                    P_list.Add(i);
                }          
            }
            var arr1 = P_list.ToArray();
            if (arr1.Length == 0)
            {
                Losowe_odbicia();           
            }
            else
            {
                Array.Sort(arr1);
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
            }

        }

        public void Trasa_Cieplna()
        {
            if (Ekran_Glowny.mapa.Plansza[py, px] == 10)
            {
                Ekran_Glowny.mapa.Plansza[py, px] = 11;
                return;
            }
            if (Ekran_Glowny.mapa.Plansza[py, px] >= 11 && Ekran_Glowny.mapa.Plansza[py, px] < 99 && Ekran_Glowny.mapa.Plansza[py, px] != 1)
            {
                if (Ekran_Glowny.mapa.Plansza[py, px] > 10)
                {
                    Ponowne_przejscia++;
                }
                if (Ekran_Glowny.mapa.Plansza[py, px] < 19)
                {
                    int zm = Ekran_Glowny.mapa.Plansza[py, px];
                    Ekran_Glowny.mapa.Plansza[py, px] = zm + 1;
                    return;


                }
            }


        } 
        public void Rysuj(Graphics g, Brush b)
        {


            if (q == 0)
            {
                for (int ppy = 0; ppy < mapa.Tab; ppy++)
                {
                    for (int ppx = 0; ppx < mapa.Tab; ppx++)
                    {
                        if (Ekran_Glowny.mapa.Plansza[ppy, ppx] == 1)
                        {
                            x = ppx * segment;
                            y = ppy * segment;
                            px = ppx;
                            py = ppy;
                            Poz_startX = px;
                            Poz_startY = py;
                            Ekran_Glowny.mapa.Plansza[py, px] = 11;

                        }


                    }

                }

            }

            q++;
            g.FillRectangle(b, x, y, segment, segment);


        }
        public Odkurzacz(int szerokosc)
        {
            segment = szerokosc / mapa.Tab;
            ruch = 1;
        }

    }
}






