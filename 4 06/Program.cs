using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
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

    public enum Specialization
    {
        Math,
        Physics,
        Chemistry,
        Biology,
        ComputerScience
    }

    public class Group
    {
        public List<Student> Students { get; set; }
        public string GroupName { get; set; }
        public Specialization GroupSpecialization { get; set; }
        public int CourseNumber { get; set; }

        public Group()
        {
            Students = new List<Student>();
            GroupName = "";
            GroupSpecialization = Specialization.ComputerScience;
            CourseNumber = 1;
        }

        public Group(Group group)
        {
            Students = new List<Student>(group.Students);
            GroupName = group.GroupName;
            GroupSpecialization = group.GroupSpecialization;
            CourseNumber = group.CourseNumber;
        }

        public void DisplayAllStudents()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Группа: {GroupName}, Специализация: {GroupSpecialization}, Курс: {CourseNumber}");
            Console.ResetColor();
            foreach (var student in Students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName))
            {
                student.DisplayStudentInfo();
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void EditStudent(int index, Student newStudentData)
        {
            if (index >= 0 && index < Students.Count)
            {
                Students[index] = newStudentData;
            }
            else
            {
                Console.WriteLine("Неверный индекс студента.");
            }
        }

        public void TransferStudent(Group targetGroup, int studentIndex)
        {
            if (studentIndex >= 0 && studentIndex < Students.Count)
            {
                var student = Students[studentIndex];
                Students.RemoveAt(studentIndex);
                targetGroup.AddStudent(student);
            }
            else
            {
                Console.WriteLine("Неверный индекс студента.");
            }
        }

        public void ExpelFailingStudents()
        {
            Students.RemoveAll(student => student.ExamGrades.Any(grade => grade < 3));
        }

        public void ExpelWorstStudent()
        {
            if (Students.Count > 0)
            {
                var worstStudent = Students.OrderBy(s => s.ExamGrades.Average()).First();
                Students.Remove(worstStudent);
            }
        }

        public void ExpelStudent(int index)
        {
            if (index >= 0 && index < Students.Count)
            {
                Students.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Неверный индекс студента.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Group group1 = new Group
            {
                GroupName = "Группа 1",
                GroupSpecialization = Specialization.Math,
                CourseNumber = 1
            };

            string[] firstNames = { "Равшан", "Алексей", "Маша", "Адександр", "Димон" };
            string[] lastNames = { "Комиров", "Фиромонов", "Агаджанян", "Пашаев", "Джульпаев" };
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                DateTime birthDate = new DateTime(random.Next(1995, 2005), random.Next(1, 13), random.Next(1, 29));
                string homeAddress = $"ул. Преображенская, {random.Next(1, 100)}";
                string phoneNumber = $"380-97-{random.Next(100, 999)}-{random.Next(1000, 9999)}";

                Student student = new Student(lastName, firstName, "Иванович", birthDate, homeAddress, phoneNumber);
                group1.AddStudent(student);
            }

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 -> Показать всех студентов");
                Console.WriteLine("2 -> Добавить студента");
                Console.WriteLine("3 -> Отчислить студента");
                Console.WriteLine("0 -> Выход");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            group1.DisplayAllStudents();
                            break;

                        case 2:
                            Console.WriteLine("Введите фамилию:");
                            string lastName = Console.ReadLine();

                            Console.WriteLine("Введите имя:");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Введите отчество:");
                            string middleName = Console.ReadLine();

                            Console.WriteLine("Введите дату рождения (гггг-мм-дд):");
                            DateTime birthDate;
                            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
                            {
                                Console.WriteLine("Неверный формат даты, попробуйте еще раз (гггг-мм-дд):");
                            }

                            Console.WriteLine("Введите домашний адрес:");
                            string homeAddress = Console.ReadLine();

                            Console.WriteLine("Введите телефонный номер:");
                            string phoneNumber = Console.ReadLine();

                            Student newStudent = new Student(lastName, firstName, middleName, birthDate, homeAddress, phoneNumber);
                            group1.AddStudent(newStudent);
                            break;

                        case 3:
                            Console.WriteLine("Введите номер студента для отчисления:");
                            for (int i = 0; i < group1.Students.Count; i++)
                            {
                                Console.WriteLine($"{i + 1} -> {group1.Students[i].FirstName} {group1.Students[i].LastName}");
                            }
                            if (int.TryParse(Console.ReadLine(), out int studentIndex))
                            {
                                group1.ExpelStudent(studentIndex - 1);
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                }
            }
        }
    }
}

// пока так ,  есть что улучшить и что исправить , доделаю чуть позже :)