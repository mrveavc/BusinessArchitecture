﻿using Core.Entities;
using Core.Repository;

namespace Entities.Models;

public class Order : Entity<Guid>
{
    //public Guid CardId { get; set; }

    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual User User { get; set; }
    //public virtual Card Card { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }
}
