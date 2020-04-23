using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace Erc1.CONTROLS
{
    public partial class SButton : UserControl
    {
        public SButton()
        {
            InitializeComponent();
        }
        public event EventHandler ButClicked;
        bool clicked = false;
        public event EventHandler ClickedChange;

        public bool Clicked { get => clicked; set { if (value != clicked) { clicked = value; ClickedChange += SButton_ClickedChange; ClickedChange.Invoke(this, EventArgs.Empty); } } }

        private void SButton_ClickedChange(object sender, EventArgs e)
        {
            if(Clicked)
            {
                this.panel1.MouseEnter -= new System.EventHandler(this.label1_Mouseenter);
                this.panel1.MouseLeave -= new System.EventHandler(this.panel1_MouseLeave);
                this.label1.MouseEnter -= new System.EventHandler(this.label1_Mouseenter);
                this.label1.MouseLeave -= new System.EventHandler(this.panel1_MouseLeave);
            }
            else
            {
                this.panel1.BackColor = Color.Transparent;
                this.label1.BackColor = Color.Transparent;
                this.panel1.MouseEnter += new System.EventHandler(this.label1_Mouseenter);
                this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
                this.label1.MouseEnter += new System.EventHandler(this.label1_Mouseenter);
                this.label1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            }
            ClickedChange -= SButton_ClickedChange;
        }

        public string labelText { get => label1.Text; set => label1.Text = value; }
        public Color panelColor { get=>panel1.BackColor; set=>panel1.BackColor=value; }
        public Color labelColor { get=>label1.BackColor; set=>label1.BackColor=value; }
        public Color textForeColor { get => label1.ForeColor; set => label1.ForeColor = value; }
        public Font textFont { get => label1.Font; set => label1.Font = value; }

        private void label1_Mouseenter(object sender, EventArgs e)
        {
            Control sen = (Control)sender;
            label1.BackColor = Color.FromArgb(94, 100, 110);
            panel1.BackColor = Color.FromArgb(108, 184, 126);

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            panel1.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Clicked)
                {
                    Clicked = true;
                    ButClicked.Invoke(this, e);
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
