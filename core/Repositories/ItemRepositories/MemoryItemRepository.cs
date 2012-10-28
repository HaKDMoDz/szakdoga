using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Repository;
using core.Domain;

namespace Repositories.ItemRepositories
{
    public class MemoryItemRepository : ItemRepository
    {
        private Dictionary<ItemName, Item> items = new Dictionary<ItemName, Item>();


        public List<Item> getAllItems()
        {
            return items.Values.ToList();
        }

        public Item getItem(ItemName itemName)
        {
            if (!items.ContainsKey(itemName))
            {
                throw new ItemNotFoundException("The " + itemName + " not found!");                
            }
            return items[itemName];
        }

        public void addItem(Item item)
        {
            if (item != null)
            {
                items.Add(item.ItemName, item);
            }
        }

        public void removeItem(Item item)
        {
            if (!items.ContainsKey(item.ItemName))
            {
                throw new ItemNotFoundException("The " + item.ItemName + " not found!");                
            }
            items.Remove(item.ItemName);
        }
    }
}
