using Core.Entities;
using Entities.Models;

namespace Entities.DTOs;

public class AddOrderDto
{
    public Guid UserId { get; set; }
    public IList<ProductTransaction> ProductTransactions { get; set; }
    //public virtual User User { get; set; }

    public AddOrderDto()
    {
        ProductTransactions = new List<ProductTransaction>();
    }
}
