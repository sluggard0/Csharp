using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void CreateProduct()
        {
            var product = new Product();
            var card = new Card();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            Console.WriteLine("Выберите тип скидки \n 1 - % от общей стоимости \n 2 - Сумма от стоимости \n 3 - Подарочная карта");
            int.TryParse(Console.ReadLine(), out var typeOfDiscount);
            if (typeOfDiscount == 1)
            {
                Console.WriteLine("Введите % скидки");
                int.TryParse(Console.ReadLine(), out var discountValue);
                while (discountValue > 100)
                {
                    Console.WriteLine("Значение скидки не может быть больше 100");
                    int.TryParse(Console.ReadLine(), out discountValue);
                }
                product.DiscountValue = discountValue;


            }
            else if (typeOfDiscount == 2)
            {
                Console.WriteLine("Введите сумму скидки");
                int.TryParse(Console.ReadLine(), out var discountSumm);
                while (discountSumm > price)
                {
                    Console.WriteLine("Сумма скидки не может быть больше стоимости товара");
                    int.TryParse(Console.ReadLine(), out discountSumm);
                }
                product.DiscountSumm = discountSumm;
            }

            else if (typeOfDiscount == 3)
            {
                Console.WriteLine("Введите стоимость карты");
                int.TryParse(Console.ReadLine(), out var discountSumm);
                card.DiscountCardSumm = discountSumm;
                Console.WriteLine("Введите срок действия карты");
                DateTime.TryParse(Console.ReadLine(), out var endDate);
                if (endDate != DateTime.MinValue)
                {
                    card.EndDate = endDate;
                }
            }

            else product.DiscountValue = 0;

            if (typeOfDiscount == 1 || typeOfDiscount == 2)
            {
                Console.WriteLine("Введите дату начала действия скидки");

                DateTime.TryParse(Console.ReadLine(), out var startSellDate);

                if (startSellDate != DateTime.MinValue)
                {
                    product.StartSellDate = startSellDate;
                }

                Console.WriteLine("Введите дату окончания действия скидки");

                DateTime.TryParse(Console.ReadLine(), out var endSellDate);

                while (endSellDate < startSellDate)
                {
                    Console.WriteLine("Введите дату окончания действия скидки");

                    DateTime.TryParse(Console.ReadLine(), out endSellDate);
                }
                if (endSellDate != DateTime.MinValue)
                {
                    product.EndSellDate = endSellDate;
                }

            }

            Console.Write($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р.");
            if (typeOfDiscount != 3)
                Console.WriteLine(product.GetSellInformation());
            else
                Console.WriteLine(card.GetSellInformation(price));

        }
    }
}
