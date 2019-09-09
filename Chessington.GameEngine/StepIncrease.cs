using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessington.GameEngine
{
    public class StepIncrease
    {
        public int RowIncrease;
        public int ColIncrease;
        public StepIncrease(int row, int col)
        {
            RowIncrease = row;
            ColIncrease = col;
        }
    }
}
