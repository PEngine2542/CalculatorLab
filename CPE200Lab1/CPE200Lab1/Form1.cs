using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        
        float in1 = 0,in2=0;
        string operate = "";
        bool percent = false;
        bool equal = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        void BtnClick(object sender,EventArgs e) //receive all of number from it owns button
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null) //check if the text is 0 and it's not display blank label
                {
                    lblDisplay.Text = ((Button)sender).Text;
                }
                else
                {
                    lblDisplay.Text += ((Button)sender).Text;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = string.Empty;
            lblDisplay.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length!=1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "0";
            }
        }

        private void SuppliedOperator(string operators)
        {
            operate = operators;
            in1 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            SuppliedOperator("+");
         
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            SuppliedOperator("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SuppliedOperator("*");
        }

        private void btnDot_Click(object sender, EventArgs e)//to insert dot
        {
            if (!lblDisplay.Text.Contains(".")) //if the label text did not contains a dot then insert dot
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent = true;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SuppliedOperator("/");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!equal)
            {
                in2 = float.Parse(lblDisplay.Text);
                equal = true;
            }

            switch (operate)
            {
                case "+":
                    if (percent)
                    {
                        in1 = in1 + ((in2 / 100) * in1);
                    }
                    else in1 = in1 + in2;
                    break;
                case "-":
                    if (percent)
                    {
                        in1 = in1 - ((in2 / 100) * in1);
                    }
                    else in1 = in1 - in2;
                    break;
                case "*":
                    if (percent)
                    {
                        in1 = in1 * ((in2 / 100) * in1);
                    }
                    else in1 = in1 * in2;
                    break;
                case "/":
                    if (percent)
                    {
                        in1 = in1 / ((in2 / 100) * in1);
                    }
                    else in1 = in1 / in2;
                    break;
                    
            }
            lblDisplay.Text=in1.ToString();
        
}
    }
}
