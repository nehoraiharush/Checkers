using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Checkers
{
    class Board
    {
        private Form context;
        private Cell[,] cells;
        private List<MoveCell> moves = new List<MoveCell> ();

        //to accsess the board from any class we need to make it self a static varubale
        private static Board instance;
        public static Board Instance { get { return instance; } }

        public Board(Form context){

            cells = new Cell[8, 8];
            this.context = context;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if((i + j) % 2 == 0 && j <= 2)
                        cells[i, j] = new Peon(i, j, PlayerTeam.White);

                    else if((i + j) % 2 == 0 && j >= 5)
                        cells[i, j] = new Peon(i, j, PlayerTeam.Black);

                    else
                        cells[i, j] = new Cell(i, j);

                    context.Controls.Add(cells[i, j]);
                }
            }

            instance = this;
        }

        public Cell[,] GetCells() { return this.cells; }

        public bool InBounds(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < 8 && point.Y < 8;
            //TODO: make the size as a varuble
        }
        
        public void AddPeon(Point point, PlayerTeam team)
        {
            context.Controls.Remove(cells[point.X, point.Y]);
            cells[point.X,point.Y] = new Peon(point, team);
            context.Controls.Add(cells[point.X, point.Y]);
        }
        
        public void RemovePeon(Point point)
        {
            context.Controls.Remove(cells[point.X, point.Y]);
            cells[point.X, point.Y] = new Cell(point);
            context.Controls.Add(cells[point.X, point.Y]);
        }

        public void MovePiece(Point src, Point dst)
        {
            context.Controls.Remove(cells[dst.X, dst.Y]);
            Cell cell = cells[src.X, src.Y];
            cell.SetPoint(dst);
            cells[dst.X, dst.Y] = cell;
            cells[src.X, src.Y] = new Cell(src);
            context.Controls.Add(cells[src.X, src.Y]);
            Console.WriteLine("Moved Piece");
        }

        public bool IsEmpty(Point point)
        {
            return !(cells[point.X, point.Y] is Peon);
        }

        public void AddMoveCell(Point point, Cell caller)
        {
            Console.WriteLine("Adding Move Cell at: " + point.X + ", " + point.Y);
            cells[point.X, point.Y].Destroy();
            context.Controls.Remove(cells[point.X, point.Y]);
            MoveCell moveCell = new MoveCell(point, caller);
            cells[point.X, point.Y] = moveCell;
            context.Controls.Add(moveCell);
            moves.Add(moveCell);
        }

        public Peon GetPeon(Point point)
        {
            if (cells[point.X, point.Y] is Peon)
            {
                Peon peon = (Peon)cells[point.X, point.Y];
                return peon;
            }

            return null;
        }

        public void AddEatCell(List<Peon> peonsToEat, Peon caller)
        {
            Console.WriteLine("Adding Eat Cell at: " + peonsToEat[0].GetPoint().X + ", " + peonsToEat[0].GetPoint().Y);
            
        }

        public void RemoveMoveCells()
        {
            Console.WriteLine("Removing all move cells");
            foreach(MoveCell moveCell in moves)
            {
                Console.WriteLine(" Removing move cell at " + moveCell.GetPoint());
                context.Controls.Remove(moveCell);
                Cell cell = new Cell(moveCell.GetPoint());
                cells[moveCell.GetPoint().X, moveCell.GetPoint().Y] = cell;
                context.Controls.Add(cells[moveCell.GetPoint().X,moveCell.GetPoint().Y]);
            }
            moves.Clear();
        }

        public bool IsEnemy(Point point, PlayerTeam team)
        {
            if(!Instance.InBounds(point))
                return false;
            if (!(Instance.cells[point.X, point.Y] is Peon)) return false;
            return ((Peon)Instance.cells[point.X, point.Y]).GetTeam() != team;
        }

    }
}
