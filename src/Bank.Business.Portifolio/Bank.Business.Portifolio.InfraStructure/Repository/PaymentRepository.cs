using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class PaymentRepository : Repository<Domain.Entities.Payment>, IPaymentRepository
    {
    }
}
