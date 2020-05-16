using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
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
            }
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
            }
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

        private void Name_Patient_TextChanged(object sender, EventArgs e)
        {

        
        }

        private void Medicine_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
