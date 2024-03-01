using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Module = Autofac.Module;
using DataAccess.Abstracts;

namespace Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ClaimManager>().As<IClaimService>();
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<ProductTransactionManager>().As<IProductTransactionService>();

        builder.RegisterType<OrderManager>().As<IOrderService>();
        builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();

        builder.RegisterType<CardTypeManager>().As<ICardTypeService>();

        builder.RegisterType<CardManager>().As<ICardService>();




        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}
