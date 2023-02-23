using System.ComponentModel;

namespace eMail;

partial class ReadEmail
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadEmail));
        this.messageTxt = new System.Windows.Forms.TextBox();
        this.messageLabel = new System.Windows.Forms.Label();
        this.subjectTxt = new System.Windows.Forms.TextBox();
        this.subjectLabel = new System.Windows.Forms.Label();
        this.senderTxt = new System.Windows.Forms.TextBox();
        this.senderLabel = new System.Windows.Forms.Label();
        this.date = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // messageTxt
        // 
        this.messageTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
        this.messageTxt.Location = new System.Drawing.Point(85, 58);
        this.messageTxt.Multiline = true;
        this.messageTxt.Name = "messageTxt";
        this.messageTxt.ReadOnly = true;
        this.messageTxt.Size = new System.Drawing.Size(646, 316);
        this.messageTxt.TabIndex = 6;
        // 
        // messageLabel
        // 
        this.messageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.messageLabel.Location = new System.Drawing.Point(25, 61);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Size = new System.Drawing.Size(54, 17);
        this.messageLabel.TabIndex = 5;
        this.messageLabel.Text = "Message:";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // subjectTxt
        // 
        this.subjectTxt.Location = new System.Drawing.Point(351, 15);
        this.subjectTxt.MaxLength = 256;
        this.subjectTxt.Name = "subjectTxt";
        this.subjectTxt.ReadOnly = true;
        this.subjectTxt.Size = new System.Drawing.Size(380, 20);
        this.subjectTxt.TabIndex = 4;
        // 
        // subjectLabel
        // 
        this.subjectLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.subjectLabel.Location = new System.Drawing.Point(291, 18);
        this.subjectLabel.Name = "subjectLabel";
        this.subjectLabel.Size = new System.Drawing.Size(54, 17);
        this.subjectLabel.TabIndex = 3;
        this.subjectLabel.Text = "Subject:";
        this.subjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // senderTxt
        // 
        this.senderTxt.Location = new System.Drawing.Point(85, 15);
        this.senderTxt.MaxLength = 200;
        this.senderTxt.Name = "senderTxt";
        this.senderTxt.ReadOnly = true;
        this.senderTxt.Size = new System.Drawing.Size(200, 20);
        this.senderTxt.TabIndex = 2;
        // 
        // senderLabel
        // 
        this.senderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.senderLabel.Location = new System.Drawing.Point(25, 16);
        this.senderLabel.Name = "senderLabel";
        this.senderLabel.Size = new System.Drawing.Size(54, 17);
        this.senderLabel.TabIndex = 1;
        this.senderLabel.Text = "Sender:";
        this.senderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // date
        // 
        this.date.Location = new System.Drawing.Point(90, 388);
        this.date.Name = "date";
        this.date.Size = new System.Drawing.Size(641, 19);
        this.date.TabIndex = 7;
        this.date.Text = "E-mail byl odeslán ";
        // 
        // ReadEmail
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(784, 461);
        this.Controls.Add(this.date);
        this.Controls.Add(this.messageTxt);
        this.Controls.Add(this.messageLabel);
        this.Controls.Add(this.subjectTxt);
        this.Controls.Add(this.subjectLabel);
        this.Controls.Add(this.senderTxt);
        this.Controls.Add(this.senderLabel);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ReadEmail";
        this.Text = "ReadEmail";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label date;

    private System.Windows.Forms.TextBox senderTxt;

    private System.Windows.Forms.TextBox messageTxt;
    private System.Windows.Forms.Label messageLabel;
    private System.Windows.Forms.TextBox subjectTxt;
    private System.Windows.Forms.Label subjectLabel;
    private System.Windows.Forms.TextBox recipientTxt;
    private System.Windows.Forms.Label senderLabel;

    #endregion
}