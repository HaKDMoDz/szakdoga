using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Repository
{
    public interface ItemRepository
    {
        List<Item> getAllItems();
        Item getItem(ItemName itemName);
        void addItem(Item item);
        void removeItem(Item item);
    }
}
