using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(BusinessDbContext context) : base(context)
    {
    }
}
