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
            SetLocation(0,0);

        }


        public Color GetCellColor(int x, int y){
            if ((x + y) % 2 == 0)
            {
                return SettingsManger.ColorWhiteCellColor;
            }
            return SettingsManger.ColorBlackCellColor;
        }

        public Point GetLocation(int x, int y){ return this.Location; }
        
        public void SetLocation(int formWidth, int formHeight)
        {
            int x = SettingsManger.BoardMarginLeft;
            int y = SettingsManger.BoardMarginTop;

            if (formHeight > 0 && formWidth > 0)
            {
                x = (formWidth - SettingsManger.boardSize) / 2;
                y = (formHeight - SettingsManger.boardSize) / 2;
            }
            

            this.Location = new Point( this.x * SettingsManger.CellSize + x,
                this.y * SettingsManger.CellSize + y);
        }
    }
}
