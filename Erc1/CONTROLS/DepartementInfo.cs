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
    public partial class DepartementInfo : UserControl
    {
        


        private string extention;
        private string depname;
        private int hosID;

        public int HosID
        {
            get { return hosID; }
            set { hosID = value; }
        }
        public string DepaName
        {
            get { return depname; }
            set 
            { 
                depname = value;
                DepName.Text = value;
            }
        }
        public string Extention
        {
            get { return extention; }
            set 
            { 
                extention = value;
                DepNumber.Text = value;
            }
        }

        public DepartementInfo(string number,string name)
        {
            InitializeComponent();
            DepaName = name;
            Extention = number;

        }
    }
}
