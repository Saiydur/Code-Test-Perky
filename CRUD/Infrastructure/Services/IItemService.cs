using Infrastructure.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IItemService
    {
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
        Item GetItem(Guid id);
        List<Item> GetAllItems();
    }
}
