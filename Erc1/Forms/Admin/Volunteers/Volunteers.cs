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

namespace Erc1.Forms.Admin.Volunteers
{
    public partial class Volunteers : Form
    {
        public Volunteers()
        {
            InitializeComponent();
            try
            {
                MyFunction.FillComboBox(City, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
                MyFunction.FillComboBox(Blood, BAL.Employees.BloodType(), "فئة", "رمز");
                MyFunction.FillComboBox(Role, BAL.Employees.GetWorks(), "وظيفة", "رمز");
            }
            catch
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            العاملون hosp = new العاملون();
            try
            {
                hosp.المركز = int.Parse(Center.Text);
                hosp.الرمز = int.Parse(ID.Text);
                hosp.اللقب = NName.Text;
                hosp.الاسم = name.Text;
                hosp.البريد = Email.Text;
                hosp.الجنسية = Nationality.Text;
                hosp.اسم_الأم = MotherName.Text;
                hosp.تاريخ_الولادة = Birthday.Value;
                hosp.تاريخ_الانتساب = ParticipationDate.Value;
                hosp.التحصيل_العلمي = Education.Text;
                hosp.رمز_المنطقة = int.Parse(Region.SelectedValue.ToString());
                hosp.الدوام = WorkTime.Text;
                hosp.العنوان = Info.Text;
                try
                {
                    hosp.الوظيفة = int.Parse(Role.SelectedValue.ToString());
                    hosp.فئة_الدم = int.Parse(Blood.SelectedValue.ToString());
                    hosp.رقم_السجل = int.Parse(Number.Text);
                }
                catch
                {

                }
                hosp.مكان_السجل = Location.Text;
                hosp.مسؤول_مهمة_أو_لا = Head.Checked;
                hosp.مسعف_أو_مساعد = Paramedic.Checked;
                hosp.سائق_أو_لا = Driver.Checked;


            }
            catch
            {

            }

            if (BAL.Employees.AddVolunteer(hosp))
            {

            }
            else
            {

            }
            dataGridView1.DataSource = BAL.Employees.Get_Employees();
        }

        private void Volunteers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BAL.Employees.Get_Employees();
        }
    }
}
