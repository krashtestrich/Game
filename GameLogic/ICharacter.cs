using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface ICharacter
    {
        #region Basic - Name, etc.
        string Name
        { get; }
        void SetName(string name);
        #endregion

        #region Health, Mana, etc.
        int Health
        {
            get; 
        }
        void SetHealth(int health);
        void LoseHealth(int amount);
        void GainHealth(int amount);
        #endregion

        #region Slots
        List<Slot> Slots
        {
            get;
        }

        void AddSlot(Slot slot);
        #endregion

        #region Equipment
        List<Equipment> CharacterEquipment
        {
            get;
        }

        bool CanEquipEquipment(Equipment equipment);
        void EquipEquipment(Equipment equipment);
        void UnEquipEquipment(Equipment equipment);
        #endregion

        #region Actions
        List<GameLogic.Actions.IAction> AvailableActions
        { get; }

        #endregion        
    }
}
