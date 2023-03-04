namespace cargo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cargo c1 = new Cargo("Address1", "Address2", 10, 100);
            Cargo c2 = new Cargo("Address5", "Address6", 30, 500);
            Cargo c3 = new Cargo("Address3", "Address4", 20, 300);
            Cargo c4 = new Cargo("Address2", "Address3", 15, 200);
            Cargo c5 = new Cargo("Address4", "Address5", 25, 400);
            List<Cargo> cargoList = new () { c1, c2, c3, c4, c5 };
            
            int size = cargoList.Count;
            Console.WriteLine("\nсписок вантажiв:");
            for(int i = 0; i < size; i++) {
                Console.WriteLine($"\nванжтаж{i + 1}\n{cargoList[i]}");
            }

            int minDeliveryIndex = 0;
            for(int i = 0; i < size; i++) { 
                if (cargoList[i].deliveryPriceCount < cargoList[minDeliveryIndex].deliveryPriceCount)
                {
                    minDeliveryIndex = i; 
                    break;
                }
            }
            Console.WriteLine($"\n\nвантаж з найменшою вартiстю доставки: вантаж{minDeliveryIndex+1}\n{cargoList[minDeliveryIndex]}");
        }
    }
}