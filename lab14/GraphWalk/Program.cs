using System;
using System.Collections.Generic;

class Lab14
{
    static HashSet<string> Traverse(Dictionary<string, List<string>> graph, string start, Dictionary<string, string> parent)
    {
        HashSet<string> visited = new HashSet<string>();
        Queue<string> pending = new Queue<string>();
        pending.Enqueue(start);
        visited.Add(start);

        while (pending.Count > 0)
        {
            string v = pending.Dequeue();
            foreach (string nb in graph[v])
            {
                if (!visited.Contains(nb))
                {
                    visited.Add(nb);
                    parent[nb] = v;
                    pending.Enqueue(nb);
                }
            }
        }
        return visited;
    }

    static HashSet<string> VisitAll(Dictionary<string, List<string>> graph, string start)
    {
        Dictionary<string, string> parent = new Dictionary<string, string>();
        return Traverse(graph, start, parent);
    }

    static bool Reachable(Dictionary<string, List<string>> graph, string start, string target)
    {
        HashSet<string> visited = VisitAll(graph, start);
        return visited.Contains(target);
    }

    static List<string> FindPath(Dictionary<string, List<string>> graph, string start, string target)
    {
        Dictionary<string, string> parent = new Dictionary<string, string>();
        HashSet<string> visited = Traverse(graph, start, parent);

        List<string> path = new List<string>();
        if (!visited.Contains(target))
            return path;

        string v = target;
        path.Add(v);
        while (v != start)
        {
            v = parent[v];
            path.Add(v);
        }
        path.Reverse();
        return path;
    }

    static void PrintPath(Dictionary<string, List<string>> graph, string start, string target)
    {
        List<string> path = FindPath(graph, start, target);
        if (path.Count == 0)
            Console.WriteLine("Шлях " + start + " -> " + target + ": порожній список (шляху немає)");
        else
            Console.WriteLine("Шлях " + start + " -> " + target + ": " + string.Join(" -> ", path) + " (ребер: " + (path.Count - 1) + ")");
    }

    static void Main()
    {
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        graph["Центр"] = new List<string> { "Парк", "Ринок" };
        graph["Парк"] = new List<string> { "Центр", "Вокзал" };
        graph["Ринок"] = new List<string> { "Центр", "Вокзал", "Стадіон" };
        graph["Вокзал"] = new List<string> { "Парк", "Ринок", "Озеро" };
        graph["Стадіон"] = new List<string> { "Ринок" };
        graph["Озеро"] = new List<string> { "Вокзал" };
        graph["Гай"] = new List<string> { "Міст" };
        graph["Міст"] = new List<string> { "Гай" };

        HashSet<string> all = VisitAll(graph, "Центр");
        Console.WriteLine("visitAll(Центр): " + all.Count + " вершин");
        Console.WriteLine("Недосяжних з Центру: " + (graph.Count - all.Count));
        Console.WriteLine();

        Console.WriteLine("reachable(Центр, Озеро): " + Reachable(graph, "Центр", "Озеро"));
        Console.WriteLine("reachable(Центр, Гай): " + Reachable(graph, "Центр", "Гай"));
        Console.WriteLine("reachable(Гай, Міст): " + Reachable(graph, "Гай", "Міст"));
        Console.WriteLine();

        PrintPath(graph, "Центр", "Озеро");
        PrintPath(graph, "Центр", "Стадіон");
        PrintPath(graph, "Центр", "Міст");
    }
}