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

    public partial class PageControl : UserControl
    {

        public PageControl()
        {
            InitializeComponent();


        }
        Color whenenter = Color.Red, whenleave = Color.White;
        
        public Color Whenenter { get => whenenter; set => whenenter = value; }
        public Color Whenleave { get => whenleave; set { whenleave = value; } }

        private void PageControl_Load(object sender, EventArgs e)
        {

        }

        private void PageControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Whenenter;
        }

        private void PageControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Whenleave;
        }

        private void PageControl_Click(object sender, EventArgs e)
        {
            
        }

        public override Color BackColor { get => base.BackColor; set { base.BackColor = value; } }




    }
}
