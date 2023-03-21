using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public class AccompCargo: Cargo
    {
        private uint discount;

        public uint Discount {
            get { return discount; }
            set
            {
                if (0 <= value && value <= 100) discount = value;
                else if (value >= 100) discount = 100;
                else discount = 0;
            }
        }
        public override double DeliveryPriceCount
        {
            get { return 2.5 * Weight * Distance * (100 - Discount) / 100 ; }
        }

        public AccompCargo(): base() { Discount = 0; }
        public AccompCargo(string senderAddress, string recipientAddress, double weight, int distance, uint discount)
        :base(senderAddress, recipientAddress, weight, distance) {
            Discount = discount;
        }

        public override string ToString()
        {
            return base.ToString() + "Відсоток здешевлення вартості доставки: " + this.Discount + "%\n";
        }
        public override AccompCargo DialogInput()
        {
            Console.WriteLine("\nВведіть дані для нового вантажу:");

            Console.Write("Адреса відправника: ");
            string senderAdd = Console.ReadLine();
            Console.Write("Адреса отримувача: ");
            string receiverAdd = Console.ReadLine();
            Console.Write("Вага: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Відстань транспортування: ");
            int distance = int.Parse(Console.ReadLine());
            Console.Write("Введіть відсоток здешевлення вартості: ");
            uint discount = uint.Parse(Console.ReadLine());
            return new AccompCargo(senderAdd, receiverAdd, weight, distance, discount);
        }
    }
}
