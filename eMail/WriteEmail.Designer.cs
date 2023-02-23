using System.ComponentModel;

namespace eMail;

partial class WriteEmail
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteEmail));
        this.recipientLabel = new System.Windows.Forms.Label();
        this.recipientTxt = new System.Windows.Forms.TextBox();
        this.subjectTxt = new System.Windows.Forms.TextBox();
        this.subjectLabel = new System.Windows.Forms.Label();
        this.messageLabel = new System.Windows.Forms.Label();
        this.messageTxt = new System.Windows.Forms.TextBox();
        this.sendBtn = new System.Windows.Forms.Button();
        this.cancelBtn = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // recipientLabel
        // 
        resources.ApplyResources(this.recipientLabel, "recipientLabel");
        this.recipientLabel.Name = "recipientLabel";
        // 
        // recipientTxt
        // 
        resources.ApplyResources(this.recipientTxt, "recipientTxt");
        this.recipientTxt.Name = "recipientTxt";
        // 
        // subjectTxt
        // 
        resources.ApplyResources(this.subjectTxt, "subjectTxt");
        this.subjectTxt.Name = "subjectTxt";
        // 
        // subjectLabel
        // 
        resources.ApplyResources(this.subjectLabel, "subjectLabel");
        this.subjectLabel.Name = "subjectLabel";
        // 
        // messageLabel
        // 
        resources.ApplyResources(this.messageLabel, "messageLabel");
        this.messageLabel.Name = "messageLabel";
        // 
        // messageTxt
        // 
        this.messageTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
        resources.ApplyResources(this.messageTxt, "messageTxt");
        this.messageTxt.Name = "messageTxt";
        // 
        // sendBtn
        // 
        resources.ApplyResources(this.sendBtn, "sendBtn");
        this.sendBtn.Name = "sendBtn";
        this.sendBtn.UseVisualStyleBackColor = true;
        this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
        // 
        // cancelBtn
        // 
        this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        resources.ApplyResources(this.cancelBtn, "cancelBtn");
        this.cancelBtn.Name = "cancelBtn";
        this.cancelBtn.UseVisualStyleBackColor = true;
        this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
        // 
        // WriteEmail
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cancelBtn;
        this.Controls.Add(this.cancelBtn);
        this.Controls.Add(this.sendBtn);
        this.Controls.Add(this.messageTxt);
        this.Controls.Add(this.messageLabel);
        this.Controls.Add(this.subjectTxt);
        this.Controls.Add(this.subjectLabel);
        this.Controls.Add(this.recipientTxt);
        this.Controls.Add(this.recipientLabel);
        this.Name = "WriteEmail";
        this.ShowIcon = false;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button sendBtn;
    private System.Windows.Forms.Button cancelBtn;

    private System.Windows.Forms.TextBox messageTxt;

    private System.Windows.Forms.Label messageLabel;

    private System.Windows.Forms.TextBox subjectTxt;
    private System.Windows.Forms.Label subjectLabel;

    private System.Windows.Forms.TextBox recipientTxt;

    private System.Windows.Forms.Label recipientLabel;

    #endregion
}