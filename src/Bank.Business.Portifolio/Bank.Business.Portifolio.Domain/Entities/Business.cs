using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bank.Business.Portifolio.Domain.Entities
{
    public class Business
    {
        public int IdBusiness { get; set; }
        public int IdPortifolio { get; set; }
        public int IdCategoryBusiness { get; set; }
        public int IdClient { get; set; }
        public string TypeBusiness { get; set; }
        public decimal ValueBusiness { get; set; }
        public DateTime DateReference { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual Portifolio Portifolio { get; set; }
        public virtual CategoryBusiness CategoryBusiness { get; set; }
        public virtual Client Client { get; set; }

        public bool ValidateTxt(string[] LinesTxt)
        {
            bool result = true;
            int cont = 0;
            int portifolio;

            foreach (var item in LinesTxt)
            {
                if (cont == 0 && !DateTime.TryParse(item, new CultureInfo("pt-BR"), DateTimeStyles.None, out var data))
                    return false;
                if (cont == 1 && !Int32.TryParse(item, out portifolio))
                    return false;
                if (cont >= 2)
                {
                    decimal value;
                    var arr = item.Split(' ');
                    if (cont > 2)
                        arr = Array.Empty<string>();

                    int contArr = 0;

                    foreach (var itemArr in arr)
                    {
                        if (contArr == 0 && !decimal.TryParse(itemArr, out value))
                            return false;
                        if (String.Equals(itemArr.Trim().ToLower(), "private") || String.Equals(itemArr.Trim().ToLower(), "public") && contArr == 1)
                            continue;

                        if (contArr == 2 && !DateTime.TryParse(item, new CultureInfo("pt-BR"), DateTimeStyles.None, out var dataArr))
                            return false;

                        contArr++;
                    }

                }
                cont++;
            }
            return result;
        }
    }
}
