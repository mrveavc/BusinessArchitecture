using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IProductTransactionRepository : IAsyncRepository<ProductTransaction>, IRepository<ProductTransaction>
{
}
