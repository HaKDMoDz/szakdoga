using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Repository;
using core.Domain;

namespace Services.BackpackServices
{
    public class SimpleBackpackService : BackpackService
    {
        private BackpackRepository backpackRepository;

        public BackpackRepository BackpackRepository
        {
            set
            {
                backpackRepository = value;
            }
        }

        public SimpleBackpackService(BackpackRepository backpackRepository)
        {
            this.backpackRepository = backpackRepository;
        }

        public void addItem(Item item)
        {
            addItem(item, 1);
        }

        public void addItem(Item item, int count)
        {

            BackpackItem backpackItem = new BackpackItem();
            backpackItem.Item = item;

            if (backpackRepository.contains(item.ItemName))
            {
                backpackItem.increaseCount(count);
                backpackRepository.updateItem(backpackItem);
            }
            else
            {
                backpackItem.Count = count;
                backpackRepository.addItem(backpackItem);
            }
        }

        public void addItems(BoughtItem[] items)
        {
            foreach (var item in items)
            {
                addItem(item.Item, item.Count);
            }
        }

        public void removeItem(ItemName itemName, int count)
        {
            if (contains(itemName))
            {
                backpackRepository.removeItem(itemName, count);
            }
        }

        public void removeItem(ItemName itemName)
        {
            removeItem(itemName, 1);
        }

        public List<Item> getAllItems()
        {
            List<Item> ret = new List<Item>();
            var list = backpackRepository.getAllItems();

            foreach (var item in list)
            {
                ret.Add(item.Item);
            }

            return ret;
        }

        public bool contains(ItemName itemName)
        {
            bool ret = false;
            if (backpackRepository.contains(itemName))
            {
                ret = true;
            }
            else
            {
                throw new ItemNotFoundException("The " + itemName + " wasn't found!");
            }

            return ret;
        }

        public int getQuantity(ItemName itemName)
        {
            return backpackRepository.getItem(itemName).Count;
        }

    }
}
