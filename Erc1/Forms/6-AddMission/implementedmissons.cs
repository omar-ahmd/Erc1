using Erc1.CONTROLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms
{
    public enum MissionType
    {
        Implemented,
        Dlayed,
        Canceled

    }
    public partial class implementedmissons : Form
    {
        ParamInformation pI = new ParamInformation();
        PatientInformation paI = new PatientInformation();
        public implementedmissons()
        {
            InitializeComponent();


            

        }
        
        public implementedmissons(MissionType missionType)
        {
            InitializeComponent();
            switch (missionType)
            {
                case Forms.MissionType.Implemented:
                    {
                        pI.TopLevel = false;
                        pI.Dock = DockStyle.Fill;
                        tableLayoutPanel20.Controls.Add(pI, 0, 1);
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

        
    }
}
