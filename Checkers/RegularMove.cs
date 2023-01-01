using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers
{
    internal class RegularMove: IMoveCommand
    {
        private Point from;
        private Point to;

        public RegularMove(Point from, Point to)
        {
            this.from = from;
            this.to = to;
        }
        
        public void ChangeDestination(Point to)
        {
            this.to = to;
        }

        public void Execute()
        {
            Board.Instance.MovePiece(from, to);
        }

        public void Revert()
        {
            Board.Instance.MovePiece(to, from);
        }
    }
}
