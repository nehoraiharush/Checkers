using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    internal class Peon : Cell
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
        
        public PlayerTeam GetTeam()
        {
            return team;
        }

        public void ShowMoves(object obj, EventArgs e)
        {
            if (!GameSession.IsMyTurn(team)) return;
            Board.Instance.RemoveMoveCells();
            CheckMoves(this.GetPoint());
        }

        public virtual void CheckMoves(Point point, List<EatCell> eatCells = null, List<Peon> eatenPeons = null)
        {
            if (eatCells == null) eatCells = new List<EatCell>();
            if(eatenPeons == null) eatenPeons = new List<Peon>();
            //check if we need to swap the y axis
            int yMultiplier = GameSession.MovesDown(team) ? -1 : 1;
            //check the left corner for eating options only
            Point leftPoint = new Point(point.X - 1, point.Y + yMultiplier);
            if (Board.Instance.IsEnemy(leftPoint, team))
            {
                Point leftEatPoint = new Point(point.X - 2, point.Y + yMultiplier * 2);
                if (Board.Instance.IsEmpty(leftEatPoint))
                {
                    Peon peon = Board.Instance.GetPeon(leftPoint);
                    if (peon != null)
                    {
                        eatenPeons.Add(peon);
                        eatCells.Add(new EatCell(leftEatPoint, this,eatenPeons));
                        CheckMoves(leftEatPoint, eatCells, eatenPeons);
                        eatenPeons.Remove(peon);
                    }
                }
            }
            //check the right corner for eating options only
            Point rightPoint = new Point(point.X + 1, point.Y + yMultiplier);
            if (Board.Instance.IsEnemy(rightPoint, team))
            {
                Point rightEatPoint = new Point(point.X + 2, point.Y + yMultiplier * 2);
                if (Board.Instance.IsEmpty(rightEatPoint))
                {
                    Peon peon = Board.Instance.GetPeon(rightPoint);
                    if (peon != null)
                    {
                        eatenPeons.Add(peon);
                        eatCells.Add(new EatCell(rightEatPoint, this, eatenPeons));
                        CheckMoves(rightEatPoint, eatCells, eatenPeons);
                        eatenPeons.Remove(peon);
                    }
                }
            }
            //if there was no eating options, that means the player can do a regular move
            if (eatCells.Count == 0) return;
            //check the left corner for regular moves
            Point leftMovePoint = new Point(point.X - 1, point.Y + yMultiplier);
            if(Board.Instance.IsEmpty(leftMovePoint))
            {
                eatCells.Add(new EatCell(leftMovePoint, this, eatenPeons));
            }
            //check the right corner for regular moves
            Point rightMovePoint = new Point(point.X + 1, point.Y + yMultiplier);
            if (Board.Instance.IsEmpty(rightMovePoint))
            {
                eatCells.Add(new EatCell(rightMovePoint, this, eatenPeons));
            }
        }
    }
}
