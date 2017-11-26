using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_model_remake
{
    public class Entity
    {
        public Location myLocation;
        public int totalMoves = 0;
        public EntityType myType;
        public Level myLevel;

        public Entity(EntityType aType, Level aLevel)
        {
            myType = aType;
            myLevel = aLevel;
        }

        public Location GetLocation()
        {
            return myLocation;
        }

        public void SetLocation(int x, int y)
        {
            myLocation = new Location();
            myLocation.x = x;
            myLocation.y = y;
        }
        /*Pass a direction,
         * And an entity
         * Should an entity be a wall, do nothing
         */
        public void MoveMe(Direction dir, Entity aEntity)
        {
            int x = 0;
            bool canMove = true;
            int y = 0;
            if ( aEntity.myType != EntityType.WALL )
            {
                if ( dir == Direction.RIGHT )
                {
                    x = 1;
                }

                else if ( dir == Direction.LEFT )
                {
                    x = -1;
                }

                else if ( dir == Direction.UP )
                {
                    y -= 1;
                }
                else {
                    y = 1;
                }
                Entity hit = PlaceMeeting(x, y);
                if ( hit.myType == EntityType.WALL )
                {
                    System.Console.WriteLine("HIT A WALL!!!! LOOOOOOL!!!!");
                    canMove = false;
                }

                else if ( hit.myType == EntityType.BLOCK )
                {
                    Location testLocation = hit.myLocation;
                    hit.MoveMe(dir, this);
                    if (hit.myLocation.x == testLocation.x && hit.myLocation.y == testLocation.y)
                    {
                        canMove = false;
                    }
                }

                if ( canMove )
                {
                    myLocation.x += x;
                    myLocation.y += y;
                    totalMoves++;
                }

                
            }
            Console.WriteLine(myType + "mylocation: " + myLocation.x + " " + myLocation.y);
        }

        public Entity PlaceMeeting(int x, int y)
        {
            myLevel.data.Remove(this);
            Location myLocation = GetLocation();
            Entity hit = new Entity(EntityType.FLOOR, null);
            foreach(Entity target in myLevel.data)
            {
                if ( myLocation.x + x == target.myLocation.x && myLocation.y + y == target.myLocation.y)
                {
                    if ( target.myType == EntityType.WALL || target.myType == EntityType.BLOCK )
                    {
                        hit = target;
                    }
                }
            }
            myLevel.data.Add(this);
            return hit;
        }
    }
}
