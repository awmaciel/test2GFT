using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class PortifolioRepository : Repository<Domain.Entities.Portifolio>, IPortifolioRepository
    {
    }
}
