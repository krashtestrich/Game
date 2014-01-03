using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Arena
{
    public class Arena
    {
        #region Constructors
        #region Arena
        public void ResetArena()
        {
            _characters = new List<Character>();
            _arenaFloor = null;
        }

        #region Arena Floor
        private ArenaFloorTile[,] _arenaFloor;

        public ArenaFloorTile[,] ArenaFloor
        {
            get
            {
                return _arenaFloor;
            }
        }
  
        public void BuildArenaFloor(int width)
        {
            _arenaFloor = new ArenaFloorTile[width, width];
        }

        public ArenaFloorTile[,] GetArenaFloor()
        {
            return _arenaFloor;
        }
        #endregion

        #endregion

        #region Characters
        private List<Character> _characters;
        private Player _player;
        public List<Character> Characters
        {
            get
            {
                return _characters;
            }
        }

        public Player Player
        {
            get
            {
                return _player;
            }
        }

        public void AddCharacterToArena(Character c)
        {
            if (_arenaFloor == null)
            {
                throw new Exception("Arena not been constructed!");
            }

            _characters.Add(c);
        }

        public void AddPlayerToArena(Player p, int? xLoc = null, int? yLoc = null)
        {
            if (_arenaFloor == null)
            {
                throw new Exception("Arena not been constructed!");
            }

            _player = p;
            if (xLoc == null || yLoc == null)
            {
                SetDefaultPlayerLocation();
            }
            else
            {
                _player.SetCharacterLocation((int)xLoc, (int)yLoc);
            }
        }

        public void SetDefaultPlayerLocation()
        {
            if (_player == null)
            {
                throw new Exception("Player hasn't been added to Arena!");
            }

            if (_arenaFloor == null)
            {
                throw new Exception("Arena floor hasn't been setup!");
            }

            var xLoc = _arenaFloor.GetLength(0) - 1;
            var yLoc = Math.Floor((double)((_arenaFloor.GetLength(1) - 1) / 2));
            _player.SetCharacterLocation(xLoc, (int)yLoc);
        }

        #endregion

        #region Battle

        private Battle.Battle _battle;
        #endregion

        public Arena()
        {
            _characters = new List<Character>();
        }
        #endregion
    }
}
