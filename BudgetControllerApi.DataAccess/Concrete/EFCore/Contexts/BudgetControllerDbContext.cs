﻿using BudgetControllerApi.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Contexts
{
    public class BudgetControllerDbContext : IdentityDbContext<User>
    {
        public BudgetControllerDbContext(DbContextOptions<BudgetControllerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Receipt> Receipts => Set<Receipt>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ReceiptProduct> ReceiptProducts => Set<ReceiptProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Get all IEntityTypeConfigurations from executing Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
