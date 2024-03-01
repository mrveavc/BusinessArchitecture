using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Models;

namespace Entities.DTOs;

public class AddProductTransactionDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public ProductTransaction GetProductTransaction()
    {
        return new()
        {
            ProductId = ProductId,
            Quantity = Quantity,
           
        };
    }
}
public class ViewProductTransactionDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public ViewProductTransactionDto(ProductTransaction productTransaction)
    {
        ProductId = productTransaction.ProductId;
        Quantity = productTransaction.Quantity;
     
    }
}