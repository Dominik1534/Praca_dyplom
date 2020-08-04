using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Odkurzacz
    {
        
        public int segment;
        public int[] x = new int[1000];
        public int[] y = new int[1000];
        public string ruch;



        public void move()
        {
            //for (int i = segmenty; i > 0; i--)
            //{
            //    x[i] = x[(i - 1)];
            //    y[i] = y[(i - 1)];

            //}
            if (ruch=="lewo")
            {
                x[0] = x[0] - segment;
            }
            if (ruch=="prawo")
            {
                x[0] = x[0] + segment;
            }
            if (ruch=="gora")
            {
                y[0] = y[0] - segment;

            }
            if (ruch=="dol")
            {
                y[0] = y[0] + segment;

            }
            if (x[0] == 0)
            {
                ruch = "gora";
                
            }

            if (x[0] == segment*19)
            {
                
                ruch = "dol";

            }

            if (y[0] == 0)
            {
                ruch = "prawo";
                
            }

            if (y[0] == segment * 19)
            {
                ruch = "lewo";
               
            }
            if(y[0] == segment * 19&& x[0]==0)
            {
                ruch = "gora";
            }
            if (x[0] == segment * 19 && y[0] == 0)
            {
                ruch = "dol";
            }

        }
        public void rysuj (Graphics g,Brush b)
        {
            
                g.FillRectangle(b, x[0], y[0], segment, segment);
            
        }

        public Odkurzacz(int szerokosc, int wysokosc)
        {
            segment = szerokosc / 20;
            
            ruch = "prawo";
            int xg = 10 * segment;
            int yg = 10 * segment;
            
        }
       

        
    }
}
