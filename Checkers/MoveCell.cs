using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers
{
    internal class MoveCell: Cell
    {
        private Cell caller;

        public MoveCell(int x, int y,Cell caller): base(x, y)
        {
            this.caller = caller;
            this.BackColor = SettingsManger.OptionCellColor;

            this.Click += new EventHandler(OnClickAction);
        }

        public MoveCell(Point point, Cell caller): base(point)
        {
            this.caller = caller;
            this.BackColor = SettingsManger.OptionCellColor;

            this.Click += new EventHandler(OnClickAction);
        }



        private void OnClickAction(object obj, EventArgs e)
        {
            Board.Instance.RemoveMoveCells();
            RegularMove move = new RegularMove(caller.GetPoint(), this.GetPoint());
            GameSession.ExecuteMove(move);
        }
    }
}
