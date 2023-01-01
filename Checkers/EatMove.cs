using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Checkers
{
    internal class EatMove: IMoveCommand
    {
        private List<Peon> eatenCells;
        private Peon peon;
        private RegularMove move;


        public EatMove(Peon peon, List<Peon> eatenCells)
        {
            this.peon = peon;
            this.eatenCells = eatenCells;
            if(eatenCells.Count > 0)
                move = new RegularMove(peon.GetPoint(), eatenCells[eatenCells.Count - 1].Location);
            this.move = new RegularMove(peon.GetPoint(), peon.GetPoint());
        }
        
        public void AddOption(Peon peon, Point point)
        {
            eatenCells.Add(peon);
            move.ChangeDestination(point);
        }
        
        public void Execute()
        {
            foreach (var eatenCell in eatenCells)
            {
                Board.Instance.RemovePeon(eatenCell.GetPoint());
            }
            Board.Instance.MovePiece(peon.GetPoint(), eatenCells[eatenCells.Count - 1].GetPoint());
        }
        
        public void Revert()
        {
            Board.Instance.MovePiece(eatenCells[eatenCells.Count - 1].GetPoint(), peon.GetPoint());
            foreach (var eatenCell in eatenCells)
            {
                Board.Instance.AddPeon(eatenCell.GetPoint(),eatenCell.GetTeam());
            }
        }
    }
}