using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public class Cargo
    {
        private string senderAdress;
        private string recipientAdress;
        private double weight;
        private int distance;

        public Cargo()
        {
            senderAdress = "немає даних";
            recipientAdress = "немає даних";
            weight = 0.0;
            distance = 0;
        }
        public Cargo(string sender_adress, string recipient_adress, double weight, int distance)
        {
            this.senderAdress = sender_adress;
            this.recipientAdress = recipient_adress;
            this.weight = weight;
            this.distance = distance;
        }

        public double deliveryPriceCount
        {
            get { return 2.5 * weight * distance; }
        }

        public override string ToString()
        {
            return $"адреса вiдправника: {senderAdress} \nадреса отримувача: {recipientAdress} \nвага: {weight}, " +
                $"вiдстань транспортування: {distance} \nвартiсть доставки: {deliveryPriceCount}";
        }
        public static bool operator< (Cargo left, Cargo right)
        {
            return left.weight < right.weight;
        }
        public static bool operator> (Cargo left, Cargo right)
        {
            return left.weight > right.weight;
        }
        
    }
}
