using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;
public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(BusinessDbContext context) : base(context)
    {
    }
}
