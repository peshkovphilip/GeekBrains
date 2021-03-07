using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Array2D
    {
        public int[,] arr;

        public int Min
        {
            get
            {
                int min = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] < min)
                            min = arr[i, j];
                    }
                }
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > max)
                            max = arr[i, j];
                    }
                }
                return max;
            }
        }

        public Array2D(int[,] inArr)
        {
            arr = new int[inArr.GetLength(0), inArr.GetLength(1)];
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(10, 100);
                }
            }
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
            }
            return sum;
        }

        public int Sum(int minValue)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] >= minValue)
                        sum += arr[i, j];
                }
            }
            return sum;
        }

        public void maxCount(out int x, out int y)
        {
            x = 0;
            y = 0;
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        y = i + 1;
                        x = j + 1;
                    }
                }
            }
        }

        public void AddLineFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string str = reader.ReadLine();
                int.TryParse(str, out int len);

                if (arr.GetLength(1) == len)
                {
                    int[,] arrNew = new int[arr.GetLength(0) + 1, len];
                    for (int i = 0; i <= arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (i < arr.GetLength(0))
                                arrNew[i, j] = arr[i, j];
                            else
                            {
                                int.TryParse(reader.ReadLine(), out int num);
                                arrNew[i, j] = num;
                            }
                        }
                    }
                    arr = arrNew;
                }
                else
                    throw new Exception();
                reader.Close();
            }
            else
                throw new FileNotFoundException();
        }

        public void SaveArrayToFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string text = "";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j < arr.GetLength(1) - 1)
                        text += $"{arr[i, j]}, ";
                    else
                        text += arr[i, j];
                }
                writer.WriteLine(text);
            }
            writer.Close();
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j < arr.GetLength(1) - 1)
                        text += $"{arr[i, j]}, ";
                    else
                        text += arr[i, j];
                }
                text += "\r\n";
            }
            return text;
        }
    }
}
