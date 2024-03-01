using Business.Abstracts;
using Business.Validations;
using Core.Entities;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class UserClaimManager : IUserClaimService
{

    public readonly IUserClaimRepository _userClaimRepository;


    public UserClaimManager(IUserClaimRepository userClaimRepository
    )
    {
        _userClaimRepository = userClaimRepository;
    }
    public UserClaim Add(UserClaim userClaim)
    {
        return _userClaimRepository.Add(userClaim);
    }

    public async Task<UserClaim> AddAsync(UserClaim userClaim)
    {
        return await _userClaimRepository.AddAsync(userClaim);
    }

    public void DeleteById(Guid id)
    {
        var userClaim = _userClaimRepository.Get(u => u.Id == id);
        _userClaimRepository.Delete(userClaim);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var userClaim = _userClaimRepository.Get(u => u.Id == id);
        await _userClaimRepository.DeleteAsync(userClaim);
    }

    public IList<UserClaim> GetAll()
    {
        return _userClaimRepository.GetAll().ToList();
    }

    public async Task<IList<UserClaim>> GetAllAsync()
    {
        var result = await _userClaimRepository.GetAllAsync();
        return result.ToList();
    }

    public UserClaim? GetById(Guid id)
    {
        return _userClaimRepository.Get(u => u.Id == id);
    }

    public async Task<UserClaim?> GetByIdAsync(Guid id)
    {
        return await _userClaimRepository.GetAsync(u => u.Id == id);
    }
    public async Task<UserClaim?> GetByUserIdAsync(Guid id)
    {
        return await _userClaimRepository.GetAsync(u => u.UserId == id);
    }

    public UserClaim Update(UserClaim userClaimType)
    {
        return _userClaimRepository.Update(userClaimType);
    }

    public async Task<UserClaim> UpdateAsync(UserClaim userClaimType)
    {
        return await _userClaimRepository.UpdateAsync(userClaimType);
    }
}
