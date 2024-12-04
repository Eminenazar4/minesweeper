namespace mayin_tarlasi
{
    partial class Form2
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
            button1 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.Location = new Point(213, 12);
            button1.Name = "button1";
            button1.Size = new Size(150, 29);
            button1.TabIndex = 1;
            button1.Text = "Skor Tablosu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(95, 17);
            label1.TabIndex = 0;
            label1.Text = "Hamle Sayısı: 0";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(88, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(398, 383);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_2;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(582, 553);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label1;
        private Panel panel1;
    }
}