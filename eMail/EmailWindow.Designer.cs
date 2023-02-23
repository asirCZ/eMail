namespace eMail
{
    partial class EmailWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailWindow));
            this.emailList = new System.Windows.Forms.DataGridView();
            this.appPanel = new System.Windows.Forms.Panel();
            this.newMailBtn = new System.Windows.Forms.Button();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.errorLabelReg = new System.Windows.Forms.Label();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.regRepeatTxt = new System.Windows.Forms.TextBox();
            this.regPasswordLabel = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.regUsernameLabel = new System.Windows.Forms.Label();
            this.regPasswordTxt = new System.Windows.Forms.TextBox();
            this.regUserTxt = new System.Windows.Forms.TextBox();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.errorLabelLog = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.emailList)).BeginInit();
            this.appPanel.SuspendLayout();
            this.registerPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailList
            // 
            this.emailList.AllowDrop = true;
            this.emailList.AllowUserToAddRows = false;
            this.emailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.emailList.Location = new System.Drawing.Point(27, 22);
            this.emailList.Name = "emailList";
            this.emailList.ReadOnly = true;
            this.emailList.RowTemplate.ReadOnly = true;
            this.emailList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.emailList.Size = new System.Drawing.Size(400, 251);
            this.emailList.StandardTab = true;
            this.emailList.TabIndex = 0;
            this.emailList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.emailList_DoubleClick);
            this.emailList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.emailList_DeletingRow);
            // 
            // appPanel
            // 
            this.appPanel.Controls.Add(this.newMailBtn);
            this.appPanel.Controls.Add(this.emailList);
            this.appPanel.Location = new System.Drawing.Point(794, 12);
            this.appPanel.Name = "appPanel";
            this.appPanel.Size = new System.Drawing.Size(457, 610);
            this.appPanel.TabIndex = 1;
            // 
            // newMailBtn
            // 
            this.newMailBtn.Location = new System.Drawing.Point(323, 537);
            this.newMailBtn.Name = "newMailBtn";
            this.newMailBtn.Size = new System.Drawing.Size(104, 44);
            this.newMailBtn.TabIndex = 1;
            this.newMailBtn.Text = "Nový e-mail";
            this.newMailBtn.UseVisualStyleBackColor = true;
            this.newMailBtn.Click += new System.EventHandler(this.newMailBtn_Click);
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.errorLabelReg);
            this.registerPanel.Controls.Add(this.repeatLabel);
            this.registerPanel.Controls.Add(this.regRepeatTxt);
            this.registerPanel.Controls.Add(this.regPasswordLabel);
            this.registerPanel.Controls.Add(this.registerBtn);
            this.registerPanel.Controls.Add(this.regUsernameLabel);
            this.registerPanel.Controls.Add(this.regPasswordTxt);
            this.registerPanel.Controls.Add(this.regUserTxt);
            this.registerPanel.Location = new System.Drawing.Point(382, 12);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(406, 610);
            this.registerPanel.TabIndex = 2;
            // 
            // errorLabelReg
            // 
            this.errorLabelReg.ForeColor = System.Drawing.Color.Red;
            this.errorLabelReg.Location = new System.Drawing.Point(25, 480);
            this.errorLabelReg.Name = "errorLabelReg";
            this.errorLabelReg.Size = new System.Drawing.Size(353, 118);
            this.errorLabelReg.TabIndex = 9;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(12, 385);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(93, 13);
            this.repeatLabel.TabIndex = 11;
            this.repeatLabel.Text = "Repeat password:";
            // 
            // regRepeatTxt
            // 
            this.regRepeatTxt.Location = new System.Drawing.Point(111, 385);
            this.regRepeatTxt.Name = "regRepeatTxt";
            this.regRepeatTxt.Size = new System.Drawing.Size(267, 20);
            this.regRepeatTxt.TabIndex = 7;
            this.regRepeatTxt.UseSystemPasswordChar = true;
            // 
            // regPasswordLabel
            // 
            this.regPasswordLabel.AutoSize = true;
            this.regPasswordLabel.Location = new System.Drawing.Point(47, 359);
            this.regPasswordLabel.Name = "regPasswordLabel";
            this.regPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.regPasswordLabel.TabIndex = 9;
            this.regPasswordLabel.Text = "Password:";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(137, 432);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(189, 45);
            this.registerBtn.TabIndex = 8;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // regUsernameLabel
            // 
            this.regUsernameLabel.AutoSize = true;
            this.regUsernameLabel.Location = new System.Drawing.Point(45, 336);
            this.regUsernameLabel.Name = "regUsernameLabel";
            this.regUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.regUsernameLabel.TabIndex = 8;
            this.regUsernameLabel.Text = "Username:";
            // 
            // regPasswordTxt
            // 
            this.regPasswordTxt.Location = new System.Drawing.Point(111, 359);
            this.regPasswordTxt.Name = "regPasswordTxt";
            this.regPasswordTxt.Size = new System.Drawing.Size(267, 20);
            this.regPasswordTxt.TabIndex = 6;
            this.regPasswordTxt.UseSystemPasswordChar = true;
            // 
            // regUserTxt
            // 
            this.regUserTxt.Location = new System.Drawing.Point(111, 333);
            this.regUserTxt.MaxLength = 200;
            this.regUserTxt.Name = "regUserTxt";
            this.regUserTxt.Size = new System.Drawing.Size(267, 20);
            this.regUserTxt.TabIndex = 5;
            this.regUserTxt.Tag = "";
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.errorLabelLog);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.usernameLabel);
            this.loginPanel.Controls.Add(this.usernameTxt);
            this.loginPanel.Controls.Add(this.passwordTxt);
            this.loginPanel.Controls.Add(this.loginBtn);
            this.loginPanel.Location = new System.Drawing.Point(12, 12);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(359, 610);
            this.loginPanel.TabIndex = 3;
            // 
            // errorLabelLog
            // 
            this.errorLabelLog.ForeColor = System.Drawing.Color.Red;
            this.errorLabelLog.Location = new System.Drawing.Point(3, 463);
            this.errorLabelLog.Name = "errorLabelLog";
            this.errorLabelLog.Size = new System.Drawing.Size(353, 135);
            this.errorLabelLog.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(9, 356);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(9, 333);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(73, 330);
            this.usernameTxt.MaxLength = 200;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(267, 20);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.Tag = "";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(73, 356);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(267, 20);
            this.passwordTxt.TabIndex = 2;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(110, 391);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(189, 45);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Log in";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // EmailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1263, 634);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.registerPanel);
            this.Controls.Add(this.appPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "EmailWindow";
            this.Tag = "";
            this.Text = "E-mail Client";
            ((System.ComponentModel.ISupportInitialize)(this.emailList)).EndInit();
            this.appPanel.ResumeLayout(false);
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button newMailBtn;

        private System.Windows.Forms.Label errorLabelReg;

        private System.Windows.Forms.Label errorLabelLog;

        #endregion

        private System.Windows.Forms.DataGridView emailList;
        private System.Windows.Forms.Panel appPanel;
        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.TextBox regRepeatTxt;
        private System.Windows.Forms.Label regPasswordLabel;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Label regUsernameLabel;
        private System.Windows.Forms.TextBox regPasswordTxt;
        private System.Windows.Forms.TextBox regUserTxt;
        private System.Windows.Forms.Label passwordLabel;
    }
}

