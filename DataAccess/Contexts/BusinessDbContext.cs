using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Entities;


namespace DataAccess.Contexts;

public class BusinessDbContext:DbContext
{
	public BusinessDbContext()
	{
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //todo: Add Configuration transfer with projects
        //var connectionString = Configuration.GetValue<string>("ConnectionStrings:Production");
        //optionsBuilder.UseSqlServer("Server=localhost;Database=BusinessSimple;User Id=SA;TrustServerCertificate=true;Password=reallyStrongPwd123;");
        optionsBuilder.UseSqlServer("Server=DESKTOP-KMBI23L\\SQLEXPRESS;Database=BusinessArchitecture;TrustServerCertificate=true;Integrated Security=true;");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Order { get; set; }

    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<ProductTransaction> ProductTransactions { get; set; }

    public DbSet<AccountTransaction> AccountTransactions { get; set; }



}

