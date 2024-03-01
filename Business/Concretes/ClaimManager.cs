using Business.Abstracts;
using Business.Validations;
using Core.Aspects.Autofac.Transaction;
using DataAccess.Abstracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concretes;
[HandleSecurity]

public class ClaimManager : IClaimService
{
    private readonly IClaimRepository _claimRepository;
    private readonly ClaimValidations _claimValidations;
    public ClaimManager(IClaimRepository claimRepository,ClaimValidations claimValidations)
    {
        _claimRepository = claimRepository;
        _claimValidations = claimValidations;
    }
    [TransactionScopeAspect]
    [CacheRemoveAspect("Business.Abstracts.IClaimService.GetAllAsync")]
    [SecurityAspect]
    public Claim Add(Claim claim)
    {
        return _claimRepository.Add(claim);
    }
    [TransactionScopeAspect]
    [CacheRemoveAspect("Business.Abstracts.IClaimService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Claim> AddAsync(Claim claim)
    {
        return await _claimRepository.AddAsync(claim);
    }
    [SecurityAspect]
    public void DeleteById(Guid id)
    {
        var claim = _claimRepository.Get(c=>c.Id==id);
        _claimValidations.ClaimMustNotBeEmpty(claim).Wait();
        _claimRepository.Delete(claim);
    }
    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var claim = _claimRepository.Get(c => c.Id == id);
        await _claimValidations.ClaimMustNotBeEmpty(claim);
        await _claimRepository.DeleteAsync(claim);
    }
    [SecurityAspect]
    public IList<Claim> GetAll()
    {
        return _claimRepository.GetAll().ToList();
    }
    [SecurityAspect]
    public async Task<IList<Claim>> GetAllAsync()
    {
        var result= await _claimRepository.GetAllAsync();
        return result.ToList();
    }
    [SecurityAspect]
    public IList<Claim> GetAllByUserId(Guid userId)
    {
        return _claimRepository.GetAll(c => c.UserClaim.UserId == userId, include: claim => claim.Include(c => c.UserClaim)).ToList();
    }
    [SecurityAspect]
    public async Task<IList<Claim>> GetAllByUserIdAsync(Guid userId)
    {
        var result = await _claimRepository.GetAllAsync(c => c.UserClaim.UserId == userId, include: claim => claim.Include(c => c.UserClaim));
        return result.ToList();
    }
    [SecurityAspect]
    public Claim? GetById(Guid id)
    {
        return _claimRepository.Get(c=>c.Id==id);
    }
    [SecurityAspect]
    public Claim? GetByGroupAndName(string group, string name)
    {
        return _claimRepository.Get(c => c.Group == group && c.Name == name);
    }
    [SecurityAspect]
    [CacheAspect(10)]
    public async Task<Claim?> GetByIdAsync(Guid id)
    {
        return await _claimRepository.GetAsync(c => c.Id == id);
    }
    [CacheRemoveAspect("Business.Abstracts.IClaimService.GetAllAsync")]
    [SecurityAspect]
    public Claim Update(Claim claim)
    {
        return _claimRepository.Update(claim);
    }
    [CacheRemoveAspect("Business.Abstracts.IClaimService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Claim> UpdateAsync(Claim claim)
    {
        return await _claimRepository.UpdateAsync(claim);
    }
}