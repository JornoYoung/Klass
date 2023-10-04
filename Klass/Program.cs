using System;
using System.Collections.Generic;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    /// <summary>
    /// Выводит информацию о студенте.
    /// </summary>
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName}, возраст: {Age} лет");
    }

    /// <summary>
    /// Редактирует информацию о студенте.
    /// </summary>
    public virtual void EditInfo()
    {
        Console.Write("Введите новое имя: ");
        FirstName = Console.ReadLine();
        Console.Write("Введите новую фамилию: ");
        LastName = Console.ReadLine();
        Console.Write("Введите новый возраст: ");
        Age = int.Parse(Console.ReadLine());
    }
}

class HeadStudent : Student
{
    public HeadStudent(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
    }

    /// <summary>
    /// Выводит информацию о старосте.
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"Староста: {FirstName} {LastName}, возраст: {Age} лет");
    }
}

class StudentGroup
{
    public string GroupName { get; set; }
    public List<Student> Students { get; set; }
    public HeadStudent GroupHead { get; set; }

    public StudentGroup(string groupName)
    {
        GroupName = groupName;
        Students = new List<Student>();
    }

    /// <summary>
    /// Выводит информацию о группе студентов, включая студентов и старосту.
    /// </summary>
    public void DisplayGroupInfo()
    {
        Console.WriteLine($"Группа: {GroupName}");
        Console.WriteLine("Список студентов:");
        foreach (var student in Students)
        {
            student.DisplayInfo();
        }
        Console.WriteLine("Староста:");
        GroupHead.DisplayInfo();
    }

    /// <summary>
    /// Редактирует информацию о группе, включая название и данные старосты.
    /// </summary>
    public void EditGroupInfo()
    {
        Console.Write("Введите новое название группы: ");
        GroupName = Console.ReadLine();
        Console.WriteLine("Редактирование данных старосты:");
        GroupHead.EditInfo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Иван", "Иванов", 20);
        Student student2 = new Student("Мария", "Петрова", 21);
        HeadStudent headStudent = new HeadStudent("Анна", "Смирнова", 22);

        StudentGroup group = new StudentGroup("Группа 1");
        group.Students.Add(student1);
        group.Students.Add(student2);
        group.GroupHead = headStudent;

        Console.WriteLine("Режим отображения данных:\n");
        group.DisplayGroupInfo();

        Console.WriteLine("\nРежим редактирования данных:\n");
        group.EditGroupInfo();

        Console.WriteLine("\nПосле редактирования:\n");
        group.DisplayGroupInfo();
    }
}
