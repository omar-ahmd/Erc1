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
            this.panel1 = new System.Windows.Forms.Panel();
            this._1Center = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TeamContainer = new System.Windows.Forms.Panel();
            this.carsControl5 = new Erc1.CONTROLS.CarsControl();
            this.carsControl1 = new Erc1.CONTROLS.CarsControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this._1Center.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.59596F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.40404F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(990, 576);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.panel1.TabIndex = 0;
            // 
            // _1Center
            // 
            this._1Center.AutoScroll = true;
            this._1Center.Controls.Add(this.carsControl5);
            this._1Center.Controls.Add(this.carsControl1);
            this._1Center.Dock = System.Windows.Forms.DockStyle.Top;
            this._1Center.Location = new System.Drawing.Point(0, 0);
            this._1Center.Margin = new System.Windows.Forms.Padding(0);
            this._1Center.Name = "_1Center";
            this._1Center.Size = new System.Drawing.Size(589, 163);
            this._1Center.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.TeamContainer, 0, 1);
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
            this.TeamContainer.Size = new System.Drawing.Size(401, 429);
            this.TeamContainer.TabIndex = 1;
            // 
            // carsControl5
            // 
            this.carsControl5.BackColor = System.Drawing.Color.Transparent;
            this.carsControl5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("carsControl5.BackgroundImage")));
            this.carsControl5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carsControl5.CarID = 105;
            this.carsControl5.Clicked = false;
            this.carsControl5.Entered = false;
            this.carsControl5.Location = new System.Drawing.Point(3, 3);
            this.carsControl5.Name = "carsControl5";
            this.carsControl5.Size = new System.Drawing.Size(224, 126);
            this.carsControl5.TabIndex = 4;
            this.carsControl5.conClick += new System.EventHandler(this.carsControl1_conClick_1);
            this.carsControl5.conEntered += new System.EventHandler(this.carsControl1_conClick_1);
            this.carsControl5.conLeft += new System.EventHandler(this.carsControl1_conClick_1);
            // 
            // carsControl1
            // 
            this.carsControl1.BackColor = System.Drawing.Color.Transparent;
            this.carsControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("carsControl1.BackgroundImage")));
            this.carsControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carsControl1.CarID = 102;
            this.carsControl1.Clicked = false;
            this.carsControl1.Entered = false;
            this.carsControl1.Location = new System.Drawing.Point(233, 3);
            this.carsControl1.Name = "carsControl1";
            this.carsControl1.Size = new System.Drawing.Size(224, 126);
            this.carsControl1.TabIndex = 5;
            this.carsControl1.conClick += new System.EventHandler(this.carsControl1_conClick_1);
            this.carsControl1.conEntered += new System.EventHandler(this.carsControl1_conClick_1);
            this.carsControl1.conLeft += new System.EventHandler(this.carsControl1_conClick_1);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this._1Center.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel _1Center;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel TeamContainer;
        private CONTROLS.CarsControl carsControl5;
        private CONTROLS.CarsControl carsControl1;
    }
}