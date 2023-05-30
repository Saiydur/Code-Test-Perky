using Autofac;
using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;

namespace CRUD.API.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        private IItemService _itemService;
        private IMapper _mapper;

        public ItemModel()
        {
            
        }

        public ItemModel(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public void ResolveDependecnies(ILifetimeScope scope)
        {
            _itemService = scope.Resolve<IItemService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public void CreateItem()
        {
            var itemBO = _mapper.Map<Item>(this);
            _itemService.CreateItem(itemBO);
        }

        public void DeleteItem(Guid id)
        {
            _itemService.DeleteItem(id);
        }

        public void UpdateItem()
        {
            var itemBO = _mapper.Map<Item>(this);
            _itemService.UpdateItem(itemBO);
        }

        public List<ItemModel> GetAllItems()
        {
            var itemBOs = _itemService.GetAllItems();
            return _mapper.Map<List<ItemModel>>(itemBOs);
        }

        public ItemModel GetItem(Guid id)
        {
            var itemBO = _itemService.GetItem(id);
            return _mapper.Map<ItemModel>(itemBO);
        }
    }
}
