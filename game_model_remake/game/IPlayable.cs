using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_model_remake
{
    public interface IPlayable
    {
        void MovePlayer(Direction direction);

        int GetMoveCount();

        void UndoMove();
    }
}
