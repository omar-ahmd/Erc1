using System;
using System.Windows.Forms;

namespace Erc1.Forms._6_AddMission
{
    public partial class stripForHospitals : UserControl
    {
        public stripForHospitals()
        {
            InitializeComponent();
        }


        private void sButton3_ButClicked(object sender, EventArgs e)
        {
            try
            {

                addhos.Clicked = false;
                HosClicked.Invoke(this, e);
            }
            catch (Exception)
            {


            }
        }

        private void sButton2_ButClicked(object sender, EventArgs e)
        {
            try
            {

                
                Hos.Clicked = false;
                AddHosClicked.Invoke(this, e);
            }
            catch (Exception)
            {


            }
        }







        public event EventHandler HosClicked, AddHosClicked;


    }
}
