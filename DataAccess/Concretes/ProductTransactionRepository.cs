using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class ProductTransactionRepository : Repository<ProductTransaction>, IProductTransactionRepository
{
    public ProductTransactionRepository(BusinessDbContext context) : base(context)
    {
    }
}
