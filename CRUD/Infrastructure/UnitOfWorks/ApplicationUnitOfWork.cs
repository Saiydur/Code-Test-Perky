using Infrastructure.DbContexts;
using Infrastructure.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        //Repos
        public IOrderItemRepository OrderItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IItemRepository Items { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IItemRepository itemRepository)
            : base((DbContext)dbContext)
        {
            OrderItems = orderItemRepository;
            Orders = orderRepository;
            Items = itemRepository;
        }
    }
}
