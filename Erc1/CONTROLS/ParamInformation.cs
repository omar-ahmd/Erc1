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

        public void Name_HeadOfMission_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)this.Controls["param"].Controls[na].Controls["ID" + "_" + na];
            if (sen.SelectedValue != null)
            {
                t.Text = sen.SelectedValue.ToString();
            }
            else
            {
                t.Text = "";
            }

        }

        private void Name_HeadOfShift_DisplayMemberChanged(object sender, System.EventArgs e)
        {
            ComboBox sen = (ComboBox)sender;
            string na = sen.Name.Split('_')[1];
            TextBox t = (TextBox)this.Controls["param"].Controls[na].Controls["ID" + "_" + na];
            t.Text = "";
        }
    }
}
