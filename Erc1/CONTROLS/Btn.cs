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
    public partial class Btn : UserControl
    {
        public event EventHandler conClick;
        public Btn()
        {
            InitializeComponent();
        }
        public string text 
        {
            get {return CarId.Text; }
            set {CarId.Text = value; }
        }
        public Font font
        {
            get { return CarId.Font; }
            set { CarId.Font = value; }
        }

        private void CarId_Click(object sender, EventArgs e)
        {
            conClick.Invoke(this, EventArgs.Empty);
        }
    }
}
