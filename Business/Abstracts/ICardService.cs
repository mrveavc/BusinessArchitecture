using Core.Entities;
using Entities.Models;

namespace Business.Abstracts;

public interface ICardService
{

    Card? GetById(Guid id);
    Task<Card?> GetByIdAsync(Guid id);
    IList<Card> GetAll();
    Task<IList<Card>> GetAllAsync();
    Card Add(Card card);
    Card Update(Card card);
    void DeleteById(Guid id);
    Task<Card> AddAsync(Card card);
    Task<Card> UpdateAsync(Card card);
    Task DeleteByIdAsync(Guid id);
}
