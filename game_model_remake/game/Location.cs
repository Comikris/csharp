using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_model_remake
{
    public struct Location
    {
        public int x { get; set; }
        public int y { get; set; }

        public Location(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }
    }
}
