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
            this.components = new System.ComponentModel.Container();
            this.groupBoxAll = new System.Windows.Forms.GroupBox();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.iNBCSPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.iSapGuiPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.iTransaction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.isMaxGui = new System.Windows.Forms.CheckBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.iLanguage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.iClient = new System.Windows.Forms.TextBox();
            this.iPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iUserName = new System.Windows.Forms.TextBox();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.iSapRouter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iSysID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iApplSrv = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ttOption = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxAll.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.groupBoxConnection.SuspendLayout();
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
            this.groupBoxAll.Size = new System.Drawing.Size(552, 301);
            this.groupBoxAll.TabIndex = 0;
            this.groupBoxAll.TabStop = false;
            this.groupBoxAll.Text = "SAP Connection placeholders";
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.iNBCSPath);
            this.groupBoxPath.Controls.Add(this.label9);
            this.groupBoxPath.Controls.Add(this.iSapGuiPath);
            this.groupBoxPath.Controls.Add(this.label8);
            this.groupBoxPath.Location = new System.Drawing.Point(6, 215);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(533, 73);
            this.groupBoxPath.TabIndex = 4;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "System paths";
            // 
            // iNBCSPath
            // 
            this.iNBCSPath.CausesValidation = false;
            this.iNBCSPath.Location = new System.Drawing.Point(136, 41);
            this.iNBCSPath.Name = "iNBCSPath";
            this.iNBCSPath.ReadOnly = true;
            this.iNBCSPath.Size = new System.Drawing.Size(373, 20);
            this.iNBCSPath.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.CausesValidation = false;
            this.label9.Location = new System.Drawing.Point(4, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "SAP Bussines Client path";
            // 
            // iSapGuiPath
            // 
            this.iSapGuiPath.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.iSapGuiPath.Location = new System.Drawing.Point(136, 17);
            this.iSapGuiPath.Name = "iSapGuiPath";
            this.iSapGuiPath.ReadOnly = true;
            this.iSapGuiPath.Size = new System.Drawing.Size(373, 20);
            this.iSapGuiPath.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "SAP Gui path";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.iTransaction);
            this.groupBoxOptions.Controls.Add(this.label7);
            this.groupBoxOptions.Controls.Add(this.isMaxGui);
            this.groupBoxOptions.Location = new System.Drawing.Point(6, 159);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(533, 50);
            this.groupBoxOptions.TabIndex = 3;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Gui start options";
            // 
            // iTransaction
            // 
            this.iTransaction.Location = new System.Drawing.Point(133, 16);
            this.iTransaction.Name = "iTransaction";
            this.iTransaction.Size = new System.Drawing.Size(184, 20);
            this.iTransaction.TabIndex = 2;
            this.iTransaction.MouseHover += new System.EventHandler(this.OnTransactionHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Run after logon";
            // 
            // isMaxGui
            // 
            this.isMaxGui.AutoSize = true;
            this.isMaxGui.Location = new System.Drawing.Point(344, 19);
            this.isMaxGui.Name = "isMaxGui";
            this.isMaxGui.Size = new System.Drawing.Size(158, 17);
            this.isMaxGui.TabIndex = 0;
            this.isMaxGui.Text = "Run with maximized window";
            this.isMaxGui.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.label11);
            this.groupBoxLogin.Controls.Add(this.iLanguage);
            this.groupBoxLogin.Controls.Add(this.label10);
            this.groupBoxLogin.Controls.Add(this.label6);
            this.groupBoxLogin.Controls.Add(this.iClient);
            this.groupBoxLogin.Controls.Add(this.iPassword);
            this.groupBoxLogin.Controls.Add(this.label5);
            this.groupBoxLogin.Controls.Add(this.iUserName);
            this.groupBoxLogin.Location = new System.Drawing.Point(350, 19);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(189, 134);
            this.groupBoxLogin.TabIndex = 2;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 100);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Language";
            // 
            // iLanguage
            // 
            this.iLanguage.Location = new System.Drawing.Point(70, 97);
            this.iLanguage.Name = "iLanguage";
            this.iLanguage.Size = new System.Drawing.Size(94, 20);
            this.iLanguage.TabIndex = 17;
            this.iLanguage.MouseHover += new System.EventHandler(this.OnLanguageHover);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 74);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Client";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Password";
            // 
            // iClient
            // 
            this.iClient.Location = new System.Drawing.Point(71, 71);
            this.iClient.Name = "iClient";
            this.iClient.Size = new System.Drawing.Size(94, 20);
            this.iClient.TabIndex = 15;
            // 
            // iPassword
            // 
            this.iPassword.Location = new System.Drawing.Point(71, 45);
            this.iPassword.Name = "iPassword";
            this.iPassword.ReadOnly = true;
            this.iPassword.Size = new System.Drawing.Size(94, 20);
            this.iPassword.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "User name";
            // 
            // iUserName
            // 
            this.iUserName.Location = new System.Drawing.Point(71, 19);
            this.iUserName.Name = "iUserName";
            this.iUserName.ReadOnly = true;
            this.iUserName.Size = new System.Drawing.Size(94, 20);
            this.iUserName.TabIndex = 7;
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.label4);
            this.groupBoxConnection.Controls.Add(this.iSapRouter);
            this.groupBoxConnection.Controls.Add(this.label3);
            this.groupBoxConnection.Controls.Add(this.iSysID);
            this.groupBoxConnection.Controls.Add(this.label2);
            this.groupBoxConnection.Controls.Add(this.iNumber);
            this.groupBoxConnection.Controls.Add(this.label1);
            this.groupBoxConnection.Controls.Add(this.iApplSrv);
            this.groupBoxConnection.Location = new System.Drawing.Point(6, 19);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(338, 134);
            this.groupBoxConnection.TabIndex = 1;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "System connection";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 100);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SAProuter string";
            // 
            // iSapRouter
            // 
            this.iSapRouter.Location = new System.Drawing.Point(133, 97);
            this.iSapRouter.Name = "iSapRouter";
            this.iSapRouter.Size = new System.Drawing.Size(184, 20);
            this.iSapRouter.TabIndex = 11;
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
            // iSysID
            // 
            this.iSysID.Location = new System.Drawing.Point(133, 71);
            this.iSysID.Name = "iSysID";
            this.iSysID.Size = new System.Drawing.Size(184, 20);
            this.iSysID.TabIndex = 9;
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
            // 
            // iNumber
            // 
            this.iNumber.Location = new System.Drawing.Point(133, 45);
            this.iNumber.Name = "iNumber";
            this.iNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iNumber.Size = new System.Drawing.Size(184, 20);
            this.iNumber.TabIndex = 7;
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
            // iApplSrv
            // 
            this.iApplSrv.Location = new System.Drawing.Point(133, 19);
            this.iApplSrv.Name = "iApplSrv";
            this.iApplSrv.Size = new System.Drawing.Size(184, 20);
            this.iApplSrv.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::KPSAPLunch.Properties.Resources.okey_16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(12, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnBtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = global::KPSAPLunch.Properties.Resources.cancel_16;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(122, 319);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.OnBtnCancel_Click);
            // 
            // ttOption
            // 
            this.ttOption.IsBalloon = true;
            this.ttOption.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttOption.ToolTipTitle = "Placeholder info...";
            // 
            // OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBoxAll);
            this.Name = "OptionDialog";
            this.Text = "KPSapLunch Options";
            this.groupBoxAll.ResumeLayout(false);
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAll;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iApplSrv;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox iPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox iUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iSapRouter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox iSysID;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.TextBox iNBCSPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox iSapGuiPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox isMaxGui;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox iLanguage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox iClient;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox iTransaction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip ttOption;
    }
}