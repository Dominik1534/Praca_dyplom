using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_symulujący_strategie_sprzątania
{
    class Brud
    {
        public static int ilosc;
        int i,j;
        public int[]x= new int[ilosc];
        public int[]y= new int[ilosc];
        public int segment;
        public static int wynik=0;

        public static void IlośćBrudu(string Ilosc)
        {
            ilosc = int.Parse(Form1.TextIlosc);
        }
        public void nowy_brud()
        {
            Random r = new Random();

            for ( i = 0; i < x.Length; i++)
            {
            x[i] = r.Next(0, 20) * segment;

            }
            for ( j = 0; j < y.Length; j++)
            {

            y[j] = r.Next(0, 20) * segment;
            }
        }
        public Brud(int segment)
        {
            this.segment = segment;
            
            nowy_brud();
            
        }
        public void Zbieranie(int glowa_x, int glowa_y, Graphics g, Brush b)
        {
            for (i = 0; i < x.Length; i++)
            {
                for (i = 0; i < y.Length; i++)
                {

                    if (x[i] == glowa_x && y[i] == glowa_y)
                    {
                        g.FillRectangle(b, x[i], y[i], segment, segment);
                        x[i] = 300;
                        y[i] = 300;

                    }

                }

            }
            
        }

        public bool czy_nowy_brud(int glowa_x, int glowa_y)
        {

            for (i = 0; i < x.Length; i++)
            {
                for (i = 0; i < y.Length; i++)
                {

                    if (x[i] == glowa_x && y[i] == glowa_y)
                    {
                        wynik++;
                       
                        return true;
                    }


                }

            }
                    return false;

        }
        public void rysuj_brud(Graphics g,Brush b)
        {
          
            {

                for ( i = 0; i < x.Length; i++)
                {
                    for (i = 0; i < y.Length; i++)
                    {
                        g.FillRectangle(b, x[i], y[i], segment, segment);
                    
                    }
                        
                }
              
            }
        }
    }
}
