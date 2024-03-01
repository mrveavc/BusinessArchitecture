using Business.Abstracts;
using Business.Validations;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concretes;
[HandleSecurity]

public class ProductTransactionManager : IProductTransactionService
{
    private readonly IProductTransactionRepository _productTransactionRepository;
    private readonly ProductTransactionValidations _productTransactionValidations;
    public ProductTransactionManager(IProductTransactionRepository productTransactionRepository, ProductTransactionValidations productTransactionValidations)
    {
        _productTransactionRepository = productTransactionRepository;
        _productTransactionValidations = productTransactionValidations;
    }

    [CacheRemoveAspect("Business.Abstracts.IProductTransactionService.GetAllAsync")]
    [SecurityAspect]
    public ProductTransaction Add(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Add(productTransaction);
    }

    [CacheRemoveAspect("Business.Abstracts.IProductTransactionService.GetAllAsync")]
    [SecurityAspect]
    public async Task<ProductTransaction> AddAsync(ProductTransaction productTransaction)
    {
        return await _productTransactionRepository.AddAsync(productTransaction);
    }

    [SecurityAspect]

    public void DeleteById(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(u => u.Id == id);
        _productTransactionValidations.ProductTransactionMustNotBeEmpty(productTransaction).Wait();
        _productTransactionRepository.Delete(productTransaction);
    }

    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(u => u.Id == id);
        await _productTransactionValidations.ProductTransactionMustNotBeEmpty(productTransaction);
        await _productTransactionRepository.DeleteAsync(productTransaction);
    }

    [SecurityAspect]
    public IList<ProductTransaction> GetAll()
    {
        return _productTransactionRepository.GetAll().ToList();
    }

    [SecurityAspect]
    public async Task<IList<ProductTransaction>> GetAllAsync()
    {
        var result = await _productTransactionRepository.GetAllAsync();
        return result.ToList();
    }

    [SecurityAspect]
    public async Task<IList<ProductTransaction>> GetAllWithProduct()
    {
        var result = await _productTransactionRepository.GetAllAsync(include: productTransaction => productTransaction.Include(p => p.Product));
        return result.ToList();
    }

    [SecurityAspect]
    public ProductTransaction? GetById(Guid id)
    {
        return _productTransactionRepository.Get(u => u.Id == id);
    }

    [SecurityAspect]
    public async Task<ProductTransaction?> GetByIdAsync(Guid id)
    {
        return await _productTransactionRepository.GetAsync(u => u.Id == id);
    }

    [CacheRemoveAspect("Business.Abstracts.IProductTransactionService.GetAllAsync")]
    [SecurityAspect]
    public ProductTransaction Update(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Update(productTransaction);
    }

    [CacheRemoveAspect("Business.Abstracts.IProductTransactionService.GetAllAsync")]
    [SecurityAspect]
    public async Task<ProductTransaction> UpdateAsync(ProductTransaction productTransaction)
    {
        return await _productTransactionRepository.UpdateAsync(productTransaction);
    }
}
