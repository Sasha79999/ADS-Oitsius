using System;

class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class Lab12
{
    static int compareCount = 0;

    static Node Insert(Node node, int key)
    {
        if (node == null)
            return new Node(key);
        if (key < node.Value)
            node.Left = Insert(node.Left, key);
        else if (key > node.Value)
            node.Right = Insert(node.Right, key);
        return node;
    }

    static bool Search(Node node, int key)
    {
        if (node == null)
            return false;
        compareCount++;
        if (key == node.Value)
            return true;
        if (key < node.Value)
            return Search(node.Left, key);
        else
            return Search(node.Right, key);
    }

    static void Inorder(Node node)
    {
        if (node == null)
            return;
        Inorder(node.Left);
        Console.Write(node.Value + " ");
        Inorder(node.Right);
    }

    static int CountNodes(Node node)
    {
        if (node == null)
            return 0;
        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    static int Depth(Node node)
    {
        if (node == null)
            return 0;
        int left = Depth(node.Left);
        int right = Depth(node.Right);
        if (left > right)
            return left + 1;
        else
            return right + 1;
    }

    static void Main()
    {
        int[] values = { 42, 18, 65, 9, 27, 55, 90, 33 };
        Node root = null;

        foreach (int v in values)
        {
            root = Insert(root, v);
        }

        Console.WriteLine("Вузлів у дереві: " + CountNodes(root));

        Console.Write("Симетричний обхід: ");
        Inorder(root);
        Console.WriteLine();

        compareCount = 0;
        Console.WriteLine("search(55): " + Search(root, 55));
        Console.WriteLine("Порівнянь: " + compareCount);

        compareCount = 0;
        Console.WriteLine("search(30): " + Search(root, 30));
        Console.WriteLine("Порівнянь: " + compareCount);

        Console.WriteLine("Глибина найдовшої гілки: " + Depth(root));

        root = Insert(root, 27);
        Console.WriteLine("Вузлів після повторної вставки 27: " + CountNodes(root));
    }
}