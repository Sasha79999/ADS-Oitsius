using System;

class Task2
{
    static void Main()
    {
        (int month, double amount)[] operations =
        {
            (1, 100.0), (3, 250.5), (1, 50.0), (12, 300.0), (3, -20.5)
        };

        double[] totals = new double[12];     

        foreach (var op in operations)
            totals[op.month - 1] += op.amount;    

        for (int i = 0; i < 12; i++)
            Console.WriteLine($"Місяць {i + 1}: {totals[i]}");
    }
}