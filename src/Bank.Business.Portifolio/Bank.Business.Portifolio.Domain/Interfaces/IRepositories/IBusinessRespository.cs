using System.Collections.Generic;
using System.Linq;

namespace Bank.Business.Portifolio.Domain.Interfaces.IRepositories
{
    public interface IBusinessRespository : IRepository<Entities.Business>
    {
        List<Domain.Entities.Business> GetClientByCategories();
    }
}
