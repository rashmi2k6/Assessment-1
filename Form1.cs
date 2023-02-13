using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Week3_Projectcharlie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        bool buttonwasclicked = false;
        

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            char let;
            string email = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            string NZ_Mobile = (@"^[0-9]{10}$");
            if (textBox1.Text == "")
            {
                MessageBox.Show("*First Name can't be empty*");
                textBox1.BackColor = Color.OrangeRed;
                textBox1.Focus();

            }
            else if (int.TryParse(textBox1.Text, out num) == true)
            {
                MessageBox.Show("*First Name can't contain numbers/symbols*");
                textBox1.BackColor = Color.OrangeRed;
                textBox1.Focus();

            }
            else if (char.TryParse(textBox1.Text, out let) == true)
            {
                MessageBox.Show("*First Name can't contain numbers/symbols*");
                textBox1.BackColor = Color.OrangeRed;
                textBox1.Focus();

            }
            else if (textBox5.Text == "")
            {
                textBox1.BackColor = Color.White;
                MessageBox.Show("*Last Name needs to be filled*");
                textBox5.BackColor = Color.OrangeRed;
                textBox5.Focus();
            }
            else if (int.TryParse(textBox5.Text, out num) == true)
            {
                textBox1.BackColor = Color.White;
                MessageBox.Show("*Last Name can't contain numbers/symbols*");
                textBox5.BackColor = Color.OrangeRed;
                textBox5.Focus();

            }
            else if (char.TryParse(textBox5.Text, out let) == true)
            {
                textBox1.BackColor = Color.White;
                MessageBox.Show("*Last Name can't contain numbers/symbols*");
                textBox5.BackColor = Color.OrangeRed;
                textBox5.Focus();

            }
            else if (textBox4.Text == "")
            {
                textBox5.BackColor = Color.White;
                MessageBox.Show("*Mobile number required*");
                textBox4.BackColor = Color.OrangeRed;
                textBox4.Focus();
            }
            else if (int.TryParse(textBox4.Text, out num) == false)
            {
                textBox5.BackColor = Color.White;
                MessageBox.Show("*Please enter a valid Mobile number starting with 0, 1 or 2*");
                textBox4.BackColor = Color.OrangeRed;
                textBox4.Focus();
            }
            else if (char.TryParse(textBox4.Text, out let) == true)
            {
                textBox5.BackColor = Color.White;
                MessageBox.Show("*Mobile number can't contain letters/symbols*");
                textBox4.BackColor = Color.OrangeRed;
                textBox4.Focus();

            }
            else if (Regex.IsMatch(textBox4.Text, NZ_Mobile) == false)
            {
                textBox5.BackColor = Color.White;
                MessageBox.Show("*Please enter a valid Mobile number of ten digits*");
                textBox4.BackColor = Color.OrangeRed;
                textBox4.Focus();

            }
            else if (textBox3.Text == "")
            {

                textBox4.BackColor = Color.White;
                MessageBox.Show("*Email Address required*");
                textBox3.BackColor = Color.OrangeRed;
                textBox3.Focus();
            }
            else if (Regex.IsMatch(textBox3.Text, email) == false)
            {
                textBox4.BackColor = Color.White;
                MessageBox.Show("*Please enter a vaild email address*");
                textBox3.BackColor = Color.OrangeRed;
                textBox3.Focus();
            }
            else if (dateTimePicker1.Value < DateTime.Today)
            {
                textBox3.BackColor = Color.White;
                MessageBox.Show("*Please select a vaild date*");

            }

            else if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("*Please enter the Meeting time:*");
                numericUpDown1.BackColor = Color.OrangeRed;
                numericUpDown2.BackColor = Color.OrangeRed;
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                numericUpDown1.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                MessageBox.Show("Please select AM or PM");

            }
            else if (comboBox1.SelectedIndex == -1)
            {
                numericUpDown1.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                MessageBox.Show("*Please select a person to meet*");
            }
            else if (buttonwasclicked == false)
            {
                MessageBox.Show("*Please select a meeting aim*");
            }
            else if (button2.Text == "Select an option")
            {
                MessageBox.Show("*Please select a meeting aim*");
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                numericUpDown1.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                listBox1.Items.Add("Full Name: " + textBox1.Text + " " + textBox5.Text);
                listBox1.Items.Add("Mobile Number: " + textBox4.Text);
                listBox1.Items.Add("Email Address: " + textBox3.Text);
                listBox1.Items.Add("Meeting Date: " + dateTimePicker1.Value.ToShortDateString());
                listBox1.Items.Add("Meeting Time: " + numericUpDown1.Value + ":" + numericUpDown2.Value + " " + comboBox2.SelectedItem);
                listBox1.Items.Add("Meeting with: " + comboBox1.SelectedItem);
                listBox1.Items.Add("Meeting Aim: " + button2.Text);
                listBox1.Items.Add("    ***************************");
                resetFields();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            


        }
        private void button2_Click(object sender, EventArgs e)
        {
            buttonwasclicked = true;

            Form2 sv = new Form2();


            if (sv.ShowDialog() == DialogResult.OK)
            {
                if (sv.radioButton1.Checked == true)
                    button2.Text = sv.radioButton1.Text;
                else if (sv.radioButton2.Checked == true)
                    button2.Text = sv.radioButton2.Text;
                else if (sv.radioButton3.Checked == true)
                    button2.Text = sv.radioButton3.Text;
                else if (sv.radioButton4.Checked == true)
                    button2.Text = sv.radioButton4.Text;
                else if (!sv.radioButton1.Checked && !sv.radioButton2.Checked && !sv.radioButton3.Checked && !sv.radioButton4.Checked)
                {
                    MessageBox.Show("*Please select one option*");
                }
            }
            else 
            {
                button2.Text = "Select an option";

            }
        }
        void resetFields()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

            comboBox1.Text = "Select one";
            comboBox2.Text = "Select one"; 

            button2.Text = "Select an option";

            dateTimePicker1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                button3.Enabled = false;
                MessageBox.Show("*The List is all clear*");
            }
            else if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("*Please Select something to remove.*");
            }
            else if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0)
            {
                button4.Enabled = false;
                MessageBox.Show("*The List is all clear*");
            }
            else
            { listBox1.Items.Clear(); }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
