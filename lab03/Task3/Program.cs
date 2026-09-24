using System;

class Task3
{
    static void Main()
    {
        const int N = 5;
        string[] events = new string[8];
        for (int i = 0; i < events.Length; i++)
            events[i] = $"подія {i + 1}";

        string[] buf = new string[N];
        int pos = 0;
        int count = 0;

        foreach (var e in events)
        {
            buf[pos] = e;
            pos = (pos + 1) % N;
            count++;
        }

        int size = Math.Min(count, N);
        int start = count >= N ? pos : 0;     
        for (int k = 0; k < size; k++)
            Console.WriteLine(buf[(start + k) % N]);
    }
}