using Erc1.CONTROLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms.Admin
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            btn1.conClick += Btn2_conClick;
            btn2.conClick += Btn2_conClick;
            btn3.conClick += Btn2_conClick;
            btn4.conClick += Btn2_conClick;
            btn5.conClick += Btn2_conClick;
            btn6.conClick += Btn2_conClick;
            btn7.conClick += Btn2_conClick;
            btn8.conClick += Btn2_conClick;
            btn9.conClick += Btn2_conClick;
            btn10.conClick += Btn2_conClick;
        }

        private void Btn2_conClick(object sender, EventArgs e)
        {
            string i = ((Btn)sender).Name[3].ToString();
            if (i == "2")
            {
                Hos = new Hospitals();
                Hos.StartPosition = FormStartPosition.CenterParent;
                Hos.Show();
            }
            else if(i=="1")
            {
                Vol = new Volunteers.Volunteers();
                Vol.StartPosition = FormStartPosition.CenterParent;
                Vol.Show();
            }
        }

        Hospitals Hos;
        Volunteers.Volunteers Vol;
        private void btn2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
