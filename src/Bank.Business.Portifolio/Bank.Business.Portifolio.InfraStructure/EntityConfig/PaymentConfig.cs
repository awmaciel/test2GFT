using System.Data.Entity.ModelConfiguration;

namespace Bank.Business.Portifolio.InfraStructure.EntityConfig
{
    public class PaymentConfig : EntityTypeConfiguration<Domain.Entities.Payment>
    {
        public PaymentConfig()
        {
            HasKey(c => c.IdPayment);

            Property(c => c.IdBusiness).IsRequired();

            Property(c => c.DateTimeNextPayment).IsRequired();

            Property(c => c.paid);

            Property(c => c.DateRegister).IsRequired();

            Property(c => c.DateUpdate);

            HasRequired(p => p.Business).WithMany().HasForeignKey(p => p.IdBusiness);
        }
    }
}
