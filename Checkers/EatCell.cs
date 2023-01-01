using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers
{
    internal class EatCell: MoveCell
    {
        private EatMove eatMove;
        public EatCell(Point point, Peon caller, List<Peon> eatenPeons): base(point, caller)
        {
            this.BackColor = SettingsManger.EatCellColor; 
        }
    }
}
