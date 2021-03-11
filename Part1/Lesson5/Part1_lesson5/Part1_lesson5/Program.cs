using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_lesson5
{
    class Message
    {
        public string text { get; set; }

        public Message()
        {
            text = "";
        }
        public Message(string fileName)
        {
            string str = "";
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                str = reader.ReadToEnd();
                reader.Close();
            }
            else
                throw new FileNotFoundException();

            text = str;
        }

        public List<string> WordsWithMinLetters(int nLetters)
        {
            Match[] matches = Regex.Matches(text, @"\b([A-Za-z]{1,"+nLetters+@"})\b").Cast<Match>().ToArray();
            List<string> words = new List<string>();
            foreach(Match match in matches)
            {
                words.Add(match.Value);
            }
            return words;
        }

        public string TextWithoutWordsEndInLetter(char letter)
        {
            // если мы хотим разобрать по словам и убрать слова заканчивающиеся на букву
            //Match[] matches = Regex.Matches(text, @"\b\w+(?<!" + letter + ")\b").Cast<Match>().ToArray(); 

            // если же мы хотим убрать только слова заканчивающиеся на букву, не вижу практического смысла, так как знаки припинания и пробелы остануться между/до/после убранных слов, но все же:
            Match[] matches = Regex.Matches(text, @"([\W]?)+\b\w*(?<!" + letter + @")\b([\W]?)").Cast<Match>().ToArray();
            string mess = "";
            foreach (Match match in matches)
            {
                mess += match.Value;
            }
            return mess;
        }

        public string GetLongestWord()
        {
            Match[] matches = Regex.Matches(text, @"\b\w*\b").Cast<Match>().ToArray();
            string longestword = "";
            foreach (Match match in matches)
            {
                if (match.Value.Length > longestword.Length)
                    longestword = match.Value;
            }
            return longestword;
        }

        public string ConcatWithLongestWords(int countLongest)
        {
            Match[] matches = Regex.Matches(text, @"\b\w*\b").Cast<Match>().ToArray();
            StringBuilder linefromlongestwords = new StringBuilder();
            linefromlongestwords.Clear();
            string[] words = new string[countLongest];
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = "";
            }
            foreach (Match match in matches)
            {
                if (match.Value.Length >= words[0].Length)
                    words[0] = match.Value;
                Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                    linefromlongestwords.Append($"{words[i].Substring(0,1).ToUpper()}{words[i].Substring(1)} ");
                else if (i < (words.Length - 1))
                    linefromlongestwords.Append($"{words[i].ToLower()} ");
                else
                    linefromlongestwords.Append($"{words[i].ToLower()}.");
            }
            return linefromlongestwords.ToString();
        }
    }

    class People
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public double Average
        {
            get
            {
                return Convert.ToDouble(Convert.ToSingle(P1 + P2 + P3) / 3);
            }
        }
        public People(string lname, string fname, int p1, int p2, int p3)
        {
            FName = fname;
            LName = lname;
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
    }
    class Questions
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Questions(string question, string answer)
        {
            Question = question;
            Answer = answer;
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

        // 1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка 
        // от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        static void SubProgram1()
        {
            // а) без использования регулярных выражений;
            Console.WriteLine("Please type a correct login to enter into the system.");
            int counter = 0;
            bool doit = true;
            string login = "";
            bool isCorrect = true;
            do
            {
                Console.Write("Login: ");
                login = Console.ReadLine();
                isCorrect = true;
                if ((login.Length >= 1) && (login.Length <= 10))
                {
                    for (int i = 0; i < login.Length; i++)
                    {
                        //if ((char.GetUnicodeCategory(login[i]) == UnicodeCategory.DecimalDigitNumber) && (i == 0))
                        if ((char.IsDigit(login[i])) && (i == 0))
                        {
                            isCorrect = false;
                            break;
                        }
                        if (((!char.IsDigit(login[i])) && ((int)login[i] < 65)) || (((int)login[i] >= 91) && ((int)login[i] < 96)) || ((int)login[i] >= 123))
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                }
                else
                {
                    isCorrect = false;
                }   
                
                if (isCorrect)
                {
                    Console.WriteLine($"Welcome, {login} !");
                    doit = false;
                }
                else
                {
                    if (counter < 2)
                        Console.WriteLine("Wrong login. Please try again.");
                    counter++;
                }
            }
            while ((counter < 3) && (doit));
            if (counter >= 3)
            {
                Console.WriteLine("DDos attack detected!");
            }

            // б) *с использованием регулярных выражений.
            Console.WriteLine("Please type a correct password to continue");
            counter = 0;
            doit = true;
            string pass = "";
            do
            {
                Console.Write("Password: ");
                pass = Console.ReadLine();

                if (Regex.IsMatch(pass, @"^[A-Za-z][0-9A-Za-z]{1,9}$"))
                {
                    Console.WriteLine("Access granted!");
                    doit = false;
                }
                else
                {
                    if (counter < 2)
                        Console.WriteLine("Wrong password. Please try again.");
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

        // 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
        // Продемонстрируйте работу программы на текстовом файле с вашей программой.
        static void SubProgram2()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "SampleText.txt";
            Message mess;
            try
            {
                mess = new Message(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            catch (Exception)
            {
                Console.WriteLine("Data incorrect!");
            }
            finally
            {
                mess = new Message(path);
            }

            // а) Вывести только те слова сообщения, которые содержат не более n букв.
            int nLetters = 7;
            Console.WriteLine($"Words with less than {nLetters + 1} letters:");
            foreach(string word in mess.WordsWithMinLetters(nLetters))
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            char letter = 'm';
            Console.WriteLine($"Text without word that end in {letter} letter:");
            Console.WriteLine(mess.TextWithoutWordsEndInLetter(letter));
            Console.WriteLine();

            // в) Найти самое длинное слово сообщения.
            Console.WriteLine($"The longest word is {mess.GetLongestWord()}");
            Console.WriteLine();

            // г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            int countLongest = 5;
            Console.WriteLine($"The line from the longest {countLongest} words");
            Console.WriteLine(mess.ConcatWithLongestWords(countLongest));
            Console.WriteLine();
            Console.ReadKey();
        }

        // 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        // Регистр можно не учитывать:
        
        
        // Например:
        // badc являются перестановкой abcd.
        static void SubProgram3()
        {
            Console.WriteLine("Please type first string to compare:");
            string inputText1 = Console.ReadLine();
            Console.WriteLine("Please type a second string:");
            string inputText2 = Console.ReadLine();
            bool isSimilar = true;
            // а) с использованием методов C#;
            if (inputText1.Length == inputText2.Length)
            {
                foreach(char text in inputText1)
                {
                    for(int i = 0; i < inputText2.Length; i++)
                    {
                        if (text.CompareTo(inputText2[i]) == 0)
                        {
                            inputText2.Remove(i, 1);
                            break;
                        }
                        if (i == inputText2.Length - 1)
                            isSimilar = false;
                    }
                    if (!isSimilar) break;
                }
            }
            else
            {
                isSimilar = false;
            }
            Console.WriteLine($"Is {inputText1} similar {inputText2}? {isSimilar}!");

            // variant 2
            // б) *разработав собственный алгоритм.
            isSimilar = true;
            string inputText4 = inputText2;
            if (inputText1.Length == inputText2.Length)
            {
                foreach (char text in inputText1)
                {
                    for (int i = 0; i < inputText2.Length; i++)
                    {
                        if (text == inputText2[i])
                        {
                            string inputText3 = "";
                            for (int j = 0; j < inputText2.Length; j++)
                            {
                                if (j != i)
                                    inputText3 += inputText2[j];
                            }
                            inputText2 = inputText3;
                            //inputText2.Remove(i, 1);
                            break;
                        }
                        if (i == inputText2.Length - 1)
                            isSimilar = false;
                    }
                    if (!isSimilar) break;
                }
            }
            else
            {
                isSimilar = false;
            }
            Console.WriteLine($"Is {inputText1} similar {inputText4}? variant 2 = {isSimilar}!");

            // variant 3
            // это оптимальный вариант для решения
            char[] x1 = inputText1.ToArray();
            char[] x2 = inputText4.ToArray();
            Array.Sort(x1);
            Array.Sort(x2);
            isSimilar = x1.SequenceEqual(x2);
            Console.WriteLine($"Is {inputText1} similar {inputText4}? variant 3 = {isSimilar}!");
            Console.ReadKey();
        }

        //  4. Задача ЕГЭ.
        // *На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
        // В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
        // каждая из следующих N строк имеет следующий формат:
        // <Фамилия> <Имя> <оценки>,
        // где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, 
        // <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и<Имя>, 
        // а также <Имя> и<оценки> разделены одним пробелом.
        // Пример входной строки:
        // Иванов Петр 4 5 3
        // Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена 
        // трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, 
        // что и один из трёх худших, следует вывести и их фамилии и имена.
        static void SubProgram4()
        {
            Console.WriteLine("We recognize the worst of the students by sight");
            Console.WriteLine(@"Please type 10-100 pupil or type ""exit"" to end");
            List<People> people = new List<People>();
            do
            {
                Console.Write($"{people.Count + 1}. ");
                string inputLine = Console.ReadLine();
                if (inputLine == "exit")
                    break;
                string[] lineArr = inputLine.Split(' ');
                int[] rating = new int[3];
                if (lineArr.Length == 5)
                {
                    rating[0] = Convert.ToInt32(lineArr[2]);
                    rating[1] = Convert.ToInt32(lineArr[3]);
                    rating[2] = Convert.ToInt32(lineArr[4]);

                    if ((lineArr[0].Length <= 20) && (lineArr[0].Length >= 1) && (lineArr[1].Length <= 15) && (lineArr[1].Length >= 1) && (rating[0] >= 2) && (rating[0] <= 5) && (rating[1] >= 2) && (rating[1] <= 5) && (rating[2] >= 2) && (rating[2] <= 5))
                        people.Add(new People(lineArr[0], lineArr[1], rating[0], rating[1], rating[2]));
                    else
                        Console.WriteLine(@"Incorrect format data. 
LastName[mx 20 letters] FirstName[max 15 letters] [2-5] [2-5] [2-5]
or type ""exit"" to end");
                }
                else
                {
                    Console.WriteLine(@"Incorrect format data. 
LastName[mx 20 letters] FirstName[max 15 letters] [2-5] [2-5] [2-5]
or type ""exit"" to end");
                }
            }
            while (people.Count <= 100);
            
            if (people.Count >= 10)
            {
                Console.WriteLine("The worst pupils are:");
                List<People> pupil = people.OrderBy(x => x.Average).ToList();
                int maxPupil = 3;
                for (int i = 0; i < maxPupil; i++)
                {
                    Console.WriteLine("{0}. {1} {2} with average rating = {3:F2}", i + 1, pupil[i].LName, pupil[i].FName, pupil[i].Average);
                    if (i == (maxPupil - 1))
                    {
                        if (pupil.Count > maxPupil)
                        {
                            if (pupil[maxPupil].Average == pupil[i].Average)
                                maxPupil++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You entered data for less than 10 students.");
                Console.WriteLine("Please try again.");
            }
            Console.ReadKey();
        }

        // 5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. Например: 
        // «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти данные, случайным образом выбирает 
        // 5 вопросов и задаёт их игроку. Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
        // Список вопросов ищите во вложении или воспользуйтесь интернетом.
        static void SubProgram5()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Questions.txt";
            List<Questions> questions = new List<Questions>();
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineArr = line.Split('?');
                    questions.Add(new Questions(lineArr[0]+"?", lineArr[1]));
                }
                reader.Close();
            }
            else
                throw new FileNotFoundException();

            Console.WriteLine("Welcome to the Game TRUE or FALSE");

            if (questions.Count > 0)
            {
                int rating = 0;
                Console.WriteLine("Please answer on 5 question and take your rating (Y - Yes, N - No)");
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    int nextQ = rnd.Next(questions.Count);
                    Console.Write($"{i+1}. {questions[nextQ].Question} ");
                    char answer = Console.ReadKey().KeyChar;
                    char realAnswer = questions[nextQ].Answer.ToLower()[1];
                    questions.RemoveAt(nextQ);
                    if (answer == realAnswer)
                        rating++;
                    Console.WriteLine("");
                }
                Console.WriteLine($"Your rating is {rating} / 5");
                if (rating == 5)
                    Console.WriteLine("Congratulations! You are unique person.");
            }
            else
            {
                Console.WriteLine("No found any questions.");
            }
            Console.ReadKey();
        }
    }
}
