using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class King : Cell
    {
        private PlayerTeam team;
        public King(int x, int y, PlayerTeam team) : base(x, y)
        {

        }
    }
}
