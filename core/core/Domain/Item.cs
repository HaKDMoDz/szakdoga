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
        public float MagicDefense { get; set; }
    }
}
