using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class BackpackItem
    {
        private Item item;
        private int count;

        public ItemName ItemName
        {
            get
            {
                return item.ItemName;
            }
        }

        public Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public void increaseCount(int amount)
        {
            count += amount;
        }

        public void decreaseCount(int amount)
        {
            if (count >= amount)
            {
                count -= amount;
            }
        }
    }
}
