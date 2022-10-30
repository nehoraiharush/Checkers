using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Checkers
{
    class Peon : Cell
    {
        private PlayerTeam team;

        public Peon(int x, int y, PlayerTeam team): base(x,y){

            this.team = team;

            if (team == PlayerTeam.Black)
                this.Image = Image.FromFile(SpriteManager.blackPoen_image);
            else if (team == PlayerTeam.White)
                this.Image = Image.FromFile(SpriteManager.whitePoen_image);
        }
    }
}
