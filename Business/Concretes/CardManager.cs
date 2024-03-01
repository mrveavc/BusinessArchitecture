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
public class CardManager : ICardService
{

    public readonly ICardRepository _cardRepository;
    private readonly CardValidations _cardValidations;


    public CardManager(ICardRepository cardRepository,
      CardValidations _cardValidations)
    {
        _cardRepository = cardRepository;
        _cardValidations = _cardValidations;
    }
    [SecurityAspect]
    public Card Add(Card card)
    {
        return _cardRepository.Add(card);
    }
    [SecurityAspect]
    public async Task<Card> AddAsync(Card card)
    {
        return await _cardRepository.AddAsync(card);
    }
    [SecurityAspect]
    public void DeleteById(Guid id)
    {
        var card = _cardRepository.Get(u => u.Id == id);
        _cardValidations.CardMustNotBeEmpty(card).Wait();
        _cardRepository.Delete(card);
    }
    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var card = _cardRepository.Get(c => c.Id == id);
        await _cardRepository.DeleteAsync(card);
    }

    public IList<Card> GetAll()
    {
        return _cardRepository.GetAll().ToList();
    }

    public async Task<IList<Card>> GetAllAsync()
    {
        var result = await _cardRepository.GetAllAsync();
        return result.ToList();
    }

    public Card? GetById(Guid id)
    {
        return _cardRepository.Get(u => u.Id == id);
    }

    public async Task<Card?> GetByIdAsync(Guid id)
    {
        return await _cardRepository.GetAsync(u => u.Id == id);
    }
    [SecurityAspect]
    public Card Update(Card cardType)
    {
        return _cardRepository.Update(cardType);
    }
    [SecurityAspect]
    public async Task<Card> UpdateAsync(Card cardType)
    {
        return await _cardRepository.UpdateAsync(cardType);
    }
}
