using Bank.Business.Portifolio.Domain.Interfaces;
using Bank.Business.Portifolio.Domain.Interfaces.IDtos;
using System;

namespace Bank.Business.Portifolio.Domain.Dto
{
    public class Trade : ITrade
    {
        public int IdBusiness { get; set; }
        public string NameClient { get; set; }
        public string CategoryClient { get; set; }
        public string SectorClient { get; set; }
        public string NamePortifolio { get; set; }       
        public decimal ValueInvestment { get; set; }
        public DateTime DateNextPayment { get; set; }
        public string Note { get; set; }
    }
}
