using Core.Entities;
using Entities.Models;

namespace Business.Abstracts;

public interface ICategoryService
{
    Category? GetById(Guid id);
    Task<Category?> GetByIdAsync(Guid id);
    IList<Category> GetAll();
    Task<IList<Category>> GetAllAsync();
    Category Add(Category category);
    Category Update(Category category);
    void DeleteById(Guid id);
    Task<Category> AddAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task DeleteByIdAsync(Guid id);
    IList<Category> GetAllWithProducts();
    Task<IList<Category>> GetAllWithProductsAsync();



}
