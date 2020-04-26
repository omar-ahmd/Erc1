using System.Windows.Forms;

namespace Erc1.CONTROLS
{
    public partial class ParamInformation : Form
    {
        public ParamInformation()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
    }
}
