
namespace WinFormsApp2
{
    partial class SideForm
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
            this.gridLog1 = new Serilog.Sinks.WinForms.Core.GridLog();
            this.SuspendLayout();
            // 
            // gridLog1
            // 
            this.gridLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLog1.Location = new System.Drawing.Point(0, 0);
            this.gridLog1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridLog1.Name = "gridLog1";
            this.gridLog1.Size = new System.Drawing.Size(760, 256);
            this.gridLog1.TabIndex = 0;
            // 
            // SideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 256);
            this.Controls.Add(this.gridLog1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SideForm";
            this.Text = "Logs";
            this.ResumeLayout(false);

        }

        #endregion

        private Serilog.Sinks.WinForms.Core.GridLog gridLog1;
    }
}