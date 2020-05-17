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
        ComboBox data, da;
        public DataTable SelectedCases;

        public CasesOfMission(ComboBox Data)
        {
            InitializeComponent();
            SelectedCases = new DataTable();
            SelectedCases.Columns.Add("ID");
            SelectedCases.Columns.Add("Case");


            da = Data;
            data = new ComboBox() ;
            data.DropDownStyle = Data.DropDownStyle;
            data.Font = Data.Font;
            data.Dock = Data.Dock;
            data.RightToLeft = Data.RightToLeft;

            data.DataSource = da.DataSource;
            data.ValueMember = da.ValueMember;
            data.DisplayMember = da.DisplayMember;

            data.SelectedValueChanged += Data_SelectedValueChanged;

            dataGridView1.DataSource = SelectedCases;

            this.tableLayoutPanel1.Controls.Add(data, 0, 1);
        }

        private void Data_SelectedValueChanged(object sender, EventArgs e)
        {

            AddCase(data.Text.ToString(), int.Parse(data.SelectedValue.ToString()));
        }

        public int AddCase(string Case,int caseID)
        {
            bool exist = false;
            foreach (DataRow row in SelectedCases.Rows)
            {
                
                if(int.Parse(row[0].ToString())==caseID)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                DataRow dr = SelectedCases.NewRow();
                dr[0] = caseID;
                dr[1] = Case;
                SelectedCases.Rows.Add(dr);
            }
            return SelectedCases.Rows.Count;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void CasesOfMission_Shown(object sender, EventArgs e)
        {

            
        }
    }
}
