using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;
using core.Repository;

namespace Repositories.BackpackRepositories
{
    public class MemoryBaseBackpackRepository : BackpackRepository
    {
        private Dictionary<ItemName, BackpackItem> items = new Dictionary<ItemName, BackpackItem>();

        public void addItem(BackpackItem item)
        {
            CheckItemNull(item);

            items.Add(item.ItemName, item);
        }

        public void updateItem(BackpackItem item)
        {
            CheckItemNull(item);

            if (items.ContainsKey(item.ItemName))
            {
                items.Remove(item.ItemName);
                items.Add(item.ItemName, item);
            }
        }

        public void removeItem(ItemName itemName, int count)
        {
            BackpackItem backpackItem = getItem(itemName);
            if (backpackItem.Count < count)
            {
                throw new NotEnoughtItemException("The available item lesser than the requested!");
            }
            else if (backpackItem.Count > count)
            {
                items[itemName].decreaseCount(count);
            }
            else
            {
                items.Remove(itemName);
            }

        }

        public void removeItem(ItemName itemName)
        {
            removeItem(itemName, 1);
        }

        public BackpackItem getItem(ItemName itemName)
        {
            BackpackItem ret = null;
            if (items.ContainsKey(itemName))
            {
                ret = items[itemName];
            }
            else
            {
                throw new BackPackItemNotFound("The " + itemName + " wasn't found!");
            }

            return ret;
        }

        public List<BackpackItem> getAllItems()
        {
            return items.Values.ToList();
        }

        private void CheckItemNull(BackpackItem item)
        {
            if (item == null)
            {
                throw new NullReferenceException("Not valid item!");
            }
        }

        public bool contains(ItemName itemName)
        {
            return items.ContainsKey(itemName);
        }

    }
}
