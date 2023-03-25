using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int maxLen = 1 + Math.Max(firstNumberTextBox.Text.Length, secondNumberTextBox.Text.Length);
            int[] number1 = new int[maxLen];
            int[] number2 = new int[maxLen];
            int[] sum = new int[maxLen];
            int[] extra = new int[maxLen];
            int numberIdx, textIdx;
            numberIdx = maxLen - 1;
            textIdx = firstNumberTextBox.Text.Length - 1;
            while (textIdx >= 0)
            {
                number1[numberIdx] = (firstNumberTextBox.Text[textIdx] - '0');
                textIdx--;
                numberIdx--;
            }
            numberIdx = maxLen - 1;
            textIdx = secondNumberTextBox.Text.Length - 1;
            while (textIdx >= 0)
            {
                number2[numberIdx] = (secondNumberTextBox.Text[textIdx] - '0');
                textIdx--;
                numberIdx--;
            }
            for (numberIdx = maxLen - 1; numberIdx > 0; numberIdx--)
            {
                sum[numberIdx] = (number1[numberIdx] + number2[numberIdx] + extra[numberIdx]) % 10;
                extra[numberIdx - 1] = (number1[numberIdx] + number2[numberIdx] + extra[numberIdx]) % 10;
                sum[0] = extra[0];
                bool isNumber = false;
                foreach (int digit in sum)
                {
                    if (digit > 0)
                    {
                        isNumber = true;
                        sumNumberTextBox.Text += digit;
                    }
                    else
                    {
                        if (isNumber)
                            sumNumberTextBox.Text += digit;
                    }
                }
            }
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.TextBox textbox in Controls.OfType<System.Windows.Forms.TextBox>())
                textbox.Text = "";
        }

        private void firstNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
