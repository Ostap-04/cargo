using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public class Cargo
    {
        private string senderAddress;
        private string recipientAddress;
        private double weight;
        private int distance;

        public Cargo()
        {
            senderAddress = "немає даних";
            recipientAddress = "немає даних";
            weight = 0.0;
            distance = 0;
        }
        public Cargo(string senderAddress, string recipientAddress, double weight, int distance)
        {
            this.senderAddress = senderAddress;
            this.recipientAddress = recipientAddress;
            this.weight = weight;
            this.distance = distance;
        }

        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }
        public string RecipientAddress
        {
            get { return recipientAddress; }
            set { recipientAddress = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { 
                if(value > 0.0) weight = value;
                else weight = 1.0;
            }
        }
        public int Distance
        {
            get { return distance; }
            set {
                if (value > 0) distance = value;
                else distance = 1;
            }
        }

        public double DeliveryPriceCount
        {
            get { return 2.5 * weight * distance; }
        }

        public override string ToString()
        {
            return $"адреса вiдправника: {senderAddress} \nадреса отримувача: {recipientAddress} \nвага: {weight}, " +
                $"вiдстань транспортування: {distance} \nвартiсть доставки: {DeliveryPriceCount}";
        }
        public static bool operator< (Cargo left, Cargo right)
        {
            return left.weight < right.weight;
        }
        public static bool operator> (Cargo left, Cargo right)
        {
            return left.weight > right.weight;
        }
        public static Cargo operator+ (Cargo left, int addDistance)
        {
            return new Cargo(left.senderAddress, left.recipientAddress, left.weight, left.distance + addDistance);
        }
        public static Cargo operator- (Cargo left, int addDistance)
        {
            return new Cargo(left.senderAddress, left.recipientAddress, left.weight, left.distance - addDistance);
        }
    }
}
