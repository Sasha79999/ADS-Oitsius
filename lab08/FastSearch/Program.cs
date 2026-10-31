using System;
using System.Collections.Generic;

class Client
{
    public int Id;
    public string Name;

    public Client(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Order
{
    public int Number;
    public int ClientId;
    public int Sum;

    public Order(int number, int clientId, int sum)
    {
        Number = number;
        ClientId = clientId;
        Sum = sum;
    }
}

class Lab08
{
    static void Main()
    {
        List<Client> clients = new List<Client>
        {
            new Client(101, "Коваленко"),
            new Client(102, "Мельник"),
            new Client(103, "Шевчук"),
            new Client(104, "Бондар"),
            new Client(105, "Ткачук"),
            new Client(106, "Гриценко"),
        };

        List<Order> orders = new List<Order>
        {
            new Order(1, 103, 450),
            new Order(2, 101, 120),
            new Order(3, 105, 980),
            new Order(4, 103, 300),
            new Order(5, 102, 75),
            new Order(6, 106, 1500),
            new Order(7, 101, 220),
            new Order(8, 103, 60),
        };

        List<int> blocked = new List<int> { 102, 104 };

        Console.WriteLine("Фрагмент 1");
        // foreach (Order order in orders)
        // {
        //     foreach (Client client in clients)
        //     {
        //         if (client.Id == order.ClientId)
        //             Console.WriteLine("Замовлення " + order.Number + " - " + client.Name);
        //     }
        // }
        Dictionary<int, string> namesById = new Dictionary<int, string>();
        foreach (Client client in clients)
        {
            namesById[client.Id] = client.Name;
        }
        foreach (Order order in orders)
        {
            Console.WriteLine("Замовлення " + order.Number + " - " + namesById[order.ClientId]);
        }
        Console.WriteLine();

        Console.WriteLine("Фрагмент 2");
        // int total = 0;
        // foreach (Order order in orders)
        // {
        //     if (!blocked.Contains(order.ClientId))
        //         total = total + order.Sum;
        // }
        HashSet<int> blockedSet = new HashSet<int>();
        foreach (int id in blocked)
        {
            blockedSet.Add(id);
        }
        int total = 0;
        foreach (Order order in orders)
        {
            if (!blockedSet.Contains(order.ClientId))
                total = total + order.Sum;
        }
        Console.WriteLine("Сума прийнятих замовлень: " + total);
        Console.WriteLine();

        Console.WriteLine("Фрагмент 3");
        // List<int> counted = new List<int>();
        // foreach (Order order in orders)
        // {
        //     if (counted.Contains(order.ClientId))
        //         continue;
        //     int count = 0;
        //     foreach (Order other in orders)
        //     {
        //         if (other.ClientId == order.ClientId)
        //             count = count + 1;
        //     }
        //     counted.Add(order.ClientId);
        //     Console.WriteLine(order.ClientId + ": " + count);
        // }
        Dictionary<int, int> counts = new Dictionary<int, int>();
        List<int> firstSeen = new List<int>();
        foreach (Order order in orders)
        {
            if (counts.ContainsKey(order.ClientId))
            {
                counts[order.ClientId] = counts[order.ClientId] + 1;
            }
            else
            {
                counts[order.ClientId] = 1;
                firstSeen.Add(order.ClientId);
            }
        }
        foreach (int id in firstSeen)
        {
            Console.WriteLine(id + ": " + counts[id]);
        }
        Console.WriteLine();

        Console.WriteLine("Фрагмент 4");
        Order best = orders[0];
        foreach (Order order in orders)
        {
            if (order.Sum > best.Sum)
                best = order;
        }
        Console.WriteLine("Найбільше замовлення: " + best.Sum);
        Console.WriteLine();

        Console.WriteLine("Фрагмент 5");
        foreach (Order order in orders)
        {
            Dictionary<int, Client> byId = new Dictionary<int, Client>();
            foreach (Client client in clients)
            {
                byId[client.Id] = client;
            }
            Console.WriteLine("Замовлення " + order.Number + " - " + byId[order.ClientId].Name);
        }
    }
}