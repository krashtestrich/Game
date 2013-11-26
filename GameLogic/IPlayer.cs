using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface IPlayer
    {
        int Cash
        { get; }

        void SetCash(int amount);
        void AddCash(int amount);
        bool CanAffordEquipment(Equipment e);
        void PurchaseEquipment(Equipment e);
    }
}
