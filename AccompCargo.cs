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

        //конструктори
        public AccompCargo()
           : base()
        {
            discount = 0;
        }
        public AccompCargo(string senderAddress, string receiverAddress, double weight, int distance, int deliveryLeft, uint disc)
            : base(senderAddress, receiverAddress, weight, distance, deliveryLeft)
        {
            discount = disc;
        }

        //властивості 
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
            get { return (base.DeliveryPriceCount * (100 - discount) / 100); }
        }

        //перевизначення ToString()
        public override string ToString()
        {
            return base.ToString() + "Відсоток здешевлення вартості доставки: " + this.Discount + "%\n";
        }
        public override string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                return ToString();
            }

            string[] symbols = format.Split(' ');

            StringBuilder result = new StringBuilder();

            foreach (string symbol in symbols)
            {
                switch (symbol.ToLower())
                {
                    case "s":
                        result.Append($"Адреса вiдправника: {SenderAddress}\n");
                        break;
                    case "r":
                        result.Append($"Адреса отримувача: {ReceiverAddress}\n");
                        break;
                    case "w":
                        result.Append($"Вага: {Weight}\n");
                        break;
                    case "d":
                        result.Append($"Вiдстань транспортування: {Distance}\n");
                        break;
                    case "p":
                        result.Append($"Вартiсть доставки: {DeliveryPriceCount}грн\n");
                        break;
                    case "l":
                        result.Append($"час до закінчення доставки: {Distance}днів\n");
                        break;
                    case "%":
                        result.Append($"Відсоток здешевлення вартості доставки: {this.Discount}%");
                        break;
                    default:
                        throw new FormatException($"The '{symbol}' format specifier is not supported.");
                }
            }

            return result.ToString();
        }

        //ввід даних про вантажі з консолі
        public override AccompCargo DialogInput()
        {
            //Console.WriteLine("\nВведіть дані для нового вантажу:");

            //Console.Write("Адреса відправника: ");
            //string senderAdd = Console.ReadLine();
            //Console.Write("Адреса отримувача: ");
            //string receiverAdd = Console.ReadLine();
            //Console.Write("Вага: ");
            //double weight = double.Parse(Console.ReadLine());
            //Console.Write("Відстань транспортування: ");
            //int distance = int.Parse(Console.ReadLine());
            Cargo c = base.DialogInput();
            Console.Write("Введіть відсоток здешевлення вартості: ");
            uint discount = uint.Parse(Console.ReadLine());
            //return new AccompCargo(senderAdd, receiverAdd, weight, distance, discount);
            return new AccompCargo(c.SenderAddress,c.ReceiverAddress, c.Weight, c.Distance, c.DeliveryLeft, discount);

        }
    }
}
