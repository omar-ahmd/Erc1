using Erc1.CONTROLS;
using System;
using System.Collections;
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

            //var b = new BindingSource();
            //b.DataSource = centers;
            
            comboBox1.DataSource = centers;
            comboBox1.DisplayMember = "centers";
            comboBox1.ValueMember = "id";
           // MessageBox.Show(comboBox1.SelectedValue.ToString());
            comboBox1.Invalidate();
            dataGridView1.DataSource = centers;
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
            var cars = Classes.Mission.Getالآليات(int.Parse(comboBox1.SelectedValue.ToString()));
            comboBox12.DataSource = cars;
            comboBox12.DisplayMember = "cars";

            var staff = Classes.mission.Get_العاملون_by_idالمراكز(int.Parse(comboBox1.SelectedValue.ToString()));
            ComboBox _c20 = (ComboBox)(tableLayoutPanel20.Controls.Find("pi",true)[0].Controls.Find("tpi1",true)[0].Controls.Find("tpi5",true)[0].Controls.Find("Name_HeadOfShift", true))[0];
            _c20.DataSource = staff;
            _c20.ValueMember = "الرمز";
            _c20.DisplayMember = "الاسم";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 
    }
}
