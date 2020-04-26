using System;
using System.Drawing;
using System.Windows.Forms;

namespace Erc1.CONTROLS
{
    public partial class LabelBord : UserControl
    {
        public LabelBord()
        {
            InitializeComponent();
        }


        public event EventHandler CheckChange;


        bool check = false;
        public bool Check { get => check; set { check = value; CheckChange += LabelBord_CheckChange; CheckChange.Invoke(this, EventArgs.Empty); } }
        public string text { get => label1.Text; set => label1.Text = value; }
        public Color ForColor { get => label1.ForeColor; set => label1.ForeColor = value; }
        public Font font { get => label1.Font; set => label1.Font = value; }




        private void LabelBord_CheckChange(object sender, EventArgs e)
        {
            if (Check)
            {
                panel1.BackColor = Color.FromArgb(109, 184, 127);
            }
            else
            {
                panel1.BackColor = Color.Transparent;
            }
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            if (Check)
            {
                panel1.BackColor = Color.Transparent;
                Check = !Check;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(109, 184, 127);
                Check = !Check;
            }
        }


    }
}
