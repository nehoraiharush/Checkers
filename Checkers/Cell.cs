using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Checkers
{
    class Cell : Label
    {
        private int x;
        private int y;


        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.BackColor = GetCellColor(x,y);
            this.Width = SettingsManger.CellSize;
            this.Height = SettingsManger.CellSize;
            this.Location = GetLocation(x,y);
            
        }




        public static System.Drawing.Color GetCellColor(int x, int y){
            if ((x + y) % 2 == 0)
            {
                return SettingsManger.ColorWhiteCellColor;
            }
            return SettingsManger.ColorBlackCellColor;
        }

        public static Point GetLocation(int x, int y){
            return new Point(x * SettingsManger.CellSize + SettingsManger.BoardMarginLeft , y * SettingsManger.CellSize + SettingsManger.BoardMarginTop);
            //TODO: make it always in the middle of the screen
        }
    }
}
