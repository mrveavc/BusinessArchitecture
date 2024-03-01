using Core.Entities;
using Entities.DTOs;
using Entities.Models;

namespace Business.Abstracts;

public interface IOrderService
{
    Order? GetById(Guid id);
    Task<Order?> GetByIdAsync(Guid id);
    IList<Order> GetAll();
    Task<IList<Order>> GetAllAsync();
    Order Add(AddOrderDto addOrderDto);
    Order Update(Order order);
    void DeleteById(Guid id);
    Task<Order> AddAsync(AddOrderDto addOrderDto);
    Task<Order> UpdateAsync(Order order);
    Task DeleteByIdAsync(Guid id);
    IList<Order> GetAllWithDetails();
    Task<IList<Order>> GetAllWithDetailsAsync();
}
