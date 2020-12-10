using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Sciany
    {
        public int x;
        public int y;
        public bool a = false;

        Mapa mapa = new Mapa();
        public void rysuj(Graphics g, Brush b ,int segment)
        {
            bool a = true;
            for (int py = 0; py < mapa.Tab; py++)
            {
                for (int px = 0; px < mapa.Tab; px++)
                {
                    if (Form1.mapa.Plansza[py, px] == 99) { x = px * segment; y = py * segment; }
                    
                    g.FillRectangle(b, x, y, segment, segment);
                 
                }
            }

            }
            

    }
}
