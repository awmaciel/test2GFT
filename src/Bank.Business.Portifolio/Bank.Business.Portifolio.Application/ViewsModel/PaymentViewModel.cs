using System;

namespace Bank.Business.Portifolio.Application.ViewsModel
{
    public class PaymentViewModel
    {
        public int IdPayment { get; set; }
        public int IdBusiness { get; set; }
        public DateTime DateTimeNextPayment { get; set; }
        public bool paid { get; set; }
    }
}
