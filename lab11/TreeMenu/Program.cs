using System;
using System.Collections.Generic;

class Node
{
    public string Title;
    public List<Node> Children;

    public Node(string title, List<Node> children)
    {
        Title = title;
        Children = children;
    }
}

class Lab11
{
    static int callCount = 0;

    static void PrintMenu(Node node, int level)
    {
        string indent = new string(' ', level * 2);
        Console.WriteLine(indent + node.Title);
        foreach (Node child in node.Children)
        {
            PrintMenu(child, level + 1);
        }
    }

    static int CountItems(Node node)
    {
        callCount++;
        int total = 1;
        foreach (Node child in node.Children)
        {
            total = total + CountItems(child);
        }
        return total;
    }

    static bool Find(Node node, string name)
    {
        if (node.Title == name)
            return true;
        foreach (Node child in node.Children)
        {
            if (Find(child, name))
                return true;
        }
        return false;
    }

    static void Main()
    {
        Node menu = new Node("Головне меню", new List<Node>
        {
            new Node("Файл", new List<Node>
            {
                new Node("Новий", new List<Node>()),
                new Node("Зберегти", new List<Node>()),
            }),
            new Node("Правка", new List<Node>
            {
                new Node("Копіювати", new List<Node>()),
            }),
            new Node("Вигляд", new List<Node>
            {
                new Node("Масштаб", new List<Node>
                {
                    new Node("Збільшити", new List<Node>()),
                    new Node("Зменшити", new List<Node>()),
                }),
            }),
            new Node("Довідка", new List<Node>()),
        });

        PrintMenu(menu, 0);
        Console.WriteLine();

        callCount = 0;
        int total = CountItems(menu);
        Console.WriteLine("Кількість пунктів: " + total);
        Console.WriteLine("Викликів CountItems: " + callCount);
        Console.WriteLine();

        Console.WriteLine("Зберегти: " + Find(menu, "Зберегти"));
        Console.WriteLine("Масштаб: " + Find(menu, "Масштаб"));
        Console.WriteLine("Довідка: " + Find(menu, "Довідка"));
        Console.WriteLine("Експорт: " + Find(menu, "Експорт"));
    }
}