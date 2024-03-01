using Core.Entities;

namespace Business.Abstracts;

public interface IUserClaimService
{

    UserClaim? GetById(Guid id);
    Task<UserClaim?> GetByIdAsync(Guid id);
    IList<UserClaim> GetAll();
    Task<IList<UserClaim>> GetAllAsync();
    UserClaim Add(UserClaim userClaim);
    UserClaim Update(UserClaim userClaim);
    void DeleteById(Guid id);
    Task<UserClaim> AddAsync(UserClaim userClaim);
    Task<UserClaim> UpdateAsync(UserClaim userClaim);
    Task DeleteByIdAsync(Guid id);
    Task<UserClaim?> GetByUserIdAsync(Guid id);
    
}
