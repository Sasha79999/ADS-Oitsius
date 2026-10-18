using System;
using System.Collections.Generic;

class Request
{
    public string Name;
    public int Minutes;

    public Request(string name, int minutes)
    {
        Name = name;
        Minutes = minutes;
    }
}

class Lab07
{
    static bool IsBalanced(string line)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in line)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                    return false;
                char top = stack.Pop();
                if (c == ')' && top != '(') return false;
                if (c == ']' && top != '[') return false;
                if (c == '}' && top != '{') return false;
            }
        }
        return stack.Count == 0;
    }

    static void ProcessQueue(Queue<Request> requests)
    {
        if (requests.Count == 0)
        {
            Console.WriteLine("Обробляти нічого, черга порожня");
            return;
        }

        int currentMinute = 0;
        int order = 1;
        int totalWaiting = 0;

        while (requests.Count > 0)
        {
            Request r = requests.Dequeue();
            int start = currentMinute;
            int end = start + r.Minutes;
            Console.WriteLine(order + ". " + r.Name + " з " + start + " до " + end + " хв");
            totalWaiting += start;
            currentMinute = end;
            order++;
        }

        Console.WriteLine("Оброблено заявок: " + (order - 1) + ", загальний час: " + currentMinute + " хв");
        double average = (double)totalWaiting / (order - 1);
        Console.WriteLine("Середній час очікування: " + average + " хв");
    }

    static void Main()
    {
        string[] lines = {
            "",
            "a + b",
            "{[a] + (b)}",
            "([)]",
            "a)",
            "(a[b]",
            "f(x[1]) * {y + (z)}",
        };

        foreach (string line in lines)
        {
            bool result = IsBalanced(line);
            string answer = result ? "так" : "ні";
            Console.WriteLine(line + " -> " + answer);
        }

        Console.WriteLine();

        Queue<Request> requests = new Queue<Request>();
        requests.Enqueue(new Request("Довідка про навчання", 4));
        requests.Enqueue(new Request("Академічна відпустка", 7));
        requests.Enqueue(new Request("Копія наказу", 2));
        requests.Enqueue(new Request("Виписка з оцінками", 6));
        requests.Enqueue(new Request("Перескладання", 9));
        requests.Enqueue(new Request("Студентський квиток", 3));

        ProcessQueue(requests);

        Console.WriteLine();

        Queue<Request> empty = new Queue<Request>();
        ProcessQueue(empty);
    }
}