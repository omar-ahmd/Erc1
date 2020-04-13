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

namespace ERC
{
    public partial class OperationForm : Form
    {
        public OperationForm()
        {
            InitializeComponent();
            // StartPosition was set to FormStartPosition.Manual in the properties window.


        }



        private void OperationForm_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (int)((screen.Width + Width) / (1.8f));
            int h = Height >= screen.Height ? screen.Height : (int)((screen.Height + Height) / (1.8f));
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            
            this.Size = new Size(w, h);


        }



        private void OperationForm_ClientSizeChanged(object sender, EventArgs e)
        {

            if (this.Size.Width < 800)
            {


                //pictureBox3.Hide();

            }
            else
            {

                //button1.Text = "الصفحة الرئيسية";
                //button2.Text = "التقارير";
                //button3.Text = "المستشفيات";
                //button4.Text = "سيارات الاسعاف";
                //button5.Text = "اضافة مهمة";
                //button6.Text = "اعدادات";
                //pictureBox3.Show();
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Control sen = (Control)sender;

            string name = sen.Name;
            if(name.StartsWith("label"))
            {
                sen.BackColor = Color.FromArgb(113, 120, 132);
                string name_1 = name.Split('l')[2];
                //MessageBox.Show(name_1);
                Control sen_1 = sen.Parent.Controls[("tableLayout" + name_1)];
                sen_1.BackColor= Color.FromArgb(108, 184, 126);
            }
            else if(name.StartsWith("picture"))
            {
                sen.Parent.BackColor = Color.FromArgb(108, 184, 126);
                string name_1 = name.Split('x')[1];
                //MessageBox.Show(name_1);
                Control sen_1 = sen.Parent.Parent.Controls["label" + name_1];
                sen_1.BackColor = Color.FromArgb(113, 120, 132);
            }
 
         


        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Control sen = (Control)sender;
            string name = sen.Name;
            if (name.StartsWith("label"))
            {
                sen.BackColor = Color.FromArgb(143, 148, 158);
                string name_1 = name.Split('l')[2];
                //MessageBox.Show(name_1);
                Control sen_1 = sen.Parent.Controls[("tableLayout" + name_1)];
                sen_1.BackColor = Color.Transparent;
            }
            else if (name.StartsWith("picture"))
            {
                sen.Parent.BackColor = Color.Transparent;
                string name_1 = name.Split('x')[1];
                //MessageBox.Show(name_1);
                Control sen_1 = sen.Parent.Parent.Controls["label" + name_1];
                //MessageBox.Show(sen_1.ToString());
                sen_1.BackColor = Color.FromArgb(143, 148, 158);
            }




        }



        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            Control sen =(PictureBox)sender;
            sen.BackColor = Color.FromArgb(222, 54, 66);
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            Control sen = (PictureBox)sender;
            sen.BackColor = Color.FromArgb(255,255,255);
        }

        private void tableLayoutPanel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            Control sen = (PictureBox)sender;
            sen.BackColor = Color.FromArgb(108, 184, 126);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool normal = true;
        private void pictureBox11_Click(object sender, EventArgs e)
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }
    }
}
