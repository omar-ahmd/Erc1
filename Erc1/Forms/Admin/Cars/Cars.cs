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

namespace Erc1.Forms.Admin
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            try
            {
                MyFunction.FillComboBox(Center, BAL.addMission.Get_centers(), "centers", "id");
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            الآليات car = new الآليات();
            try
            {

                car.رمز_الآلية = int.Parse(CarId.Text);
                car.المركز = int.Parse(Center.SelectedValue.ToString());
                car.بالخدمة_او_لا = true;
                car.نوعية_الاستخدام = comboBox1.Text;
                car.موديل_ = textBox1.Text;
                car.نوعية_السيارة = textBox3.Text;
                car.رقم_اللوحة = int.Parse(textBox2.Text);
                if(comboBox2.Text == "بنزين")
                {
                    car.مازوت_او_بنزين = true;
                }
                else
                {
                    car.مازوت_او_بنزين = false;
                }
                 
            }
            catch
            {

            }

            if (BAL.Cars.AddCar(car))
            {

            }
            else
            {

            }
            dataGridView1.DataSource = BAL.Cars.GetCars();
        }

        private void Cars_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BAL.Cars.GetCars();
        }

        private void CarId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int carid = int.Parse(CarId.Text);

                الآليات hosp = BAL.Cars.Get_Car_Info(carid);

                CarId.Text = hosp.رمز_الآلية.ToString();
                Center.SelectedValue = hosp.المركز;
                comboBox1.Text = hosp.نوعية_الاستخدام;
                textBox1.Text = hosp.موديل_;
                textBox3.Text = hosp.نوعية_السيارة;
                textBox2.Text = hosp.رقم_اللوحة.ToString();
                if (hosp.مازوت_او_بنزين == true)
                {
                    comboBox2.Text = "بنزين";
                }
                else
                {
                    comboBox2.Text = "مازوت";
                }


            }
            catch
            {
                Center.SelectedValue = "";
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
            }
        }
    }
}
