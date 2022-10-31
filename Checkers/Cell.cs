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

            //We shall move this to the Poen/King class | already been moved just need to delete this until we 
            //will create Poen/King objects
            if(y <= 2 && (x + y) % 2 == 0)
                this.Image = Image.FromFile(SpriteManager.whitePoen_image);
            else if(y >= 5 && (x + y) % 2 == 0)
                this.Image = Image.FromFile(SpriteManager.blackPoen_image);
        }




        public Color GetCellColor(int x, int y){
            if ((x + y) % 2 == 0)
            {
                return SettingsManger.ColorWhiteCellColor;
            }
            return SettingsManger.ColorBlackCellColor;
        }

        public Point GetLocation(int x, int y){
            return new Point(x * SettingsManger.CellSize +  SettingsManger.BoardMarginLeft ,
                y * SettingsManger.CellSize + SettingsManger.BoardMarginTop);
            //TODO: make it always in the middle of the screen
        }
        //not done yet
        public void SetLocation(float widthRatio, float heightRatio)
        {
            this.Location = new Point( (int) ( this.x * SettingsManger.CellSize + (widthRatio * SettingsManger.BoardMarginLeft )),
                (int) (this.y * SettingsManger.CellSize + (heightRatio * SettingsManger.BoardMarginTop )));
        }
    }
}
