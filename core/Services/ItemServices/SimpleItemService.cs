using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Service;
using core.Repository;

namespace Services.ItemServices
{
    public class SimpleItemService : ItemService
    {
        private ItemRepository itemRepository;

        public ItemRepository ItemRepository
        {
            set
            {
                itemRepository = value;
            }
        }

        public void changeItem()
        {
            throw new NotImplementedException();
        }
    }
}
