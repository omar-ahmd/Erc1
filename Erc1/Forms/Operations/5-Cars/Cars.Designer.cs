namespace Erc1.Forms._5_Cars
{
    partial class Cars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cars));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TeamContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._1Center = new System.Windows.Forms.FlowLayoutPanel();
            this.carsControl5 = new Erc1.CONTROLS.CarsControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.refreshBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this._1Center.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.59596F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.40404F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(990, 576);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.TeamContainer, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(589, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.97917F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.47916F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.54167F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(401, 576);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TeamContainer
            // 
            this.TeamContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamContainer.Location = new System.Drawing.Point(0, 69);
            this.TeamContainer.Margin = new System.Windows.Forms.Padding(0);
            this.TeamContainer.Name = "TeamContainer";
            this.TeamContainer.Size = new System.Drawing.Size(401, 428);
            this.TeamContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this._1Center);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 576);
            this.panel1.TabIndex = 2;
            // 
            // _1Center
            // 
            this._1Center.AutoScroll = true;
            this._1Center.AutoSize = true;
            this._1Center.Controls.Add(this.carsControl5);
            this._1Center.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._1Center.Location = new System.Drawing.Point(0, 0);
            this._1Center.Margin = new System.Windows.Forms.Padding(0);
            this._1Center.Name = "_1Center";
            this._1Center.Size = new System.Drawing.Size(230, 132);
            this._1Center.TabIndex = 2;
            // 
            // carsControl5
            // 
            this.carsControl5.BackColor = System.Drawing.Color.Transparent;
            this.carsControl5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("carsControl5.BackgroundImage")));
            this.carsControl5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carsControl5.CarID = 105;
            this.carsControl5.CenterID = 0;
            this.carsControl5.Clicked = false;
            this.carsControl5.Entered = false;
            this.carsControl5.Location = new System.Drawing.Point(3, 3);
            this.carsControl5.Name = "carsControl5";
            this.carsControl5.Size = new System.Drawing.Size(224, 126);
            this.carsControl5.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.refreshBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 502);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 69);
            this.panel2.TabIndex = 2;
            // 
            // refreshBtn
            // 
            this.refreshBtn.AutoSize = true;
            this.refreshBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(54)))), ((int)(((byte)(67)))));
            this.refreshBtn.Depth = 0;
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshBtn.Location = new System.Drawing.Point(0, 0);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.refreshBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Primary = false;
            this.refreshBtn.Size = new System.Drawing.Size(391, 69);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // Cars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 576);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cars";
            this.Text = "Cars";
            this.Load += new System.EventHandler(this.Cars_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._1Center.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel TeamContainer;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.FlowLayoutPanel _1Center;
        private CONTROLS.CarsControl carsControl5;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton refreshBtn;
    }
}