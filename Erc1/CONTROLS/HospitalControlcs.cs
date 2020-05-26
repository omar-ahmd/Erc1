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
    public enum HosStatus
    {
        Available,
        Busy,
        AvailBusy

    }
    public partial class HospitalControlcs : UserControl
    {
        public event EventHandler HosIDChanged;
        //public HospitalInfo (new form)
        //public Hospital(BAL) TO GET ACCSESS TO HOPITAL DATA


        private int hosID;
        public int HosID
        {
            get 
            {
                return hosID; 
            }
            set 
            {
                hosID = value;
                textBox1.Text = "ff";
            }
        }


        public HospitalControlcs()
        {
            InitializeComponent();

        }

        private HosStatus hosstatus = HosStatus.Available;

        public HosStatus Hosstatus
        {
            get 
            {
                return hosstatus; 
            }
            set 
            {
                hosstatus = value;
                HosIDChanged += HospitalControlcs_HosIDChanged;
                HosIDChanged.Invoke(this, EventArgs.Empty);
                 
            }
        }

        private void HospitalControlcs_HosIDChanged(object sender, EventArgs e)
        {
            //GetHos(int ID) we should get id/name/number/available or not/Notes/Departements/ext/
            //add info into this user control and into this HopitalsInfo Form

            HosIDChanged -= HospitalControlcs_HosIDChanged;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me=(MouseEventArgs) e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right){ MessageBox.Show("kk"); }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right) 
            {

                switch (Hosstatus)
                {
                    case HosStatus.Available:
                        {
                            Hosstatus = HosStatus.Busy;
                            textBox1.Text = "";
                            textBox1.ReadOnly = true;
                            textBox1.BackColor = Color.FromArgb(222,54,67);
                            break;
                        }
                    case HosStatus.Busy:
                        {
                            Hosstatus = HosStatus.AvailBusy;
                            textBox1.ReadOnly = false;
                            textBox1.BackColor = Color.FromArgb(241,149,98);
                            break;
                        }
                    case HosStatus.AvailBusy:
                        {
                            Hosstatus = HosStatus.Available;
                            textBox1.Text = "";
                            textBox1.ReadOnly = true;
                            textBox1.BackColor = Color.FromArgb(109, 184, 127);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HospitalName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hospital Form");
        }
    }
}
