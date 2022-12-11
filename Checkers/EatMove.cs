using System.Collections.Generic;

namespace Checkers
{
    public class EatMove: IMoveCommand
    {
        private List<Peon> eatenCells;
        private Peon peon;
        
        
        public EatMove(Peon peon, List<Peon> eatenCells)
        {
            this.peon = peon;
            this.eatenCells = eatenCells;
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