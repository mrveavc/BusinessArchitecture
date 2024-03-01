using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IOrderRepository : IAsyncRepository<Order>, IRepository<Order>
{

}
