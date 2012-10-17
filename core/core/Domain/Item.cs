using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Domain
{
    public class Item
    {
        public String Name { get; set; }
        public ItemType ItemType { get; set; }
        public ItemClass ItemClass { get; set; }
        public ItemName ItemName { get; set; }
        public float MagicDefense { get; set; }

        private static Builder builder;

        private Item()
        {
        }

        private class Builder
        {
            Item item = new Item();

            public Item Item
            {
                get
                {
                    return item;
                }
            }
        }

        public static Item create()
        {
            return builder.Item;
        }

        public Item clone()
        {
            return new Item();
        }

    }
}
