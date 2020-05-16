using Erc1.BAL;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Erc1.CONTROLS
{
    
    public partial class PatientInformation : Form
    {


        public PatientInformation()
        {
            InitializeComponent();
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

        private void FromHos_CheckChange(object sender, EventArgs e)
        {
            if (!FromHos.Check)
            {
                FromHosInfo.Enabled = false;
            }
            else
            {
                FromHosInfo.Enabled = true;
                if (FromHome.Check)
                {
                    FromHomeInfo.Enabled = false;
                    FromHome.Check = false;
                }

                IEnumerable Hos = BAL.PatientInfo.GetHospitals();
                Name_FromHospital.DataSource = Hos;
                Name_FromHospital.ValueMember = "رمز_المستشفى";
                Name_FromHospital.DisplayMember = "اسم_المستشفى";
                Name_FromHospital.Text = "";
                Name_FromHospital.SelectedValueChanged += Name_FromHospital_SelectedValueChanged;

            }
        }

        private void Name_FromHospital_SelectedValueChanged(object sender, EventArgs e)
        {
            IEnumerable DepHos = BAL.PatientInfo.GetDepartementOfHos(int.Parse(Name_FromHospital.SelectedValue.ToString()));
            FromHosDepartement.DataSource = DepHos;
            FromHosDepartement.ValueMember = "sections_id";
            FromHosDepartement.DisplayMember = "sections_name";
            FromHosDepartement.Text = "";
            FromHosDepartement.SelectedValueChanged += FromHosDepartement_SelectedValueChanged;

            IEnumerable FloorHos = BAL.PatientInfo.GetFloors(int.Parse(Name_FromHospital.SelectedValue.ToString()));
            FromHosFloor.DataSource = FloorHos;
            FromHosFloor.ValueMember = "رمز_المستشفى";
            FromHosFloor.DisplayMember = "عدد_الطوابق";
            FromHosFloor.Text = "";
            
        }

        private void FromHosDepartement_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FromHome_CheckChange(object sender, EventArgs e)
        {
            if (!FromHome.Check)
            {
                FromHomeInfo.Enabled = false;
            }
            else
            {

                FromHomeInfo.Enabled = true;
                if (FromHos.Check)
                {
                    FromHosInfo.Enabled = false;
                    FromHos.Check = false;
                }

                IEnumerable Cities = BAL.PatientInfo.GetCities();
                FromCity.DataSource = Cities;
                FromCity.ValueMember = "رمز";
                FromCity.DisplayMember = "المدينة";
                FromCity.Text = "";
                FromCity.SelectedValueChanged += FromCity_SelectedValueChanged;
            }

            


        }

        private void FromCity_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ToHos_CheckChange(object sender, EventArgs e)
        {
            if (!ToHos.Check)
            {
                ToHosInfo.Enabled = false;


            }
            else
            {
                ToHosInfo.Enabled = true;
                if (ToHome.Check)
                {
                    ToHomeInfo.Enabled = false;
                    ToHome.Check = false;
                }
            }
        }
        private void ToHome_CheckChange(object sender, EventArgs e)
        {
            if (!ToHome.Check)
            {
                ToHomeInfo.Enabled = false;
            }
            else
            {

                ToHomeInfo.Enabled = true;
                if (ToHos.Check)
                {
                    ToHosInfo.Enabled = false;
                    ToHos.Check = false;
                }
            }
        }



        private void Save_Click(object sender, EventArgs e)
        {

        }

        public void Name_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Name_Patient.Text == "جديد")
            {
                Erc1.Forms._8_AddPatient.AddPatient addPatient = new Forms._8_AddPatient.AddPatient();
                addPatient.Show();
            }

        }

        public  void Name_Patient_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            MyFunction.FillComboBox(Name_Patient, PatientInfo.GetPatients(), "اسم", "الرمز");

        }
    }
}
