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
    public partial class Teams : UserControl
    {
        public Teams()
        {
            InitializeComponent();
        }
        private int iD;

        public int Id
        {
            get { return iD; }
            set 
            {
                iD = value;
                ID.Text = value.ToString();
            }
        }

    }
}
