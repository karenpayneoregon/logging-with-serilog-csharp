﻿namespace CreateDynamicControlsCore;

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
        ProductsListBox = new ListBox();
        SuspendLayout();
        // 
        // ProductsListBox
        // 
        ProductsListBox.FormattingEnabled = true;
        ProductsListBox.Location = new Point(183, 21);
        ProductsListBox.Name = "ProductsListBox";
        ProductsListBox.Size = new Size(258, 364);
        ProductsListBox.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(459, 421);
        Controls.Add(ProductsListBox);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Create buttons Core version";
        ResumeLayout(false);
    }

    #endregion

    private ListBox ProductsListBox;
}
