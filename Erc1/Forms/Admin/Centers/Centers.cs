using Erc1.BAL;
using Erc1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms.Admin.Centers
{
    public partial class Centers : Form
    {
        public Centers()
        {
            InitializeComponent();
            try
            {
                MyFunction.FillComboBox(City, BAL.PatientInfo.GetCities(), "المدينة", "رمز");
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            المراكز center = new المراكز();
            try
            {
                
                center.الرمز = int.Parse(Center.Text);
                center.المدينة = int.Parse(City.SelectedValue.ToString());
                center.تاريخ_التاسيس = ParticipationDate.Value;
            }
            catch
            {

            }

            if (BAL.center.AddCenter(center))
            {

            }
            else
            {

            }
            dataGridView1.DataSource = BAL.center.GetCenters();
        }

        private void Centers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BAL.center.GetCenters();
        }

        private void Center_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int centerid = int.Parse(Center.Text);

                المراكز hosp = BAL.center.GetCenter(centerid);

                Center.Text = hosp.الرمز.ToString();
                City.SelectedValue = hosp.المدينة;
                ParticipationDate.Value = (DateTime)hosp.تاريخ_التاسيس;


            }
            catch
            {
                
                City.SelectedValue = "";
                ParticipationDate.Value = DateTime.Now;
            }
        }
    }
}
