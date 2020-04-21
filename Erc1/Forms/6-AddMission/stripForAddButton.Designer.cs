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
            this.sButton3 = new Erc1.CONTROLS.SButton();
            this.sButton2 = new Erc1.CONTROLS.SButton();
            this.sButton1 = new Erc1.CONTROLS.SButton();
            this.AddmissionLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddmissionLayout
            // 
            this.AddmissionLayout.ColumnCount = 3;
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddmissionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddmissionLayout.Controls.Add(this.sButton3, 1, 0);
            this.AddmissionLayout.Controls.Add(this.sButton2, 0, 0);
            this.AddmissionLayout.Controls.Add(this.sButton1, 2, 0);
            this.AddmissionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddmissionLayout.Location = new System.Drawing.Point(0, 0);
            this.AddmissionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.AddmissionLayout.Name = "AddmissionLayout";
            this.AddmissionLayout.RowCount = 1;
            this.AddmissionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddmissionLayout.Size = new System.Drawing.Size(965, 369);
            this.AddmissionLayout.TabIndex = 0;
            // 
            // sButton3
            // 
            this.sButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sButton3.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton3.labelText = "مهمات مؤجلة";
            this.sButton3.Location = new System.Drawing.Point(321, 0);
            this.sButton3.Margin = new System.Windows.Forms.Padding(0);
            this.sButton3.Name = "sButton3";
            this.sButton3.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton3.Size = new System.Drawing.Size(321, 369);
            this.sButton3.TabIndex = 2;
            this.sButton3.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButton3.textForeColor = System.Drawing.Color.White;
            this.sButton3.ButClicked += new System.EventHandler(this.sButton3_ButClicked);
            // 
            // sButton2
            // 
            this.sButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sButton2.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton2.labelText = "مهمات ملغاة";
            this.sButton2.Location = new System.Drawing.Point(0, 0);
            this.sButton2.Margin = new System.Windows.Forms.Padding(0);
            this.sButton2.Name = "sButton2";
            this.sButton2.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton2.Size = new System.Drawing.Size(321, 369);
            this.sButton2.TabIndex = 1;
            this.sButton2.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButton2.textForeColor = System.Drawing.Color.White;
            this.sButton2.ButClicked += new System.EventHandler(this.sButton2_ButClicked);
            // 
            // sButton1
            // 
            this.sButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sButton1.labelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton1.labelText = "مهمات منفذة";
            this.sButton1.Location = new System.Drawing.Point(642, 0);
            this.sButton1.Margin = new System.Windows.Forms.Padding(0);
            this.sButton1.Name = "sButton1";
            this.sButton1.panelColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(120)))), ((int)(((byte)(132)))));
            this.sButton1.Size = new System.Drawing.Size(323, 369);
            this.sButton1.TabIndex = 0;
            this.sButton1.textFont = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sButton1.textForeColor = System.Drawing.Color.White;
            this.sButton1.ButClicked += new System.EventHandler(this.sButton1_ButClicked);
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

        private Erc1.CONTROLS.SButton sButton1;
        private Erc1.CONTROLS.SButton sButton3;
        private Erc1.CONTROLS.SButton sButton2;
        private System.Windows.Forms.TableLayoutPanel AddmissionLayout;


    }
}
