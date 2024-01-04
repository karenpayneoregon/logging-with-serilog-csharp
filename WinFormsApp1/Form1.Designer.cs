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
        InformationButton = new Button();
        ExceptionButton = new Button();
        WarningButton = new Button();
        button1 = new Button();
        SuspendLayout();
        // 
        // InformationButton
        // 
        InformationButton.Location = new Point(47, 38);
        InformationButton.Name = "InformationButton";
        InformationButton.Size = new Size(227, 29);
        InformationButton.TabIndex = 0;
        InformationButton.Text = "Information";
        InformationButton.UseVisualStyleBackColor = true;
        InformationButton.Click += InformationButton_Click;
        // 
        // ExceptionButton
        // 
        ExceptionButton.Location = new Point(47, 101);
        ExceptionButton.Name = "ExceptionButton";
        ExceptionButton.Size = new Size(227, 29);
        ExceptionButton.TabIndex = 1;
        ExceptionButton.Text = "Exception";
        ExceptionButton.UseVisualStyleBackColor = true;
        ExceptionButton.Click += ExceptionButton_Click;
        // 
        // WarningButton
        // 
        WarningButton.Location = new Point(47, 157);
        WarningButton.Name = "WarningButton";
        WarningButton.Size = new Size(227, 29);
        WarningButton.TabIndex = 2;
        WarningButton.Text = "Warning";
        WarningButton.UseVisualStyleBackColor = true;
        WarningButton.Click += WarningButton_Click;
        // 
        // button1
        // 
        button1.Location = new Point(47, 201);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 3;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(343, 256);
        Controls.Add(button1);
        Controls.Add(WarningButton);
        Controls.Add(ExceptionButton);
        Controls.Add(InformationButton);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Logging";
        ResumeLayout(false);
    }

    #endregion

    private Button InformationButton;
    private Button ExceptionButton;
    private Button WarningButton;
    private Button button1;
}
