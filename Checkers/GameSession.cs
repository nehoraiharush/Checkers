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


        public static void Start(Form context)
        {
            GameSession.context = context;
            board = new Board(context);
        }
    }
}
