using AutoMapper;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBO = Infrastructure.BusinessObjects.Item;
using ItemEO = Infrastructure.Entities.Item;

namespace Infrastructure.Services
{
    public class ItemService : IItemService
    {

        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public ItemService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public void CreateItem(ItemBO item)
        {
            var count = _applicationUnitOfWork.Items.GetCount(x=>x.Name==item.Name);
            if(count > 0)
            {
                throw new Exception("Item already exists");
            }
            var itemEO = _mapper.Map<ItemEO>(item);
            _applicationUnitOfWork.Items.Add(itemEO);
            _applicationUnitOfWork.Save();
        }

        public void DeleteItem(Guid id)
        {
            _applicationUnitOfWork.Items.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public List<ItemBO> GetAllItems()
        {
            var itemEOs = _applicationUnitOfWork.Items.GetAll();
            if(itemEOs.Count > 0)
            {
                var itemBOs = new List<ItemBO>();
                foreach (var itemEO in itemEOs)
                {
                    var itemBO = _mapper.Map<ItemBO>(itemEO);
                    itemBOs.Add(itemBO);
                }
                return itemBOs;
            }
            else
            {
                throw new Exception("No items found");
            }
        }

        public ItemBO GetItem(Guid id)
        {
            var itemEO = _applicationUnitOfWork.Items.Get(x => x.Id.Equals(id), "")
                .FirstOrDefault();
            if(itemEO != null)
            {
                var itemBO = _mapper.Map<ItemBO>(itemEO);
                return itemBO;
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        public void UpdateItem(ItemBO item)
        {
            var itemEO = _applicationUnitOfWork.Items.GetById(item.Id);
            if (itemEO != null)
            {
                itemEO = _mapper.Map(item,itemEO);
                _applicationUnitOfWork.Save();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
    }
}
