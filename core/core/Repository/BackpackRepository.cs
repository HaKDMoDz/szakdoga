using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Repository
{
    public interface BackpackRepository
    {
        void addItem(BackpackItem item);
        void updateItem(BackpackItem item);

        /// <summary>
        /// Remove an item. Default value 1.
        /// </summary>
        /// <param name="itemName"></param>
        void removeItem(ItemName itemName);
        /// <summary>
        /// Remove an item. You can add the count.
        /// </summary>
        /// <param name="itemName">s</param>
        /// <param name="count"></param>
        void removeItem(ItemName itemName, int count);
        BackpackItem getItem(ItemName itemName);
        List<BackpackItem> getAllItems();
        bool contains(ItemName itemName);
    }
}
