using System;
using System.Collections.Generic;

class Task1
{
    static void Main()
    {
        string[] lines = { "запуск", "вхід користувача", "помилка", "вихід" };

        var log = new List<string>();
        foreach (var line in lines)
            log.Add(line);            

        log.Reverse();                
        foreach (var line in log)
            Console.WriteLine(line);
    }
}
