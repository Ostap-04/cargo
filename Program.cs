namespace cargo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Cargo c1 = new Cargo("Address1", "Address2", 10, 100);
            Cargo c2 = new Cargo("Address5", "Address6", 30, 500);
            Cargo c3 = new Cargo("Address3", "Address4", 20, 300);
            Cargo c4 = new Cargo("Address2", "Address3", 15, 200);
            Cargo c5 = new Cargo("Address4", "Address5", 25, 400);
            Cargo c7 = new Cargo("Address2", "Address5", 47, 467);


            List<Cargo> cargoList = new() { c1, c2, c3, c4, c5, c7 };

            Cargo c6 = new Cargo().DialogInput();
            cargoList.Add(c6);

            Cargo.PrintList(cargoList);
            Console.WriteLine("--------------------------------");

            int size = cargoList.Count;
            int minDeliveryIndex = 0;
            for (int i = 0; i < size; i++)
            {
                if (cargoList[i].DeliveryPriceCount < cargoList[minDeliveryIndex].DeliveryPriceCount)
                {
                    minDeliveryIndex = i;
                }
            }
            Console.WriteLine($"\nвантаж з найменшою вартiстю доставки: \n{cargoList[minDeliveryIndex]}");

            List<Cargo> senderList = new List<Cargo>();
            Console.WriteLine("Введіть адресу відправника: ");
            string senderTemp = Console.ReadLine();
            foreach (Cargo cargo in cargoList)
            {
                if (cargo == senderTemp)
                {
                    senderList.Add(cargo);
                }
            }
            Console.WriteLine("--------------------------------\nАдреса відправник {0}", senderTemp);
            Cargo.PrintList(senderList);

            Console.WriteLine("--------------------------------\nОператори:\n");
            Console.WriteLine(c2 - c1);
            Console.WriteLine(c4 - c5);
            Console.WriteLine(c1 + 200);
        }
    }
}