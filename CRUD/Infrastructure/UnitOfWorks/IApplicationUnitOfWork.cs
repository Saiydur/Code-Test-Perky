using Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IOrderItemRepository OrderItems { get; }
        public IOrderRepository Orders { get; }
        public IItemRepository Items { get; }
    }
}
