using Bank.Business.Portifolio.Domain.Dto;
using System.Collections.Generic;

namespace Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain
{
    public interface IBusinessService
    {
        List<Trade> ValidateTxt(string[] LinesTxt);
    }
}
