using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part1_Lesson8
{
    // 1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок 
    // (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    // б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» 
    // улучшения на свое усмотрение.
    public partial class formEditor : Form
    {
        private TrueFalse database = new TrueFalse();
        //private List<Question> qList = new List<Question>();

        public formEditor()
        {
            InitializeComponent();
            ClearFileds();
            ItemSave.Enabled = false;
            ItemSaveAs.Enabled = false;
        }

        private void UpdateList()
        {
            quizList.Items.Clear();
            foreach(Question item in database.List)
            {
                quizList.Items.Add(item.Text, item.IsTrue);
            }
            if (database.Count > 0)
                ItemSaveAs.Enabled = true;
            else
                ItemSaveAs.Enabled = false;
        }

        private void ClearFileds()
        {
            textQuestion.Text = "";
            checkQuestion.Checked = false;
            btnRemove.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void CheckSaveEnabled()
        {
            if (database.Count > 0)
                ItemSave.Enabled = true;
            else
                ItemSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((textQuestion.Text != "") && (quizList.SelectedIndex >= 0))
            {
                database.Edit(quizList.SelectedIndex, new Question(textQuestion.Text, checkQuestion.Checked));
                //database[quizList.SelectedIndex].Text = textQuestion.Text;
                //database[quizList.SelectedIndex].IsTrue = checkQuestion.Checked;
                UpdateList();
                ClearFileds();
            }
            //database.Add(textQuestion.Text, checkQuestion.Checked);
        }

        private void quizList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (database.Count > 0)
            {
                CheckState checkState = CheckState.Unchecked;
                if (database[e.Index].IsTrue)
                {
                    checkState = CheckState.Checked;
                    checkQuestion.Checked = true;
                }
                else
                {
                    checkQuestion.Checked = false;
                }
                e.NewValue = checkState;
                textQuestion.Text = quizList.Items[e.Index].ToString();
                btnRemove.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textQuestion.Text != "")
            {
                database.Add(textQuestion.Text, checkQuestion.Checked);
                UpdateList();
                ClearFileds();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (quizList.SelectedIndex >= 0)
            {
                // г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
                var messResult = MessageBox.Show("Do you really to remove it?", "Quiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messResult == DialogResult.Yes)
                {
                    database.Remove(quizList.SelectedIndex);
                    UpdateList();
                    ClearFileds();
                    CheckSaveEnabled();
                }
            }
        }

        private void textQuestion_TextChanged(object sender, EventArgs e)
        {
            if (textQuestion.Text != "")
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }
        private void ItemNew_Click(object sender, EventArgs e)
        {
            database = new TrueFalse();
            ItemSave.Enabled = false;
            ItemSaveAs.Enabled = false;
            UpdateList();
            ClearFileds();
        }

        private void ItemLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TrueFalse databaseLoad = new TrueFalse(openFileDialog.FileName);
                if (databaseLoad.Load())
                {
                    database = databaseLoad;
                    UpdateList();
                    ClearFileds();
                    CheckSaveEnabled();
                }
                else
                {
                    MessageBox.Show("Incorrect data format", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ItemSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        // д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).
        private void ItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFileDialog.FileName;
                database.Save();
                ItemSave.Enabled = true;
            }
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            Hide();
            new formMain().ShowDialog();
        }

        // в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
        private void ItemAbout_Click(object sender, EventArgs e)
        {
            new formAbout().ShowDialog();
        }

        private void formEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            new formMain().ShowDialog();
        }
    }
}
