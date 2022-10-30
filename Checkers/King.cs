using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Checkers
{
    class King : Cell
    {
        private PlayerTeam team;

        public King(int x, int y, PlayerTeam team) : base(x, y)
        {
            this.team = team;

            if (team == PlayerTeam.Black)
                this.Image = Image.FromFile(SpriteManager.blackKingPoen);
            else if(team == PlayerTeam.White)
                this.Image = Image.FromFile(SpriteManager.whiteKingPoen);
        }
    }
}
