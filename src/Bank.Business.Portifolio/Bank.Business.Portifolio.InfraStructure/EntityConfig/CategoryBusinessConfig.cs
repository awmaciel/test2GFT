using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class CategoryBusinessConfig : EntityTypeConfiguration<Domain.Entities.CategoryBusiness>
    {
        public CategoryBusinessConfig()
        {
            HasKey(c => c.IdCategoryBusiness);

            Property(c => c.NameCategory).IsRequired().HasMaxLength(150);

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);
        }
    }
}
