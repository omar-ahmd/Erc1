using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.CONTROLS
{
    public partial class Teams : UserControl
    {
        public Teams()
        {
            InitializeComponent();
        }
        private int iD;
        private int centerID;
        DataRow carINFO;


        public int CenterId
        {
            get {return centerID; }
            set 
            {
                centerID = value;
                CenterID.Text = value.ToString();
            }
        }
        public int Id
        {
            get { return iD; }
            set 
            {
                iD = value;
                IDD.Text = value.ToString();
                try
                {
                    carINFO = Erc1.BAL.ImportFromDrive.ReadCarInfo(iD);
                    Head_ID.Text = carINFO[1].ToString();
                    Driver_ID.Text = carINFO[2].ToString();
                    Param1_ID.Text = carINFO[3].ToString();
                    Param2_ID.Text = carINFO[4].ToString();
                    Fuel.Text = carINFO[5].ToString();
                }
                catch
                {

                }

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
