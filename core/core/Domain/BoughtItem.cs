using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class BoughtItem
    {
        private Item item;
        private int count;

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
    }
}
