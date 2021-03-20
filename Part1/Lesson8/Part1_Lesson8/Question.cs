using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_Lesson8
{
    public class Question
    {
        public string Text { get; set; }

        public bool IsTrue { get; set; }

        public Question(string text, bool istrue)
        {
            Text = text;
            IsTrue = istrue;
        }

        public Question() { }

    }
}
