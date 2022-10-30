using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Peon : Cell
    {
        private PlayerTeam team;
        public Peon(int x, int y, PlayerTeam team): base(x,y){

        }
    }
}
