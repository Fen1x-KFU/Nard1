using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nard1
{
    internal class CellState
    {
        public int station;
        public byte quantity;

        public CellState()
        {
            station = -2;
            quantity = 0;
        }
    }
}
