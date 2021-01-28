using Bank.Business.Portifolio.Application.Interfaces;
using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;

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
            var result = _FileHandle.GetFileText(endpoint);
            _BusinessService.ValidateTxt(result);
            return result;
        }
    }
}
