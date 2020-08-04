using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Brud
    {
        public int x;
        public int y;
        public int segment;
        public int ilosc=10;
        public static int wynik=0;

        public void nowy_brud()
        {
            for (int i = 0; i < ilosc; i++)
            {
            Random r = new Random();
            x = r.Next(0, 20) * segment;
            y = r.Next(0, 20) * segment;
            }
            wynik++;

        }
        public Brud(int segment)
        {
            this.segment = segment;
            nowy_brud();
        }

        public bool czy_nowy_brud(int glowa_x,int glowa_y)
        {
            if (x==glowa_x&& y==glowa_y)
            {
                nowy_brud();
                return true;
            }
            return false;
        }
        public void rysuj_brud(Graphics g,Brush b)
        {
            for (int i = 0; i < ilosc; i++)
            {
                g.FillRectangle(b, x, y, segment, segment);
            }
        }
    }
}
