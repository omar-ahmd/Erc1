using Erc1.CONTROLS;
using Erc1.Forms;
using Erc1.Forms._4_Hospitals;
using Erc1.Forms._6_AddMission;
using Erc1.Forms.Operations.Reports;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERC
{
    public partial class OperationForm : Form
    {
        bool normal = true;

        ///Add mission forms

        public AddMission cm;
        public AddMission im;
        public AddMission dm;

        public Erc1.Forms._5_Cars.Cars car;

        stripForAddButton sfab;
        stripForHospitals s;
        public OperationForm()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (int)((screen.Width + Width) / (1.8f));
            int h = Height >= screen.Height ? screen.Height : (int)((screen.Height + Height) / (1.8f));
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);

            this.DoubleBuffered = true;
            

        }



        private void exit_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void maximize_Clicked(object sender, EventArgs e)
        {

            if (normal)
            {
                
                this.WindowState = FormWindowState.Maximized;
                


                bunifuElipse1.ElipseRadius = 0;
                normal = false;
                





            }
            else
            {

                this.WindowState = FormWindowState.Normal;
                bunifuElipse1.ElipseRadius = 50;
                normal = true;

            }



        }
        private void minimize_Clicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }




        Reports r;

        private void Home_Clicked(object sender, EventArgs e)
        {


            Add.BClicked = false;
            Home.BClicked = false;
            Reports.BClicked = false;
            Hospitals.BClicked = false;
            Car.BClicked = false;
            Settings.BClicked = false;
            Paramadic.BClicked = false;

            Control sen = (Control)sender;
            ((MButton)(sen)).BClicked = true;

            foreach (var item in ContainerOfStrips.Controls)
            {
                ((Control)item).Hide();
            }
            foreach (Control cont in panel2.Controls)
            {
                cont.Size = panel2.Size;
                cont.Hide();
            }

            if (Add.BClicked)
            {

                
                if(sfab==null)
                {
                    sfab = new stripForAddButton();
                    sfab.Dock = DockStyle.Fill;

                    ContainerOfStrips.Controls.Add(sfab);
                    sfab.ImpClicked += Sfab_ImpClicked;
                    sfab.DelClicked += Sfab_DelClicked;
                    sfab.CancClicked += Sfab_CancClicked;
                    
                }
                else
                {
                    sfab.DelButton.Clicked = false;
                    sfab.ImpButton.Clicked = false;
                    sfab.CancButton.Clicked = false;
                    sfab.Show();

                }

            }
            else if(Home.BClicked)
            {

            }
            else if (Reports.BClicked)
            {
                if (r == null)
                {
                    r = new Reports() { TopLevel = false };
                    r.Size = panel2.Size;
                    r.Dock = DockStyle.Fill;
                    panel2.Controls.Add(r);


                }
                else
                {
                    
                }
                r.Show();
            }
            else if (Hospitals.BClicked)
            {
                if (s == null)
                {
                    s = new stripForHospitals();
                    s.Dock = DockStyle.Fill;
                    ContainerOfStrips.Controls.Add(s);
                    s.AddHosClicked -= S_AddHosClicked;
                    s.HosClicked -= S_HosClicked;
                    s.AddHosClicked += S_AddHosClicked;
                    s.HosClicked += S_HosClicked;
                }
                else
                {
                    s.Hos.Clicked = false;
                    s.addhos.Clicked = false;
                    s.Show();
                }
            }
            else if (Car.BClicked)
            {
                if (car == null || car.IsDisposed)
                {
                    car = new Erc1.Forms._5_Cars.Cars() { TopLevel = false };
                    if (car.CarsInfo == null)
                    {
                        MessageBox.Show("no data");
                        Car.BClicked = false;
                        car.Dispose();
                        return;
                    }
                    car.Size = panel2.Size;
                    car.Dock = DockStyle.Fill;
                    panel2.Controls.Add(car);
                }
                else
                {
                    if (car.CarsInfo == null)
                    {
                        MessageBox.Show("no data");
                        Car.BClicked = false;
                        return;
                    }
                }
                car.Show();

            }
            else if (Settings.BClicked)
            {
                if (setting == null)
                {
                    setting = new Erc1.Forms.Admin.Settings() { TopLevel = false } ;
                    setting.Size = panel2.Size;
                    setting.Dock = DockStyle.Fill;
                    panel2.Controls.Add(setting);

                }
                else
                {
                    
                }
                setting.Show();
            }
            else if (Paramadic.BClicked)
            {

            }





        }



        Erc1.Forms.Admin.Settings setting;


        Erc1.Forms._4_Hospitals.Hospitals h;
        //Hospital buttons
        private void S_HosClicked(object sender, EventArgs e)
        {
            

            if (h == null || h.IsDisposed)
            {
                h = new Hospitals() { TopLevel = false };
                h.Size = panel2.Size;
                h.Dock = DockStyle.Fill;

                panel2.Controls.Add(h);


            }
            h.Show();
        }
        private void S_AddHosClicked(object sender, EventArgs e)
        {
            
        }




        //Add Mission buttons
        public void Sfab_CancClicked(object sender, EventArgs e)
        {
            if (cm == null || cm.IsDisposed)
            {
                cm = new AddMission(Erc1.Forms.MissionType.Canceled) { TopLevel = false };
                cm.Size = panel2.Size;
                cm.Dock = DockStyle.Fill;
                panel2.Controls.Add(cm);
            }
            cm.Show();
            if (dm != null) dm.Hide();
            if (im != null) im.Hide();

        }
        public void Sfab_DelClicked(object sender, EventArgs e)
        {
            if (dm == null || dm.IsDisposed)
            {
                dm = new AddMission(Erc1.Forms.MissionType.Dlayed) { TopLevel = false };

                
                dm.MonthlyID.Hide();

                dm.AnnualID.Name = "ID";
                dm.paI.label20.Text = "رقم المتصل";
                dm.paI.label21.Text = "اسم المتصل";
                Control c = dm.paI.Insurance.Parent;
                dm.paI.Insurance.Dispose();

                TextBox t = new TextBox();
                t.Font = dm.paI.OtherInfo.Font;
                t.BackColor = dm.paI.OtherInfo.BackColor;
                t.Dock = DockStyle.Fill;
                t.Margin = dm.paI.OtherInfo.Margin;
                t.RightToLeft = RightToLeft.Yes;
                c.Controls.Add(t);


                dm.paI.tableLayoutPanel21.Hide();


                dm.Size = panel2.Size;
                dm.Dock = DockStyle.Fill;
                panel2.Controls.Add(dm);
            }
            dm.Show();
            if (im != null) im.Hide();
            if (cm != null) cm.Hide();
        }
        public void Sfab_ImpClicked(object sender, EventArgs e)
        {
            
            
            if (im == null||im.IsDisposed)
            {
                im = new AddMission(Erc1.Forms.MissionType.Implemented) { TopLevel = false };
                im.Size = panel2.Size;
                im.Dock = DockStyle.Fill;
                
                panel2.Controls.Add(im);
                
                
            }
            im.Show();
            if(dm!=null) dm.Hide();
            if(cm!=null) cm.Hide();
            



        }


    }

}
