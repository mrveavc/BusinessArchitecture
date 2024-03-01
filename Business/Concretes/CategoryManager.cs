﻿using Business.Abstracts;
using Business.Validations;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    public readonly ICategoryRepository _categoryRepository;
    private readonly CategoryValidations _categoryValidations;
    public CategoryManager(ICategoryRepository categoryRepository, CategoryValidations categoryValidations)
    {
        _categoryRepository = categoryRepository;
        _categoryValidations = categoryValidations;
    }
    public Category Add(Category category)
    {
        return _categoryRepository.Add(category);
    }

    public async Task<Category> AddAsync(Category category)
    {
        return await _categoryRepository.AddAsync(category);
    }

    public void DeleteById(Guid id)
    {
        var category = _categoryRepository.Get(u => u.Id == id);
        _categoryValidations.CategoryMustNotBeEmpty(category).Wait();
        _categoryRepository.Delete(category);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var category = _categoryRepository.Get(u => u.Id == id);
        await _categoryValidations.CategoryMustNotBeEmpty(category);
        await _categoryRepository.DeleteAsync(category);
    }

    public IList<Category> GetAll()
    {
        return _categoryRepository.GetAll().ToList();
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return result.ToList();
    }
    public async Task<IList<Category>> GetAllWithProductsAsync()
    {
        var result = await _categoryRepository.GetAllAsync(include: category => category.Include(c => c.Products));
        return result.ToList();
    }

    public IList<Category> GetAllWithProducts()
    {
        return _categoryRepository.GetAll(include: category => category.Include(c => c.Products)).ToList();

    }

    public Category? GetById(Guid id)
    {
        return _categoryRepository.Get(u => u.Id == id);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetAsync(u => u.Id == id);
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }
}
