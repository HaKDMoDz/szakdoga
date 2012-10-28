using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface BackpackService
    {
        void addItem(Item item);
        void addItem(Item item, int count);
        void addItems(BoughtItem[] items);
        void removeItem(ItemName itemName);
        void removeItem(ItemName itemName, int amount);
        List<Item> getAllItems();
        Boolean contains(ItemName itemName);
        int getQuantity(ItemName itemName);
    }
}
