using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class BankRepository : Repository<Domain.Entities.Bank>, IBankRespository
    {
    }
}
