using System.Drawing;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Sciany
    {
        public int x;
        public int y;
        public bool a = false;

        Mapa mapa = new Mapa();
        public void Rysuj(Graphics g, Brush b, int segment)
        {

            for (int py = 0; py < mapa.Tab; py++)
            {
                for (int px = 0; px < mapa.Tab; px++)
                {
                    if (Ekran_Glowny.mapa.Plansza[py, px] == 99) { x = px * segment; y = py * segment; }

                    g.FillRectangle(b, x, y, segment, segment);

                }
            }

        }


    }
}
