using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.CONTROLS
{
    public partial class MButton : UserControl 
    {
        
        public MButton()
        {
            InitializeComponent();
            
        }

        public string BText { get => this.label3.Text; set => this.label3.Text = value; }

        public  Image BImage { get => this.pictureBox3.Image; set => this.pictureBox3.Image = value; }


        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Control sen = (Control)sender;

            string name = sen.Name;
            if (name.StartsWith("label"))
            {
                sen.BackColor = Color.FromArgb(113, 120, 132);
                string name_1 = name.Split('l')[2];
                //MessageBox.Show(name_1);
                Control sen_1 = sen.Parent.Controls[("tableLayout" + name_1)];
                sen_1.BackColor = Color.FromArgb(108, 184, 126);
            }
            else if (name.StartsWith("picture"))
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
                sen.BackColor = Color.Transparent;
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
                sen_1.BackColor = Color.Transparent;
            }
        }

        public event EventHandler Clicked;

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                Clicked.Invoke(this, e);
            }
            catch (Exception)
            {

                
            }
        }
    }
}
