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



        private void OperationForm_Load(object sender, EventArgs e)
        {



        }
        
        bool normal = true;
        

        private void pageControl2_Click(object sender, EventArgs e)
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



        private void pageControl1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pageControl3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
