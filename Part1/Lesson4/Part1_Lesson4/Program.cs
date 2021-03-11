using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyLib;

namespace Part1_Lesson4
{
    class MyArray
    {
        private int[] arr;
        public int[] Arr
        {
            get
            {
                return arr;
            }
        }
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }
        public int MaxCount
        {
            get
            {
                int maxCount = 1;
                int maxValue = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i > 0)
                    {
                        if (arr[i] == maxValue)
                            maxCount++;
                        else if (arr[i] > maxValue)
                        {
                            maxCount = 1;
                            maxValue = arr[i];
                        }   
                    }
                }
                return maxCount;
            }
        }

        public MyArray(int[] arr)
        {
            this.arr = arr;
        }
        public MyArray(int[] arr, int startValue, int step)
        {
            this.arr = new int[arr.Length];
            int curValue = startValue;
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = curValue;
                curValue += step;
            }
        }

        public void CreateRandom(int maxE)
        {
            arr = new int[maxE];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int rndInt = rnd.Next(10001);
                int sign = rnd.Next(2);
                if (sign == 1)
                    rndInt = -rndInt;
                arr[i] = rndInt;
            }
        }

        public void CreateFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string str = reader.ReadLine();
                int.TryParse(str, out int len);
                arr = new int[len];
                for (int i = 0; i < len; i++)
                {
                    int.TryParse(reader.ReadLine(), out int num);
                    arr[i] = num;
                }
                reader.Close();
            }
            else
                throw new FileNotFoundException();
        }

        public int Division()
        {
            int pair = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                {
                    if (((arr[i - 1] % 3 == 0) && (arr[i] % 3 != 0)) || ((arr[i - 1] % 3 != 0) && (arr[i] % 3 == 0)))
                        pair++;
                }
            }
            return pair;
        }

        public void Inverse(out int[] inverse)
        {
            inverse = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                inverse[i] = -arr[i];
            }
        }

        public void Multi(float multi)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(arr[i] * multi);
            }
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1)
                    text += $"{arr[i]}, ";
                else
                    text += arr[i];
            }
            return text;
        }
    }

    struct Account
    {
        public string login, pass;

        public Account(string fileName)
        {
            login = "admin";
            pass = "admin";

            if (File.Exists(fileName))
            {
                Console.WriteLine("ok");
                StreamReader reader = new StreamReader(fileName);
                login = reader.ReadLine();
                pass = reader.ReadLine();
                reader.Close();
            }
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
                case 4:
                    SubProgram4();
                    return;
                case 5:
                    SubProgram5();
                    return;
                default:
                    return;
            }
        }

        //1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 
        //включительно.Заполнить случайными числами.Написать программу, позволяющую найти и вывести количество пар элементов массива, 
        //в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
        //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
        static void SubProgram1()
        {
            //int[] array1 = { 14, -2, -3, 2548, 999, -5436, 9281, -3267, -144, -632, -808, 4156, 505, 44, 79, -87, -5, 909, 215, -3463 };
            //MyArray newarr = new MyArray(array1);
            //Console.WriteLine("Current array:");
            //Console.WriteLine(newarr);
            //Console.WriteLine($"Pairs found: {newarr.Division()}");

            int[] arr = new int[20];
            int pair = 0;
            string text = "";
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int rndInt = rnd.Next(10001);
                int sign = rnd.Next(2);
                if (sign == 1)
                    rndInt = -rndInt;
                arr[i] = rndInt;
                if (i > 0)
                {
                    if (((arr[i - 1] % 3 == 0) && (arr[i] % 3 != 0)) || ((arr[i - 1] % 3 != 0) && (arr[i] % 3 == 0)))
                        pair++;
                }
                if (i < arr.Length)
                    text += $"{arr[i]}, ";
                else
                    text += arr[i];
            }
            Console.WriteLine("Current array:");
            Console.WriteLine(text);
            Console.WriteLine($"Pairs found: {pair}");
            Console.ReadKey();
        }

        //2. Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
        //в) Добавьте обработку ситуации отсутствия файла на диске.
        static void SubProgram2()
        {
            int[] arr = { };
            MyArray newDiv = new MyArray(arr);
            newDiv.CreateRandom(20);
            Console.WriteLine("Current array:");
            Console.WriteLine(newDiv);
            Console.WriteLine($"Pairs found: {newDiv.Division()}");
            Console.WriteLine("");

            
            MyArray newDiv2 = new MyArray(arr);
            string path = AppDomain.CurrentDomain.BaseDirectory + "NewArray.txt";
            Console.WriteLine($"Find from file: {path}");
            try
            {
                newDiv2.CreateFromFile(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            Console.WriteLine("Current array:");
            Console.WriteLine(newDiv2);

            Console.ReadKey();
        }

        //3. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив 
        // определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
        // Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив
        // с измененными знаками у всех элементов массива(старый массив, остается без изменений), метод Multi, 
        // умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество 
        // максимальных элементов.
        
        
        static void SubProgram3()
        {
            int[] arr = new int[10];
            //int[] arr2 = { };
            MyArray newDiv = new MyArray(arr, 100, 20);
            Console.WriteLine("Current array:");
            Console.WriteLine(newDiv);
            Console.WriteLine($"Array sum is {newDiv.Sum}");
            newDiv.Inverse(out int[] inverse);
            MyArray newDivInverse = new MyArray(inverse);
            Console.WriteLine("New array:");
            Console.WriteLine(newDivInverse);
            float multiBy = -0.1f;
            Console.WriteLine($"Multiply this array by {multiBy}:");
            newDivInverse.Multi(multiBy);
            Console.WriteLine(newDivInverse);

            int[] arr2 = { 1, 4, 64, 40, 55, 71, 31, 71, 9, 14, 71 };
            MyArray newDiv2 = new MyArray(arr2);
            Console.WriteLine($"MaxCount = {newDiv2.MaxCount} from array:");
            Console.WriteLine(newDiv2);
            Console.WriteLine("");

            // б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
            int[] arr3 = {};
            CustomArray newDiv3 = new CustomArray(arr3);
            newDiv3.CreateRandom(10);
            Console.WriteLine("New array from MyLib library:");
            Console.WriteLine(newDiv3);
            Console.WriteLine("");

            // в) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
            int[] arr4 = { 34, 65, 573, 345, 34, 345, 345 };
            CustomArray newDiv4 = new CustomArray(arr4);
            Console.WriteLine("Next array from MyLib library:");
            Console.WriteLine(newDiv4);
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for (int i = 0; i < newDiv4.Arr.Length; i++)
            {
                try
                {
                    frequency.Add(newDiv4.Arr[i], 1);
                }
                catch (ArgumentException)
                {
                    frequency[newDiv4.Arr[i]]++;
                }
            }
            Console.WriteLine("Frequency of occurrence by values:");
            foreach (KeyValuePair<int, int> freq in frequency)
            {
                Console.WriteLine($"value {freq.Key}, frequency = {freq.Value}");
            }

            Console.ReadKey();
        }

        static void SubProgram4()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Auth.txt";
            Account auth = new Account(fileName);

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
                if ((login == auth.login) && (pass == auth.pass))
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

        // 5. *а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, 
        //заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех элементов массива, 
        //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
        //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива 
        //(через параметры, используя модификатор ref или out).
        // **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        // ** в) Обработать возможные исключительные ситуации при работе с файлами.
        static void SubProgram5()
        {
            int[,] arr = new int[10, 5];
            Array2D array2D = new Array2D(arr);
            Console.WriteLine("New array2D from MyLib library:");
            Console.WriteLine(array2D);
            Console.WriteLine($"Sum of all values = {array2D.Sum()}");
            Console.WriteLine($"Sum of all values above 50 = {array2D.Sum(50)}");
            Console.WriteLine($"Min value = {array2D.Min}");
            Console.WriteLine($"Max value = {array2D.Max}");
            array2D.maxCount(out int x, out int y);
            Console.WriteLine($"Max value has a position (x, y) = {x}, {y}");
            Console.WriteLine("Try to add new line from file to array");
            string path = AppDomain.CurrentDomain.BaseDirectory + "NewArray.txt";
            try
            {
                array2D.AddLineFromFile(path);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch(Exception)
            {
                Console.WriteLine("Data incorrect!");
            }
            Console.WriteLine("current array2D:");
            Console.WriteLine(array2D);
            string path2D = AppDomain.CurrentDomain.BaseDirectory + "Array2D.txt";
            array2D.SaveArrayToFile(path2D);
            if (File.Exists(path2D))
                Console.WriteLine("Array2D has been successfully saved");
            else
                Console.WriteLine("Disk is write protect");
            Console.ReadKey();
        }

        //очень длинная домашка
    }
}
