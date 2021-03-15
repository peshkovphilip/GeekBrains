using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// 2. Используя Windows Forms, разработать игру «Угадай число». 
// Компьютер загадывает число от 1 до 100, а человек пытается его угадать 
// за минимальное число попыток. Для ввода данных от человека используется 
// элемент TextBox.
namespace Part1_Lesson7_Ex2
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int gNumber;
        private int tries;
        private string flashText;

        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        void NewGame()
        {
            txtInput.Enabled = true;
            btnOk.Enabled = true;
            txtInput.Text = "";
            gNumber = rnd.Next(1, 101);
            tries = 0;
            lblInfo.Text = "The number is conceived";
            lblTitle.Text = "Guess the number from 1 to 100";
        }

        void Win()
        {
            txtInput.Enabled = false;
            btnOk.Enabled = false;
            lblTitle.Text = "You win!";
            lblInfo.Text = $"You guessed the number in {tries} tries";
        }

        void NextTry()
        {
            int.TryParse(txtInput.Text, out int inNumber);
            txtInput.Text = "";
            if (inNumber > gNumber)
                lblInfo.Text = "Try to reduce";
            else
                lblInfo.Text = "Try to increase";
        }

        void Check()
        {
            tries++;
            if (txtInput.Text == gNumber.ToString())
                Win();
            else
                NextTry();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Check();
        }

        // пасхалочка :)
        private void lblInfo_MouseEnter(object sender, EventArgs e)
        {
            flashText = Text;
            Text = $"Cheat: guess number is {gNumber}";
        }

        private void lblInfo_MouseLeave(object sender, EventArgs e)
        {
            Text = flashText;
        }
    }
}
