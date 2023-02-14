namespace ZPInfo
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.rich = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rich
            // 
            this.rich.Location = new System.Drawing.Point(12, 12);
            this.rich.Name = "rich";
            this.rich.ReadOnly = true;
            this.rich.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rich.Size = new System.Drawing.Size(450, 334);
            this.rich.TabIndex = 0;
            this.rich.Text = resources.GetString("rich.Text");
            // 
            // License
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(474, 358);
            this.Controls.Add(this.rich);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "License";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лицензионное соглашение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich;
    }
}