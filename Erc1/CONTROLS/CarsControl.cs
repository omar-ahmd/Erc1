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
    public partial class CarsControl : UserControl
    {
        public CONTROLS.Teams t;


        public event EventHandler conClick,conEntered,conLeft;


        private bool clicked = false;

        private bool entered = false; 

        public bool Entered
        {
            get { return entered; }
            set 
            {
                entered = value;
            }
        }

        public bool Clicked
        {
            get { return clicked; }
            set 
            { 
                clicked = value;
                
            }
        }
        public Font f
        {
            get { return CarId.Font; }
            set { CarId.Font = value; }

        }

        public CarsControl()
        {
            InitializeComponent();
        }
        private int carID = 0;

        public int CarID
        {
            get { return carID; }
            set 
            {

                    carID =value;
                    CarId.Text = value.ToString();

            }
        }

        private int centerID;

        public int CenterID
        {
            get { return centerID; }
            set
            {
                centerID = value;
            }
        }

        private void CarId_Click(object sender, EventArgs e)
        {
            if (Clicked) Clicked = false;
            else Clicked = true;
            conClick.Invoke(this, EventArgs.Empty);
        }

        private void CarId_MouseEnter(object sender, EventArgs e)
        {
            
            Entered = true;
            conEntered.Invoke(this, EventArgs.Empty);
        }

        private void CarId_MouseLeave(object sender, EventArgs e)
        {
            Entered = false;
            conLeft.Invoke(this, EventArgs.Empty);
        }
    }
}
