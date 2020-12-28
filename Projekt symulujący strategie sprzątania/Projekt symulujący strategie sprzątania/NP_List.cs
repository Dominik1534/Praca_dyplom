using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_symulujący_strategie_sprzątania
{
   public class NP_List
    {
        public int Coord_X { get; set; }
        public int Coord_Y { get; set; }
        public int Distance { get; set; }

    }

    public class N_List
    {
        public int PID { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }

        public int R { get; set; }
    }

}
