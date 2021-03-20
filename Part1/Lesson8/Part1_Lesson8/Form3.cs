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
    // 2. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».
    public partial class formMain : Form
    {
        private TrueFalse database = new TrueFalse();
        private int qIndex = 0;
        private int correctAnswers = 0;

        public formMain()
        {
            InitializeComponent();
            //TrueFalse database = new TrueFalse();
            //database.FileName = "default.xml";
            TrueFalse databaseLoad = new TrueFalse("default.xml");
            if (databaseLoad.Load())
                database = databaseLoad;
            else
                MessageBox.Show("No default quiz found. Please load quiz from disk.", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            NewGame();
        }

        private void NewGame()
        {
            if (database.Count > 0)
            {
                qIndex = 0;
                correctAnswers = 0;
                panelVictory.Visible = false;
                panelQuestion.Visible = true;
                NextQuestion();
            }
            else
            {
                panelQuestion.Visible = false;
            }
        }

        private void NextQuestion()
        {
            richQuestion.Text = database[qIndex].Text;
            lblCounter.Text = (correctAnswers).ToString();
            lblNumber.Text = $"Question {qIndex+1}/{database.Count}";
        }

        private void EndGame()
        {
            lblPercent.Text = String.Format("{0:F0}%", Convert.ToSingle(correctAnswers) / database.Count * 100);
            panelQuestion.Visible = false;
            panelVictory.Visible = true;
        }

        private void menuEditor_Click(object sender, EventArgs e)
        {
            Hide();
            new formEditor().ShowDialog();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            new formAbout().ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TrueFalse databaseLoad = new TrueFalse(openFileDialog.FileName);
                if (databaseLoad.Load())
                    database = databaseLoad;
                else
                    MessageBox.Show("Incorrect data format", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NewGame();
        }

        private void menuNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (database[qIndex].IsTrue)
                correctAnswers++;
            qIndex++;
            if (qIndex < database.Count)
                NextQuestion();
            else
                EndGame();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (!database[qIndex].IsTrue)
                correctAnswers++;
            qIndex++;
            if (qIndex < database.Count)
                NextQuestion();
            else
                EndGame();
        }
    }
}
