namespace ZPInfo
{
    partial class Position
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.tb = new System.Windows.Forms.TextBox();
            this.rbVal = new System.Windows.Forms.RadioButton();
            this.rbProc = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(40, 140);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Принять";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(148, 140);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(88, 16);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Значение : ";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(15, 35);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(256, 23);
            this.tb.TabIndex = 2;
            // 
            // rbVal
            // 
            this.rbVal.AutoSize = true;
            this.rbVal.Location = new System.Drawing.Point(15, 97);
            this.rbVal.Name = "rbVal";
            this.rbVal.Size = new System.Drawing.Size(131, 20);
            this.rbVal.TabIndex = 3;
            this.rbVal.Text = "Значение (руб)";
            this.rbVal.UseVisualStyleBackColor = true;
            // 
            // rbProc
            // 
            this.rbProc.AutoSize = true;
            this.rbProc.Checked = true;
            this.rbProc.Location = new System.Drawing.Point(15, 71);
            this.rbProc.Name = "rbProc";
            this.rbProc.Size = new System.Drawing.Size(113, 20);
            this.rbProc.TabIndex = 3;
            this.rbProc.TabStop = true;
            this.rbProc.Text = "Процент (%)";
            this.rbProc.UseVisualStyleBackColor = true;
            // 
            // Position
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(287, 186);
            this.Controls.Add(this.rbProc);
            this.Controls.Add(this.rbVal);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Position";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Введите значение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.RadioButton rbVal;
        private System.Windows.Forms.RadioButton rbProc;
    }
}