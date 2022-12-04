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
        Point point;

        public Cell(int x, int y)
        {            
            this.point = new Point(x, y);

            this.BackColor = GetCellColor(x,y);
            this.Width = SettingsManger.CellSize;
            this.Height = SettingsManger.CellSize;
            SetLocation(0,0);

        }

        public Cell(Point point)
        {
            this.point = point;

            this.BackColor = GetCellColor(point.X, point.Y);
            this.Width = SettingsManger.CellSize;
            this.Height = SettingsManger.CellSize;
            SetLocation(0, 0);
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
            

            this.Location = new Point( this.point.X * SettingsManger.CellSize + x,
                this.point.Y * SettingsManger.CellSize + y);
        }

        public Point GetPoint()
        {
            return this.point;
        }

        public void SetPoint(Point point)
        {
            this.point = point;
            SetLocation(0,0);
        }
    }
}
