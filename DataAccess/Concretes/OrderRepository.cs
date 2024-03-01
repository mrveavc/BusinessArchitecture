using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(BusinessDbContext context) : base(context)
    {
    }


}
