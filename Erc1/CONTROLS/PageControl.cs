using System;
using System.Windows.Forms;

namespace Erc1.CONTROLS
{

    public partial class PageControl : UserControl
    {

        public PageControl()
        {
            InitializeComponent();


        }

        public event EventHandler Clicked;
        public enum Type
        {

            maximize,
            minimize,
            exit
        }
        public Type MyType { get; set; } = Type.maximize;


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            switch (MyType)
            {
                case Type.maximize:
                    pic.Image = Erc1.Properties.Resources.GreenCircle;
                    break;
                case Type.minimize:
                    pic.Image = Erc1.Properties.Resources.GreenCircle;
                    break;
                case Type.exit:
                    pic.Image = Erc1.Properties.Resources.RedCircle;
                    break;
                default:
                    break;
            }


        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Image = Erc1.Properties.Resources.whitecircle;
        }
        protected void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Clicked.Invoke(this, e);
            }
            catch (Exception)
            {


            }

        }



    }
}
