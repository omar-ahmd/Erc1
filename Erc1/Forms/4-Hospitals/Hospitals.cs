using Erc1.BAL;
using Erc1.Classes;
using Erc1.CONTROLS;
using System;
using System.Collections;
using System.Data;
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
        DataTable Hosdt;
        
        private void Hospitals_Load(object sender, EventArgs e)
        {
            Hosdt = Hospital.Get_Info_Hospital();
            int hosnumb = Hosdt.Rows.Count;
            for (int i = 0; i < hosnumb; i++)
            {
                HospitalControlcs h = (HospitalControlcs)tableLayoutPanel1.Controls["_" + (i + 1).ToString()];
                h.HosID = int.Parse(Hosdt.Rows[i]["رمز_المستشفى"].ToString());
                h.HospitalName.Text = Hosdt.Rows[i]["اسم_المستشفى"].ToString();
                if(h.textBox1.Text!= "")
                {
                    h.Hosstatus = HosStatus.AvailBusy;
                }
                else
                {
                    h.Hosstatus = HosStatus.Available;
                }
            }
        }
    }
}
