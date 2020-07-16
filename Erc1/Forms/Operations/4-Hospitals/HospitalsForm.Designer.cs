namespace Erc1.Forms._4_Hospitals
{
    partial class HospitalsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Hos = new System.Windows.Forms.TableLayoutPanel();
            this.HosInfo = new System.Windows.Forms.TableLayoutPanel();
            this.HosName = new System.Windows.Forms.Label();
            this.HosNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Hos.SuspendLayout();
            this.HosInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hos
            // 
            this.Hos.BackColor = System.Drawing.Color.Transparent;
            this.Hos.BackgroundImage = global::Erc1.Properties.Resources._551;
            this.Hos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Hos.ColumnCount = 1;
            this.Hos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.Hos.Controls.Add(this.HosInfo, 0, 0);
            this.Hos.Controls.Add(this.panel1, 0, 1);
            this.Hos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hos.ForeColor = System.Drawing.Color.White;
            this.Hos.Location = new System.Drawing.Point(0, 0);
            this.Hos.Name = "Hos";
            this.Hos.RowCount = 2;
            this.Hos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.253732F));
            this.Hos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.74627F));
            this.Hos.Size = new System.Drawing.Size(480, 690);
            this.Hos.TabIndex = 1;
            // 
            // HosInfo
            // 
            this.HosInfo.ColumnCount = 2;
            this.HosInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.HosInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.HosInfo.Controls.Add(this.HosName, 0, 0);
            this.HosInfo.Controls.Add(this.HosNumber, 0, 0);
            this.HosInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HosInfo.Location = new System.Drawing.Point(0, 0);
            this.HosInfo.Margin = new System.Windows.Forms.Padding(0);
            this.HosInfo.Name = "HosInfo";
            this.HosInfo.RowCount = 1;
            this.HosInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HosInfo.Size = new System.Drawing.Size(480, 63);
            this.HosInfo.TabIndex = 0;
            // 
            // HosName
            // 
            this.HosName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.HosName.AutoSize = true;
            this.HosName.Font = new System.Drawing.Font("Air Strip Arabic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HosName.Location = new System.Drawing.Point(362, 16);
            this.HosName.Name = "HosName";
            this.HosName.Size = new System.Drawing.Size(115, 31);
            this.HosName.TabIndex = 2;
            this.HosName.Text = "المشفى";
            // 
            // HosNumber
            // 
            this.HosNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HosNumber.AutoSize = true;
            this.HosNumber.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HosNumber.Location = new System.Drawing.Point(3, 14);
            this.HosNumber.Name = "HosNumber";
            this.HosNumber.Size = new System.Drawing.Size(127, 35);
            this.HosNumber.TabIndex = 3;
            this.HosNumber.Text = "06445815";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(480, 627);
            this.panel1.TabIndex = 1;
            // 
            // HospitalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(54)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(480, 690);
            this.Controls.Add(this.Hos);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HospitalsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HospitalsForm";
            this.Hos.ResumeLayout(false);
            this.HosInfo.ResumeLayout(false);
            this.HosInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Hos;
        private System.Windows.Forms.TableLayoutPanel HosInfo;
        private System.Windows.Forms.Label HosName;
        private System.Windows.Forms.Label HosNumber;
        private System.Windows.Forms.Panel panel1;
    }
}