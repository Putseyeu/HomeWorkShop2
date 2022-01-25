using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkShop2
{
    class Program
    {       
        static void Main(string[] args)
        {           
            int allMoneyShop = 100;
            int allClient = 0;
            int revenue = 0;
            Queue<string> clients = new Queue<string>();
            List<int> servicePrices = new List<int>() { 100, 200, 300, 400, 500, 600 };             

            Console.WriteLine("Укажите количесво клиентов записаных сегодня на приём очереди");
            allClient = Convert.ToInt32(Console.ReadLine());
            AddClients (ref clients, allClient);
            Console.WriteLine("Ваш список клиентов");
            ShowAllClients(clients);

            while (allClient != 0)
            {
                PayClient(ref revenue, servicePrices);
                
                allMoneyShop = allMoneyShop +  revenue;
                Console.WriteLine($"Клиент выбрал услугу  ценой  {revenue} рублей.");
                Console.WriteLine($"Баланс магазина состовляет {allMoneyShop}");
                DelleteСlient(clients, ref allClient);
                Console.ReadLine();
                Console.Clear();
                
            }
            Console.WriteLine("клиентов больше нету.");                   
        }

        static void AddClients (ref Queue<string> clients, int allClient)
        {
            int numberClient;
            for (int i = 0; i < allClient; i++)
            {
                numberClient = 1 + i;
                clients.Enqueue($"Клиент №{numberClient}");
            }
        }

        static void ShowAllClients(Queue<string> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }            
        }

        static void DelleteСlient(Queue<string> clients, ref int allClient)
        {
            allClient = allClient - 1;
            clients.Dequeue();
        }

        static void PayClient( ref int revenue, List<int> servicePrices)
        {
            Random random = new Random();
            int minIndexServices = 0;
            int maxIndexServices = servicePrices.Count;
            int index = random.Next(minIndexServices, maxIndexServices);
            revenue = servicePrices[index];                      
        }
    }
}
