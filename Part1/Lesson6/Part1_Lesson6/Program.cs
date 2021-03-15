using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Описываем делегат. В делегате описывается сигнатура методов, на
// которые он сможет ссылаться в дальнейшем (хранить в себе)
public delegate double Fun(double x);
public delegate double Fun2(double x, double a);

namespace Part1_Lesson6
{
    class Program
    {
        enum MyFunctions
        {
            NewFunc = 0,
            XnaXminusX,
            XplusX,
            XnaXplusXnaX
        }
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static void Table2(Fun2 F, double x, double b, double a)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double MyFunc2(double x, double a)
        {
            return x * x * a;
        }

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static double F2(double x)
        {
            return x * x - x;
        }
        public static double F3(double x)
        {
            return x + x;
        }
        public static double F4(double x)
        {
            return x * x + x * x;
        }
        public static void SaveFunc(string fileName, Fun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            double[] arrValues = new double[fs.Length];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                arrValues[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return arrValues;
        }

        public class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;
            // Создаем конструктор
            public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }
        }

        static int MyDelegat(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }

        public delegate int Stu(Student stu, object value);
        public static int CountAge(Student stu, object value)
        {
            if (stu.age == Convert.ToInt32(value))
                return 1;
            else
                return 0;
        }
        public static int CountCourse(Student stu, object value)
        {
            if (stu.course == Convert.ToInt32(value))
                return 1;
            else
                return 0;
        }
        public static int CountFaculty(Student stu, object value)
        {
            if (stu.faculty == Convert.ToString(value))
                return 1;
            else
                return 0;
        }
        public static int StudentDelegate(List<Student> list, Stu param, object value)
        {
            int counter = 0;
            foreach (Student student in list)
            {
                counter += param(student, value);
            }
            return counter;
        }


        public static int subprogram = 0;

        static void Main(string[] args)
        {
            do
            {
                MainMenu();
            }
            while (subprogram > 0);
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select a subprogram (1-5), anything else - exit");
            int.TryParse(Console.ReadLine(), out subprogram);
            switch (subprogram)
            {
                case 0:
                    return;
                case 1:
                    SubProgram1();
                    return;
                case 2:
                    SubProgram2();
                    return;
                case 3:
                    SubProgram3();
                    return;
                //case 4:
                //    SubProgram4();
                //    return;
                //case 5:
                //    SubProgram5();
                //    return;
                default:
                    return;
            }
        }

        //1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
        // Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        static void SubProgram1()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x) { return x * x; }, 0, 3);

            //a*x^2
            Console.WriteLine("Table of function a*x^2:");
            Table2(MyFunc2, 0, 3, 2); // a - last value

            //a*sin(x)
            Console.WriteLine("Table of function a*sin(x):");
            Table2(delegate (double x, double a) { return a * Math.Sin(x); }, 0, 3, 2); // a - last value

            Console.ReadKey();
        }

        // 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        // в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.
        // Пусть она возвращает минимум через параметр.
        static void SubProgram2()
        {
            // а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке
            // находить минимум.
            Console.WriteLine("Chose function:");
            Console.WriteLine("1. F = x * x - 50 * x + 10");
            Console.WriteLine("2. F = x * x - x");
            Console.WriteLine("3. F = x + x");
            Console.WriteLine("4. F = x * x + x * x");

            // б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
            List<Fun> listFunc = new List<Fun>();
            listFunc.Add(F1);
            listFunc.Add(F2);
            listFunc.Add(F3);
            listFunc.Add(F4);

            int curFunc = 0;
            double min = Double.MaxValue;
            int.TryParse(Console.ReadLine(), out curFunc);
            switch (curFunc)
            {
                case 0:
                    return;
                case 1:
                    SaveFunc("data.bin", listFunc[Convert.ToInt32(MyFunctions.NewFunc)], -100, 100, 0.5);
                    Load("data.bin", out min);
                    Console.WriteLine(min);
                    Console.ReadKey();
                    return;
                case 2:
                    SaveFunc("data.bin", listFunc[Convert.ToInt32(MyFunctions.XnaXminusX)], -100, 100, 0.5);
                    Load("data.bin", out min);
                    Console.WriteLine(min);
                    Console.ReadKey();
                    return;
                case 3:
                    SaveFunc("data.bin", listFunc[Convert.ToInt32(MyFunctions.XplusX)], -100, 100, 0.5);
                    Load("data.bin", out min);
                    Console.WriteLine(min);
                    Console.ReadKey();
                    return;
                case 4:
                    SaveFunc("data.bin", listFunc[Convert.ToInt32(MyFunctions.XnaXplusXnaX)], -1, 1, 0.5);
                    double[] allValues = Load("data.bin", out min);
                    Console.WriteLine(min);
                    Console.WriteLine("All values of this function are:");
                    for (int i = 0; i < allValues.Length; i++)
                    {
                        Console.WriteLine(allValues[i]);
                    }
                    Console.ReadKey();
                    return;
                default:
                    return;
            }
            
            Console.ReadKey();
        }

        // 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
        static void SubProgram3()
        {

            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students2.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error !ESC - end of program");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine();
            Console.WriteLine("All students: " + list.Count);
            Console.WriteLine("Master: {0}", magistr);
            Console.WriteLine("Bachelor: {0}", bakalavr);

            // а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            Console.WriteLine("Students on 5 and 6 course:{0} ", list.FindAll(x => x.course == 5 || x.course == 6).Count);
            
            // б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<Student> newList = new List<Student>(list.FindAll(x => x.age >= 18 && x.age <= 20));
            foreach (Student dic in newList)
            {
                if (dictionary.ContainsKey(dic.course))
                    ++dictionary[dic.course];
                else
                    dictionary[dic.course] = 1;
            }
            foreach (KeyValuePair<int, int> pair in dictionary)
                Console.WriteLine("In course {0} study {1} student from 18 to 20 years old", pair.Key, pair.Value);

            // в) отсортировать список по возрасту студента;
            Console.WriteLine();
            Console.WriteLine("Sorted by age:");
            list = list.OrderBy(o => o.age).ToList();
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine();

            // г) *отсортировать список по курсу и возрасту студента;
            Console.WriteLine("Sorted by course and age:");
            list = list.OrderBy(o => o.course).ThenBy(o => o.age).ToList();
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine();

            // д) разработать единый метод подсчета количества студентов по различным параметрам
            // выбора с помощью делегата и методов предикатов.
            Console.WriteLine($"Counts of student in 20 years old = {StudentDelegate(list, CountAge, 20)}");
            Console.WriteLine($"Counts of student study in 1 course = {StudentDelegate(list, CountCourse, 3)}");
            Console.WriteLine($"Counts of student study in IT faculty = {StudentDelegate(list, CountFaculty, "IT")}");
            Console.WriteLine();

            //Console.WriteLine(DateTime.Now - dt);

            Console.ReadKey();
        }
    }
}
