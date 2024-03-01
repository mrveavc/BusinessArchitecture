using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IOrderDetailRepository : IAsyncRepository<OrderDetail>, IRepository<OrderDetail>
{
}
