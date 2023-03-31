using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public delegate void DeliveryExpirationHandler(Cargo cargo);

    public class Cargo: IComparable, IFormattable
    {
        private string senderAddress;
        private string receiverAddress;
        private double weight;
        private int distance;
        private int deliveryLeft;

        public event DeliveryExpirationHandler DeliveryExpiration;

        //конструктори
        public Cargo()
        {
            senderAddress = "немає даних";
            receiverAddress = "немає даних";
            weight = 0.0;
            distance = 0;
            deliveryLeft = 0;
        }
        public Cargo(string senderAddress, string recipientAddress, double weight, int distance, int deliveryLeft)
        {
            this.senderAddress = senderAddress;
            this.receiverAddress = recipientAddress;
            if (weight <= 0.0)
            {
                Console.WriteLine("Увага!!! Вага повинна бути додатньою!\nЧерез неправильний ввід вага рівна 1");
                this.weight = 1.0;
            }
            else { this.weight = weight; }
            if (distance <= 0)
            {
                Console.WriteLine("Увага!!! Дистанція повинна бути додатньою!\nЧерез неправильний ввід дистанція рівна 1");
                this.distance = 1;
            }
            else { this.distance = distance; }
            if (deliveryLeft <= 0)
            {
                Console.WriteLine("Увага!!! Час доставки повинен бути додатнім!\nЧерез неправильний ввід час доставки рівний 1");
                this.deliveryLeft = 1;
            }
            else { this.deliveryLeft = deliveryLeft; }
        }

        //властивості
        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }
        public string ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value > 0.0 ? value : 1.0; }
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value > 0 ? value : 1; }
        }
        public int DeliveryLeft
        {
            get { return deliveryLeft; }
            set { deliveryLeft = value; }
        }
        public virtual double DeliveryPriceCount
        {
            get { return 2.5 * weight * distance; }
        }

        //перевизначення ToString()
        public override string ToString()
        {
            return $"адреса вiдправника: {senderAddress} \nадреса отримувача: {receiverAddress} \nвага: {weight}кг, " +
                $"вiдстань транспортування: {distance} \nвартiсть доставки: {DeliveryPriceCount}грн," +
                $"\nчас до закінчення доставки: {deliveryLeft} днів\n";
        }
        public virtual string ToString(string format, IFormatProvider provider)
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
                        result.Append($"Вага: {Weight}кг\n");
                        break;
                    case "d":
                        result.Append($"Вiдстань транспортування: {Distance}\n");
                        break;
                    case "l":
                        result.Append($"час до закінчення доставки: {Distance}днів\n");
                        break;
                    case "p":
                        result.Append($"Вартiсть доставки: {DeliveryPriceCount}грн\n");
                        break;
                    default:
                        break;
                }
            }

            return result.ToString();
        }

        //перевизначення операторів + CompareTo()
        public int CompareTo(object? obj)
        {
            Cargo c = obj as Cargo;
            if (c != null)
            {
                if (this.Weight < c.Weight) return -1;
                else if (this.Weight > c.Weight) return 1;
                else return 0;
            }
            throw new ArgumentException("Not Cargo");
        }
        public static bool operator <(Cargo left, Cargo right)
        {
            return left.weight < right.weight;
        }
        public static bool operator >(Cargo left, Cargo right)
        {
            return left.weight > right.weight;
        }
        public static bool operator ==(Cargo left, string sender)
        {
            return left.senderAddress == sender;
        }
        public static bool operator !=(Cargo left, string sender)
        {
            return left.senderAddress != sender;
        }
        public static Cargo operator +(Cargo left, int addWeight)
        {
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight + addWeight, left.distance, left.deliveryLeft);
        }
        public static Cargo operator +(Cargo left, Cargo right)
        {
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight + right.weight, left.distance, left.deliveryLeft);
        }

        /*public static Cargo operator -(Cargo left, int addDistance)
        {
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight, left.distance - addDistance);
        }*/
        /*public static Cargo operator -(Cargo left, Cargo right)
        {
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight, left.distance - right.distance);
        }*/
        /*public static void PrintCargo(Cargo cargo)
        {
            Console.WriteLine(cargo);
        }*/

        //введення та вивід вантажів
        public virtual Cargo DialogInput()
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
            Console.Write("Час до закінчення доставки (днів):");
            int deliveryLeft = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return new Cargo(senderAdd, receiverAdd, weight, distance, deliveryLeft);
        }
        public static void PrintList(List<Cargo> list)
        {
            Console.WriteLine("\nCписок вантажiв:\n");
            foreach (Cargo cargo in list)
            {
                //PrintCargo(cargo);
                Console.WriteLine(cargo);
            }
        }
    }
}
