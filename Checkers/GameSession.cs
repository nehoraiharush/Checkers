using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Checkers
{
    class GameSession
    {
        private static Board board;
        private static Form context;
        private static Cell[,] cells;


        public static void Start(Form context)
        {
            GameSession.context = context;
            board = new Board(context);
        }
        
        public static void SizeChanged(int formWidth, int formHeight)
        {
            cells = board.GetCells();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j].SetLocation(formWidth, formHeight);
                }
            }

        }
    }
}
