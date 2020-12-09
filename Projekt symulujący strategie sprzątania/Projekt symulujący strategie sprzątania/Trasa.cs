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
        Mapa mapa = new Mapa();
        public void rysuj(Graphics g, Brush b, int segment)
        {
            for (int py = 0; py < mapa.Tab; py++)
            {
                for (int px = 0; px < mapa.Tab; px++)
                {
                    if (Form1.mapa.Plansza[py, px] == 10)
                    { 
                        x = px * segment;
                        y = py * segment; 
                    g.FillRectangle(b, x, y, segment, segment);
                    }
                    if (Form1.mapa.Plansza[py, px] == 11)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Color.DarkBlue), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 12)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Color.Blue), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 13)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Color.Yellow), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 14)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Color.DarkOrange), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 15)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Color.Red), x, y, segment, segment);

                    }


                }
            }

        }
    }
}
