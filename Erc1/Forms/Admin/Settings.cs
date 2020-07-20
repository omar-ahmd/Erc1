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
            else if (i == "1")
            {
                Vol = new Volunteers.Volunteers();
                Vol.StartPosition = FormStartPosition.CenterParent;
                Vol.Show();
            }
            else if (i == "4")
            {
                center = new Centers.Centers();
                center.StartPosition = FormStartPosition.CenterScreen ;
                center.Show();
            }
            else if(i=="3")
            {
                car = new Cars();
                car.StartPosition = FormStartPosition.CenterScreen;
                car.Show();
            }
        }

        Hospitals Hos;
        Volunteers.Volunteers Vol;
        Centers.Centers center;
        Cars car;
        private void btn2_Load(object sender, EventArgs e)
        {
            
        }

        private void btn4_Load(object sender, EventArgs e)
        {

        }

        private void btn2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
