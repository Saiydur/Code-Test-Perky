using Infrastructure.DbContexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class OrderRepository : Repository<Order,Guid>, IOrderRepository
    {
        public OrderRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
