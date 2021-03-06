﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Actions;
using GameLogic.Actions.Attacks;
using GameLogic.Slots;

namespace GameLogic.Equipments.Weapons
{
    public sealed class Sword : Weapon
    {
        public override string Name
        {
            get
            {
                return "Sword";
            }
        }

        public override int BaseDamage
        {
            get { return 10; }
        }

        public override int BonusDamage
        {
            get { return 5; }
        }

        public override int Price
        {
            get { return 60;  }
        }

        public override List<IAction> Actions
        {
            get
            {
                return new List<IAction>()
                    {
                        new Swing()
                    };
            }
        }

        public Sword()
        {
            AddSlotType(new Hand());
        }
    }
}
