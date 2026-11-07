using System;
using System.Collections.Generic;

class Request
{
    public string Name;
    public int Priority;
    public int Seq;

    public Request(string name, int priority, int seq)
    {
        Name = name;
        Priority = priority;
        Seq = seq;
    }
}

class Lab10
{
    static void ProcessAll(List<Request> incoming)
    {
        PriorityQueue<Request, int> queue = new PriorityQueue<Request, int>();
        foreach (Request r in incoming)
        {
            queue.Enqueue(r, r.Priority);
        }

        int number = 1;
        while (queue.Count > 0)
        {
            Request r = queue.Dequeue();
            Console.WriteLine(number + ". " + r.Name + " | пріоритет " + r.Priority + " | seq " + r.Seq);
            number++;
        }
    }

    static void ProcessStable(List<Request> incoming)
    {
        PriorityQueue<Request, (int, int)> queue = new PriorityQueue<Request, (int, int)>();
        foreach (Request r in incoming)
        {
            queue.Enqueue(r, (r.Priority, r.Seq));
        }

        int number = 1;
        while (queue.Count > 0)
        {
            Request r = queue.Dequeue();
            Console.WriteLine(number + ". " + r.Name + " | пріоритет " + r.Priority + " | seq " + r.Seq);
            number++;
        }
    }

    static void ProcessWithLate(List<Request> incoming, Request late)
    {
        PriorityQueue<Request, (int, int)> queue = new PriorityQueue<Request, (int, int)>();
        foreach (Request r in incoming)
        {
            queue.Enqueue(r, (r.Priority, r.Seq));
        }

        int number = 1;
        for (int i = 0; i < 2; i++)
        {
            Request r = queue.Dequeue();
            Console.WriteLine(number + ". " + r.Name + " | пріоритет " + r.Priority + " | seq " + r.Seq);
            number++;
        }

        queue.Enqueue(late, (late.Priority, late.Seq));

        while (queue.Count > 0)
        {
            Request r = queue.Dequeue();
            Console.WriteLine(number + ". " + r.Name + " | пріоритет " + r.Priority + " | seq " + r.Seq);
            number++;
        }
    }

    static void Main()
    {
        List<Request> incoming = new List<Request>
        {
            new Request("Оновити підпис у листі", 3, 1),
            new Request("Сервер не відповідає", 1, 2),
            new Request("Не друкує принтер", 2, 3),
            new Request("Не працює термінал оплати", 1, 4),
            new Request("Змінити шпалери", 3, 5),
        };

        Request late = new Request("Відвалився інтернет у відділі", 1, 6);

        Console.WriteLine("Задача 1");
        ProcessAll(incoming);
        Console.WriteLine();

        Console.WriteLine("Задача 2");
        ProcessStable(incoming);
        Console.WriteLine();

        Console.WriteLine("Задача 3");
        ProcessWithLate(incoming, late);
    }
}

/*
Вивід задачі 1:
1. Сервер не відповідає | пріоритет 1 | seq 2
2. Не працює термінал оплати | пріоритет 1 | seq 4
3. Не друкує принтер | пріоритет 2 | seq 3
4. Змінити шпалери | пріоритет 3 | seq 5
5. Оновити підпис у листі | пріоритет 3 | seq 1

Вивід задачі 2:
1. Сервер не відповідає | пріоритет 1 | seq 2
2. Не працює термінал оплати | пріоритет 1 | seq 4
3. Не друкує принтер | пріоритет 2 | seq 3
4. Оновити підпис у листі | пріоритет 3 | seq 1
5. Змінити шпалери | пріоритет 3 | seq 5

Вивід задачі 3:
1. Сервер не відповідає | пріоритет 1 | seq 2
2. Не працює термінал оплати | пріоритет 1 | seq 4
3. Відвалився інтернет у відділі | пріоритет 1 | seq 6
4. Не друкує принтер | пріоритет 2 | seq 3
5. Оновити підпис у листі | пріоритет 3 | seq 1
6. Змінити шпалери | пріоритет 3 | seq 5
*/