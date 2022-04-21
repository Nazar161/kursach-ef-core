using System;
using Microsoft.EntityFrameworkCore;
namespace kursovaya
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<AccountPlan> AccountPlans { get; set; }
        public DbSet<SubAccount> SubAccounts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(o => o.UseNodaTime());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new AccountPlanConfiguration());
        }
    }
}


