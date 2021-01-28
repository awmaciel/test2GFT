using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class BankConfig : EntityTypeConfiguration<Domain.Entities.Bank>
    {
        public BankConfig()
        {
            HasKey(c => c.IdBank);

            Property(c => c.NameBank);

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);
        }
    }
}
