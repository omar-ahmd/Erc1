using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms
{
    public partial class CasesOfMission : Form
    {
        ComboBox data;
        public CasesOfMission(ComboBox Data)
        {
            InitializeComponent();
            dt = new DataTable("Cases");
            //dt.Columns.Add("الرمز");
            dt.Columns.Add("الحالة");
            data = new ComboBox() ;
            data.DropDownStyle = Data.DropDownStyle;
            data.Font = Data.Font;
            data.Dock = Data.Dock;
            data.RightToLeft = Data.RightToLeft;
            data.DataSource = Data.DataSource;
            string[] da=new string[20];
            //MessageBox.Show("f");
            Data.Items.CopyTo(da, 0);
            //MessageBox.Show(da[0]);
            data.Items.Add(da[0]);
            data.Items.Add(da[1]);
            data.Items.Add(da[2]);
            data.Items.Add(da[3]);
            data.SelectedValueChanged += Data_SelectedValueChanged;
            this.tableLayoutPanel1.Controls.Add(data, 0, 1);
        }

        private void Data_SelectedValueChanged(object sender, EventArgs e)
        {
            AddCase(data.SelectedItem.ToString(), 0);
        }

        DataTable dt;
        public int AddCase(string Case,int caseID)
        {

            DataRow dr = dt.NewRow();
            dr[0] = Case;
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            return dt.Rows.Count;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
