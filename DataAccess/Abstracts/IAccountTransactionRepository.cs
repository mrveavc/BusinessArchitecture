using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IAccountTransactionRepository : IAsyncRepository<AccountTransaction>, IRepository<AccountTransaction>
{
}
