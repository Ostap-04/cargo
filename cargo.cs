using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public class Cargo: IComparable
    {
        private string senderAddress;
        private string receiverAddress;
        private double weight;
        private int distance;

        //конструктори
        public Cargo()
        {
            senderAddress = "немає даних";
            receiverAddress = "немає даних";
            weight = 0.0;
            distance = 0;
        }
        public Cargo(string senderAddress, string recipientAddress, double weight, int distance)
        {
            this.senderAddress = senderAddress;
            this.receiverAddress = recipientAddress;
            if (weight <= 0.0)
            {
                Console.WriteLine("Увага!!! Вага повинна бути додатньою!\nЧерез неправильний ввід вага рівна 1");
                this.weight = 1.0;
            }
            else { this.weight = weight; }
            if (distance <= 0.0)
            {
                Console.WriteLine("Увага!!! Дистанція повинна бути додатньою!\nЧерез неправильний ввід дистанція рівна 1");
                this.distance = 1;
            }
            else { this.distance = distance; }
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
        public virtual double DeliveryPriceCount
        {
            get { return 2.5 * weight * distance; }
        }

        //перевизначення операторів та методу ToString()
        public override string ToString()
        {
            return $"адреса вiдправника: {senderAddress} \nадреса отримувача: {receiverAddress} \nвага: {weight}, " +
                $"вiдстань транспортування: {distance} \nвартiсть доставки: {DeliveryPriceCount}грн\n";
        }
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
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight + addWeight, left.distance);
        }
        public static Cargo operator +(Cargo left, Cargo right)
        {
            return new Cargo(left.senderAddress, left.receiverAddress, left.weight + right.weight, left.distance);
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
            Console.WriteLine();

            return new Cargo(senderAdd, receiverAdd, weight, distance);
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
