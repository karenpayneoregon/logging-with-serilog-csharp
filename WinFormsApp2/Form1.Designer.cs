namespace WinFormsApp2;

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
            this.LogWindowButton = new System.Windows.Forms.Button();
            this.LogInformationButton = new System.Windows.Forms.Button();
            this.FIleMissingButton = new System.Windows.Forms.Button();
            this.LogEntityFrameworkCoreButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogWindowButton
            // 
            this.LogWindowButton.Location = new System.Drawing.Point(22, 24);
            this.LogWindowButton.Name = "LogWindowButton";
            this.LogWindowButton.Size = new System.Drawing.Size(363, 29);
            this.LogWindowButton.TabIndex = 0;
            this.LogWindowButton.Tag = "L";
            this.LogWindowButton.Text = "Show log window";
            this.LogWindowButton.UseVisualStyleBackColor = true;
            this.LogWindowButton.Click += new System.EventHandler(this.LogWindowButton_Click);
            // 
            // LogInformationButton
            // 
            this.LogInformationButton.Location = new System.Drawing.Point(22, 76);
            this.LogInformationButton.Name = "LogInformationButton";
            this.LogInformationButton.Size = new System.Drawing.Size(363, 29);
            this.LogInformationButton.TabIndex = 1;
            this.LogInformationButton.Tag = "L";
            this.LogInformationButton.Text = "Log information static";
            this.LogInformationButton.UseVisualStyleBackColor = true;
            this.LogInformationButton.Click += new System.EventHandler(this.LogInformationButton_Click);
            // 
            // FIleMissingButton
            // 
            this.FIleMissingButton.Location = new System.Drawing.Point(22, 180);
            this.FIleMissingButton.Name = "FIleMissingButton";
            this.FIleMissingButton.Size = new System.Drawing.Size(363, 29);
            this.FIleMissingButton.TabIndex = 2;
            this.FIleMissingButton.Tag = "L";
            this.FIleMissingButton.Text = "File not found error";
            this.FIleMissingButton.UseVisualStyleBackColor = true;
            this.FIleMissingButton.Click += new System.EventHandler(this.FIleMissingButton_Click);
            // 
            // LogEntityFrameworkCoreButton
            // 
            this.LogEntityFrameworkCoreButton.Location = new System.Drawing.Point(22, 128);
            this.LogEntityFrameworkCoreButton.Name = "LogEntityFrameworkCoreButton";
            this.LogEntityFrameworkCoreButton.Size = new System.Drawing.Size(363, 29);
            this.LogEntityFrameworkCoreButton.TabIndex = 3;
            this.LogEntityFrameworkCoreButton.Tag = "L";
            this.LogEntityFrameworkCoreButton.Text = "Log information NorthWind EF Core";
            this.LogEntityFrameworkCoreButton.UseVisualStyleBackColor = true;
            this.LogEntityFrameworkCoreButton.Click += new System.EventHandler(this.LogEntityFrameworkCoreButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "F1 to hide F2 to show buttons";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogEntityFrameworkCoreButton);
            this.Controls.Add(this.FIleMissingButton);
            this.Controls.Add(this.LogInformationButton);
            this.Controls.Add(this.LogWindowButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log to child form";
            this.ResumeLayout(false);

    }

    #endregion

    private Button LogWindowButton;
    private Button LogInformationButton;
    private Button FIleMissingButton;
    private Button LogEntityFrameworkCoreButton;
    private Label label1;
}
