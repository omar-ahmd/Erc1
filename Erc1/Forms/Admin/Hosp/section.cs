using Erc1.BAL;
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
    public partial class section : Form
    {
        int HosID = 0;

        public DataTable Section;


        public section(string HosID)
        {
            InitializeComponent();
            try
            {
                Section = BAL.Hospitals.GetDepartement(int.Parse(HosID));
                this.HosID = int.Parse(HosID);
            }
            catch
            {
                Section = new DataTable();
                Section.Columns.Add("الرمز");
                Section.Columns.Add("اسم_القسم");
                Section.Columns.Add("تحويلة_القسم");
                Section.Columns.Add("الطابق");

            }


            dataGridView1.DataSource = Section;

            
            try
            {
                MyFunction.FillComboBox(Sections, BAL.PatientInfo.GetDepartement(), "اسم_القسم", "رمز");
            }
            catch
            {

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Sections.SelectedValue == null)
            {
                BAL.Hospitals.Add_Section(Sections.Text);
                try
                {
                    MyFunction.FillComboBox(Sections, BAL.PatientInfo.GetDepartement(), "اسم_القسم", "الرمز");
                }
                catch
                {

                }
            }
            else
            {
                DataRow dr = Section.NewRow();
                
                dr["الرمز"] = int.Parse(Sections.SelectedValue.ToString().Split(new char[] { ',', '=' })[1].Trim());
                dr["اسم_القسم"] = Sections.Text;
                dr["تحويلة_القسم"] = numericUpDown1.Value;
                dr["الطابق"] = numericUpDown2.Value;
                foreach (DataRow drr in Section.Rows)
                {
                    if(drr["الرمز"].ToString() == Sections.SelectedValue.ToString().Split(new char[] { ',', '=' })[1].Trim())
                    {
                        Section.Rows.Remove(drr);
                        break;
                    }
                }
                Section.Rows.Add(dr);

            }
            
        }

        private void section_Load(object sender, EventArgs e)
        {

        }
    }
}
