using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class ClientRepository : Repository<Domain.Entities.Client>, IClientRepository
    {
    }
}
