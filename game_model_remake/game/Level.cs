using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace game_model_remake
{
    public class Level : IGame
    {
        public int totalMoves = 0;
        public int RowWidth;
        public int ColumnHeight;
        public bool Completed = false;
        public string myDesign;
        public Canvas myCanvas;
        public List<Entity> data = new List<Entity>();
        public Entity myPlayer = null;

        public Level(int row, int rowW, int px, int py, string level)
        {
            char[] level_data = level.ToCharArray();
            myDesign = level;
            Console.WriteLine(level_data.Length);
            int y = 0;
            int x = 0;
            myPlayer = new Entity(EntityType.PLAYER, this);
            myPlayer.SetLocation(px, py);
            data.Add(myPlayer);
            // # = wall
            // f = floor
            // b = block
            // o = objective
            for (int i = 0; i < level_data.Length; i ++)
            {
                System.Console.Write(level_data[i]);
                char c = level_data[i];
                if ( c == '#' )
                {
                    Entity aEntity = new Entity(EntityType.WALL, this);
                    aEntity.SetLocation(x, y);
                    data.Add(aEntity);
                }

                if (c == 'f')
                {
                    Entity aEntity = new Entity(EntityType.FLOOR, this);
                    aEntity.SetLocation(x, y);
                    data.Add(aEntity);
                }

                if (c == 'b')
                {
                    Entity aEntity = new Entity(EntityType.BLOCK, this);
                    aEntity.SetLocation(x, y);
                    data.Add(aEntity);
                }

                if (c == 'o')
                {
                    Entity aEntity = new Entity(EntityType.GOALTILE, this);
                    aEntity.SetLocation(x, y);
                    data.Add(aEntity);
                }

                x++;
                if(x >= 4)
                {
                    x = 0;
                    y++;
                }
            }
        }

        public string GetLevelDesign()
        {
            return myDesign;
        }

        public int GetMoveCount()
        {
            return myPlayer.totalMoves;
        }

        public int GetPlayerPosX()
        {
            return myPlayer.myLocation.x;
        }

        public int GetPlayerPosY()
        {
            return myPlayer.myLocation.y;
        }

        public int GetRowCount()
        {
            // for the sake of not changing the dirs
            return ColumnHeight;
        }

        public int GetRowWidth()
        {
            return RowWidth;
        }

        public void MovePlayer(Direction direction)
        {
            myPlayer.MoveMe(direction, myPlayer);
        }

        public void UndoMove()
        {
            throw new NotImplementedException();
        }
    }
}
