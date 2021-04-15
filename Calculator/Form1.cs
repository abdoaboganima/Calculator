using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double num1, num2, result;
        String myOperator = "";
        bool isOperationAdded = false;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (myOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    break;
            }
            
            userInput.Text = result.ToString();
            signChange.Enabled = true;
            isOperationAdded = false;
        }
      
        private void CE_Click(object sender, EventArgs e)
        {
            userInput.Text = "0";
            isOperationAdded = false;
        }

        private void DEL_Click(object sender, EventArgs e)
        {
            if (userInput.Text.Length > 0)
                userInput.Text = userInput.Text.Remove(userInput.Text.Length - 1);
            if (userInput.Text.Length == 0)
                userInput.Text = "0";
        }
        


        private void Operator_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(userInput.Text);
            Button button = (Button)sender;
            userInput.Text += button.Text;
            myOperator = button.Text;
            isOperationAdded = true;
            signChange.Enabled = false;

        }

        private void num_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isOperationAdded)
            {
                if (userInput.Text == "0")
                {
                    userInput.Text = button.Text;
                    num2 = double.Parse(button.Text);

                }
                else
                {
                    userInput.Text += button.Text;
                    num2 = double.Parse(button.Text);
                }
            }
            else
            {
                if (userInput.Text == "0")
                {
                    userInput.Text = button.Text;
                }
                else
                {
                    userInput.Text += button.Text;
                }
            }
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            userInput.Text += ".";
        }

        private void SignChange_Click(object sender, EventArgs e)
        {
            //Cange the sign of the first operand
            double num = double.Parse(userInput.Text);
            num = -num;
            userInput.Text = num.ToString();
        }

        private void C_Click(object sender, EventArgs e)
        {
            if (isOperationAdded)
            {
                string[] results = userInput.Text.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                userInput.Text = results[0] + myOperator;
            }
            else
                userInput.Text = "0";
        }


    }
}
