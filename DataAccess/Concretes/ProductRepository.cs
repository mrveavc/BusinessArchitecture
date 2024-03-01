using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(BusinessDbContext context) : base(context)
    {
    }
}
