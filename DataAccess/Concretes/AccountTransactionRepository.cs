using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class AccountTransactionRepository : Repository<AccountTransaction>, IAccountTransactionRepository
{
    public AccountTransactionRepository(BusinessDbContext context) : base(context)
    {
    }
}
