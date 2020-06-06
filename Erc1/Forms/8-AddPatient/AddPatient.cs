using Erc1.BAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms._8_AddPatient
{
    public partial class AddPatient : Form
    {
        IEnumerable insurance = null, city = null;
        Patient patient;
        public AddPatient()
        {
            InitializeComponent();
            Thread Insurance = new Thread(() => { insurance = BAL.PatientInfo.GetInsurance(); });
            Thread City = new Thread(() => { city = BAL.PatientInfo.GetCities(); });
            //doctor

            City.Start();
            Insurance.Start();

            City.Join();
            Insurance.Join();

            MyFunction.FillComboBox(Insurancebox, PatientInfo.GetInsurance(), "الجهة_الضامنة", "الرمز");
            MyFunction.FillComboBox(CityBox, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
            CityBox.SelectedValueChanged += CityBox_SelectedValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Insurancebox.SelectedItem==null)
            {
                if(Insurancebox.Text=="")
                {

                }
                else
                {
                    // add to database
                }
            }
            if (CityBox.SelectedItem == null)
            {
                if (CityBox.Text == "")
                {

                }
                else
                {
                    // add to database
                }
            }
            if (RegionBox.SelectedItem == null)
            {
                if (RegionBox.Text == "")
                {

                }
                else
                {
                    // add to database
                }
            }
            if (DoctorBox.SelectedItem == null)
            {
                if (RegionBox.Text == "")
                {

                }
                else
                {
                    // add to database
                }
            }

            patient = new Patient();
            patient.ImportPatient(this);
            patient.AddPatient();
        }

        private void CityBox_SelectedValueChanged(object sender, EventArgs e)
        {

            if (CityBox.SelectedValue != null)
            {
                MyFunction.FillComboBox(RegionBox, BAL.PatientInfo.GetRegions(int.Parse(CityBox.SelectedValue.ToString())), "المنطقة", "رمز");
            }
            
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
