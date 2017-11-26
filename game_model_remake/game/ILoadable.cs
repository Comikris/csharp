using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_model_remake
{
    public interface ILoadable
    {
        int GetRowWidth();
        int GetRowCount();
        int GetPlayerPosX();
        int GetPlayerPosY();
        string GetLevelDesign();
    }
}
