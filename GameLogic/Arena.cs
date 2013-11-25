using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Arena
    {
        #region Constructors
        #region Arena
        public void ResetArena()
        {
            characters = new List<Character>();
            arenaFloor = null;
        }

        #region Arena Floor
        private ArenaFloorTile[,] arenaFloor;

        public ArenaFloorTile[,] ArenaFloor
        {
            get
            {
                return this.arenaFloor;
            }
        }
  
        public void BuildArenaFloor(int width)
        {
            this.arenaFloor = new ArenaFloorTile[width, width];
        }

        public ArenaFloorTile[,] GetArenaFloor()
        {
            return this.arenaFloor;
        }
        #endregion

        #endregion

        #region Characters
        private List<Character> characters;
        public List<Character> Characters
        {
            get
            {
                return characters;
            }
        }

        public void AddCharacterToArena(Character c)
        {
            characters.Add(c);
        }

        #endregion

        public Arena()
        {
            characters = new List<Character>();
        }
        #endregion
    }
}
