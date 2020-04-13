namespace ERC
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.RememberMe = new System.Windows.Forms.CheckBox();
            this.ForgotPass = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Minimize = new MaterialSkin.Controls.MaterialFlatButton();
            this.Exit = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(97, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RememberMe
            // 
            this.RememberMe.AutoSize = true;
            this.RememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RememberMe.ForeColor = System.Drawing.SystemColors.GrayText;
            this.RememberMe.Location = new System.Drawing.Point(25, 407);
            this.RememberMe.Name = "RememberMe";
            this.RememberMe.Size = new System.Drawing.Size(135, 24);
            this.RememberMe.TabIndex = 1;
            this.RememberMe.Text = "remember me";
            this.RememberMe.UseVisualStyleBackColor = true;
            // 
            // ForgotPass
            // 
            this.ForgotPass.AutoSize = true;
            this.ForgotPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPass.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ForgotPass.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.ForgotPass.Location = new System.Drawing.Point(230, 408);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(145, 20);
            this.ForgotPass.TabIndex = 8;
            this.ForgotPass.TabStop = true;
            this.ForgotPass.Text = "Forgot Password?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Minimize);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 54);
            this.panel1.TabIndex = 10;
            // 
            // Minimize
            // 
            this.Minimize.AutoSize = true;
            this.Minimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Minimize.Depth = 0;
            this.Minimize.Location = new System.Drawing.Point(339, 9);
            this.Minimize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Minimize.MouseState = MaterialSkin.MouseState.HOVER;
            this.Minimize.Name = "Minimize";
            this.Minimize.Primary = false;
            this.Minimize.Size = new System.Drawing.Size(19, 36);
            this.Minimize.TabIndex = 12;
            this.Minimize.Text = "-";
            this.Minimize.UseVisualStyleBackColor = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Exit.Depth = 0;
            this.Exit.Location = new System.Drawing.Point(366, 9);
            this.Exit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Exit.MouseState = MaterialSkin.MouseState.HOVER;
            this.Exit.Name = "Exit";
            this.Exit.Primary = false;
            this.Exit.Size = new System.Drawing.Size(24, 36);
            this.Exit.TabIndex = 11;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 1);
            this.panel2.TabIndex = 11;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "Enter Your ID";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(82, 303);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(396, 28);
            this.materialSingleLineTextField1.TabIndex = 12;
            this.materialSingleLineTextField1.Tag = "Enter Your ID";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "Enter You Password";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(82, 373);
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(396, 28);
            this.materialSingleLineTextField2.TabIndex = 13;
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            this.materialSingleLineTextField2.Click += new System.EventHandler(this.materialSingleLineTextField2_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 30;
            this.bunifuElipse2.TargetControl = this.button1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Erc1.Properties.Resources.kisspng_computer_icons_password_password_5b11e040ab26d0_1824988915278981767011;
            this.pictureBox3.Location = new System.Drawing.Point(25, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Erc1.Properties.Resources.login_icon_3048;
            this.pictureBox2.Location = new System.Drawing.Point(25, 278);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Erc1.Properties.Resources.log2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.Image = global::Erc1.Properties.Resources.output_onlinepngtools1;
            this.Logo.Location = new System.Drawing.Point(97, 73);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(213, 183);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 9;
            this.Logo.TabStop = false;
            this.Logo.MouseHover += new System.EventHandler(this.Logo_MouseHover);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(410, 553);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.materialSingleLineTextField2);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.ForgotPass);
            this.Controls.Add(this.RememberMe);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERC";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox RememberMe;
        private System.Windows.Forms.LinkLabel ForgotPass;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialFlatButton Minimize;
        private MaterialSkin.Controls.MaterialFlatButton Exit;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        //private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}

