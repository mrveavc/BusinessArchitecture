using Core.Repository;
using Entities.Models;
using Core.Entities;


namespace DataAccess.Abstracts;

public interface IUserClaimRepository : IAsyncRepository<UserClaim>, IRepository<UserClaim>
{
}

