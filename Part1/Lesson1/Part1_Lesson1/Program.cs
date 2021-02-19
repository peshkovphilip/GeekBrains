using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_Lesson1
{
    //Урок 1. Введение.Базовые типы данных.Консоль.Классы и методы.
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
            CustomMethods.CustomPrint("Welcome back, mr. Smith");
            CustomMethods.Pause();
            Console.Clear();

            #region Task1
            //        1. Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
            //          а) используя склеивание;
            //          б) используя форматированный вывод;
            //          в) *используя вывод со знаком $.
            Console.SetWindowSize(100, 40);
            int standartReward = 5000;
            Console.Title = "Bounty hunters";
            CustomMethods.CustomPrint("Criminals database.", Console.WindowWidth / 2 - 10, 1);
            Console.WriteLine("Input some data for search.");
            Console.Write("First name: ");
            string fname = Console.ReadLine();
            Console.Write("Last name: ");
            string lname = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height: ");
            int height = (int)Convert.ToSingle(Console.ReadLine());
            Console.Write("Weight: ");
            float weight = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Data recieved.");
            Console.WriteLine("Search of criminals: " + fname + " " + lname + ", age: " + age + "y.o., height: " + height + "cm, weight: " + weight + "kg");
            Console.WriteLine("Detect by parameters: age: {0}y.o., height: {1}cm, weight: {2:F}kg", age, height, weight);
            Console.WriteLine("Processing in progress...");
            Console.WriteLine();
            Console.WriteLine($"Found a violent psychopathic killer named {fname}, estimated weight {weight:F2}kg.");
            #endregion

            #region Task2
            //2.    Ввести вес и рост человека. Рассчитать и вывести индекс массы тела(ИМТ) по формуле I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах
            double violence = weight / Math.Pow(Convert.ToSingle(height),2);
            int reward = Convert.ToInt32(standartReward * violence);
            Console.WriteLine($"Violence index = {violence:F4}. Reward {reward:C}.");
            Console.Write("Get the assignment? (Y / N)");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Great!");
            Console.WriteLine($"You have to eliminate {fname} {lname}.");
            Console.WriteLine();
            #endregion

            #region Task3
            //3.  а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            //      Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            //    б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
            Console.WriteLine("Input your coordinates.");
            Console.Write("Latitude: ");
            float latitude = Convert.ToSingle(Console.ReadLine());
            Console.Write("Longitude: ");
            float longitude = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Determine the location of the killer...");
            float clatitude = 12.4f;
            float clongitude = 3.84f;
            float distance = Convert.ToSingle(GetDistance(latitude, longitude, clatitude, clongitude));
            Console.WriteLine();
            Console.WriteLine($"Killer {fname} next to you, {distance:F2} meters away.");
            Console.WriteLine("Be careful and good luck!");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Task4
            //4.Написать программу обмена значениями двух переменных.
            //    а) с использованием третьей переменной;
            //    б) *без использования третьей переменной.
            int a = 1;
            int b = 2;
            int c = a;
            a = b;
            b = c;
            #endregion

            #region Task5
            //5.
            //    а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //    б) Сделать задание, только вывод организуйте в центре экрана
            //    в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
            Console.SetWindowSize(100, 40);
            CustomMethods.CustomPrint("Chapter 1");
            CustomMethods.Pause();
            Console.Clear();
            Console.SetWindowSize(100, 40);
            CustomMethods.CustomPrint("New York, 1937", Console.WindowWidth - 25, Console.WindowHeight - 3);
            CustomMethods.Pause();
            Console.Clear();
            Console.SetWindowSize(100, 40);
            CustomMethods.CustomPrint("Peaky Blinders quarter", Console.WindowWidth - 25, Console.WindowHeight - 3);
            CustomMethods.Pause();
            Console.Clear();
            #endregion
        }

        // additional method 
        static double GetDistance(float latitude, float longitude, float clatitude, float clongitude)
        {
            double distance = Math.Sqrt(Math.Pow(clongitude - clatitude, 2) + Math.Pow(longitude - latitude, 2));
            return distance;
        }
    }

    public class CustomMethods
    {
        public static void CustomPrint(string message)
        {
            int x = (Console.WindowWidth / 2) - (message.Length / 2);
            int y = (Console.WindowHeight / 2);
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }
        public static void CustomPrint(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }
        public static void Pause()
        {
            Console.ReadKey();
        }
    }
}
