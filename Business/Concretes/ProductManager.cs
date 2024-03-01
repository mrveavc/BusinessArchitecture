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

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidations _productValidations;

    public ProductManager(IProductRepository productRepository, ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }

    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    [SecurityAspect]
    public Product Add(Product product)
    {
        return _productRepository.Add(product);
    }

    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Product> AddAsync(Product product)
    {
        return await _productRepository.AddAsync(product);
    }

    [SecurityAspect]
    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(u => u.Id == id);
        _productValidations.ProductMustNotBeEmpty(product).Wait();
        _productRepository.Delete(product);
    }

    [SecurityAspect]
    public async Task DeleteByIdAsync(Guid id)
    {
        var product = _productRepository.Get(u => u.Id == id);
        await _productValidations.ProductMustNotBeEmpty(product);
        await _productRepository.DeleteAsync(product);
    }


    [SecurityAspect]
    public IList<Product> GetAll()
    {
        return _productRepository.GetAll().ToList();
    }

    [SecurityAspect]
    public async Task<IList<Product>> GetAllAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return result.ToList();
    }

    [SecurityAspect]
    public async Task<IList<Product>> GetAllWithCAtegory()
    {
        var result = await _productRepository.GetAllAsync(include: product => product.Include(p => p.Category));
        return result.ToList();
    }

    [SecurityAspect]
    public Product? GetById(Guid id)
    {
        return _productRepository.Get(u => u.Id == id);
    }

    [SecurityAspect]
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetAsync(u => u.Id == id);

    }

    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    [SecurityAspect]
    public Product Update(Product product)
    {
        return _productRepository.Update(product);
    }

    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    [SecurityAspect]
    public async Task<Product> UpdateAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }
}
