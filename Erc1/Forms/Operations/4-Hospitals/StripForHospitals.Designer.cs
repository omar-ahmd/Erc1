namespace Erc1.Forms._6_AddMission
{
    partial class stripForHospitals
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
            this.AddmissionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.addhos = new Erc1.CONTROLS.SButton();
            this.Hos = new Erc1.CONTROLS.SButton();
            this.AddmissionLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddmissionLayout
            // 
            this.AddmissionLayout.BackColor = System.Drawing.Color.Transparent;
            this.AddmissionLayout.ColumnCount = 4;
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.AddmissionLayout.Controls.Add(this.addhos, 1, 0);
            this.AddmissionLayout.Controls.Add(this.Hos, 0, 0);
            this.AddmissionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddmissionLayout.Location = new System.Drawing.Point(0, 0);
            this.AddmissionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.AddmissionLayout.Name = "AddmissionLayout";
            this.AddmissionLayout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddmissionLayout.RowCount = 1;
            this.AddmissionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddmissionLayout.Size = new System.Drawing.Size(965, 369);
            this.AddmissionLayout.TabIndex = 0;
            // 
            // addhos
            // 
            this.addhos.Clicked = false;
            this.addhos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addhos.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.addhos.labelText = "إضافة مستشفى";
            this.addhos.Location = new System.Drawing.Point(483, 0);
            this.addhos.Margin = new System.Windows.Forms.Padding(0);
            this.addhos.Name = "addhos";
            this.addhos.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.addhos.Size = new System.Drawing.Size(241, 369);
            this.addhos.TabIndex = 2;
            this.addhos.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addhos.textForeColor = System.Drawing.Color.White;
            this.addhos.ButClicked += new System.EventHandler(this.sButton2_ButClicked);
            // 
            // Hos
            // 
            this.Hos.Clicked = false;
            this.Hos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hos.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.Hos.labelText = "المستشفيات";
            this.Hos.Location = new System.Drawing.Point(724, 0);
            this.Hos.Margin = new System.Windows.Forms.Padding(0);
            this.Hos.Name = "Hos";
            this.Hos.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.Hos.Size = new System.Drawing.Size(241, 369);
            this.Hos.TabIndex = 1;
            this.Hos.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hos.textForeColor = System.Drawing.Color.White;
            this.Hos.ButClicked += new System.EventHandler(this.sButton3_ButClicked);
            // 
            // stripForHospitals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddmissionLayout);
            this.Name = "stripForHospitals";
            this.Size = new System.Drawing.Size(965, 369);
            this.AddmissionLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel AddmissionLayout;
        public CONTROLS.SButton addhos;
        public CONTROLS.SButton Hos;
    }
}
