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
        button2 = new Button();
        StartButton = new Button();
        CancelButton = new Button();
        Start1Button = new Button();
        Cancel1Button = new Button();
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
        // button2
        // 
        button2.Location = new Point(161, 201);
        button2.Name = "button2";
        button2.Size = new Size(94, 29);
        button2.TabIndex = 4;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // StartButton
        // 
        StartButton.Location = new Point(351, 38);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(94, 29);
        StartButton.TabIndex = 5;
        StartButton.Text = "Start";
        StartButton.TextAlign = ContentAlignment.BottomCenter;
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // CancelButton
        // 
        CancelButton.Location = new Point(351, 73);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(94, 29);
        CancelButton.TabIndex = 6;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // Start1Button
        // 
        Start1Button.Location = new Point(489, 39);
        Start1Button.Name = "Start1Button";
        Start1Button.Size = new Size(94, 29);
        Start1Button.TabIndex = 7;
        Start1Button.Text = "Start 1";
        Start1Button.UseVisualStyleBackColor = true;
        Start1Button.Click += Start1Button_Click;
        // 
        // Cancel1Button
        // 
        Cancel1Button.Location = new Point(489, 74);
        Cancel1Button.Name = "Cancel1Button";
        Cancel1Button.Size = new Size(94, 29);
        Cancel1Button.TabIndex = 8;
        Cancel1Button.Text = "Cancel 1";
        Cancel1Button.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(647, 256);
        Controls.Add(Cancel1Button);
        Controls.Add(Start1Button);
        Controls.Add(CancelButton);
        Controls.Add(StartButton);
        Controls.Add(button2);
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
    private Button button2;
    private Button StartButton;
    private Button CancelButton;
    private Button Start1Button;
    private Button Cancel1Button;
}
