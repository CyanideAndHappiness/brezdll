namespace Dynamic_object
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SnowmanBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SnowmanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SnowmanBox
            // 
            this.SnowmanBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnowmanBox.Location = new System.Drawing.Point(12, 12);
            this.SnowmanBox.Name = "SnowmanBox";
            this.SnowmanBox.Size = new System.Drawing.Size(704, 350);
            this.SnowmanBox.TabIndex = 0;
            this.SnowmanBox.TabStop = false;
            this.SnowmanBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SnowmanBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 374);
            this.Controls.Add(this.SnowmanBox);
            this.Name = "Form1";
            this.Text = "Snowman";
            ((System.ComponentModel.ISupportInitialize)(this.SnowmanBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SnowmanBox;
    }
}

