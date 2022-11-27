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
        private static PlayerTeam playerUp;


        public static void Start(Form context)
        {
            GameSession.context = context;
            board = new Board(context);
            //TODO:: make the player up varuble dynamicly
            GameSession.playerUp = PlayerTeam.White;
        }
        
        public static void SizeChanged(int formWidth, int formHeight)
        {
            Cell[,] cells = board.GetCells();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j].SetLocation(formWidth, formHeight);
                }
            }

        }

        public static bool MovesDown(PlayerTeam team)
        {
            return playerUp == team;
        }
    }
}
