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
        public EatCell(Point point, Cell caller): base(point, caller)
        {
            this.BackColor = SettingsManger.EatCellColor;
        }
    }
}
