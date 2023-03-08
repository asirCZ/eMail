using System.Windows.Forms;

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
            this.appPanel = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.toggleEmailsBtn = new System.Windows.Forms.Button();
            this.newMailBtn = new System.Windows.Forms.Button();
            this.emailList = new System.Windows.Forms.DataGridView();
            this.regLink = new System.Windows.Forms.LinkLabel();
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.errorLabelLog = new System.Windows.Forms.Label();
            this.headerLogin = new System.Windows.Forms.Label();
            this.registerLink = new System.Windows.Forms.LinkLabel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.regUserTxt = new System.Windows.Forms.TextBox();
            this.regPasswordTxt = new System.Windows.Forms.TextBox();
            this.regUsernameLabel = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.regPasswordLabel = new System.Windows.Forms.Label();
            this.regRepeatTxt = new System.Windows.Forms.TextBox();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.errorLabelReg = new System.Windows.Forms.Label();
            this.regHeader = new System.Windows.Forms.Label();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.appPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailList)).BeginInit();
            this.loginPanel.SuspendLayout();
            this.registerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // appPanel
            // 
            this.appPanel.Controls.Add(this.logoutBtn);
            this.appPanel.Controls.Add(this.headerLabel);
            this.appPanel.Controls.Add(this.toggleEmailsBtn);
            this.appPanel.Controls.Add(this.newMailBtn);
            this.appPanel.Controls.Add(this.emailList);
            this.appPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appPanel.Location = new System.Drawing.Point(0, 0);
            this.appPanel.Name = "appPanel";
            this.appPanel.Size = new System.Drawing.Size(1263, 634);
            this.appPanel.TabIndex = 4;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(296, 536);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(141, 54);
            this.logoutBtn.TabIndex = 4;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.headerLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.headerLabel.Location = new System.Drawing.Point(211, 52);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(79, 37);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "Inbox:";
            // 
            // toggleEmailsBtn
            // 
            this.toggleEmailsBtn.Location = new System.Drawing.Point(673, 536);
            this.toggleEmailsBtn.Name = "toggleEmailsBtn";
            this.toggleEmailsBtn.Size = new System.Drawing.Size(141, 54);
            this.toggleEmailsBtn.TabIndex = 2;
            this.toggleEmailsBtn.Text = "Sent";
            this.toggleEmailsBtn.UseVisualStyleBackColor = true;
            this.toggleEmailsBtn.Click += new System.EventHandler(this.toggleEmailsBtn_Click);
            // 
            // newMailBtn
            // 
            this.newMailBtn.Location = new System.Drawing.Point(831, 536);
            this.newMailBtn.Name = "newMailBtn";
            this.newMailBtn.Size = new System.Drawing.Size(137, 54);
            this.newMailBtn.TabIndex = 1;
            this.newMailBtn.Text = "New E-Mail";
            this.newMailBtn.UseVisualStyleBackColor = true;
            this.newMailBtn.Click += new System.EventHandler(this.newMailBtn_Click);
            // 
            // emailList
            // 
            this.emailList.AllowDrop = true;
            this.emailList.AllowUserToAddRows = false;
            this.emailList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.emailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.emailList.Location = new System.Drawing.Point(296, 52);
            this.emailList.Name = "emailList";
            this.emailList.ReadOnly = true;
            this.emailList.RowTemplate.ReadOnly = true;
            this.emailList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.emailList.Size = new System.Drawing.Size(672, 466);
            this.emailList.StandardTab = true;
            this.emailList.TabIndex = 0;
            this.emailList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.emailList_DoubleClick);
            this.emailList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.emailList_DeletingRow);
            // 
            // regLink
            // 
            this.regLink.Location = new System.Drawing.Point(0, 0);
            this.regLink.Name = "regLink";
            this.regLink.Size = new System.Drawing.Size(100, 23);
            this.regLink.TabIndex = 0;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(180, 214);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(132, 45);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Log in";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(67, 188);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(289, 20);
            this.passwordTxt.TabIndex = 2;
            this.passwordTxt.UseSystemPasswordChar = true;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(67, 165);
            this.usernameTxt.MaxLength = 200;
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(289, 20);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.Tag = "";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(3, 168);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(5, 191);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // errorLabelLog
            // 
            this.errorLabelLog.ForeColor = System.Drawing.Color.Red;
            this.errorLabelLog.Location = new System.Drawing.Point(3, 335);
            this.errorLabelLog.Name = "errorLabelLog";
            this.errorLabelLog.Size = new System.Drawing.Size(353, 135);
            this.errorLabelLog.TabIndex = 4;
            // 
            // headerLogin
            // 
            this.headerLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.headerLogin.Location = new System.Drawing.Point(3, 40);
            this.headerLogin.Name = "headerLogin";
            this.headerLogin.Size = new System.Drawing.Size(353, 48);
            this.headerLogin.TabIndex = 5;
            this.headerLogin.Text = "Welcome back to the E-Mail Client!";
            this.headerLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registerLink
            // 
            this.registerLink.Location = new System.Drawing.Point(145, 262);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(211, 26);
            this.registerLink.TabIndex = 6;
            this.registerLink.TabStop = true;
            this.registerLink.Text = "Don\'t have an account yet? Register here!";
            this.registerLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.registerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLink_LinkClicked);
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.registerLink);
            this.loginPanel.Controls.Add(this.headerLogin);
            this.loginPanel.Controls.Add(this.errorLabelLog);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.usernameLabel);
            this.loginPanel.Controls.Add(this.usernameTxt);
            this.loginPanel.Controls.Add(this.passwordTxt);
            this.loginPanel.Controls.Add(this.loginBtn);
            this.loginPanel.Location = new System.Drawing.Point(455, 12);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(360, 610);
            this.loginPanel.TabIndex = 3;
            // 
            // regUserTxt
            // 
            this.regUserTxt.Location = new System.Drawing.Point(67, 165);
            this.regUserTxt.MaxLength = 200;
            this.regUserTxt.Name = "regUserTxt";
            this.regUserTxt.Size = new System.Drawing.Size(330, 20);
            this.regUserTxt.TabIndex = 5;
            this.regUserTxt.Tag = "";
            // 
            // regPasswordTxt
            // 
            this.regPasswordTxt.Location = new System.Drawing.Point(67, 188);
            this.regPasswordTxt.Name = "regPasswordTxt";
            this.regPasswordTxt.Size = new System.Drawing.Size(330, 20);
            this.regPasswordTxt.TabIndex = 6;
            this.regPasswordTxt.UseSystemPasswordChar = true;
            // 
            // regUsernameLabel
            // 
            this.regUsernameLabel.AutoSize = true;
            this.regUsernameLabel.Location = new System.Drawing.Point(3, 168);
            this.regUsernameLabel.Name = "regUsernameLabel";
            this.regUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.regUsernameLabel.TabIndex = 8;
            this.regUsernameLabel.Text = "Username:";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(100, 250);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(200, 45);
            this.registerBtn.TabIndex = 8;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // regPasswordLabel
            // 
            this.regPasswordLabel.AutoSize = true;
            this.regPasswordLabel.Location = new System.Drawing.Point(5, 188);
            this.regPasswordLabel.Name = "regPasswordLabel";
            this.regPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.regPasswordLabel.TabIndex = 9;
            this.regPasswordLabel.Text = "Password:";
            // 
            // regRepeatTxt
            // 
            this.regRepeatTxt.Location = new System.Drawing.Point(104, 211);
            this.regRepeatTxt.Name = "regRepeatTxt";
            this.regRepeatTxt.Size = new System.Drawing.Size(293, 20);
            this.regRepeatTxt.TabIndex = 7;
            this.regRepeatTxt.UseSystemPasswordChar = true;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(5, 214);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(93, 13);
            this.repeatLabel.TabIndex = 11;
            this.repeatLabel.Text = "Repeat password:";
            // 
            // errorLabelReg
            // 
            this.errorLabelReg.ForeColor = System.Drawing.Color.Red;
            this.errorLabelReg.Location = new System.Drawing.Point(4, 305);
            this.errorLabelReg.Name = "errorLabelReg";
            this.errorLabelReg.Size = new System.Drawing.Size(394, 165);
            this.errorLabelReg.TabIndex = 9;
            // 
            // regHeader
            // 
            this.regHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.regHeader.Location = new System.Drawing.Point(3, 40);
            this.regHeader.Name = "regHeader";
            this.regHeader.Size = new System.Drawing.Size(395, 48);
            this.regHeader.TabIndex = 12;
            this.regHeader.Text = "Register your account";
            this.regHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.regHeader);
            this.registerPanel.Controls.Add(this.errorLabelReg);
            this.registerPanel.Controls.Add(this.repeatLabel);
            this.registerPanel.Controls.Add(this.regRepeatTxt);
            this.registerPanel.Controls.Add(this.regPasswordLabel);
            this.registerPanel.Controls.Add(this.registerBtn);
            this.registerPanel.Controls.Add(this.regUsernameLabel);
            this.registerPanel.Controls.Add(this.regPasswordTxt);
            this.registerPanel.Controls.Add(this.regUserTxt);
            this.registerPanel.Location = new System.Drawing.Point(431, 12);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(400, 610);
            this.registerPanel.TabIndex = 2;
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
            this.appPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailList)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button logoutBtn;

        private System.Windows.Forms.Label headerLabel;

        private System.Windows.Forms.Button newMailBtn;
        private System.Windows.Forms.Button toggleEmailsBtn;

        private System.Windows.Forms.DataGridView emailList;

        private System.Windows.Forms.Label regHeader;

        private System.Windows.Forms.LinkLabel registerLink;

        private System.Windows.Forms.Label headerLogin;

        private System.Windows.Forms.LinkLabel regLink;
        

        private System.Windows.Forms.Label errorLabelReg;

        private System.Windows.Forms.Label errorLabelLog;

        #endregion

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

