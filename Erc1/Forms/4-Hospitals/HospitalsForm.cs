using ERC;
using Erc1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms._4_Hospitals
{


    public partial class HospitalsForm : Form
    {
        public HospitalsForm()
        {
            InitializeComponent();
        }
        bool available = true;
        bool Busy = false;
        bool MidBusy = false;
        أقسام_المستشفيات departement = new أقسام_المستشفيات();
        private void button1_Click(object sender, EventArgs e)
        {
            Mybutton sen = (Mybutton)sender;
            if (sen.available)
            {
                sen.BackColor = Color.Red;
                sen.available = false;
                sen.Busy = true;
            }
            else if (sen.Busy)
            {
                sen.BackColor = Color.Orange;
                sen.MidBusy = true;
                sen.Busy = false;
            }
            else if (sen.MidBusy)
            {
                sen.BackColor = Color.FromArgb(109, 184, 127) ;
                sen.MidBusy = false;
                sen.available = true;
            }

        }
        int row=0, column=1;
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            int startX = button1.Location.X, startY = button1.Location.Y;
            int width = button1.Width, heigh = button1.Height;
            Mybutton bt = new Mybutton();
            bt.Click += button1_Click;
            bt.Text = "H";

            bt.Font = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            bt.BackColor = Color.FromArgb(109, 184, 127);
            bt.Location = button2.Location;
            bt.Size = button2.Size;
            bt.Text = "hos";
            panel1.Controls.Add(bt);
            if (button2.Location.X + 2 * button2.Size.Width + 20 > panel1.Width) 
            {
                row++;
                column = 0;
                
            }
            else
            {
                column++;
               
            }
            button2.Location = new Point(startX + column * (width + startX), startY + row * (startY + heigh));
        }
    }
    public class Mybutton : Button
    {
        public bool available = true;
        public bool Busy = false;
        public bool MidBusy = false;


    }
}
