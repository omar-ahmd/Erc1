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

        private int hosPages = 1;

        DataTable Hosdt;
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



        int maxHosPages = 0;
        public Hospitals()
        {
            InitializeComponent();


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Empty()
        {
            foreach (Control item in this.tableLayoutPanel1.Controls)
            {
                if(item.GetType() ==typeof(HospitalControlcs))
                {
                    HospitalControlcs h = (HospitalControlcs)item;
                    h.Hosstatus = HosStatus.None;
                }
            }
        }
        private void Down_Click(object sender, EventArgs e)
        {


            if (HosPages < maxHosPages)
            {
                Empty();
                HosPages++;
                int count = Hosdt.Rows.Count;
                int y;
                if (HosPages == maxHosPages) y = count % 22;
                else y = 22;
                for (int i = 0; i < y; i++)
                {
                    int index = i + (HosPages-1) * 22;
                    HospitalControlcs h = (HospitalControlcs)tableLayoutPanel1.Controls["_" + (i + 1).ToString()];
                    h.HosID = int.Parse(Hosdt.Rows[index]["رمز_المستشفى"].ToString());
                    h.HospitalName.Text = Hosdt.Rows[index]["اسم_المستشفى"].ToString();
                    if (Hosdt.Rows[index]["الملاحظات"].ToString() != "")
                    {
                        h.Hosstatus = HosStatus.AvailBusy;
                    }
                    else
                    {
                        if (Hosdt.Rows[index]["الحالة"].ToString() == "متاح")
                        {

                            h.Hosstatus = HosStatus.Available;
                        }
                        else if (Hosdt.Rows[index]["الحالة"].ToString() == "غير متاح")
                        {
                            h.Hosstatus = HosStatus.Busy;
                        }

                    }
                }

            }
            
        }
        
        private void Hospitals_Load(object sender, EventArgs e)
        {
            Hosdt = BAL.Hospitals.GetHospitals();
            maxHosPages = (Hosdt.Rows.Count / 22);
            int count = Hosdt.Rows.Count;
            if (Hosdt.Rows.Count % 22 != 0) maxHosPages++;

            int y;
            if (HosPages == maxHosPages) y = count % 22;
                else y = 22;

            for (int i = 0; i < y; i++) 
            {
                HospitalControlcs h = (HospitalControlcs)tableLayoutPanel1.Controls["_" + (i + 1).ToString()];
                h.HosID = int.Parse(Hosdt.Rows[i]["رمز_المستشفى"].ToString());
                h.HospitalName.Text = Hosdt.Rows[i]["اسم_المستشفى"].ToString();
                if(Hosdt.Rows[i]["الملاحظات"].ToString() != "")
                {
                    h.Hosstatus = HosStatus.AvailBusy;
                }
                else
                {
                    if (Hosdt.Rows[i]["الحالة"].ToString() == "متاح")
                    {
                        
                        h.Hosstatus = HosStatus.Available;
                    }
                    else if (Hosdt.Rows[i]["الحالة"].ToString() == "غير متاح")
                    {
                        h.Hosstatus = HosStatus.Busy;
                    }

                }
            }
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (HosPages > 1)
            {
                Empty();
                HosPages--;
                int count = Hosdt.Rows.Count;
                int y;
                if (HosPages == maxHosPages) y = count % 22;
                else y = 22;
                for (int i = 0; i < y; i++)
                {
                    int index = i + (HosPages - 1) * 22;
                    HospitalControlcs h = (HospitalControlcs)tableLayoutPanel1.Controls["_" + (i + 1).ToString()];
                    h.HosID = int.Parse(Hosdt.Rows[index]["رمز_المستشفى"].ToString());
                    h.HospitalName.Text = Hosdt.Rows[index]["اسم_المستشفى"].ToString();
                    if (Hosdt.Rows[index]["الملاحظات"].ToString() != "")
                    {
                        h.Hosstatus = HosStatus.AvailBusy;
                    }
                    else
                    {
                        if (Hosdt.Rows[index]["الحالة"].ToString() == "متاح")
                        {

                            h.Hosstatus = HosStatus.Available;
                        }
                        else if (Hosdt.Rows[index]["الحالة"].ToString() == "غير متاح")
                        {
                            h.Hosstatus = HosStatus.Busy;
                        }

                    }
                }

            }
        }
    }
}
