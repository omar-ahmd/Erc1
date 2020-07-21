using dotnetCHARTING.WinForms;
using Erc1.BAL;
using Erc1.Forms.Admin.Volunteers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms.Operations.Reports
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            try
            {
                centers.Items.Add("all");
                MyFunction.FillComboBox(centers, BAL.addMission.Get_centers(), "id", "centers");
                MyFunction.FillComboBox(volunteers,BAL.Employees.Get_Employees() , "الاسم", "الرمز");
                MyFunction.FillComboBox(CaseType, BAL.addMission.Get_CasesType(), "النوعية", "الرمز");
                MyFunction.FillComboBox(Patient, BAL.PatientInfo.GetPatients(), "اسم", "الرمز");
                centers.SelectedValueChanged += Centers_SelectedValueChanged;



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Centers_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                MyFunction.FillComboBox(Cars, BAL.addMission.GetCars(int.Parse(centers.SelectedValue.ToString())), "cars", "cars");


            }
            catch
            {
                Cars.DataSource = null;
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void view_Click(object sender, EventArgs e)
        {
            
            int? y, m;
            try
            {
                y = int.Parse(year.Text);
                
            }
            catch
            {
                y = null;
            }
            try
            {
                m = int.Parse(Months.Text);
            }
            catch
            {
                m = null;
            }
            int? c = (int?)centers.SelectedValue
                , ca = (int?)CaseType.SelectedValue
                , v = (int?)volunteers.SelectedValue
                , car = (int?)Cars.SelectedValue
                ,p= (int?)Patient.SelectedValue;
            dataGridView1.DataSource = Classes.mission.Get_Missions(y,m ,c ,ca ,v ,car ,p );
            label9.Text = dataGridView1.Rows.Count.ToString() + "مهمة";
        }
        int Cid;
        string CategorieName;
        Chart chart;
        //DataTable Count;
        DataColumn CatName;
        void draw(DataTable Count)
        {
            try { chart.Dispose(); }
            catch { }

            
            chart = new Chart();
            chart.Use3D = true;
            chart.Dock = DockStyle.Fill;
            chart.Type = ChartType.Combo;
            foreach (DataRow dr in Count.Rows)
            {
                Element element = new Element(dr["Month"].ToString(), float.Parse(dr["Missions Number"].ToString()));
                element.Annotation = new Annotation(dr["Missions Number"].ToString());
                ElementCollection eCollection = new ElementCollection();
                eCollection.Add(element);
                Series serie = new Series(dr["Month"].ToString(), eCollection);
                chart.SeriesCollection.Add(serie);
            }
            Form d = new Form();
            d.WindowState = FormWindowState.Maximized;
            chart.Dock = DockStyle.Fill;
            d.Controls.Add(chart);
            d.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            char i = ((Button)sender).Name[1];
            MessageBox.Show(i.ToString());
            try
            {


                switch (i)
                {
                    case '1':
                        {

                            draw(Classes.mission.MissionsInYear(int.Parse(year.Text)));
                            break;
                        }
                    case '3':
                        {
                            draw(Classes.mission.MissionsInYearByCar(int.Parse(year.Text), (int)Cars.SelectedValue));
                            break;
                        }
                    case '2':
                        {
                            draw(Classes.mission.MissionsInYearByCaseType(int.Parse(year.Text), (int)CaseType.SelectedValue));
                            break;
                        }
                    case '4':
                        {
                            draw(Classes.mission.MissionsInYearByVolunteer(int.Parse(year.Text), (int)volunteers.SelectedValue));
                            break;
                        }
                    case '5':
                        {
                            draw(Classes.mission.MissionsInYear(int.Parse(year.Text),(int)centers.SelectedValue));
                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                

            }

        }
    }
}
