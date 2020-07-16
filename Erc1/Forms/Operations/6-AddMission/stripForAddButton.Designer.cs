namespace Erc1.Forms._6_AddMission
{
    partial class stripForAddButton
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
            this.DelButton = new Erc1.CONTROLS.SButton();
            this.CancButton = new Erc1.CONTROLS.SButton();
            this.ImpButton = new Erc1.CONTROLS.SButton();
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
            this.AddmissionLayout.Controls.Add(this.DelButton, 1, 0);
            this.AddmissionLayout.Controls.Add(this.CancButton, 0, 0);
            this.AddmissionLayout.Controls.Add(this.ImpButton, 2, 0);
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
            // DelButton
            // 
            this.DelButton.Clicked = false;
            this.DelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DelButton.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.DelButton.labelText = "مهمات مؤجلة";
            this.DelButton.Location = new System.Drawing.Point(483, 0);
            this.DelButton.Margin = new System.Windows.Forms.Padding(0);
            this.DelButton.Name = "DelButton";
            this.DelButton.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.DelButton.Size = new System.Drawing.Size(241, 369);
            this.DelButton.TabIndex = 2;
            this.DelButton.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelButton.textForeColor = System.Drawing.Color.White;
            this.DelButton.ButClicked += new System.EventHandler(this.sButton3_ButClicked);
            // 
            // CancButton
            // 
            this.CancButton.Clicked = false;
            this.CancButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancButton.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.CancButton.labelText = "مهمات ملغاة";
            this.CancButton.Location = new System.Drawing.Point(724, 0);
            this.CancButton.Margin = new System.Windows.Forms.Padding(0);
            this.CancButton.Name = "CancButton";
            this.CancButton.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.CancButton.Size = new System.Drawing.Size(241, 369);
            this.CancButton.TabIndex = 1;
            this.CancButton.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancButton.textForeColor = System.Drawing.Color.White;
            this.CancButton.ButClicked += new System.EventHandler(this.sButton2_ButClicked);
            // 
            // ImpButton
            // 
            this.ImpButton.Clicked = false;
            this.ImpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImpButton.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.ImpButton.labelText = "مهمات منفذة";
            this.ImpButton.Location = new System.Drawing.Point(242, 0);
            this.ImpButton.Margin = new System.Windows.Forms.Padding(0);
            this.ImpButton.Name = "ImpButton";
            this.ImpButton.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.ImpButton.Size = new System.Drawing.Size(241, 369);
            this.ImpButton.TabIndex = 0;
            this.ImpButton.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImpButton.textForeColor = System.Drawing.Color.White;
            this.ImpButton.ButClicked += new System.EventHandler(this.sButton1_ButClicked);
            // 
            // stripForAddButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddmissionLayout);
            this.Name = "stripForAddButton";
            this.Size = new System.Drawing.Size(965, 369);
            this.AddmissionLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel AddmissionLayout;
        public CONTROLS.SButton ImpButton;
        public CONTROLS.SButton DelButton;
        public CONTROLS.SButton CancButton;
    }
}
