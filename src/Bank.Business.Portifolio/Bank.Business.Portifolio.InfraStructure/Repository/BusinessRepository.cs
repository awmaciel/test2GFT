using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Business.Portifolio.InfraStructure.Repository
{
    public class BusinessRepository : Repository<Domain.Entities.Business>, IBusinessRespository
    {
        public List<Domain.Entities.Business> GetClientByCategories()
        {
            try
            {
                return this.Db.Business.Include("Client").ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
