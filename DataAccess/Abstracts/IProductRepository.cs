using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IProductRepository : IAsyncRepository<Product>, IRepository<Product>
{
}
