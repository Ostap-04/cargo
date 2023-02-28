using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cargo
{
    public class Cargo
    {
        private string sender_adress;
        private string recipient_adress;
        private double weight;
        private int distance;

        public Cargo()
        {
            sender_adress = "немає даних";
            recipient_adress = "немає даних";
            weight = 0.0;
            distance = 0;
        }
        public Cargo(string sender_adress, string recipient_adress, double weight, int distance)
        {
            this.sender_adress = sender_adress;
            this.recipient_adress = recipient_adress;
            this.weight = weight;
            this.distance = distance;
        }
        public override string ToString()
        {
            return $"адреса вiдправника: {sender_adress} \nадреса отримувача: {recipient_adress} \nвага: {weight}, вiдстань транспортування:{distance}\n";
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
