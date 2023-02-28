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
            sender_adress = "Остап і Юля ПМі-26";
            recipient_adress = "Ярошко Сергій Адамович";
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
    }
}
