using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class PortifolioConfig : EntityTypeConfiguration<Domain.Entities.Portifolio>
    {
        public PortifolioConfig()
        {
            HasKey(c => c.IdPortifolio);

            Property(C => C.IdBank);

            Property(c => c.NameProtifolio).IsRequired().HasMaxLength(150);

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);

            HasRequired(p => p.Bank).WithMany().HasForeignKey(p => p.IdBank);
        }
    }
}
