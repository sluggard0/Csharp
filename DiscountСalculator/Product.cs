using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountValue { get; set; }
        public int DiscountSumm { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }
        
        public int CalculateDiscountPrice()
        {
            if (DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow)
            {
                return Price - (Price * DiscountValue / 100);
            }
            else if (DiscountSumm != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow)
            {
                return Price - DiscountSumm;
            }
            else return Price;
        }

        public string GetSellInformation()
        {
            if (DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue)
                return $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {CalculateDiscountPrice()}р.";
            else if (DiscountSumm != 0 && StartSellDate.HasValue && EndSellDate.HasValue)
                return $"На данный товар действует скидка {DiscountSumm}р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {CalculateDiscountPrice()}р.";
            else return "В настоящий момент на данный товар нет скидок.";
        }
    }        
}
