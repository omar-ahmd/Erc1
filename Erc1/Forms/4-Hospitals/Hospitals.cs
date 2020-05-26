using Erc1.BAL;
using Erc1.Classes;
using Erc1.CONTROLS;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Erc1.Forms._4_Hospitals
{
    public enum MissionType
    {
        Implemented,
        Dlayed,
        Canceled

    }
    public partial class Hospitals : Form
    {

        private int hosPages = 0;

        public int HosPages
        {
            get { return hosPages; }
            set { hosPages = value; }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }




        public Hospitals()
        {
            InitializeComponent();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (HosPages < 4)
            {
                int i = 0;
                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    if (item.GetType() == typeof(HospitalControlcs))
                    {
                        HospitalControlcs con = (HospitalControlcs)item;
                        con.HosID = (22 * HosPages) + i;
                        i++;

                    }
                }
                HosPages++;
            }
            
        }

        private void Hospitals_Load(object sender, EventArgs e)
        {

        }
    }
}
