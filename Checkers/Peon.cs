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
            this.Image = SpriteManager.GetPoenSprite(team);
        }
    }
}
