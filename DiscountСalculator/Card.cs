using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountСalculator
{
    class Card 
    {
        public int DiscountCardSumm { get; set; }
        public DateTime? EndDate { get; set; }
     
        public string GetSellInformation(int price)
        {
            return DiscountCardSumm != 0 && EndDate.HasValue && EndDate >= DateTime.UtcNow
                ?  $"Сумма с учётом скидки - {price - DiscountCardSumm}р."
                : "Карта не действительна.";
        }
    }
}
