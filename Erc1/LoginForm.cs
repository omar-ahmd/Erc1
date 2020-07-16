using Erc1.BAL;
using System;
using System.Threading;
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


        Thread ImportCasesType,ImportFromDrive;
        private void button1_Click(object sender, EventArgs e)
        {
            ImportCasesType = new Thread(() => { addMission.Get_CasesType(); });
            ImportFromDrive = new Thread(() => { Erc1.BAL.ImportFromDrive.ReadEnteries(); });
            ImportFromDrive.Start();
            ImportCasesType.Start();

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
