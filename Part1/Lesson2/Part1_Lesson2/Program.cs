using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Урок 2. Управляющие конструкции
namespace Part1_Lesson2
{
    class Program
    {
        public static int subprogram = 0;
        public static int amountRec = 0;
        
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
            Console.WriteLine("Please select a subprogram (1-7), 0 - exit");
            subprogram = Convert.ToInt32(Console.ReadLine());
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
                case 4:
                    SubProgram4();
                    return;
                case 5:
                    IMTAnalyze();
                    return;
                case 6:
                    SubProgram6();
                    return;
                case 7:
                    SubProgram7();
                    return;
                default:
                    return;
            }
        }

        //1.Написать метод, возвращающий минимальное из трех чисел.
        static void SubProgram1()
        {
            Console.WriteLine("Please type a 3 value:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            int z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Min value is {Min(x, y, z)}");
            Console.ReadKey();
        }

        //2. Написать метод подсчета количества цифр числа.
        static void SubProgram2()
        {
            Console.Write("Please type value: ");
            string x = Console.ReadLine();
            Console.WriteLine($"The number of digits in a value is {x.Length}");
            Console.ReadKey();
        }

        //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        static void SubProgram3()
        {
            Console.WriteLine("Please type value, 0 - show amount of all value");
            int amount = 0;
            int x = 0;
            do
            {
                x = Convert.ToInt32(Console.ReadLine());
                amount += x;
            }
            while (x != 0);
            Console.WriteLine($"Amount of all values is {amount}");
            Console.ReadKey();
        }

        //4. Реализовать метод проверки логина и пароля.На вход подается логин и пароль.На выходе истина, 
        //если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
        //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
        //программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.
        static void SubProgram4()
        {
            Console.WriteLine("Please type a login and password to enter into the system.");
            int counter = 0;
            bool doit = true;
            string login = "";
            string pass = "";
            do
            {
                Console.Write("Login: ");
                login = Console.ReadLine();
                Console.Write("Password: ");
                pass = Console.ReadLine();
                if ((login == "root") && (pass == "GeekBrains"))
                {
                    Console.WriteLine($"Welcome, {login} !");
                    doit = false;
                }
                else
                {
                    Console.WriteLine("Wrong login or password. Please try again.");
                    counter++;
                }
            }
            while ((counter < 3) && (doit));
            if (counter >= 3)
            {
                Console.WriteLine("DDos attack detected!");
            }
            Console.ReadKey();
        }

        //5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
        //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        static void IMTAnalyze()
        {
            float height = 0;
            do
            {
                Console.Write("Please type your height in meters: ");
                height = Convert.ToSingle(Console.ReadLine());
            }
            while (height > 3f);

            Console.Write("Please type your weight in kg: ");
            float weight = Convert.ToSingle(Console.ReadLine());
            float imt = weight / (height * height);

            //ИМТ < 18.5:	Ниже нормального веса
            //ИМТ >= 18.5 И < 25:	Нормальный вес
            //ИМТ >= 25 И < 30:	Избыточный вес
            //ИМТ >= 30 И < 35:	Ожирение I степени
            //ИМТ >= 35 И < 40:	Ожирение II степени
            //ИМТ >= 40:	Ожирение III степени

            float normalMinIMT = 18.5f;
            float normalMaxIMT = 25f;
            float normalMinWeight = (height * height) * normalMinIMT;
            float normalMaxWeight = (height * height) * normalMaxIMT;

            if (imt < normalMinIMT)
                Console.WriteLine($"Your weight is under normal. Gain {(normalMinWeight - weight):f2}kg");
            else if ((imt >= normalMinIMT) && (imt < normalMaxIMT))
                Console.WriteLine("Your weight is normal. Very well!");
            else if ((imt >= normalMaxIMT) && (imt < 30))
                Console.WriteLine($"Your weight is above normal. Lose {(weight - normalMaxWeight):f2}kg");
            else if ((imt >= 30f) && (imt < 35))
                Console.WriteLine($"You are obese 1 degree. Urgent lose {(weight - normalMaxWeight):f2}kg");
            else if ((imt >= 35f) && (imt < 40))
                Console.WriteLine($"You are obese 2 degree. Very urgent lose {(weight - normalMaxWeight):f2}kg");
            else
                Console.WriteLine($"You are obese 2 degree. Immediately lose {(weight - normalMaxWeight):f2}kg");
            Console.ReadKey();
        }

        //6. *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
        //Хорошим называется число, которое делится на сумму своих цифр. Реализовать подсчет времени выполнения программы, используя структуру DateTime.
        static void SubProgram6()
        {
            Console.WriteLine("Please wait while program in proccess...");
            int counter = 0;
            float startTime = DateTime.Now.Millisecond;
            for (int i = 1; i <= 1000000; i++) // 1 billion is too much, set 1 million
            {
                string iStr = i.ToString();
                int amount = 0;
                for (int j = 0; j < iStr.Length; j++)
                {
                    amount += Convert.ToInt32(iStr.Substring(j, 1));
                }
                if ((i % amount) == 0)
                    counter++;
            }
            float finishTime = DateTime.Now.Millisecond;
            Console.WriteLine($"The program ran in {((finishTime - startTime)/1000):f2}sec");
            Console.WriteLine($"Count of all good numbers is {counter}");
            Console.ReadKey();
        }

        //7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
        //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        //Достаточно решить 4 задачи.Разбивайте программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все программы делайте в одном решении.
        static void SubProgram7()
        {
            Console.Write("Please type the first value: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = 0;
            do
            {
                Console.Write("Please type the second value is greater than the first: ");
                b = Convert.ToInt32(Console.ReadLine());
            }
            while (a >= b);
            amountRec = 0;
            Rec(a, b);
            Console.Write($"Amount of all values between {a} and {b} is {amountRec}");
            Console.ReadKey();
        }

        static void Rec(int a, int b)
        {
            if (a < b)
            {
                Console.WriteLine(a);
                amountRec += a;
                Rec(a+1, b);
            }
        }

        static int Min(int x, int y, int z)
        {
            if ((x <= y) && (x <= z))
                return x;
            else if ((y <= x) && (y <= z))
                return y;
            else 
                return z;
        }
    }
}
