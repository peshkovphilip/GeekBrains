using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
namespace Part1_Lesson7
{
    public partial class Doubler : Form
    {
        int memNumber = 0;
        Random rnd = new Random();
        int counter = 0;
        List<int> listValues = new List<int>();

        public Doubler()
        {
            InitializeComponent();
            Block(true);
            //NewGame();
        }

        void Block(bool dis)
        {
            if (dis)
            {
                label1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                label1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        void checkFinal()
        {
            counter++;
            listValues.Add(Convert.ToInt32(label1.Text));
            redoToolStripMenuItem.Enabled = true;
            if (label1.Text == memNumber.ToString())
            {
                MessageBox.Show($"You won in {counter} moves");
                label1.Text = "0";
                Block(true);
            }
        }
        
        void NewGame()
        {
            memNumber = rnd.Next(100);
            MessageBox.Show($"You should get the number {memNumber}");
            counter = 0;
            label1.Text = "0";
            listValues.Clear();
            listValues.Add(Convert.ToInt32(label1.Text));
            redoToolStripMenuItem.Enabled = false;
            Block(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            checkFinal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) * 2).ToString();
            checkFinal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
        }

        // б) Добавить меню и команду «Играть». При нажатии появляется сообщение, 
        // какое число должен получить игрок. Игрок должен постараться получить это число
        // за минимальное количество ходов.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        // в) *Добавить кнопку «Отменить», которая отменяет последние ходы.
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listValues.Count > 1)
            {
                listValues.RemoveAt(listValues.Count - 1);
                label1.Text = listValues[listValues.Count - 1].ToString();
                counter--;
            }
            if (listValues.Count == 1)
            {
                redoToolStripMenuItem.Enabled = false;
            }
        }
    }
}
