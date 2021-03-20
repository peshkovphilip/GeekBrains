using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Part1_Lesson8
{
    public class TrueFalse
    {
        
        #region Private Fields

        private string fileName;
        private List<Question> list;

        #endregion

        #region Public Properties

        public string FileName
        {
            set { fileName = value; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public List<Question> List
        {
            get { return list; }
        }

        #endregion

        #region Constructors

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public TrueFalse()
        {
            list = new List<Question>();
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }

        public void Edit(int index, Question question)
        {
            if (list != null && index < list.Count && index >= 0)
                list[index] = question;
        }

        public bool Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                List<Question> list2 = new List<Question>();
                try
                {
                    list = (List<Question>)xmlSerializer.Deserialize(fileStream);
                }
                catch(Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }

        #endregion

    }
}
