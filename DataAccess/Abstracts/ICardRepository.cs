using Entities.Models;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface ICardRepository : IAsyncRepository<Card>, IRepository<Card>
{
}
