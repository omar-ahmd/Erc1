namespace Erc1.CONTROLS
{
    partial class DepartementInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DepNumber = new System.Windows.Forms.Label();
            this.DepName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.DepNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DepName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 45);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // DepNumber
            // 
            this.DepNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DepNumber.AutoSize = true;
            this.DepNumber.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepNumber.ForeColor = System.Drawing.Color.Black;
            this.DepNumber.Location = new System.Drawing.Point(3, 5);
            this.DepNumber.Name = "DepNumber";
            this.DepNumber.Size = new System.Drawing.Size(127, 35);
            this.DepNumber.TabIndex = 4;
            this.DepNumber.Text = "06445815";
            // 
            // DepName
            // 
            this.DepName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DepName.AutoSize = true;
            this.DepName.Font = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(54)))), ((int)(((byte)(67)))));
            this.DepName.Location = new System.Drawing.Point(360, 7);
            this.DepName.Name = "DepName";
            this.DepName.Size = new System.Drawing.Size(115, 31);
            this.DepName.TabIndex = 3;
            this.DepName.Text = "المشفى";
            // 
            // DepartementInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DepartementInfo";
            this.Size = new System.Drawing.Size(478, 45);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label DepNumber;
        private System.Windows.Forms.Label DepName;
    }
}
