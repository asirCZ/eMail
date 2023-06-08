using System.ComponentModel;

namespace eMail.Window_Forms;

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
        this.toWhomLabel = new System.Windows.Forms.Label();
        this.recipientTxt = new System.Windows.Forms.TextBox();
        this.subjectTxt = new System.Windows.Forms.TextBox();
        this.subjectLabel = new System.Windows.Forms.Label();
        this.messageLabel = new System.Windows.Forms.Label();
        this.messageTxt = new System.Windows.Forms.TextBox();
        this.sendBtn = new System.Windows.Forms.Button();
        this.cancelBtn = new System.Windows.Forms.Button();
        this.recipientsLabel = new System.Windows.Forms.Label();
        this.addRecipient = new System.Windows.Forms.Button();
        this.listOfRecipients = new System.Windows.Forms.ListBox();
        this.SuspendLayout();
        // 
        // toWhomLabel
        // 
        this.toWhomLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.toWhomLabel.Location = new System.Drawing.Point(2, 20);
        this.toWhomLabel.Name = "toWhomLabel";
        this.toWhomLabel.Size = new System.Drawing.Size(64, 17);
        this.toWhomLabel.TabIndex = 0;
        this.toWhomLabel.Text = "To whom:";
        this.toWhomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // recipientTxt
        // 
        this.recipientTxt.Location = new System.Drawing.Point(72, 20);
        this.recipientTxt.MaxLength = 200;
        this.recipientTxt.Name = "recipientTxt";
        this.recipientTxt.Size = new System.Drawing.Size(486, 20);
        this.recipientTxt.TabIndex = 1;
        // 
        // subjectTxt
        // 
        this.subjectTxt.Location = new System.Drawing.Point(72, 187);
        this.subjectTxt.MaxLength = 256;
        this.subjectTxt.Name = "subjectTxt";
        this.subjectTxt.Size = new System.Drawing.Size(646, 20);
        this.subjectTxt.TabIndex = 3;
        // 
        // subjectLabel
        // 
        this.subjectLabel.Location = new System.Drawing.Point(12, 187);
        this.subjectLabel.Name = "subjectLabel";
        this.subjectLabel.Size = new System.Drawing.Size(54, 17);
        this.subjectLabel.TabIndex = 2;
        this.subjectLabel.Text = "Subject:";
        this.subjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // messageLabel
        // 
        this.messageLabel.Location = new System.Drawing.Point(12, 213);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Size = new System.Drawing.Size(54, 17);
        this.messageLabel.TabIndex = 4;
        this.messageLabel.Text = "Message:";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // messageTxt
        // 
        this.messageTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
        this.messageTxt.Location = new System.Drawing.Point(72, 213);
        this.messageTxt.Multiline = true;
        this.messageTxt.Name = "messageTxt";
        this.messageTxt.Size = new System.Drawing.Size(646, 257);
        this.messageTxt.TabIndex = 5;
        // 
        // sendBtn
        // 
        this.sendBtn.Location = new System.Drawing.Point(573, 493);
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
        this.cancelBtn.Location = new System.Drawing.Point(72, 493);
        this.cancelBtn.Name = "cancelBtn";
        this.cancelBtn.Size = new System.Drawing.Size(145, 47);
        this.cancelBtn.TabIndex = 7;
        this.cancelBtn.Text = "Cancel";
        this.cancelBtn.UseVisualStyleBackColor = true;
        this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
        // 
        // recipientsLabel
        // 
        this.recipientsLabel.Location = new System.Drawing.Point(5, 47);
        this.recipientsLabel.Name = "recipientsLabel";
        this.recipientsLabel.Size = new System.Drawing.Size(61, 15);
        this.recipientsLabel.TabIndex = 8;
        this.recipientsLabel.Text = "Recipients:";
        this.recipientsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // addRecipient
        // 
        this.addRecipient.AutoSize = true;
        this.addRecipient.Location = new System.Drawing.Point(573, 20);
        this.addRecipient.Name = "addRecipient";
        this.addRecipient.Size = new System.Drawing.Size(145, 42);
        this.addRecipient.TabIndex = 9;
        this.addRecipient.Text = " Add to recipients";
        this.addRecipient.UseVisualStyleBackColor = true;
        this.addRecipient.Click += new System.EventHandler(this.addRecipient_Click);
        // 
        // listOfRecipients
        // 
        this.listOfRecipients.Location = new System.Drawing.Point(72, 46);
        this.listOfRecipients.Name = "listOfRecipients";
        this.listOfRecipients.ScrollAlwaysVisible = true;
        this.listOfRecipients.SelectionMode = System.Windows.Forms.SelectionMode.None;
        this.listOfRecipients.Size = new System.Drawing.Size(486, 134);
        this.listOfRecipients.Sorted = true;
        this.listOfRecipients.TabIndex = 11;
        // 
        // WriteEmail
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cancelBtn;
        this.ClientSize = new System.Drawing.Size(784, 562);
        this.Controls.Add(this.listOfRecipients);
        this.Controls.Add(this.addRecipient);
        this.Controls.Add(this.recipientsLabel);
        this.Controls.Add(this.cancelBtn);
        this.Controls.Add(this.sendBtn);
        this.Controls.Add(this.messageTxt);
        this.Controls.Add(this.messageLabel);
        this.Controls.Add(this.subjectTxt);
        this.Controls.Add(this.subjectLabel);
        this.Controls.Add(this.recipientTxt);
        this.Controls.Add(this.toWhomLabel);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(15, 15);
        this.Name = "WriteEmail";
        this.Text = "WriteEmail";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.ListBox listOfRecipients;

    private System.Windows.Forms.Button addRecipient;

    private System.Windows.Forms.Label recipientsLabel;

    private System.Windows.Forms.Button sendBtn;
    private System.Windows.Forms.Button cancelBtn;

    private System.Windows.Forms.TextBox messageTxt;

    private System.Windows.Forms.Label messageLabel;

    private System.Windows.Forms.TextBox subjectTxt;
    private System.Windows.Forms.Label subjectLabel;

    private System.Windows.Forms.TextBox recipientTxt;

    private System.Windows.Forms.Label toWhomLabel;

    #endregion
}