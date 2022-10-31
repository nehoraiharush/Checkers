using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class SpriteManager
    {
        public static string blackPoen_image = "pics/blackPoen.png";
        public static string whitePoen_image = "pics/whitePoen.png";
        public static string whiteKingPoen = "pics/whiteKingPoen.png";
        public static string blackKingPoen = "pics/blackKingPoen.png";

        public static Image GetPoenSprite(PlayerTeam team)
        {
            if (team == PlayerTeam.Black)
                return Image.FromFile(SpriteManager.blackPoen_image);
            else if (team == PlayerTeam.White)
                return Image.FromFile(SpriteManager.whitePoen_image);
            else
            {
                Console.WriteLine("Error: accses without team");
                return null;
            }

        } 

        public static Image GetKingSprite(PlayerTeam team)
        {
            if (team == PlayerTeam.Black)
                return Image.FromFile(SpriteManager.blackKingPoen);
            else if (team == PlayerTeam.White)
                return Image.FromFile(SpriteManager.whiteKingPoen);
            else
            {
                Console.WriteLine("Error: accses without team");
                return null;
            }
        }
    }
}
