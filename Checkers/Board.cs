using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    class Board
    {
        private Form context;
        private Cell[,] cells;



        public Board(Form context){
            cells = new Cell[8, 8];
            this.context = context;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j] = new Cell(i, j);
                    context.Controls.Add(cells[i, j]);
                }
            }
        }

        public Cell[,] GetCells() { return this.cells; }
    }
}
