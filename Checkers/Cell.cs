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
            SetLocation();

        }

        public void Destroy()
        {
            this.Visible = false;
            this.Dispose();
        }
        
        public Cell(Point point)
        {
            this.point = point;

            this.BackColor = GetCellColor(point.X, point.Y);
            this.Width = SettingsManger.CellSize;
            this.Height = SettingsManger.CellSize;
            SetLocation();
        }


        public Color GetCellColor(int x, int y){
            if ((x + y) % 2 == 0)
            {
                return SettingsManger.ColorWhiteCellColor;
            }
            return SettingsManger.ColorBlackCellColor;
        }

        public Point GetLocation(int x, int y){ return this.Location; }

        public void SetLocation()
        {
            this.Location = new Point( this.point.X * SettingsManger.CellSize,
                this.point.Y * SettingsManger.CellSize);
        }

        public Point GetPoint()
        {
            return this.point;
        }

        public void SetPoint(Point point)
        {
            this.point = point;
            SetLocation();
        }
    }
}
