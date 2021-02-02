using Bank.Business.Portifolio.Domain.Dto;
using System.Collections.Generic;

namespace Bank.Business.Portifolio.Application.Interfaces
{
    public interface IBusinessAppService
    {
        List<Trade> AddBusiness(string endpoint);
    }
}
