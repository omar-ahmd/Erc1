using Erc1.BAL;
using Erc1.Classes;
using Erc1.CONTROLS;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading;
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

        public event EventHandler SaveMission;
        public CasesOfMission cM;
        bool l = false;


        private Erc1.BAL.MissionType type=Erc1.BAL.MissionType.Cold;
        private MissionType missionTy;

        public Erc1.BAL.MissionType Type { get { return type; } set {type=value; } }
        
        public MissionType MissionTy
        {
            get { return missionTy; }
            set { missionTy = value; }
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




        public AddMission(MissionType missionType)
        {
            InitializeComponent();

            Year.SelectedItem = DateTime.Now.Year.ToString("D2");
            Month.SelectedItem = DateTime.Now.Month.ToString("D2");
            Day.SelectedItem = DateTime.Now.Day.ToString("D2");
            Time.Value = DateTime.Now;
            this.DoubleBuffered = true;
            System.Reflection.PropertyInfo a = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            MissionTy = missionType;


            switch (missionType)
            {
                case Forms.MissionType.Implemented:
                    {
                        pI = new ParamInformation();
                        paI = new PatientInformation();
                        pI.TopLevel = false;
                        pI.Dock = DockStyle.Fill;
                        tableLayoutPanel20.Controls.Add(pI, 0, 1);
                        
                        pI.Show();

                        paI.TopLevel = false;
                        paI.Dock = DockStyle.Fill;
                        tableLayoutPanel20.Controls.Add(paI, 0, 1);

                        paI.Hide();
                        button2.Show();

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
        private void button1_Click(object sender, EventArgs e)
        {
            panel9.BackgroundImage = Erc1.Properties.Resources._12;

            pI.Show();
            paI.Hide();



        }
        private void AddMission_Load(object sender, EventArgs e)
        {

            BAL.addMission.FillAddMissionForm(this);
            Case.SelectedValueChanged += Case_SelectedValueChanged;
            



        }

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
                if (MissionTy == Forms.MissionType.Implemented)
                {
                    MonthlyID.Text = mission.Get_MonthlyID(int.Parse(Year.SelectedItem.ToString()), int.Parse(Month.SelectedItem.ToString())).ToString();
                    AnnualID.Text = mission.Get_YearID(int.Parse(Year.SelectedItem.ToString())).ToString();
                }
                

            }
            for (int i = 1; i <= dayinmonth; i++)
            {
                Day.Items.Add(i.ToString("D2"));
            }
            Year.SelectedValueChanged += Month_SelectedValueChanged;


        }



        private void UrgentMission_CheckChange(object sender, EventArgs e)
        {
            if (UrgentMission.Check)
            {
                Type = BAL.MissionType.Urgent;
                ColdMission.Check = false;
            }
            
            
            
        }
        private void ColdMission_CheckChange(object sender, EventArgs e)
        {
            if (ColdMission.Check)
            {
                
                Type = BAL.MissionType.Cold;
                UrgentMission.Check = false;
                
            }
        }
        private void ActivityMission_CheckChange(object sender, EventArgs e)
        {
            /*if (ActivityMission.Check)
            {
                type = BAL.MissionType.Activity;
                
                FireMission.Check = false;
                
            }*/
        }
        private void FireMission_CheckChange(object sender, EventArgs e)
        {
            /*if (FireMission.Check)
            {
                type = BAL.MissionType.Fire;

                ActivityMission.Check = false;
            }*/
        }


        public void CenterID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CenterID.SelectedItem != null)
            {
                CarId.DataSource = addMission.GetCars(int.Parse(CenterID.SelectedValue.ToString()));
                CarId.DisplayMember = "cars";
                CarId.SelectedItem = null;
                bool done=BAL.ParamedicsInfo.FillParamForm(pI, this);
                if(!done)
                {
                    MessageBox.Show("error on importing data from database");
                    return;
                }
            }
            




        }

        private void ShowCase_Click(object sender, EventArgs e)
        {
            if (cM == null)
            {
                cM = new CasesOfMission(Case);
            }
            cM.Show();
            
        }
        private void Case_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cM==null)
            {
                cM = new CasesOfMission(Case);
            }
            if (Case.SelectedValue != null)
            {
                cM.AddCase(Case.Text, int.Parse(Case.SelectedValue.ToString()));
            }
            cM.dataGridView1.UserDeletedRow -= DataGridView1_UserDeletedRow;
            cM.dataGridView1.UserDeletedRow += DataGridView1_UserDeletedRow;
            cM.dataGridView1.RowsAdded -= DataGridView1_RowsAdded;
            cM.dataGridView1.RowsAdded += DataGridView1_RowsAdded;
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (cM.SelectedCases.Rows.Count == 0)
            {
                Case.SelectedItem = null;
            }
            else
            {
                Case.SelectedValue = int.Parse((cM.SelectedCases.Rows[cM.SelectedCases.Rows.Count - 1]["ID"]).ToString());
            }
            
        }

        private void DataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if(cM.SelectedCases.Rows.Count==0)
            {
                Case.SelectedItem = null;

            }
            else
            {
                Case.SelectedValue = int.Parse((cM.SelectedCases.Rows[cM.SelectedCases.Rows.Count-1]["ID"]).ToString());
            }
        }

        private void Case_DisplayMemberChanged(object sender, EventArgs e)
        {
            
        }


    }
}
