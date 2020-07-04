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

namespace Erc1.Forms._5_Cars
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void carsControl1_conClick(object sender, EventArgs e)
        {
        }

        private void carsControl1_conClick_1(object sender, EventArgs e)
        {
            CarsControl carbt = (CarsControl)sender;
            if (carbt.Clicked || carbt.Entered) TeamContainer.Controls.Add(new CONTROLS.Teams()
            {
                Dock = DockStyle.Fill,
                Id = carbt.CarID
            }) ;
            else { TeamContainer.Controls.Clear(); }
        }
    }
}
