using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class ClientConfig : EntityTypeConfiguration<Domain.Entities.Client>
    {
        public ClientConfig()
        {
            HasKey(c => c.IdClient);

            Property(c => c.IdBank);

            Property(c => c.NameClient).IsRequired().HasMaxLength(150);

            Property(c => c.SectorClient).IsRequired().HasMaxLength(50);            

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);

            HasRequired(p => p.Bank).WithMany().HasForeignKey(p => p.IdBank);
        }
    }
}
