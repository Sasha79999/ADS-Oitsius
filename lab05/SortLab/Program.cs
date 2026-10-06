using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Surname;
    public string Group;
    public int Grade;
    public int Year;

    public Student(string surname, string group, int grade, int year)
    {
        Surname = surname;
        Group = group;
        Grade = grade;
        Year = year;
    }
}

class Lab05
{
    static void PrintAll(string title, List<Student> items)
    {
        Console.WriteLine(title);
        foreach (var s in items)
            Console.WriteLine($"{s.Surname} {s.Group} {s.Grade} {s.Year}");
        Console.WriteLine();
    }

    static void Main()
    {
        var students = new List<Student>
        {
            new Student("Ткаченко", "ІПЗ-3/1", 85, 2024),
            new Student("Бондар", "ІПЗ-3/2", 92, 2023),
            new Student("Іваненко", "ІПЗ-3/1", 85, 2024),
            new Student("Коваль", "ІПЗ-3/2", 78, 2024),
            new Student("Сидоренко", "ІПЗ-3/1", 85, 2023),
            new Student("Мельник", "ІПЗ-3/2", 92, 2024),
            new Student("Гриценко", "ІПЗ-3/1", 78, 2023),
            new Student("Дяченко", "ІПЗ-3/2", 85, 2023),
        };

        var bySurname = students.OrderBy(s => s.Surname).ToList();
        PrintAll("За прізвищем:", bySurname);

        var byGrade = students.OrderByDescending(s => s.Grade).ToList();
        PrintAll("За балом:", byGrade);

        var byGroupThenGrade = students.OrderBy(s => s.Group).ThenByDescending(s => s.Grade).ToList();
        PrintAll("За групою, всередині за балом:", byGroupThenGrade);

        var byGradeThenSurname = students.OrderByDescending(s => s.Grade).ThenBy(s => s.Surname).ToList();
        PrintAll("За балом, серед однакових за прізвищем:", byGradeThenSurname);
    }
}