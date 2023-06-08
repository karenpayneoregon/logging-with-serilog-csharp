namespace WinFormsApp1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.InformationButton = new System.Windows.Forms.Button();
            this.ExceptionButton = new System.Windows.Forms.Button();
            this.WarningButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InformationButton
            // 
            this.InformationButton.Location = new System.Drawing.Point(47, 38);
            this.InformationButton.Name = "InformationButton";
            this.InformationButton.Size = new System.Drawing.Size(227, 29);
            this.InformationButton.TabIndex = 0;
            this.InformationButton.Text = "Information";
            this.InformationButton.UseVisualStyleBackColor = true;
            this.InformationButton.Click += new System.EventHandler(this.InformationButton_Click);
            // 
            // ExceptionButton
            // 
            this.ExceptionButton.Location = new System.Drawing.Point(47, 101);
            this.ExceptionButton.Name = "ExceptionButton";
            this.ExceptionButton.Size = new System.Drawing.Size(227, 29);
            this.ExceptionButton.TabIndex = 1;
            this.ExceptionButton.Text = "Exception";
            this.ExceptionButton.UseVisualStyleBackColor = true;
            this.ExceptionButton.Click += new System.EventHandler(this.ExceptionButton_Click);
            // 
            // WarningButton
            // 
            this.WarningButton.Location = new System.Drawing.Point(47, 157);
            this.WarningButton.Name = "WarningButton";
            this.WarningButton.Size = new System.Drawing.Size(227, 29);
            this.WarningButton.TabIndex = 2;
            this.WarningButton.Text = "Warning";
            this.WarningButton.UseVisualStyleBackColor = true;
            this.WarningButton.Click += new System.EventHandler(this.WarningButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 256);
            this.Controls.Add(this.WarningButton);
            this.Controls.Add(this.ExceptionButton);
            this.Controls.Add(this.InformationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logging";
            this.ResumeLayout(false);

    }

    #endregion

    private Button InformationButton;
    private Button ExceptionButton;
    private Button WarningButton;
}
