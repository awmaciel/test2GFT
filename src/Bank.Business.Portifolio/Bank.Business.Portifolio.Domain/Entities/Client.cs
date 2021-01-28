using System;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public int IdBank { get; set; }
        public string NameClient { get; set; }
        public string SectorClient { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
