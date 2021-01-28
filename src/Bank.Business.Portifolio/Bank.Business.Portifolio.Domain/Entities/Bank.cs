using System;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class Bank
    {
        public int IdBank { get; set; }
        public string NameBank { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
