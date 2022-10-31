using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers
{
    class SettingsManger
    {
        public static Color ColorWhiteCellColor = Color.White;
        public static Color ColorBlackCellColor = Color.Black;
        
        public static int BoardMarginTop = 50;
        public static int BoardMarginLeft = 175;

        public static int CellSize = 50;

        public static int boardSize = CellSize * 8;
    }
}
