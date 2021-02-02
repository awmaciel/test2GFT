using Bank.Business.Portifolio.Application.Interfaces;
using Bank.Business.Portifolio.Domain.Dto;
using Bank.Business.Portifolio.Domain.Interfaces.ICrossCutting;
using Bank.Business.Portifolio.Domain.Interfaces.IRepositories;
using Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain;
using System;
using System.Collections.Generic;

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
        public List<Trade> AddBusiness(string endpoint)
        {
            List<Trade> resultReturn = null;
            try
            {
                string[]  result = _FileHandle.GetFileText(endpoint);
                resultReturn = _BusinessService.ValidateTxt(result);
            }
            catch(Exception ex)
            {
                throw;
            }
            return resultReturn;
        }
    }
}
