using Bank.Business.Portifolio.Domain.Entities;
using Bank.Business.Portifolio.InfraStructure.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Bank.Business.Portifolio.InfraStructure.Context
{
    public class Context : DbContext
    {
        public Context()
            :base("BankTest")
        {

        }
        public DbSet<Portifolio.Domain.Entities.Bank> Bank { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<CategoryBusiness> CategoryBusiness { get; set; }
        public DbSet<Portifolio.Domain.Entities.Portifolio> Portifolio { get; set; }
        public DbSet<Portifolio.Domain.Entities.Business> Business { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Context>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new BankConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new CategoryBusinessConfig());
            modelBuilder.Configurations.Add(new BusinessConfig());
            modelBuilder.Configurations.Add(new PortifolioConfig());
            modelBuilder.Configurations.Add(new PaymentConfig());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegister").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateUpdate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
