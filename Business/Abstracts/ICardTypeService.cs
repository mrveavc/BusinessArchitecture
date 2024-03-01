using Core.Entities;
using Entities.Models;

namespace Business.Abstracts;

public interface ICardTypeService
{
    CardType? GetById(Guid id);
    Task<CardType?> GetByIdAsync(Guid id);
    IList<CardType> GetAll();
    Task<IList<CardType>> GetAllAsync();
    CardType Add(CardType cardType);
    CardType Update(CardType cardType);
    void DeleteById(Guid id);
    Task<CardType> AddAsync(CardType cardType);
    Task<CardType> UpdateAsync(CardType cardType);
    Task DeleteByIdAsync(Guid id);
}
