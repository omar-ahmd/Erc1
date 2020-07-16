using ERC;
using Erc1.CONTROLS;
using Erc1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erc1.Forms._4_Hospitals
{


    public partial class HospitalsForm : Form
    {
        private int hosID;

        public int HosID
        {
            get { return hosID; }
            set 
            {
                hosID = value;

            }
        }
        DataTable depTable;
        public HospitalsForm(DataRow dr)
        {

            

            InitializeComponent();

            HosID = int.Parse(dr["رمز_المستشفى"].ToString());

            HosName.Text = dr["اسم_المستشفى"].ToString();
            HosNumber.Text = dr["الهاتف"].ToString();


            depTable = BAL.Hospitals.GetDepartement(HosID);
            foreach (DataRow row in depTable.Rows)
            {
                string y =row["تحويلة_القسم"].ToString();
                string r = row["اسم_القسم"].ToString();
                var dep = new DepartementInfo(row["تحويلة_القسم"].ToString(), row["اسم_القسم"].ToString());
                dep.Dock = DockStyle.Top;
                dep.Size = new Size(200, 40);
                panel1.Controls.Add(dep);
            }
            
            

        }

 
    }
}