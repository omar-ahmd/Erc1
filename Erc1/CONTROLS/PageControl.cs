using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erc1;

namespace Erc1.CONTROLS
{

    public partial class PageControl : UserControl
    {

        public PageControl()
        {
            InitializeComponent();


        }
        

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
        public event EventHandler Clicked;

        
    }
}
