using Business.Abstracts;
using Business.Validations;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Core.Aspects.Autofac.Caching;

namespace Business.Concretes;
[HandleSecurity]

public class OrderManager : IOrderService
{

    public readonly IOrderRepository _orderRepository;
    private readonly OrderValidations _orderValidations;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IProductTransactionService _productTransactionService;

    public OrderManager(IOrderRepository orderRepository, IProductTransactionService productTransactionService, IOrderDetailService orderDetailService, OrderValidations orderValidations)
    {
        _orderRepository = orderRepository;
        _productTransactionService = productTransactionService;
        _orderDetailService = orderDetailService;
        _orderValidations = orderValidations;
    }
    [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
    [SecurityAspect]
    public Order Add(AddOrderDto addOrderDto)
    {
        _orderValidations.CheckTransactionCount(addOrderDto);
        _orderValidations.CheckProductListCount(addOrderDto);
        _orderValidations.CheckStock(addOrderDto);
        var addedOrder = _orderRepository.Add(new()
            {
                UserId = addOrderDto.UserId,
                CreatedDate = DateTime.UtcNow
            });
            addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
            {
                productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
                var addedProductTransaction = _productTransactionService.Add(productTransaction);
                _orderDetailService.Add(new()
                {
                    OrderId = addedOrder.Id,
                    ProductId = productTransaction.ProductId,
                    ProductTransactionId = addedProductTransaction.Id
                });
            });


        return addedOrder;


    }
    [ValidationAspect(typeof(OrderValidations))]
    [TransactionScopeAspect]
    [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Order> AddAsync(AddOrderDto addOrderDto)
    {
        await _orderValidations.CheckTransactionCount(addOrderDto);
        await _orderValidations.CheckProductListCount(addOrderDto);
        await _orderValidations.CheckStock(addOrderDto);

        var addedOrder = _orderRepository.Add(new()
            {
                UserId = addOrderDto.UserId,
                CreatedDate = DateTime.UtcNow
            });
            addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
            {
                productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
                var addedProductTransaction = _productTransactionService.Add(productTransaction);
                _orderDetailService.AddAsync(new()
                {
                    OrderId = addedOrder.Id,
                    ProductId = productTransaction.ProductId,
                    ProductTransactionId = addedProductTransaction.Id
                });

            });
        return addedOrder;


    }
    [SecurityAspect]
    public void DeleteById(Guid id)
    {
        var order = _orderRepository.Get(od => od.Id == id);
        _orderValidations.OrderMustNotBeEmpty(order).Wait();
        _orderRepository.Delete(order);
    }
    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var order = _orderRepository.Get(od => od.Id == id);
        await _orderValidations.OrderMustNotBeEmpty(order);
        await _orderRepository.DeleteAsync(order);
    }
    [SecurityAspect]
    public IList<Order> GetAll()
    {
        return _orderRepository.GetAll().ToList();
    }
    [SecurityAspect]
    public async Task<IList<Order>> GetAllAsync()
    {
        var result = await _orderRepository.GetAllAsync();
        return result.ToList();
    }
    [SecurityAspect]
    public Order? GetById(Guid id)
    {
        return _orderRepository.Get(u => u.Id == id);
    }
    [SecurityAspect]
    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetAsync(u => u.Id == id);

    }
    [SecurityAspect]
    public async Task<IList<Order>> GetAllWithDetailsAsync()
    {
        var result = await _orderRepository.GetAllAsync(include: order =>
         order.Include(o => o.User)
             .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
             .Include(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction));
        return result.ToList();
    }
    [SecurityAspect]
    public IList<Order> GetAllWithDetails()
    {
        return _orderRepository.GetAll(include: order =>
         order.Include(o => o.User)
             .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
             .Include(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)).ToList();

    }
    [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
    [SecurityAspect]
    public Order Update(Order order)
    {
        return _orderRepository.Update(order);
    }

    [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Order> UpdateAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }
}
