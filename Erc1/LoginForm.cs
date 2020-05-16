using System;
using System.Windows.Forms;

namespace ERC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }


        public static OperationForm of = new OperationForm();



        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            of.Show();

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
