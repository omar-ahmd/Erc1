﻿using Erc1.CONTROLS;
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
        ParamInformation pI = new ParamInformation();
        PatientInformation paI = new PatientInformation();
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
            paI.Invalidate();
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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {


        }


    }
}