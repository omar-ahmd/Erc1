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
            if(available)
            {
                button1.BackColor = Color.Red;
                available = false;
                Busy = true;
            }
            else if(Busy)
            {
                button1.BackColor = Color.Orange;
                MidBusy = true;
                Busy = false;
            }
            else if(MidBusy)
            {
                button1.BackColor = Color.Green;
                MidBusy = false;
                available = true;
            }

            using (ERCEntities3 db = new ERCEntities3())
            {

                
                departement.اسم_القسم = "الطوائ";


                db.أقسام_المستشفيات.Add(departement);
                db.SaveChanges();

            }
        }
        int row=0, column=1;
        
        private void button2_Click(object sender, EventArgs e)
        {
       
            int startX = button1.Location.X, startY = button1.Location.Y;
            int width = button1.Width, heigh = button1.Height;
            Button bt = new Button();
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
}
