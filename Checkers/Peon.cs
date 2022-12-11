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

        public virtual void CheckMoves(Point point, bool wasEatingOption = false)
        {
            //check how to change the y coordinate
            int yChange = GameSession.MovesDown(team) ? 1 : -1;
            
            //check the right corner
            Point rightCorner = new Point(point.X + 1, point.Y + yChange);
            Console.WriteLine("Checking right corner: " + rightCorner);
            if (Board.Instance.InBounds(rightCorner))
            {
                Console.WriteLine("\tIn bounds");
                if (Board.Instance.IsEmpty(rightCorner))
                {
                    Console.WriteLine("\tEmpty");
                    if (!wasEatingOption)
                    {
                        Console.WriteLine("\tthere is no eating option");
                        Board.Instance.AddMoveCell(rightCorner, this);
                    }
                }
                else if (Board.Instance.IsEnemy(rightCorner, team))
                {
                    Console.WriteLine("\tEnemy");
                    Point rightCornerEating = new Point(rightCorner.X + 1, rightCorner.Y + yChange);
                    if (Board.Instance.InBounds(rightCornerEating) && Board.Instance.IsEmpty(rightCornerEating))
                    {
                        Console.WriteLine("\tEating option");
                        Board.Instance.AddEatCell(rightCornerEating, this);
                        CheckMoves(rightCornerEating, true);
                    }
                }
            }
            
            //check the left corner
            Point leftCorner = new Point(point.X - 1, point.Y + yChange);
            Console.WriteLine("Checking left corner: " + leftCorner);
            if (Board.Instance.InBounds(leftCorner))
            {
                Console.WriteLine("\tIn bounds");
                if (Board.Instance.IsEmpty(leftCorner))
                {
                    Console.WriteLine("\tEmpty");
                    if (!wasEatingOption)
                    {
                        Console.WriteLine("\tthere is no eating option");
                        Board.Instance.AddMoveCell(leftCorner, this);
                    }
                }
                else if (Board.Instance.IsEnemy(leftCorner, team))
                {
                    Console.WriteLine("\tEnemy");
                    //go check for eating options
                    Point leftCornerEating = new Point(leftCorner.X - 1, leftCorner.Y + yChange);
                    if (Board.Instance.InBounds(leftCornerEating) && Board.Instance.IsEmpty(leftCornerEating))
                    {
                        Console.WriteLine("\tEating option");
                        Board.Instance.AddEatCell(leftCornerEating, this);
                        CheckMoves(leftCornerEating, true);
                    }
                }
            }
        }
    }
}
