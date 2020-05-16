using Erc1.Classes;
using Erc1.CONTROLS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;


namespace Erc1.Forms
{ 
    public enum MissionType
    {
        Implemented,
        Dlayed,
        Canceled

    }
    public partial class AddMission : Form
    {
        PatientInformation paI;
        ParamInformation pI;
        public AddMission()
        {
            InitializeComponent();
            /*this.SetStyle(ControlStyles.UserPaint
                        | ControlStyles.OptimizedDoubleBuffer
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.SupportsTransparentBackColor, true);*/

            this.DoubleBuffered = true;


        }

        public static void EnableDoubleBuff(Control c)
        {
            PropertyInfo DemoProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            DemoProp.SetValue(c, true, null);
        }


        public AddMission(MissionType missionType)
        {
            InitializeComponent();
            switch (missionType)
            {
                case Forms.MissionType.Implemented:
                    {
                        pI = new ParamInformation();
                        pI.Name = "pi";
                        paI = new PatientInformation();
                        pI.TopLevel = false;
                        pI.Dock = DockStyle.Fill;
                        tableLayoutPanel20.Controls.Add(pI, 0, 1);
                        pI.Invalidate();
                        pI.Show();

                        paI.TopLevel = false;
                        paI.Dock = DockStyle.Fill;
                       paI.Name="pai";
                        tableLayoutPanel20.Controls.Add(paI, 0, 1);

                        paI.Hide();

                        button2.Show();
                        //this.MissionType.Show();
                        //this.MissionID.Show();
                        this.panel9.BackgroundImage = Erc1.Properties.Resources._12;
                        break;

                    }

                case Forms.MissionType.Dlayed:
                    {
                        paI = new PatientInformation();
                        button2.Hide();
                        button1.Text = "معلومات الحالة";
                        button1.Enabled = false;


                        this.panel9.BackgroundImage = Erc1.Properties.Resources._14;

                        paI.TopLevel = false;
                        paI.Dock = DockStyle.Fill;
                        paI.Show();
                        tableLayoutPanel20.Controls.Add(paI, 0, 1);

                        break;
                    }
                case Forms.MissionType.Canceled:
                    {
                        paI = new PatientInformation();
                        button2.Hide();
                        button1.Text = "معلومات الحالة";
                        button1.Enabled = false;
                        

                        this.panel9.BackgroundImage = Erc1.Properties.Resources._14;
                        paI.CancilingtText.Visible = true;
                        paI.panel3.Visible = true;
                        paI.TopLevel = false;
                        paI.Dock = DockStyle.Fill;
                        paI.Show();
                        tableLayoutPanel20.Controls.Add(paI, 0, 1);
                        break;
                    }
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel9.BackgroundImage = Erc1.Properties.Resources._112;
            paI.Show();
            pI.Hide();
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
        private void button1_Click(object sender, EventArgs e)
        {
            panel9.BackgroundImage = Erc1.Properties.Resources._12;

            pI.Show();
            paI.Hide();



        }
        bool isFilled =false;
        private void AddMission_Load(object sender, EventArgs e)
        {
           
            

            var centers = Classes.mission.Get_Centers();

            
            comboBox1.DataSource = centers;
            comboBox1.DisplayMember = "centers";
            comboBox1.ValueMember = "id";




            if (!isFilled)
            {
                comboBox1.SelectedIndexChanged += comboBox1_SelectionChangeCommitted;
                isFilled = true;
            }

            comboBox3.Items.Add(DateTime.Now.Year);
            comboBox3.SelectedIndex = 0;
            comboBox2.Items.Add(DateTime.Now.Month);
            comboBox2.SelectedIndex = 0;
            comboBox4.Items.Add(DateTime.Now.Day);
            comboBox4.SelectedIndex = 0;


            var disease_type = Classes.mission.Get_نوعيات_الحالات();
            comboBox6.DataSource = disease_type;
            comboBox6.ValueMember = "الرمز";
            comboBox6.DisplayMember = "النوعية";
            comboBox6.SelectedIndexChanged += ComboBox6_SelectedIndexChanged;

            ComboBox _c21 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp5", true)[0].Controls.Find("c1", true))[0];
            var p= mission.Get_المرضى();
            _c21.DataSource = p;
            _c21.ValueMember ="الرمز";
            _c21.DisplayMember = "اسم";
            _c21.SelectedValueChanged += _c21_SelectedValueChanged;

            ComboBox c22 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("FromHomeInfo", true)[0].Controls.Find("FromCity", true))[0];
            var city = mission.Get_المدن();
            c22.DataSource = city;
            c22.ValueMember = "رمز";
            c22.DisplayMember = "المدينة";
            c22.SelectedIndexChanged += C22_SelectedIndexChanged;


            ComboBox c24 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp6", true)[0].Controls.Find("Name_FromHospital", true))[0];
            var hospital = mission.Get_المستشفيات();
            c24.DataSource = hospital;
            c24.ValueMember = "رمز_المستشفى";
            c24.DisplayMember = "اسم_المستشفى";
            c24.SelectedIndexChanged += C24_SelectedIndexChanged;


        }

        private void C24_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c24 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp6", true)[0].Controls.Find("Name_FromHospital", true))[0];
            ComboBox c25 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp9", true)[0].Controls.Find("Name_FromHosSection", true))[0];
            // var sections = mission.Get_أقسام_المستشفيات_Datalayer(int.Parse(c24.SelectedValue.ToString()));
            //  dataGridView1.DataSource = sections;
            var sections = mission.Get_أقسام_المستشفيات(int.Parse(c24.SelectedValue.ToString()));
            c25.DataSource = sections;
            c25.ValueMember = "sections_id";
            c25.DisplayMember = "sections_name";
            ComboBox c26 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp9", true)[0].Controls.Find("FromHosFloor", true))[0];
            var levels = mission.Get_طوابق_المستشفيات(int.Parse(c24.SelectedValue.ToString()));
            c26.DataSource = levels;
            c26.ValueMember = "رمز_المستشفى";
            c26.DisplayMember = "عدد_الطوابق";
            TextBox t = (TextBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp6", true)[0].Controls.Find("ID_FromHospital", true))[0];
            t.Text = c24.SelectedValue.ToString();



        }

        private void C22_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c22 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("FromHomeInfo", true)[0].Controls.Find("FromCity", true))[0];
            ComboBox c23 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("FromHomeInfo", true)[0].Controls.Find("FromRegion", true))[0];
            var regions = mission.Get_المناطق(int.Parse(c22.SelectedValue.ToString()));
            c23.DataSource = regions;
            c23.DisplayMember = "المنطقة";
        }

        private void _c21_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox _c21 = (ComboBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp5", true)[0].Controls.Find("c1", true))[0];
            TextBox t = (TextBox)(tableLayoutPanel20.Controls.Find("pai", true)[0].Controls.Find("tp1", true)[0].Controls.Find("tp5", true)[0].Controls.Find("ID_Patient", true))[0];
            t.Text = _c21.SelectedValue.ToString();
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            var disease = Classes.mission.Get_الحالات_by_idنوعية_الحالة(int.Parse(comboBox6.SelectedValue.ToString()));
            comboBox5.DataSource = disease;
            comboBox5.ValueMember = "رمز";
            comboBox5.DisplayMember = "المرض";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            textBox3.Text = mission.Get_MonthlyID().ToString();



            var cars = Classes.mission.Getالآليات();
            comboBox12.DataSource = cars;
            comboBox12.DisplayMember = "cars";

            var staff = Classes.mission.Get_المسعفون_by_idالمراكز(int.Parse(comboBox1.SelectedValue.ToString()));
            ComboBox _c20 = (ComboBox)(tableLayoutPanel20.Controls.Find("pi",true)[0].Controls.Find("tpi1",true)[0].Controls.Find("tpi5",true)[0].Controls.Find("Name_HeadOfShift", true))[0];
            _c20.DataSource = staff;
            _c20.ValueMember = "الرمز";
            _c20.DisplayMember = "الاسم";

            var driver= Classes.mission.Get_السائقون_by_idالمراكز(int.Parse(comboBox1.SelectedValue.ToString()));
            ComboBox _c21 = (ComboBox)(tableLayoutPanel20.Controls.Find("pi", true)[0].Controls.Find("tpi1", true)[0].Controls.Find("tp6", true)[0].Controls.Find("Name_Driver", true))[0];
            _c21.DataSource = driver;
            _c21.ValueMember = "الرمز";
            _c21.DisplayMember = "الاسم";

            var mission_resposable= Classes.mission.Get_مسؤول_مهمة_by_idالمراكز(int.Parse(comboBox1.SelectedValue.ToString()));
            ComboBox _c22 = (ComboBox)(tableLayoutPanel20.Controls.Find("pi", true)[0].Controls.Find("tpi1", true)[0].Controls.Find("tp2", true)[0].Controls.Find("Name_HeadOfMission", true))[0];
            _c22.DataSource = mission_resposable;
            _c22.ValueMember = "الرمز";
            _c22.DisplayMember = "الاسم";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 
    }
}
