using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Trasa
    {
        public int x;
        public int y;

        public void rysuj(Graphics g, Brush b)
        {
            for (int py = 0; py < 20; py++)
            {
                for (int px = 0; px < 20; px++)
                {
                    if (Form1.mapa.Plansza[py, px] == 10)
                    { 
                        x = px * 14; y = py * 14; 
                    }

                    g.FillRectangle(b, x, y, 14, 14);
                    
                }
            }

        }
    }
}
