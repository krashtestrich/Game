﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Actions;
using GameLogic.Arena;
using GameLogic.Slots;
using GameLogic.Actions.Movements;
using MoreLinq;

namespace GameLogic
{
    public class Character : ICharacter
    {
        #region Name
        private string name;
        public void SetName(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        #endregion

        #region Health
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
        }

        public void SetHealth(int health)
        {
            health = health;
        }

        public void LoseHealth(int amount)
        {
            health = health - amount;
        }

        public void GainHealth(int amount)
        {
            health = health + amount;
        }

        #endregion

        #region Slots
        private List<Slot> slots;

        public List<Slot> Slots
        {
            get
            {
                return this.slots;
            }
        }

        public void AddSlot(Slot slot)
        {
            slots.Add(slot);
        }
        #endregion

        #region Position
        private ArenaFloorPosition characterLocation;
        public ArenaFloorPosition CharacterLocation
        {
            get
            {
                return characterLocation;
            }
        }
        public void SetCharacterLocation(int x, int y)
        {
            characterLocation = new ArenaFloorPosition(x, y);
        }
        #endregion

        #region Equipment
        private List<Equipment> characterEquipment;

        public bool CanEquipEquipment(Equipment equipment)
        {
            var uniqueSlots = equipment.Slots.Distinct();

            foreach (var e in uniqueSlots)
            {
                if (slots.Count(i => i.SlotFree && i.SlotType == e.SlotType) < equipment.Slots.Select(x => x.SlotType == e.SlotType).Count())
                {
                    return false;
                }
            }
            return true;
        }

        public void EquipEquipment(Equipment equipment)
        {
            if (CanEquipEquipment(equipment))
            {
                this.characterEquipment.Add(equipment);
                foreach (var s in equipment.Slots)
                {
                    this.slots.Find(sf => sf.SlotFree && sf.SlotType == s.SlotType).SetSlotFree(false, equipment.Name);
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public void UnEquipEquipment(Equipment equipment)
        {
            this.characterEquipment.Remove(equipment);
            foreach (var s in equipment.Slots)
            {
                this.slots.Find(sf => !sf.SlotFree && sf.SlotType == s.SlotType).SetSlotFree(true, null);
            }
        }

        public List<Equipment> CharacterEquipment
        {
            get
            {
                return this.characterEquipment;
            }
        }

        #endregion    

        #region Actions
        public List<IAction> AvailableActions
        {
            get
            {
                var aa = new List<IAction>()
                {
                    new Run()
                };

                aa.AddRange(CharacterEquipment.SelectMany(i => i.Actions));
                return aa.DistinctBy(i => i.Name).ToList();
            }
        }

        public void PerformAction(IAction a)
        {
            
        }

        #endregion

        #region Battle

        public List<IAction> ChosenActions { get; set; }

        #endregion

        public Character()
        {
            characterEquipment = new List<Equipment>();

            slots = new List<Slot>();

            var h1 = new Hand();
            slots.Add(h1);

            var h2 = new Hand();
            slots.Add(h2);

            ChosenActions = new List<IAction>();
        }
    }
}
