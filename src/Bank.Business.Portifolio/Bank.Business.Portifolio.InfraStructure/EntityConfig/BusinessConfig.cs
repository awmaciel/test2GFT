using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class BusinessConfig : EntityTypeConfiguration<Domain.Entities.Business>
    {
        public BusinessConfig()
        {
            HasKey(c => c.IdBusiness);

            Property(c => c.IdCategoryBusiness);

            Property(c => c.IdClient);

            Property(c => c.IdPortifolio);

            Property(c => c.TypeBusiness);

            Property(c => c.ValueBusiness);

            Property(c => c.DateReference);

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);


            HasRequired(p => p.CategoryBusiness).WithMany().HasForeignKey(p => p.IdCategoryBusiness);
            HasRequired(p => p.Client).WithMany().HasForeignKey(p => p.IdClient);
            HasRequired(p => p.Portifolio).WithMany().HasForeignKey(p => p.IdPortifolio);
        }
    }
}
