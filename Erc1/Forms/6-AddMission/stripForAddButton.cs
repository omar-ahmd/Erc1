using System;
using System.Windows.Forms;

namespace Erc1.Forms._6_AddMission
{
    public partial class stripForAddButton : UserControl
    {
        public stripForAddButton()
        {
            InitializeComponent();
        }


        private void sButton3_ButClicked(object sender, EventArgs e)
        {
            try
            {

                sButton2.Clicked = false;
                sButton1.Clicked = false;
                DelClicked.Invoke(this, e);
            }
            catch (Exception)
            {


            }
        }

        private void sButton2_ButClicked(object sender, EventArgs e)
        {
            try
            {

                sButton1.Clicked = false;
                sButton3.Clicked = false;
                CancClicked.Invoke(this, e);
            }
            catch (Exception)
            {


            }
        }



        private void sButton1_ButClicked(object sender, EventArgs e)
        {
            try
            {

                sButton2.Clicked = false;
                sButton3.Clicked = false;

                ImpClicked.Invoke(this, e);



            }
            catch (Exception)
            {


            }
        }



        public event EventHandler ImpClicked, DelClicked, CancClicked;


    }
}
