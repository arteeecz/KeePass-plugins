namespace KPSAPLunch
{
    partial class OptionDialog
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
            this.groupBoxAll = new System.Windows.Forms.GroupBox();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.applSrv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sysID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sapRouter = new System.Windows.Forms.TextBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.language = new System.Windows.Forms.TextBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.isMaxGui = new System.Windows.Forms.CheckBox();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sapGuiPath = new System.Windows.Forms.TextBox();
            this.NBCSPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxAll.SuspendLayout();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAll
            // 
            this.groupBoxAll.Controls.Add(this.groupBoxPath);
            this.groupBoxAll.Controls.Add(this.groupBoxOptions);
            this.groupBoxAll.Controls.Add(this.groupBoxLogin);
            this.groupBoxAll.Controls.Add(this.groupBoxConnection);
            this.groupBoxAll.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAll.Name = "groupBoxAll";
            this.groupBoxAll.Size = new System.Drawing.Size(552, 266);
            this.groupBoxAll.TabIndex = 0;
            this.groupBoxAll.TabStop = false;
            this.groupBoxAll.Text = "SAP Connection placeholders";
            this.groupBoxAll.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.label7);
            this.groupBoxConnection.Controls.Add(this.language);
            this.groupBoxConnection.Controls.Add(this.label4);
            this.groupBoxConnection.Controls.Add(this.sapRouter);
            this.groupBoxConnection.Controls.Add(this.label3);
            this.groupBoxConnection.Controls.Add(this.sysID);
            this.groupBoxConnection.Controls.Add(this.label2);
            this.groupBoxConnection.Controls.Add(this.number);
            this.groupBoxConnection.Controls.Add(this.label1);
            this.groupBoxConnection.Controls.Add(this.applSrv);
            this.groupBoxConnection.Location = new System.Drawing.Point(6, 19);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(338, 156);
            this.groupBoxConnection.TabIndex = 1;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "System connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Instance number (port)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(133, 45);
            this.number.Name = "number";
            this.number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.number.Size = new System.Drawing.Size(184, 20);
            this.number.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Application server (host)";
            // 
            // applSrv
            // 
            this.applSrv.Location = new System.Drawing.Point(133, 19);
            this.applSrv.Name = "applSrv";
            this.applSrv.Size = new System.Drawing.Size(184, 20);
            this.applSrv.TabIndex = 5;
            this.applSrv.TextChanged += new System.EventHandler(this.applSrv_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 74);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "System ID";
            // 
            // sysID
            // 
            this.sysID.Location = new System.Drawing.Point(133, 71);
            this.sysID.Name = "sysID";
            this.sysID.Size = new System.Drawing.Size(184, 20);
            this.sysID.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 100);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SAProuter string";
            // 
            // sapRouter
            // 
            this.sapRouter.Location = new System.Drawing.Point(133, 97);
            this.sapRouter.Name = "sapRouter";
            this.sapRouter.Size = new System.Drawing.Size(184, 20);
            this.sapRouter.TabIndex = 11;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.label6);
            this.groupBoxLogin.Controls.Add(this.password);
            this.groupBoxLogin.Controls.Add(this.label5);
            this.groupBoxLogin.Controls.Add(this.userName);
            this.groupBoxLogin.Location = new System.Drawing.Point(350, 19);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(189, 68);
            this.groupBoxLogin.TabIndex = 2;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "User name";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(71, 13);
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(94, 20);
            this.userName.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 42);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(71, 39);
            this.password.Name = "password";
            this.password.ReadOnly = true;
            this.password.Size = new System.Drawing.Size(94, 20);
            this.password.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 126);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Language (optional)";
            // 
            // language
            // 
            this.language.Location = new System.Drawing.Point(133, 123);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(184, 20);
            this.language.TabIndex = 13;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.isMaxGui);
            this.groupBoxOptions.Location = new System.Drawing.Point(350, 93);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(189, 82);
            this.groupBoxOptions.TabIndex = 3;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Connection options";
            // 
            // isMaxGui
            // 
            this.isMaxGui.AutoSize = true;
            this.isMaxGui.Location = new System.Drawing.Point(6, 19);
            this.isMaxGui.Name = "isMaxGui";
            this.isMaxGui.Size = new System.Drawing.Size(158, 17);
            this.isMaxGui.TabIndex = 0;
            this.isMaxGui.Text = "Run with maximized window";
            this.isMaxGui.UseVisualStyleBackColor = true;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.NBCSPath);
            this.groupBoxPath.Controls.Add(this.label9);
            this.groupBoxPath.Controls.Add(this.sapGuiPath);
            this.groupBoxPath.Controls.Add(this.label8);
            this.groupBoxPath.Location = new System.Drawing.Point(6, 181);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(533, 73);
            this.groupBoxPath.TabIndex = 4;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "System paths";
            this.groupBoxPath.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "SAP Gui binary found on:";
            // 
            // sapGuiPath
            // 
            this.sapGuiPath.Location = new System.Drawing.Point(136, 17);
            this.sapGuiPath.Name = "sapGuiPath";
            this.sapGuiPath.ReadOnly = true;
            this.sapGuiPath.Size = new System.Drawing.Size(373, 20);
            this.sapGuiPath.TabIndex = 1;
            this.sapGuiPath.UseWaitCursor = true;
            // 
            // NBCSPath
            // 
            this.NBCSPath.CausesValidation = false;
            this.NBCSPath.Location = new System.Drawing.Point(136, 41);
            this.NBCSPath.Name = "NBCSPath";
            this.NBCSPath.ReadOnly = true;
            this.NBCSPath.Size = new System.Drawing.Size(373, 20);
            this.NBCSPath.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.CausesValidation = false;
            this.label9.Location = new System.Drawing.Point(4, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "SAP Gui binary found on:";
            // 
            // OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 286);
            this.Controls.Add(this.groupBoxAll);
            this.Name = "OptionDialog";
            this.Text = "KPSapLunch Options";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxAll.ResumeLayout(false);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAll;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox applSrv;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox language;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sapRouter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sysID;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.TextBox NBCSPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sapGuiPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox isMaxGui;
    }
}