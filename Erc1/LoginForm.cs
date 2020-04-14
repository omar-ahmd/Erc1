using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ERC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }





        
        private void button1_Click(object sender, EventArgs e)
        {
            OperationForm of = new OperationForm();
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
