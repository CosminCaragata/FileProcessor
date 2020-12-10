using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2FAProject
{
    public partial class Form1 : Form
    {

        DomainMock Domain = new DomainMock();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox1.Text) &&
                Domain.UserExists(textBox1.Text))                
            {
                string token = Domain.AddTokenToUser(textBox1.Text);
                MailService.Send2faMail(textBox1.Text, token);
            }
            else
            {
                label4.Text = "Invalid mail";
            }
            

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Domain.LoginUser(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                label4.Text = "You are logged in";
            }
            else
            {
                label4.Text = "Incorrect credentials";
            }
        }
    }
}
