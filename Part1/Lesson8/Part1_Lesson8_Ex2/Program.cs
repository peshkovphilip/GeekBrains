using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Part1_Lesson8_Ex2
{
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

        public Student()
        {

        }
    }

    // 3. * Написать программу-преобразователь из CSV в XML-файл с информацией о студентах(6 урок).
    class Program
    {
        public static string fileCSV = "students.csv";
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            if (File.Exists(fileCSV))
            {
                using (StreamReader sr = new StreamReader(fileCSV))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] s = sr.ReadLine().Split(';');
                            list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Error !ESC - end of program");
                            if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                        }
                    }
                    sr.Close();
                    if (list.Count > 0)
                    {
                        if (SaveListToXML("students.xml", list))
                            Console.WriteLine($"File {fileCSV} converted to XML success");
                        else
                            Console.WriteLine($"File {fileCSV} not converted to XML");
                    }
                        
                }
            }
            else
            {
                Console.WriteLine($"File {fileCSV} not found");
            }
            Console.ReadKey();
               
        }

        public static bool SaveListToXML(string fileName, List<Student> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            try
            {
                var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlSerializer.Serialize(fileStream, list);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
