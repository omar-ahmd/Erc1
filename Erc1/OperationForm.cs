using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erc1.CONTROLS;
using Erc1.Forms;
using Erc1.Forms._6_AddMission;

namespace ERC
{
    public partial class OperationForm : Form
    {
        public OperationForm()
        {
            InitializeComponent();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (int)((screen.Width + Width) / (1.8f));
            int h = Height >= screen.Height ? screen.Height : (int)((screen.Height + Height) / (1.8f));
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
            
        }

        bool normal = true;
        


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
            
            stripForAddButton sfab = new stripForAddButton();
            sfab.Dock = DockStyle.Fill;
            ContainerOfStrips.Controls.Add(sfab);
            sfab.ImpClicked += Sfab_ImpClicked;
            sfab.DelClicked += Sfab_DelClicked;
            sfab.CancClicked += Sfab_CancClicked;

        }

        private void Sfab_CancClicked(object sender, EventArgs e)
        {
            if(dm != null)
            {
                dm.Hide();
            }
            if (im != null)
            {
                im.Hide();
            }
            if (cm == null)
            {
                cm = new CanceledMission
                {
                    BackColor = Color.Black,
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true


                };
                //panel2.Controls.Clear();
                panel2.Controls.Add(cm);
            }
            cm.TopLevel = false;
            cm.TopMost = true;
            cm.Show();
            
        }
        CanceledMission cm;
        DelayedMissions dm;
        implementedmissons im;
        private void Sfab_DelClicked(object sender, EventArgs e)
        {
            if (cm!=null)
            {
                cm.Hide();
            }
            if (im != null)
            {
                im.Hide();
            }
            if (dm == null)
            {
                dm = new DelayedMissions
                {
                    BackColor = Color.Yellow,
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true

                };
                //panel2.Controls.Clear();
                panel2.Controls.Add(dm);
            }
            dm.TopLevel = false;
            dm.TopMost = true;
            dm.Show();
        }

        private void Sfab_ImpClicked(object sender, EventArgs e)
        {
            if (dm!=null)
            {
                dm.Hide();
            }
            if (cm!=null)
            {
                cm.Hide();
            }
            if (im == null)
            {
                im = new implementedmissons
                {
                    BackColor = Color.Black,
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    TopMost = true


                };
                //panel2.Controls.Clear();
                panel2.Controls.Add(im);
            }
            im.TopLevel = false;
            im.TopMost = true;
            im.Show();
            

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }

}
