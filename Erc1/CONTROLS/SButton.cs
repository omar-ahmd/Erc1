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
    public partial class SButton : UserControl
    {
        public SButton()
        {
            InitializeComponent();
        }

        public string labelText { get => label1.Text; set => label1.Text = value; }
        public Color panelColor { get=>panel1.BackColor; set=>panel1.BackColor=value; }
        public Color labelColor { get=>label1.BackColor; set=>label1.BackColor=value; }
        public Color textForeColor { get => label1.ForeColor; set => label1.ForeColor = value; }
        public Font textFont { get => label1.Font; set => label1.Font = value; }
        public event EventHandler Mouseenter;
        private void label1_Mouseenter(object sender, EventArgs e)
        {
            try
            {
                Mouseenter.Invoke(this, e);
            }
            catch (Exception)
            {

                
            }
        }
        public event EventHandler Mouseleave;
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Mouseleave.Invoke(this, e);
            }
            catch (Exception)
            {


            }
        }
    }
}
