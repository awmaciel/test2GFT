using System;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class Portifolio
    {
        public int IdPortifolio { get; set; }
        public int IdBank { get; set; }
        public string NameProtifolio { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
