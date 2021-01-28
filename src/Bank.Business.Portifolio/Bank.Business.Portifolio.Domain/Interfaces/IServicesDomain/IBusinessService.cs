using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Business.Portifolio.Domain.Interfaces.IServicesDomain
{
    public interface IBusinessService
    {
        string[] ValidateTxt(string[] LinesTxt);
    }
}
