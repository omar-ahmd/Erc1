using Erc1.CONTROLS;
using System;
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
        public PatientInformation paI;
        public ParamInformation pI;
        public Erc1.BAL.MissionType type { get; set; }
        public AddMission()
        {
            InitializeComponent();
            /*this.SetStyle(ControlStyles.UserPaint
                        | ControlStyles.OptimizedDoubleBuffer
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.SupportsTransparentBackColor, true);*/

            this.DoubleBuffered = true;
            type = BAL.MissionType.Cold;
            
        }

        public static void EnableDoubleBuff(Control c)
        {
            PropertyInfo DemoProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            DemoProp.SetValue(c, true, null);
        }

        private MissionType missionTy;

        public MissionType MissionTy
        {
            get { return missionTy; }
            set { missionTy = value; }
        }

        public AddMission(MissionType missionType)
        {
            InitializeComponent();
            missionTy = missionType;
            switch (missionType)
            {
                case Forms.MissionType.Implemented:
                    {
                        pI = new ParamInformation();
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
            MessageBox.Show("dd");
            cM = new CasesOfMission(Case);
            //cM.comboBox1.DataSource = Case.DataSource;
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

        private void AddMission_Load(object sender, EventArgs e)
        {
            Day.DropDownHeight = Day.ItemHeight * 5;
            Month.DropDownHeight = Month.ItemHeight * 5;
            Year.DropDownHeight = Year.ItemHeight * 5;

            Month.SelectedItem = DateTime.Now.Day.ToString("D2");
            Day.SelectedItem = DateTime.Now.Month.ToString("D2");
            Year.SelectedItem = DateTime.Now.Year.ToString("D2");

            int dayinmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            


            Time.Value = DateTime.Now;


        }
        bool l = false;
        private void Month_SelectedValueChanged(object sender, EventArgs e)
        {
            
            Day.Items.Clear();
            int dayinmonth;
            if(!l)
            {
                dayinmonth = DateTime.DaysInMonth((int)(DateTime.Now.Year), (int)(DateTime.Now.Month));
                l = true;
            }
            else
            {
                dayinmonth = DateTime.DaysInMonth(int.Parse(Year.SelectedItem.ToString()), int.Parse(Month.SelectedItem.ToString()));
            }
            for (int i = 1; i <= dayinmonth; i++)
            {
                Day.Items.Add(i.ToString("D2"));
            }

            
        }

        private void UrgentMission_CheckChange(object sender, EventArgs e)
        {
            if (UrgentMission.Check)
            {
                
                type = BAL.MissionType.Urgent;
                ColdMission.Check = false;
                FireMission.Check = false;
                ActivityMission.Check = false;


            }
            
            
            
        }

        private void ColdMission_CheckChange(object sender, EventArgs e)
        {
            if (ColdMission.Check)
            {
                type = BAL.MissionType.Cold;
                UrgentMission.Check = false;
                FireMission.Check = false;
                ActivityMission.Check = false;
            }
        }

        private void ActivityMission_CheckChange(object sender, EventArgs e)
        {
            if (ActivityMission.Check)
            {
                type = BAL.MissionType.Activity;
                ColdMission.Check = false;
                FireMission.Check = false;
                UrgentMission.Check = false;
            }
        }

        private void FireMission_CheckChange(object sender, EventArgs e)
        {
            if (FireMission.Check)
            {
                type = BAL.MissionType.Fire;
                ColdMission.Check = false;
                UrgentMission.Check = false;
                ActivityMission.Check = false;
            }
        }
        CasesOfMission cM;
        private void Save_Click(object sender, EventArgs e)
        {
            cM.Show();
            
        }

        private void Case_SelectedValueChanged(object sender, EventArgs e)
        {
            cM.AddCase(Case.SelectedItem.ToString(), 8);
        }
    }
}
