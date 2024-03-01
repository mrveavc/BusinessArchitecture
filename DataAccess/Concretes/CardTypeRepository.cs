using Entities.Models;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class CardTypeRepository : Repository<CardType>, ICardTypeRepository
{
    public CardTypeRepository(BusinessDbContext context) : base(context)
    {
    }
}
