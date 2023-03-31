﻿using System.Globalization;
using System.Runtime.InteropServices;

namespace cargo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //українська мова в консолі

            //створення екземплярів класу за допомогою конструктора
            Cargo c1 = new Cargo("Address1", "Address2", 10, 100, 2);
            Cargo c2 = new Cargo("Address5", "Address6", 30, 500, 10);
            Cargo c3 = new Cargo("Address3", "Address4", 20, 300, 6);
            Cargo c4 = new Cargo("Address2", "Address3", 15, 200, 4);
            Cargo c5 = new Cargo("Address4", "Address5", 25, 400, 8);
            Cargo c7 = new Cargo("Address2", "Address5", 47, 467, 9);
            AccompCargo ac1 = new AccompCargo("Address1", "Address2", 13, 90, 2, 99);
            AccompCargo ac2 = new AccompCargo("Address2", "Address5", 30, 170, 13, 15);
            AccompCargo ac3 = new AccompCargo("Address3", "Address1", 124, 50, 11, 13);

            List<Cargo> cargoList = new() { c1, c2, c3, c4, c5, c7, ac1, ac2, ac3 };

            Console.Write("**************** Ввід в режимі діалогу ****************\n");
            Console.Write("\nВведіть кількість вантажів які ви бажаєте задати: ");
            int n = int.Parse(Console.ReadLine());
            string cargoType;
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Який вантаж бажаєте задати? Для супутнього вантажу введіть 1: ");
                cargoType = Console.ReadLine();
                if (cargoType == "1") cargoList.Add(new AccompCargo().DialogInput());
                else cargoList.Add(new Cargo().DialogInput());
            }

            Console.Write("\n**************** Друк всіх елементів контейнера ****************\n");
            Cargo.PrintList(cargoList);

            Console.Write("\n**************** Пошук вантажу з найменшою вартiстю доставки ****************\n");
            int size = cargoList.Count;
            int minDeliveryIndex = 0;
            for (int i = 0; i < size; i++)
            {
                if (cargoList[i].DeliveryPriceCount < cargoList[minDeliveryIndex].DeliveryPriceCount)
                {
                    minDeliveryIndex = i;
                }
            }
            cargoType = cargoList[minDeliveryIndex].GetType().Name;
            string strType = cargoType == "Cargo" ? "Простий вантаж" : "Супутній вантаж";
            Console.WriteLine($"\nвантаж з найменшою вартiстю доставки: \n{cargoList[minDeliveryIndex]}Тип вантажу: {strType}\n");

            Console.WriteLine("\n**************** Використання операторів ****************\n");
            //Console.WriteLine(c2 - c1);
            //Console.WriteLine(c4 - c5);
            Console.WriteLine(c1 + 200);
            Console.WriteLine(c1 < c2);
            Console.WriteLine(c1 > c7);

            Console.WriteLine("\n\n**** Збільшення удвічі відсоток здешевлення супутніх вантажів ****");
            foreach (Cargo cargo in cargoList)
            {
                if (cargo is AccompCargo)
                {
                    AccompCargo ac = cargo as AccompCargo;
                    ac.Discount = ac.Discount * 2;
                }
            }
            Cargo.PrintList(cargoList);

            Console.WriteLine("\n****** Створення нової колекції з одним відправником ******\n");
            List<Cargo> senderList = new List<Cargo>();
            Console.WriteLine("Введіть адресу відправника: ");
            string senderTemp = Console.ReadLine();
            foreach (Cargo cargo in cargoList)
            {
                if (cargo == senderTemp) senderList.Add(cargo);
            }
            Console.WriteLine("--------------------------------\n");
            for (int i = 0; i < senderList.Count; i++)
            {
                Console.WriteLine(senderList[i].ToString("R w D p %", null));
            }

            Console.WriteLine("\n****** Робота з подіями ******\n");
            foreach (var sender in cargoList)
                sender.DeliveryExpiration += DealWithDeliveryExpiration;
            for (int i = 0; i < 15; ++i)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine($"*** Пройшов {i} день ***\n");
                        break;
                    case 2:
                    case 3:
                    case 4:
                        Console.WriteLine($"*** Пройшло {i} дні ***\n");
                        break;
                    default:
                        Console.WriteLine($"*** Пройшло {i} днів *** \n");
                        break;
                }
                foreach (var sender in cargoList)
                    sender.OnDeliveryExpiration();
                Console.ReadLine();
            }
        }

        public static void DealWithDeliveryExpiration(object sender, DeliveryEventArgs arg)
        {
            Cargo c = sender as Cargo;
            if (c.DeliveryLeft == 0)
            {
                arg.Msg += $"Вантаж прибув до отримувача:\n{c}";
                c.DeliveryExpiration -= DealWithDeliveryExpiration;
            }
            else if (c.DeliveryLeft == 2)
            {
                arg.Msg += $"Вантаж близько до прибуття, залишилося: {arg.TimeLeft} д.\n{c}";
                c.DeliveryLeft -= 1;
            }
            else
            {
                c.DeliveryLeft -= 1;
                arg.Msg = string.Empty;
            }
        }
    }
}