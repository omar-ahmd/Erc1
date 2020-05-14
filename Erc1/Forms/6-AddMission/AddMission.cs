using Erc1.BAL;
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
        public Erc1.BAL.MissionType type { get; set; }
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

        CasesOfMission cM;



        Thread ImportCasesType, ImportCenter, ImportCases;
        IEnumerable casetype = null, centers = null, Cases = null;

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
            cM = new CasesOfMission(Case);

            






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
            ImportCasesType = new Thread(() => { casetype = addMission.Get_CasesType(); });
            ImportCenter = new Thread(() => { centers = addMission.Get_centers(); });
            ImportCases = new Thread(() => { Cases = addMission.GetCases(); }) ;

            ImportCasesType.Start();
            ImportCenter.Start();
            ImportCases.Start();

            ImportCenter.Join();
            ImportCasesType.Join();
            ImportCases.Join();


            CenterID.DataSource = centers;
            CenterID.ValueMember = "id";
            CenterID.DisplayMember = "centers";
            CenterID.SelectedValueChanged += CenterID_SelectedValueChanged;

            CaseType.DataSource = casetype;
            CaseType.ValueMember = "الرمز";
            CaseType.DisplayMember = "النوعية";

            CenterAdded = true;
            CenterID.SelectedValue = 200;
            CenterID.SelectedValue = 100;

            Case.DataSource = Cases;
            Case.ValueMember = "رمز";
            Case.DisplayMember = "المرض";


            
            
            Year.SelectedItem = DateTime.Now.Year.ToString("D2");
            Month.SelectedItem = DateTime.Now.Month.ToString("D2");
            Day.SelectedItem = DateTime.Now.Day.ToString("D2");

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
        bool CenterAdded = false;
        private void CenterID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CenterAdded)
            {
                CarId.DataSource = addMission.GetCars(int.Parse(CenterID.SelectedValue.ToString()));
                CarId.ValueMember = "id";
                CarId.DisplayMember = "cars";



                IEnumerable HeadOfshift = addMission.GetWorkers(int.Parse(CenterID.SelectedValue.ToString()));
                IEnumerable HeadOfmission = addMission.GetWorkers(int.Parse(CenterID.SelectedValue.ToString()));
                IEnumerable paramedic1 = addMission.GetWorkers(int.Parse(CenterID.SelectedValue.ToString()));
                IEnumerable paramedic2 = addMission.GetWorkers(int.Parse(CenterID.SelectedValue.ToString()));
                IEnumerable recipientOfMission = addMission.GetWorkers(int.Parse(CenterID.SelectedValue.ToString()));

                string valuem = "الرمز", Display = "الاسم";

                try
                {
                    pI.Name_HeadOfMission.DataSource = HeadOfmission;
                    pI.Name_HeadOfMission.ValueMember = valuem;
                    pI.Name_HeadOfMission.DisplayMember = Display;
                    if (pI.Name_HeadOfMission.SelectedValue != null)
                    {
                        pI.ID_HeadOfMission.Text = pI.Name_HeadOfMission.SelectedValue.ToString();
                    }
                    pI.Name_HeadOfMission.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

                    pI.Name_HeadOfShift.DataSource = HeadOfshift;
                    pI.Name_HeadOfShift.ValueMember = valuem;
                    pI.Name_HeadOfShift.DisplayMember = Display;
                    if (pI.Name_HeadOfShift.SelectedValue != null)
                    {
                        pI.ID_HeadOfShift.Text = pI.Name_HeadOfShift.SelectedValue.ToString();
                    }
                    pI.Name_HeadOfShift.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

                    pI.Name_Paramedic1.DataSource = paramedic1;
                    pI.Name_Paramedic1.ValueMember = valuem;
                    pI.Name_Paramedic1.DisplayMember = Display;
                    if (pI.Name_Paramedic1.SelectedValue != null)
                    {
                        pI.ID_Paramedic1.Text = pI.Name_Paramedic1.SelectedValue.ToString();
                    }
                    pI.Name_Paramedic1.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

                    pI.Name_Paramedic2.DataSource = paramedic2;
                    pI.Name_Paramedic2.ValueMember = valuem;
                    pI.Name_Paramedic2.DisplayMember = Display;
                    if (pI.Name_Paramedic2.SelectedValue != null)
                    {
                        pI.ID_Paramedic2.Text = pI.Name_Paramedic2.SelectedValue.ToString();
                    }
                    pI.Name_Paramedic2.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;

                    pI.Name_RecipientOfMission.DataSource = recipientOfMission;
                    pI.Name_RecipientOfMission.ValueMember = valuem;
                    pI.Name_RecipientOfMission.DisplayMember = Display;

                        pI.ID_RecipientOfMission.Text = pI.Name_RecipientOfMission.SelectedValue.ToString();
                    

                    pI.Name_RecipientOfMission.SelectedValueChanged += pI.Name_HeadOfMission_SelectedValueChanged;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
