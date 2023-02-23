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
        this.recipientLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.recipientLabel.Location = new System.Drawing.Point(2, 20);
        this.recipientLabel.Name = "recipientLabel";
        this.recipientLabel.Size = new System.Drawing.Size(64, 17);
        this.recipientLabel.TabIndex = 0;
        this.recipientLabel.Text = "Recipient:";
        this.recipientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // recipientTxt
        // 
        this.recipientTxt.Location = new System.Drawing.Point(72, 20);
        this.recipientTxt.MaxLength = 200;
        this.recipientTxt.Name = "recipientTxt";
        this.recipientTxt.Size = new System.Drawing.Size(200, 20);
        this.recipientTxt.TabIndex = 1;
        // 
        // subjectTxt
        // 
        this.subjectTxt.Location = new System.Drawing.Point(338, 20);
        this.subjectTxt.MaxLength = 256;
        this.subjectTxt.Name = "subjectTxt";
        this.subjectTxt.Size = new System.Drawing.Size(380, 20);
        this.subjectTxt.TabIndex = 3;
        // 
        // subjectLabel
        // 
        this.subjectLabel.Location = new System.Drawing.Point(278, 20);
        this.subjectLabel.Name = "subjectLabel";
        this.subjectLabel.Size = new System.Drawing.Size(54, 17);
        this.subjectLabel.TabIndex = 2;
        this.subjectLabel.Text = "Subject:";
        this.subjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // messageLabel
        // 
        this.messageLabel.Location = new System.Drawing.Point(12, 66);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Size = new System.Drawing.Size(54, 17);
        this.messageLabel.TabIndex = 4;
        this.messageLabel.Text = "Message:";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // messageTxt
        // 
        this.messageTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
        this.messageTxt.Location = new System.Drawing.Point(72, 63);
        this.messageTxt.Multiline = true;
        this.messageTxt.Name = "messageTxt";
        this.messageTxt.Size = new System.Drawing.Size(646, 316);
        this.messageTxt.TabIndex = 5;
        // 
        // sendBtn
        // 
        this.sendBtn.Location = new System.Drawing.Point(573, 402);
        this.sendBtn.Name = "sendBtn";
        this.sendBtn.Size = new System.Drawing.Size(145, 47);
        this.sendBtn.TabIndex = 6;
        this.sendBtn.Text = "Send";
        this.sendBtn.UseVisualStyleBackColor = true;
        this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
        // 
        // cancelBtn
        // 
        this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelBtn.Location = new System.Drawing.Point(72, 402);
        this.cancelBtn.Name = "cancelBtn";
        this.cancelBtn.Size = new System.Drawing.Size(145, 47);
        this.cancelBtn.TabIndex = 7;
        this.cancelBtn.Text = "Cancel";
        this.cancelBtn.UseVisualStyleBackColor = true;
        this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
        // 
        // WriteEmail
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cancelBtn;
        this.ClientSize = new System.Drawing.Size(784, 461);
        this.Controls.Add(this.cancelBtn);
        this.Controls.Add(this.sendBtn);
        this.Controls.Add(this.messageTxt);
        this.Controls.Add(this.messageLabel);
        this.Controls.Add(this.subjectTxt);
        this.Controls.Add(this.subjectLabel);
        this.Controls.Add(this.recipientTxt);
        this.Controls.Add(this.recipientLabel);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(15, 15);
        this.Name = "WriteEmail";
        this.Text = "WriteEmail";
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