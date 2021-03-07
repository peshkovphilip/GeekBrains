using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class CustomArray
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

        public CustomArray(int[] arr)
        {
            this.arr = arr;
        }
        public CustomArray(int[] arr, int startValue, int step)
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
}
