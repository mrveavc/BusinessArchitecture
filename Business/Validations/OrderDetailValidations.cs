using Business.Tools.Exceptions;
using Core.Entities;
using Entities.Models;

namespace Business.Validations;

public class OrderDetailValidations
{
    public async Task OrderDetailMustNotBeEmpty(OrderDetail? orderDetail)
    {
        if (orderDetail == null)
        {
            throw new ValidationException("OrderDetail must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}