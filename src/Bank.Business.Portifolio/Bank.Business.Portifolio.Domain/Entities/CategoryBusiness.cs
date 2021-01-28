using System;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class CategoryBusiness
    {
        public int IdCategoryBusiness { get; set; }
        public string NameCategory { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
