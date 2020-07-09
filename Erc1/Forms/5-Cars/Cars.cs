using Erc1.BAL;
using Erc1.CONTROLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms._5_Cars
{
    public partial class Cars : Form
    {
        DataTable CarsInfo;
        public Cars()
        {
            InitializeComponent();
            
            CarsInfo = ImportFromDrive.ReadEnteries();

        }

        private void carsControl1_conClick(object sender, EventArgs e)
        {
        }

        private void carsControl1_conClick_1(object sender, EventArgs e)
        {
            CarsControl carbt = (CarsControl)sender;

            if (carbt.Clicked || carbt.Entered)
            {
                Teams p = new CONTROLS.Teams()
                {
                    Size = TeamContainer.Size,
                    Id = carbt.CarID,
                    CenterId = carbt.CenterID

                };
        
                TeamContainer.SuspendLayout();
                TeamContainer.Controls.Add(p);
                TeamContainer.ResumeLayout();
        
               
            }
            else { TeamContainer.Controls.Clear(); }

        }

        private void Cars_Load(object sender, EventArgs e)
        {
            //get centers
            //get cars according to the center
            
            int i = 1;
            var Centers = BAL.addMission.Get_centers();
            Size ca = carsControl5.Size;
            carsControl5.Dispose();
            panel1.SuspendLayout();
            foreach (dynamic center in Centers)
            {
                FlowLayoutPanel centerflowlayout;
                if (i > 1)
                {
                    centerflowlayout = new FlowLayoutPanel();
                    centerflowlayout.Dock = System.Windows.Forms.DockStyle.Bottom;
                    centerflowlayout.Size = new Size(panel1.Size.Height / i, 2 * ca.Height + 10);
                    centerflowlayout.AutoScroll = true;
                    centerflowlayout.Location = new Point(0, 0);
                    centerflowlayout.Margin = new System.Windows.Forms.Padding(0);
                    centerflowlayout.Name = "_" + i.ToString() + "Center";
                }
                else
                {
                    centerflowlayout = _1Center;
                    centerflowlayout.Size = new Size(panel1.Size.Height / i, 2 * ca.Height + 10);
                }


                string cen = center.ToString();
                int centerID = int.Parse(cen.Split(',')[0].Split('=')[1].Replace(" ", string.Empty));
                var Ambulances = BAL.Cars.getAmbulances(centerID);

                foreach (dynamic item in Ambulances)
                {

                    bool existe = false;

                    string dd = item.ToString();
                    int idd = int.Parse(dd.Substring(9, 3));

                    foreach (DataRow dr in CarsInfo.Rows)
                    {
                        if (dr[0].ToString() == idd.ToString())
                        {
                            existe = true;
                        }
                    }



                    CarsControl c = new CarsControl();
                    c.Size = ca;

                    c.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;


                    c.CarID = idd;
                    c.CenterID = centerID;
                    c.Clicked = false;
                    c.Entered = false;

                    if (!existe)
                    {
                        c.Enabled = false;
                    }



                    c.conClick += carsControl1_conClick_1;
                    c.conEntered += carsControl1_conClick_1;
                    c.conLeft += carsControl1_conClick_1;

                    centerflowlayout.Controls.Add(c);
                

                }
                

                

                panel1.Controls.Add(centerflowlayout);
                i++;
            }
            panel1.ResumeLayout();

        }
    }
}
