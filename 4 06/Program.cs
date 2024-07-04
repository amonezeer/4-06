using System;
using System.Collections.Generic;

public class Student
{
    private string lastName;
    private string firstName;
    private string middleName;
    private DateTime birthDate;
    private string homeAddress;
    private string phoneNumber;

    private List<int> homeworkGrades;
    private List<int> courseGrades;
    private List<int> examGrades;

    public Student()
    {
        lastName = "";
        firstName = "";
        middleName = "";
        birthDate = DateTime.MinValue;
        homeAddress = "";
        phoneNumber = "";
        homeworkGrades = new List<int>();
        courseGrades = new List<int>();
        examGrades = new List<int>();
    }

    public Student(string lastName, string firstName, string middleName, DateTime birthDate, string homeAddress, string phoneNumber)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
        this.birthDate = birthDate;
        this.homeAddress = homeAddress;
        this.phoneNumber = phoneNumber;
        this.homeworkGrades = new List<int>();
        this.courseGrades = new List<int>();
        this.examGrades = new List<int>();
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string MiddleName
    {
        get { return middleName; }
        set { middleName = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public string HomeAddress
    {
        get { return homeAddress; }
        set { homeAddress = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public List<int> HomeworkGrades
    {
        get { return homeworkGrades; }
        set { homeworkGrades = value; }
    }

    public List<int> CourseGrades
    {
        get { return courseGrades; }
        set { courseGrades = value; }
    }

    public List<int> ExamGrades
    {
        get { return examGrades; }
        set { examGrades = value; }
    }

    public void DisplayStudentInfo()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"фамилия -> {lastName}");
        Console.WriteLine($"имя -> {firstName}");
        Console.WriteLine($"отчество -> {middleName}");
        Console.WriteLine($"дата рождения -> {birthDate.ToShortDateString()}");
        Console.WriteLine($"домашний адрес -> {homeAddress}");
        Console.WriteLine($"телефонный номер -> {phoneNumber}");
        Console.WriteLine($"оценки за домашние задания -> {string.Join(", ", homeworkGrades)}");
        Console.WriteLine($"оценки за курсовые работы -> {string.Join(", ", courseGrades)}");
        Console.WriteLine($"оценки за экзамены -> {string.Join(", ", examGrades)}\n");
        Console.ResetColor();

    }
}

public class Program
{
    public static void Main(string[] args)
    {

        Student student1 = new Student("Демидов", "Артур", "Иванович", new DateTime(2004, 3, 15), "ул Преображенская 4", "380-97-39-55-211");
        Student student2 = new Student("Черенков ", "Петр", "Архипович", new DateTime(1999, 4, 11), "ул Гвардейская 11а", "380-66-53-22-423");
        Student student3 = new Student("Джульпаев", "Равшан", "Суренович", new DateTime(2001, 3, 3), "ул Генеузька 12/2", "380-63-11-55-123");

        student1.HomeworkGrades.Add(5);
        student1.HomeworkGrades.Add(4);
        student1.CourseGrades.Add(5);
        student1.ExamGrades.Add(3);

        student2.HomeworkGrades.Add(3);
        student2.HomeworkGrades.Add(4);
        student2.CourseGrades.Add(4);
        student2.ExamGrades.Add(5);

        student3.HomeworkGrades.Add(4);
        student3.HomeworkGrades.Add(4);
        student3.CourseGrades.Add(3);
        student3.ExamGrades.Add(4);

        List<Student> students = new List<Student> { student1, student2, student3 };

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("выберите студента");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}-> {students[i].FirstName} {students[i].LastName}");
            }
            Console.WriteLine("0 -> выход");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");

            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice) && choice >= 0 && choice <= students.Count)
            {
                if (choice == 0)
                {
                    break;
                }
                else
                {
                    students[choice - 1].DisplayStudentInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("неверный выбор  , повторите попытку");
            }
        }
    }
}
