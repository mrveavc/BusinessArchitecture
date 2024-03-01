﻿using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public class BusinessServiceModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddScoped<IClaimService, ClaimManager>();
        services.AddScoped<AddUserValidations>();
        services.AddScoped<UpdateUserValidations>();
        services.AddScoped<ClaimValidations>();
        services.AddScoped<AuthValidations>();
        services.AddScoped<DeleteValidations>();
        services.AddScoped<CategoryValidations>();
        services.AddScoped<ProductValidations>();
        services.AddScoped<ProductTransactionValidations>();
        services.AddScoped<OrderValidations>();
        services.AddScoped<OrderDetailValidations>();
        services.AddScoped<CardTypeValidations>();
        services.AddScoped<CardValidations>();





    }
}

