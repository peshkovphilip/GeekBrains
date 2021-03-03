using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_Lesson3
{
    class Fraction
    {
        private double dividend;
        private double divider;

        public double Dividend
        {
            get
            {
                return dividend;
            }
            set
            {
                dividend = value;
            }
        }

        public double Divider
        {
            get
            {
                return divider;
            }
            set
            {
                if (divider != 0)
                    divider = value;
                else
                    divider = 1;
            }
        }

        public Fraction(double dividend, double divider)
        {
            this.dividend = dividend;
            if (divider != 0)
                this.divider = divider;
            else
            {
                Console.WriteLine($"Divider could not = 0. Automaticaly set divider in Fraction {ToString()} to 1");
                this.divider = 1;
            }
        }

        public double Result()
        {
            return Convert.ToSingle(dividend / divider);
        }
        public double Plus(Fraction x)
        {
            return Result() + x.Result();
        }
        public double Minus(Fraction x)
        {
            return Result() - x.Result();
        }
        public double Multi(Fraction x)
        {
            return Result() * x.Result();
        }
        public double Fract(Fraction x)
        {
            return Result() / x.Result();
        }
        public Fraction Simplification()
        {
            Fraction simple = new Fraction(dividend, divider);
            int min;
            if (dividend > divider)
                min = Convert.ToInt32(divider);
            else
                min = Convert.ToInt32(dividend);
            for (int counter = min; counter > 1; counter--)
            {
                if (min % counter == 0)
                {
                    simple.dividend = dividend / counter;
                    simple.divider = divider / counter;
                    break;
                }
            }
            return simple;
        }

        public override string ToString()
        {
            return $"{dividend} / {divider}";
        }

    }
    struct Complex
    {
        public double real;
        public double imagine;

        public Complex Plus(Complex x)
        {
            Complex y;
            y.real = real + x.real;
            y.imagine = imagine + x.imagine;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.real = real - x.real;
            y.imagine = imagine - x.imagine;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y;
            y.real = real * x.real;
            y.imagine = imagine * x.imagine;
            return y;
        }

        public override string ToString()
        {
            if (imagine >=0)
                return string.Format("{0} + {1}i", real, imagine);
            else
                return string.Format("{0} - {1}i", real, imagine);
        }

    }

    class Program
    {
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
            Console.WriteLine("Please select a subprogram (1-3), anything else - exit");
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
                default:
                    return;
            }
        }

        //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;
        //б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;
        static void SubProgram1()
        {
            Complex complex1;
            complex1.real = 10;
            complex1.imagine = 5;
            Complex complex2;
            complex2.real = -10;
            complex2.imagine = 0;

            Console.WriteLine($"{complex1} - {complex2} = {complex1.Minus(complex2)}");
            Console.WriteLine($"{complex1} * {complex2} = {complex1.Multi(complex2)}");
            Console.ReadKey();
        }

        //2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел.Сами числа и сумму вывести на экран, используя tryParse;
        //б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
        static void SubProgram2()
        {
            int y = 0;
            int amount = 0;
            List<int> even = new List<int>();
            Console.WriteLine("Enter a number, 0 - end of program");
            do
            {
                bool isTry = false;
                string curType = Console.ReadLine();
                isTry = int.TryParse(curType, out y);
                if (isTry)
                {
                    if ((y > 0) && (y % 2 == 0))
                    {
                        amount += y;
                        even.Add(y);
                    }    
                }
                else
                {
                    Console.WriteLine($"Please type a real number, {curType} - not a number.");
                    y = -1;
                }
            }
            while (y != 0);
            Console.WriteLine("All even numbers above zero are:");
            for(int cur = 0; cur < even.Count; cur++)
            {
                if (cur < even.Count - 1)
                    Console.Write($"{even[cur]}, ");
                else
                    Console.WriteLine(even[cur]);
            }
            Console.WriteLine($"Amount of all even numbers above zero is {amount}");
            Console.ReadKey();
        }

        //3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
        //Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, 
        //демонстрирующую все разработанные элементы класса.
        //Достаточно решить 2 задачи.Все программы сделать в одном решении.
        //** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
        //ArgumentException("Знаменатель не может быть равен 0");
        //Добавить упрощение дробей.
        static void SubProgram3()
        {
            Fraction fraction1 = new Fraction(10,2);
            Fraction fraction2 = new Fraction(6, 0);

            Console.WriteLine($"({fraction1}) + ({fraction2}) = {fraction1.Plus(fraction2)}");
            Console.WriteLine($"({fraction1}) - ({fraction2}) = {fraction1.Minus(fraction2)}");
            Console.WriteLine($"({fraction1}) * ({fraction2}) = {fraction1.Multi(fraction2)}");
            Console.WriteLine($"({fraction1}) / ({fraction2}) = {fraction1.Fract(fraction2)}");

            Console.WriteLine($"Simplification {fraction1} is {fraction1.Simplification()}");
            Console.WriteLine($"Simplification {fraction2} is {fraction2.Simplification()}");
            Console.ReadKey();
        }
    }
}
