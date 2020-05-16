using ERC;
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
                FromHospital.Enabled = false;
            }
            else
            {
                FromHospital.Enabled = true;

                

                if (FromHome.Check)
                {
                    FromHomeInfo.Enabled = false;
                    FromHome.Check = false;
                    FromBuilding.Text = "";
                    FromCity.Text = "";
                    FromRegion.Text = "";
                    FromFloor.Text = "";
                    FromStreet.Text = "";
                    MoreFromInfo.Text = "";

                }
                try
                {
                    
                    FromCity.SelectedValueChanged -= Name_FromHospital_SelectedValueChanged;
                    
                }
                catch { }

                MyFunction.FillComboBox(Name_FromHospital, BAL.PatientInfo.GetHospitals(), "اسم_المستشفى", "رمز_المستشفى");
                ID_FromHospital.Text = "";
                Name_FromHospital.SelectedValueChanged += Name_FromHospital_SelectedValueChanged;

            }
        }

        private void Name_FromHospital_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            t.Text = ("H"+sen.SelectedValue.ToString()).ToUpper();


            IEnumerable DepHos = BAL.PatientInfo.GetDepartementOfHos(int.Parse(Name_FromHospital.SelectedValue.ToString()));

            MyFunction.FillComboBox(FromHosDepartement, DepHos, "sections_name", "sections_id");
            FromHosDepartement.SelectedValueChanged += FromHosDepartement_SelectedValueChanged;

            IEnumerable FloorHos = BAL.PatientInfo.GetFloors(int.Parse(Name_FromHospital.SelectedValue.ToString()));
            MyFunction.FillComboBox(FromHosFloor, FloorHos, "عدد_الطوابق", "رمز_المستشفى");
            
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
                    FromHospital.Enabled = false;
                    FromHos.Check = false;

                    ID_FromHospital.Text="";
                    Name_FromHospital.Text = "";
                    FromHosDepartement.Text = "";
                    FromHosFloor.Text = "";
                    FromHosRoom.Text = "";



                }
                try
                {
                    FromCity.SelectedValueChanged -= FromCity_SelectedValueChanged;
                }
                catch { };
                IEnumerable Cities = BAL.PatientInfo.GetCities();

                MyFunction.FillComboBox(FromCity, Cities, "المدينة", "رمز");
                FromCity.SelectedValueChanged += FromCity_SelectedValueChanged;
            }

            


        }

        private void FromCity_SelectedValueChanged(object sender, EventArgs e)
        {
            MyFunction.FillComboBox(FromRegion, BAL.PatientInfo.GetRegions(int.Parse(FromCity.SelectedValue.ToString())),"المنطقة", "رمز");
        }




        private void ToHos_CheckChange(object sender, EventArgs e)
        {
            if (!ToHos.Check)
            {
                ToHospital.Enabled = false;


            }
            else
            {
                ToHospital.Enabled = true;
                if (ToHome.Check)
                {
                    ToHomeInfo.Enabled = false;
                    ToHome.Check = false;
                    Name_ToHospital.DataSource = null;

                    ToBuilding.Text = "";
                    ToCity.Text = "";
                    ToRegion.Text = "";
                    ToFloor.Text = "";
                    ToStreet.Text = "";
                    MoreToInfo.Text = "";
                }
                try
                {
                    ToCity.SelectedValueChanged -= Name_ToHospital_SelectedValueChanged;
                }
                catch { }

                MyFunction.FillComboBox(Name_ToHospital, BAL.PatientInfo.GetHospitals(), "اسم_المستشفى", "رمز_المستشفى");
                ID_ToHospital.Text = "";
                Name_ToHospital.SelectedValueChanged += Name_ToHospital_SelectedValueChanged;
            }
        }

        private void Name_ToHospital_SelectedValueChanged(object sender, EventArgs e)
        {

            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            t.Text = ("H" + sen.SelectedValue.ToString()).ToUpper();

            IEnumerable DepHos = BAL.PatientInfo.GetDepartementOfHos(int.Parse(Name_ToHospital.SelectedValue.ToString()));

            MyFunction.FillComboBox(ToHosDepartement, DepHos, "sections_name", "sections_id");
            ToHosDepartement.SelectedValueChanged += ToHosDepartement_SelectedValueChanged;

            IEnumerable FloorHos = BAL.PatientInfo.GetFloors(int.Parse(Name_ToHospital.SelectedValue.ToString()));
            MyFunction.FillComboBox(ToHosFloor, FloorHos, "عدد_الطوابق", "رمز_المستشفى");
        }

        private void ToHosDepartement_SelectedValueChanged(object sender, EventArgs e)
        {
            
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
                    ToHospital.Enabled = false;
                    ToHos.Check = false;

                    ID_ToHospital.Text = "";
                    Name_ToHospital.Text = "";
                    ToHosDepartement.Text = "";
                    ToHosFloor.Text = "";
                    ToHosRoom.Text = "";
                }
                try
                {
                    ToCity.SelectedValueChanged -= ToCity_SelectedValueChanged;
                }
                catch { };
                IEnumerable Cities = BAL.PatientInfo.GetCities();

                MyFunction.FillComboBox(ToCity, Cities, "المدينة", "رمز");
                ToCity.SelectedValueChanged += ToCity_SelectedValueChanged;
            }
        }

        private void ToCity_SelectedValueChanged(object sender, EventArgs e)
        {
            MyFunction.FillComboBox(ToRegion, BAL.PatientInfo.GetRegions(int.Parse(ToCity.SelectedValue.ToString())), "المنطقة", "رمز");

        }





        private void Save_Click(object sender, EventArgs e)
        {
            addMission add = new addMission();
            add.ImportInfo(LoginForm.of.im);
            
        }

        public void Name_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Name_Patient.Text == "جديد")
            {
                Erc1.Forms._8_AddPatient.AddPatient addPatient = new Forms._8_AddPatient.AddPatient();
                addPatient.Show();
            }

        }



        private void PatientInformation_Load(object sender, EventArgs e)
        {
            Name_Patient.SelectedValueChanged -= Name_Patient_SelectedValueChanged1;
            MyFunction.FillComboBox(Name_Patient, PatientInfo.GetPatients(), "اسم", "الرمز");
            Name_Patient.SelectedValueChanged += Name_Patient_SelectedValueChanged1;


        }

        private void Name_Patient_SelectedValueChanged1(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            t.Text = sen.SelectedValue.ToString();
        }
    }
}
