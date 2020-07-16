using Erc1.BAL;
using Erc1.DAL;
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
    public partial class Hospitals : Form
    {
        public Hospitals()
        {
            InitializeComponent();
            try
            {
                MyFunction.FillComboBox(City, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
            }
            catch
            {

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Hos_Name.Text == "") button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        section s;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                s.Dispose();
            }
            catch
            {

            }

            if (s == null || s.IsDisposed)
            {
                s = new section(ID.Text);
                s.StartPosition = FormStartPosition.CenterParent;
            }
            s.Show();
        }

        private void City_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                MyFunction.FillComboBox(Region, BAL.PatientInfo.GetRegions(int.Parse(City.SelectedValue.ToString())), "المنطقة", "رمز");
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            المستشفيات hosp = new المستشفيات();
            try
            {
                hosp.رمز_المستشفى = int.Parse(ID.Text);
                hosp.اسم_المستشفى = Hos_Name.Text;
                hosp.رمز_المنطقة = int.Parse(Region.SelectedValue.ToString());
                hosp.الطابق_السفلي = (short)numericUpDown1.Value;
                hosp.الطابق_العلوي = (short)numericUpDown2.Value;
                hosp.العنوان = Info.Text;
                hosp.الهاتف = phone.Text;
                
            }
            catch
            {

            }
            
            if(BAL.Hospitals.AddHospital(hosp,s.Section))
            {
                
            }
            else
            {

            }


        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int HosID = int.Parse(ID.Text);

                 المستشفيات hosp = BAL.Hospitals.GetHospital(HosID);

                ID.Text = hosp.رمز_المستشفى.ToString();
                Hos_Name.Text = hosp.اسم_المستشفى;
                City.SelectedValue = BAL.Hospitals.GetCityId(hosp.رمز_المنطقة);
                Region.SelectedValue = hosp.رمز_المنطقة;
                numericUpDown1.Value = (decimal)hosp.الطابق_السفلي;
                numericUpDown2.Value = (decimal)hosp.الطابق_العلوي;
                Info.Text = hosp.العنوان;
                phone.Text = hosp.الهاتف;


            }
            catch
            {
                Hos_Name.Text = "";
                City.SelectedValue = "";
                Region.SelectedValue = "";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                Info.Text = "";
                phone.Text = "";
            }
            if (Hos_Name.Text == "") button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
