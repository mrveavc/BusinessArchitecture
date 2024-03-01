using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface ICardTypeRepository : IAsyncRepository<CardType>, IRepository<CardType>
{
}
