using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class BusinessRepository : Repository<Domain.Entities.Business>, IBusinessRespository
    {
    }
}
