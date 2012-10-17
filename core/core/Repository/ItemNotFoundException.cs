using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core.Repository
{
    public class ItemNotFoundException  :Exception
    {
        public ItemNotFoundException()
            : base("Item not found!")
        {

        }

        public ItemNotFoundException(string msg) 
            : base(msg)
        {

        }
    }
}
