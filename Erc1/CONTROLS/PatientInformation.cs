﻿using ERC;
using Erc1.BAL;
using Erc1.Classes;
using Erc1.DAL;
using Erc1.Forms._8_AddPatient;
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
                    FromRegion.SelectedItem = null;
                    FromCity.SelectedItem = null;
                    
                    FromFloor.Text = "";
                    FromStreet.Text = "";
                    MoreFromInfo.Text = "";

                }
                try
                {
                    
                    FromCity.SelectedValueChanged -= Name_FromHospital_SelectedValueChanged;
                    
                }
                catch { }
                if (Name_FromHospital.DataSource == null)
                {
                    MyFunction.FillComboBox(Name_FromHospital, BAL.PatientInfo.GetHospitals(), "اسم_المستشفى", "رمز_المستشفى");
                }
                ID_FromHospital.Text = "";
                Name_FromHospital.SelectedValueChanged += Name_FromHospital_SelectedValueChanged;

            }
        }

        private void Name_FromHospital_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            if (sen.SelectedValue != null)
            {
                t.Text = ("H" + sen.SelectedValue.ToString()).ToUpper();

               

                FromHosDepartement.SelectedValueChanged -= FromHosDepartement_SelectedValueChanged;

                MyFunction.FillComboBox(FromHosDepartement, BAL.PatientInfo.GetDepartementOfHos(int.Parse(Name_FromHospital.SelectedValue.ToString())), "sections_name", "sections_id");

                FromHosDepartement.SelectedValueChanged += FromHosDepartement_SelectedValueChanged;
                

                short[] FloorHos = BAL.PatientInfo.GetFloors(int.Parse(Name_FromHospital.SelectedValue.ToString()));
                MyFunction.FillComboBox(FromHosFloor, FloorHos, "عدد_الطوابق", "رمز_المستشفى");




                FromHosFloor.Text = "";
            }
            else
            {
                t.Text = "";

            }

            

            
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
                    Name_FromHospital.SelectedItem = null ;
                    FromHosDepartement.SelectedItem = null;
                    FromHosFloor.SelectedItem = null;
                    FromHosRoom.Text = "";

                    

                }
                try
                {
                    FromCity.SelectedValueChanged -= FromCity_SelectedValueChanged;
                }
                catch { };
                if (FromCity.DataSource == null)
                {
                    MyFunction.FillComboBox(FromCity, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
                }
                FromCity.SelectedValueChanged += FromCity_SelectedValueChanged;
                
            }

            


        }

        private void FromCity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FromCity.SelectedValue != null)
            {
                MyFunction.FillComboBox(FromRegion, BAL.PatientInfo.GetRegions(int.Parse(FromCity.SelectedValue.ToString())), "المنطقة", "رمز");
            }
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
                    tableLayoutPanel15.Enabled = false;
                    tableLayoutPanel20.Enabled = false;
                    ToHome.Check = false;

                    ToBuilding.Text = "";
                    ToRegion.SelectedItem = null;
                    ToCity.SelectedItem = null;

                    ToFloor.Text = "";
                    ToStreet.Text = "";
                    MoreToInfo.Text = "";

                }
                try
                {

                    ToCity.SelectedValueChanged -= Name_ToHospital_SelectedValueChanged;

                }
                catch { }
                if (Name_ToHospital.DataSource == null)
                {
                    MyFunction.FillComboBox(Name_ToHospital, BAL.PatientInfo.GetHospitals(), "اسم_المستشفى", "رمز_المستشفى");
                }
                ID_ToHospital.Text = "";
                Name_ToHospital.SelectedValueChanged += Name_ToHospital_SelectedValueChanged;

            }
        
        }

        private void Name_ToHospital_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            if (sen.SelectedValue != null)
            {
                t.Text = ("H" + sen.SelectedValue.ToString()).ToUpper();



                ToHosDepartement.SelectedValueChanged -= ToHosDepartement_SelectedValueChanged;

                MyFunction.FillComboBox(ToHosDepartement, BAL.PatientInfo.GetDepartementOfHos(int.Parse(Name_ToHospital.SelectedValue.ToString())), "sections_name", "sections_id");

                ToHosDepartement.SelectedValueChanged += ToHosDepartement_SelectedValueChanged;


                short[] FloorHos = BAL.PatientInfo.GetFloors(int.Parse(Name_ToHospital.SelectedValue.ToString()));
                MyFunction.FillComboBox(ToHosFloor, FloorHos, "عدد_الطوابق", "رمز_المستشفى");




                ToHosFloor.Text = "";
            }
            else
            {
                t.Text = "";

            }
        }

        private void ToHosDepartement_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ToHome_CheckChange(object sender, EventArgs e)
        {
            if (!ToHome.Check)
            {
                tableLayoutPanel15.Enabled = false;
                tableLayoutPanel20.Enabled = false;
            }
            else
            {

                tableLayoutPanel15.Enabled = true;
                tableLayoutPanel20.Enabled = true;
                if (ToHos.Check)
                {
                    ToHospital.Enabled = false;
                    ToHos.Check = false;

                    ID_ToHospital.Text = "";
                    Name_ToHospital.SelectedItem = null;
                    ToHosDepartement.SelectedItem = null;
                    ToHosFloor.SelectedItem = null;
                    ToHosRoom.Text = "";
                }
                try
                {
                    ToCity.SelectedValueChanged -= ToCity_SelectedValueChanged;
                }
                catch { };
                if (ToCity.DataSource == null)
                {
                    MyFunction.FillComboBox(ToCity, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
                }
                ToCity.SelectedValueChanged += ToCity_SelectedValueChanged;
            }
        }

        private void ToCity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ToCity.SelectedValue != null)
            {
                MyFunction.FillComboBox(ToRegion, BAL.PatientInfo.GetRegions(int.Parse(ToCity.SelectedValue.ToString())), "المنطقة", "رمز");
            }

        }




        addMission add;
        private void Save_Click(object sender, EventArgs e)
        {
            add = new addMission();
            bool done;
            if (((Erc1.Forms.AddMission)(this.Parent.Parent.Parent.Parent.Parent)).MissionTy == Forms.MissionType.Implemented)
            {
                done = add.ImportInfo(LoginForm.of.im);
                if (done)
                {

                    if (add.SaveImplementedMission())
                    {

                        LoginForm.of.im.Dispose();
                        LoginForm.of.Sfab_ImpClicked(0, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }



                }
            }
            else if (((Erc1.Forms.AddMission)(this.Parent.Parent.Parent.Parent.Parent)).MissionTy == Forms.MissionType.Dlayed)
            {
                done = add.ImportInfo(LoginForm.of.dm);
                if (done)
                {
                    if (add.SaveDelayedMission())
                    {

                        LoginForm.of.im.Dispose();
                        LoginForm.of.Sfab_DelClicked(0, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
            else
            {
                done = add.ImportInfo(LoginForm.of.cm);
                if(done)
                {

                }
            }
        }

            
        

        public void Name_Patient_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void PatientInformation_Load(object sender, EventArgs e)
        {
            Name_Patient.SelectedValueChanged -= Name_Patient_SelectedValueChanged1;
            MyFunction.FillComboBox(Name_Patient, PatientInfo.GetPatients(), "اسم", "الرمز");
            Name_Patient.SelectedValueChanged += Name_Patient_SelectedValueChanged1;


            MyFunction.FillComboBox(Insurance, PatientInfo.GetInsurance(), "الجهة_الضامنة", "الرمز");
            MyFunction.FillComboBox(MedcineID, PatientInfo.GetMedicine(), "اسم", "رمز");
            MyFunction.FillComboBox(InfectionDiseases, PatientInfo.GetInfectiousDeseases(), "المرض", "الرمز");

        }

        public void Name_Patient_SelectedValueChanged1(object sender, EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)sen.Parent.Controls["ID" + "_" + na];
            t.Text = sen.SelectedValue.ToString();
        }
        public AddPatient addp;
        private void button1_Click(object sender, EventArgs e)
        {
            addp = new AddPatient(this);
            addp.StartPosition = FormStartPosition.CenterScreen;
            
            
            addp.Show();
        }
    }
}
