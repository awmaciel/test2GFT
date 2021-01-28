using System;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class Payment
    {
        public int IdPayment { get; set; }
        public int IdBusiness { get; set; }
        public DateTime DateTimeNextPayment { get; set; }
        public bool paid { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual Business Business { get; set; }
    }
}
