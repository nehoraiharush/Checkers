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
        private static Stack<IMoveCommand> movesDone = new Stack<IMoveCommand>();
        private static PlayerTeam currentTeam = PlayerTeam.White;

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
                    cells[i, j].SetLocation();
                }
            }

        }

        public static bool MovesDown(PlayerTeam team)
        {
            return playerUp == team;
        }

        public static void ExecuteMove(IMoveCommand move)
        {
            Console.WriteLine("Executing Command " + move);
            move.Execute();
            movesDone.Push(move);
            SwitchTeams();
        }

        public static void RevertLastMove()
        {
            IMoveCommand move = movesDone.Pop();
            move.Revert();
            SwitchTeams();
        }

        public static bool IsMyTurn(PlayerTeam team)
        {
            return team == currentTeam;
        }




        private static void SwitchTeams()
        {
            if (currentTeam == PlayerTeam.White)
            {
                currentTeam = PlayerTeam.Black;
            }
            else
            {
                currentTeam = PlayerTeam.White;
            }
        }
    }
}
