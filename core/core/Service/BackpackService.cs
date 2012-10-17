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
        void removeItem(ItemName itemName);
        List<Item> getAllItems();
        Boolean contains(ItemName itemName);
        int getQuantity(ItemName itemName);
    }
}
