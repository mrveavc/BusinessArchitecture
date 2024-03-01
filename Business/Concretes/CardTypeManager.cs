using Business.Abstracts;
using Business.Validations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.Models;

namespace Business.Concretes;
[HandleSecurity]
public class CardTypeManager : ICardTypeService
{

    public readonly ICardTypeRepository _cardTypeRepository;
    private readonly CardTypeValidations _cardTypeValidations;


    public CardTypeManager(ICardTypeRepository cardTypeRepository,
      CardTypeValidations cardTypeValidations)
    {
        _cardTypeRepository = cardTypeRepository;
        _cardTypeValidations = cardTypeValidations;
    }
    [CacheRemoveAspect("Business.Abstracts.ICardTypeService.GetAllAsync")]
    [SecurityAspect]
    public CardType Add(CardType cardType)
    {
        return _cardTypeRepository.Add(cardType);
    }
    [CacheRemoveAspect("Business.Abstracts.ICardTypeService.GetAllAsync")]
    [SecurityAspect]
    public async Task<CardType> AddAsync(CardType cardType)
    {
        return await _cardTypeRepository.AddAsync(cardType);
    }
    [SecurityAspect]
    public void DeleteById(Guid id)
    {
        var cardType = _cardTypeRepository.Get(u => u.Id == id);
        _cardTypeValidations.CardTypeMustNotBeEmpty(cardType).Wait();
        _cardTypeRepository.Delete(cardType);
    }
    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var cardType = _cardTypeRepository.Get(u => u.Id == id);
        await _cardTypeValidations.CardTypeMustNotBeEmpty(cardType);
        await _cardTypeRepository.DeleteAsync(cardType);
    }

    public IList<CardType> GetAll()
    {
        return _cardTypeRepository.GetAll().ToList();
    }

    public async Task<IList<CardType>> GetAllAsync()
    {
        var result = await _cardTypeRepository.GetAllAsync();
        return result.ToList();
    }

    public CardType? GetById(Guid id)
    {
        return _cardTypeRepository.Get(u => u.Id == id);
    }
    [CacheAspect(10)]

    public async Task<CardType?> GetByIdAsync(Guid id)
    {
        return await _cardTypeRepository.GetAsync(u => u.Id == id);
    }
    [SecurityAspect]
    public CardType Update(CardType cardType)
    {
        return _cardTypeRepository.Update(cardType);
    }
    [CacheRemoveAspect("Business.Abstracts.ICardTypeService.GetAllAsync")]
    [SecurityAspect]
    public async Task<CardType> UpdateAsync(CardType cardType)
    {
        return await _cardTypeRepository.UpdateAsync(cardType);
    }
}
