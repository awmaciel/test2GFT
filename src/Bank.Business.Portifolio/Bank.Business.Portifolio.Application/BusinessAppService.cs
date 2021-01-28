using Bank.Business.Portifolio.Application.Interfaces;
using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;
using System;

namespace Bank.Business.Portifolio.Application
{
    public class BusinessAppService : IBusinessAppService
    {
        private readonly IFileHandle _FileHandle;
        private readonly IBusinessService _BusinessService;
        public BusinessAppService(IFileHandle FileHandle, 
                                  IBusinessService BusinessService)
        {
            _FileHandle = FileHandle;
            _BusinessService = BusinessService;
        }
        public string[] AddBusiness(string endpoint)
        {
            string[] result = Array.Empty<string>();
            try
            {
                result = _FileHandle.GetFileText(endpoint);
                _BusinessService.ValidateTxt(result);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
