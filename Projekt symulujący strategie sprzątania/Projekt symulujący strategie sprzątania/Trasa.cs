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
        List<Color> Kolory = new List<Color>() {Color.DarkBlue,Color.Blue,Color.Cyan,Color.YellowGreen,Color.Yellow,Color.Orange,Color.OrangeRed,Color.Red,Color.DarkRed};
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
                        g.FillRectangle(new SolidBrush(Kolory[0]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 12)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[1]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 13)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[2]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 14)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[3]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 15)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[4]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 16)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[5]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 17)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[6]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 18)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[7]), x, y, segment, segment);

                    }
                    if (Form1.mapa.Plansza[py, px] == 19)
                    {
                        x = px * segment;
                        y = py * segment;
                        g.FillRectangle(new SolidBrush(Kolory[8]), x, y, segment, segment);

                    }


                }
            }

        }
    }
}
