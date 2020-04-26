using Erc1.CONTROLS;
using Erc1.Forms;
using Erc1.Forms._6_AddMission;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERC
{
    public partial class OperationForm : Form
    {
        bool normal = true;

        ///Add mission forms

        AddMission cm = new AddMission(MissionType.Canceled) { TopLevel = false };
        AddMission im = new AddMission(MissionType.Implemented) { TopLevel = false };
        AddMission dm = new AddMission(MissionType.Dlayed) { TopLevel = false };
        public OperationForm()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (int)((screen.Width + Width) / (1.8f));
            int h = Height >= screen.Height ? screen.Height : (int)((screen.Height + Height) / (1.8f));
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);

            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.SupportsTransparentBackColor, true);
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
        private void Add_Clicked(object sender, EventArgs e)
        {
            panel2.Controls.Add(cm);
            panel2.Controls.Add(im);
            panel2.Controls.Add(dm);
            foreach (Control cont in panel2.Controls)
            {
                cont.Size = panel2.Size;
            }


            Add.BClicked = true;
            Home.BClicked = false;
            Reports.BClicked = false;
            Hospitals.BClicked = false;
            Car.BClicked = false;
            Settings.BClicked = false;
            Paramadic.BClicked = false;

            stripForAddButton sfab = new stripForAddButton();
            sfab.Dock = DockStyle.Fill;
            ContainerOfStrips.Controls.Add(sfab);
            sfab.ImpClicked += Sfab_ImpClicked;
            sfab.DelClicked += Sfab_DelClicked;
            sfab.CancClicked += Sfab_CancClicked;

        }
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


            //MessageBox.Show(sender.GetType().ToString());
        }





        //Add Mission buttons
        private void Sfab_CancClicked(object sender, EventArgs e)
        {

            cm.Show();
            dm.Hide();
            im.Hide();

        }
        private void Sfab_DelClicked(object sender, EventArgs e)
        {
            dm.Show();
            cm.Hide();
            im.Hide();
        }
        private void Sfab_ImpClicked(object sender, EventArgs e)
        {
            im.Show();
            dm.Hide();
            cm.Hide();



        }




        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control cont in panel2.Controls)
            {
                cont.Size = panel2.Size;
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            panel2.Update();
        }

        private void OperationForm_Resize(object sender, EventArgs e)
        {
            this.Update();
            panel2.Update();
        }
    }

}
