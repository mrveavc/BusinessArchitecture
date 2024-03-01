using Entities.Models;
using Core.Repository;


namespace DataAccess.Abstracts;

public interface ICategoryRepository : IAsyncRepository<Category>, IRepository<Category>
{
}
