using Business.Tools.Exceptions;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;

namespace Business.Validations;

public class OrderValidations:BaseValidation
{
    public readonly IProductTransactionRepository _productTransactionRepository;

    public OrderValidations(IProductTransactionRepository productTransactionRepository)
    {
        _productTransactionRepository = productTransactionRepository;
    }

    public async Task OrderMustNotBeEmpty(Order? order)
    {
        if (order == null) throw new ValidationException("Order not found.");
    }
    public async Task CheckTransactionCount(AddOrderDto addOrderDto)
    {
        if (addOrderDto.ProductTransactions.Count() == 0)
        {
          
            throw new ValidationException("Product list not be empty.");
        }
    }
    public async Task CheckProductListCount(AddOrderDto addOrderDto)
    {
        if (addOrderDto.ProductTransactions.Where(t => t.Quantity == 0).Any())
        {
            
            throw new ValidationException("Product count must not be zero. Please check product list.");
        }
    }
    public async Task CheckStock(AddOrderDto addOrderDto)
    {
        var checkCounts = addOrderDto.ProductTransactions.Select(t =>
            _productTransactionRepository.GetAll(pt => pt.ProductId == t.ProductId).Sum(transaction => transaction.Quantity) - t.Quantity
        ).Where(q => q < 0).Any();
        if (checkCounts)
        {
            throw new ValidationException("We are has not any product stock. Please check stock count");
        }
    }
}

