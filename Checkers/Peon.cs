using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    class Peon : Cell
    {
        private PlayerTeam team;

        public Peon(int x, int y, PlayerTeam team): base(x,y){

            this.team = team;
            this.Image = SpriteManager.GetPoenSprite(team);

            this.Click += new EventHandler(ShowMoves);
        }

        public Peon(Point point, PlayerTeam team): base(point)
        {
            this.team = team;
            this.Image = SpriteManager.GetPoenSprite(team);

            this.Click += new EventHandler(ShowMoves);
        }

        public void ShowMoves(object obj, EventArgs e)
        {
            if (!GameSession.IsMyTurn(team)) return;
            Board.Instance.RemoveMoveCells();
            CheckMoves(this.GetPoint());
        }

        public virtual void CheckMoves(Point point)
        {
            //check how to chnage the y cordinate
            int ym = -1;
            if (GameSession.MovesDown(this.team))
            {
                ym = 1;
            }

            //check the right corner
            Point rightCorner = new Point(point.X - 1, point.Y + ym);
            if (Board.Instance.InBounds(rightCorner) && Board.Instance.IsEmpty(rightCorner))
            {
                Board.Instance.AddMoveCell(rightCorner, this);
            }
            else
            {
                Point eatPoint = new Point(point.X - 2, point.Y + ym * 2);
                if(Board.Instance.InBounds(eatPoint) && Board.Instance.IsEmpty(eatPoint))
                {
                    Board.Instance.AddMoveCell(eatPoint, this);
                    CheckMoves(eatPoint);
                }
            }

            //check the left corner
            Point leftcorner = new Point(point.X + 1, point.Y + ym);
            if (Board.Instance.InBounds(leftcorner) && Board.Instance.IsEmpty(leftcorner))
            {
                Board.Instance.AddMoveCell(leftcorner, this);
            }
            else
            {
                Point eatPoint = new Point(point.X + 2, point.Y + ym * 2);
                if (Board.Instance.InBounds(eatPoint) && Board.Instance.IsEmpty(eatPoint))
                {
                    Board.Instance.AddMoveCell(eatPoint, this);
                    CheckMoves(eatPoint);
                }
            }
        }
    }
}
